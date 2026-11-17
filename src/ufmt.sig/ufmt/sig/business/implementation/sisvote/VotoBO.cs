using System;
using System.Collections.Generic;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.business.sisvote;
using ufmt.sig.entity;
using ufmt.sig.entity.sisvote;

namespace ufmt.sig.business.implementation.sisvote;

public class VotoBO : IVotoBO, IDisposable
{
	private ISession session;

	internal VotoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public void Votar(Candidato candidato, ufmt.sig.entity.sisvote.Cargo cargo, Servidor servidorVotante, TipoVoto tipoVoto, string ip)
	{
		if (cargo == null)
		{
			throw new Exception("O cargo que o voto vai ser computado deve ser definido.");
		}
		if (servidorVotante == null)
		{
			throw new Exception("O servidor que realizou o voto não foi definido.");
		}
		if (tipoVoto == null)
		{
			throw new Exception("O tipo do voto não foi definido.");
		}
		if (string.IsNullOrEmpty(ip))
		{
			throw new Exception("O IP do usuário que votou não é válido.");
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Voto voto = new Voto();
			voto.Candidato = candidato;
			voto.Cargo = cargo;
			voto.Ip = ip;
			voto.Servidor = servidorVotante;
			voto.TipoVoto = tipoVoto;
			DateTime dataHora = DateTime.Now.AddHours(-1.0);
			voto.DataHora = dataHora;
			session.SaveOrUpdate(voto);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar o voto.", innerException);
		}
	}

	public void RemoverVoto(long? candidatoUID, long cargoUID, long servidorVotanteUID, long tipoVotoUID)
	{
		Voto voto;
		try
		{
			IQuery query = session.CreateQuery("select distinct v from ufmt.sig.entity.sisvote.Voto v where (v.TipoVoto.TipoVotoUID = :tipoVotoUID)   and (:candidatoUID is null or v.Candidato.CandidatoUID = :candidatoUID)   and (v.Cargo.CargoUID = :cargoUID)   and (v.Servidor.ServidorUID = :servidorUID)").SetParameter("tipoVotoUID", tipoVotoUID).SetParameter("candidatoUID", candidatoUID)
				.SetParameter("cargoUID", cargoUID)
				.SetParameter("servidorUID", servidorVotanteUID);
			voto = query.UniqueResult<Voto>();
			if (voto == null)
			{
				throw new Exception("Não foi encontrado nenhum voto com os parâmetros informados.");
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("Erro ao tentar recuperar o voto a ser removido.", innerException);
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.Delete(voto);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException2)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível remover o voto.", innerException2);
		}
	}

	public IList<Voto> GetVotos(long candidatoUID, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct v from ufmt.sig.entity.sisvote.Voto v where (v.Candidato.CandidatoUID = :candidatoUID)").SetParameter("candidatoUID", candidatoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Voto>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Erro ao tentar recuperar os votos deste candidato.", innerException);
		}
	}

	public IList<Voto> GetVotos(long cargoUID, TipoVoto tipoVoto, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct v from ufmt.sig.entity.sisvote.Voto v where (:tipoVoto is null or v.TipoVoto.TipoVotoUID = :tipoVoto)   and (v.Cargo.CargoUID = :cargoUID)").SetParameter("tipoVoto", tipoVoto).SetParameter("cargoUID", cargoUID);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Voto>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Erro ao tentar recuperar os votos deste cargo.", innerException);
		}
	}

	public TipoVoto GetTipoVoto(long tipoVotoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct t from ufmt.sig.entity.sisvote.TipoVoto t where (t.TipoVotoUID = :tipoVotoUID)").SetParameter("tipoVotoUID", tipoVotoUID);
			return query.UniqueResult<TipoVoto>();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public Voto GetVoto(long servidorUID, long cargoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct v from ufmt.sig.entity.sisvote.Voto v where (v.Servidor.ServidorUID = :servidorUID)   and (v.Cargo.CargoUID = :cargoUID)").SetParameter("servidorUID", servidorUID).SetParameter("cargoUID", cargoUID);
			return query.UniqueResult<Voto>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Erro ao tentar recuperar o voto deste candidato.", innerException);
		}
	}

	public Eleicao GetEleicao(long eleicaoUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select distinct e from ufmt.sig.entity.sisvote.Eleicao e where (e.EleicaoUID = :eleicaoUID)").SetParameter("eleicaoUID", eleicaoUID);
			return query.UniqueResult<Eleicao>();
		}
		catch (Exception)
		{
			return null;
		}
	}

	public void atualizarSituacaoEleicao(long eleicaoUID, SituacaoEleicaoEnum situacao)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			Eleicao eleicao = GetEleicao(eleicaoUID);
			if (eleicao == null)
			{
				throw new Exception("Não foi possível recuperar a eleição.");
			}
			eleicao.Situacao = situacao;
			session.SaveOrUpdate(eleicao);
			if (!isActive)
			{
				transaction.Commit();
			}
		}
		catch (Exception innerException)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível atualizar a eleição.", innerException);
		}
	}
}
