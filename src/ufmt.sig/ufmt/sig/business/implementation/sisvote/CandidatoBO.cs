using System;
using System.Collections.Generic;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.business.sisvote;
using ufmt.sig.entity.sisvote;

namespace ufmt.sig.business.implementation.sisvote;

public class CandidatoBO : ICandidatoBO, IDisposable
{
	private ISession session;

	internal CandidatoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public Candidato GetCandidato(long candidatoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct c from ufmt.sig.entity.sisvote.Candidato c where (c.CandidatoUID = :candidatoUID)").SetParameter("candidatoUID", candidatoUID);
			return query.UniqueResult<Candidato>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o candidato.", innerException);
		}
	}

	public IList<Candidato> GetCandidatos(long eleicaoUID, long? cargoUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select c from ufmt.sig.entity.sisvote.Candidato c where (:cargoUID is null or c.Cargo.CargoUID = :cargoUID)   and (c.Cargo.Eleicao.EleicaoUID = :eleicaoUID) order by c.Servidor.Pessoa.Nome ").SetParameter("cargoUID", cargoUID).SetParameter("eleicaoUID", eleicaoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Candidato>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os candidatos da eleição.", innerException);
		}
	}
}
