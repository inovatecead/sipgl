using System;
using System.Collections.Generic;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.business.sisvote;
using ufmt.sig.entity.sisvote;

namespace ufmt.sig.business.implementation.sisvote;

public class CargoBO : ICargoBO, IDisposable
{
	private ISession session;

	internal CargoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public IList<Cargo> GetCargos(long eleicaoUID, long? unidadeUID, string descricaoParcial, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct c from ufmt.sig.entity.sisvote.Cargo c where (:unidadeUID is null or c.Unidade.UnidadeUID = :unidadeUID)   and (:descricaoParcial is null or ilike(c.Descricao, :descricaoParcial))   and (c.Eleicao.EleicaoUID = :eleicaoUID)").SetParameter("unidadeUID", unidadeUID).SetParameter("descricaoParcial", descricaoParcial)
				.SetParameter("eleicaoUID", eleicaoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Cargo>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os cargos da eleição.", innerException);
		}
	}

	public Cargo GetCargo(long cargoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct c from ufmt.sig.entity.sisvote.Cargo c where (c.CargoUID = :cargoUID)").SetParameter("cargoUID", cargoUID);
			return query.UniqueResult<Cargo>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o cargo.", innerException);
		}
	}
}
