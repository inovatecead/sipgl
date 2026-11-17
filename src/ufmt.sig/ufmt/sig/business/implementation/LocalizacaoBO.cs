using System;
using System.Collections.Generic;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;
using ufmt.sig.entity.sge;

namespace ufmt.sig.business.implementation;

[Serializable]
public class LocalizacaoBO : ILocalizacaoBO, IDisposable
{
	private ISession session;

	internal LocalizacaoBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public IList<Campus> GetCampi()
	{
		try
		{
			IQuery query = session.CreateQuery("select c from Campus c order by c.Nome");
			return query.List<Campus>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar campi.", innerException);
		}
	}

	public IList<Unidade> GetUnidades(int? campusUID, long? unidadeSuperiorUID, string nomeParcial, string siglaParcial, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select u from Unidade u where (:campusUID is null or u.Campus.CampusUID = :campusUID)   and (:unidadeSuperiorUID is null or u.UnidadeSuperior.UnidadeUID = :unidadeSuperiorUID)   and ( :unidadeSuperiorUID is null or (u.UnidadeSuperior is not null and u.UnidadeSuperior.UnidadeUID = :unidadeSuperiorUID) )   and (:nomeParcial is null or u.Nome like :nomeParcial)   and (:siglaParcial is null or u.Sigla like :siglaParcial)   and (:tipoUnidade is null or (u.CodigoTipoUnidade & :tipoUnidade) <> 0 ) order by u.Nome");
			query.SetParameter("campusUID", campusUID);
			query.SetParameter("unidadeSuperiorUID", unidadeSuperiorUID);
			query.SetParameter("nomeParcial", string.IsNullOrEmpty(nomeParcial) ? null : ('%' + nomeParcial + '%'));
			query.SetParameter("siglaParcial", string.IsNullOrEmpty(siglaParcial) ? null : ('%' + siglaParcial + '%'));
			query.SetParameter("tipoUnidade", tipoUnidade.HasValue ? new int?((int)tipoUnidade.Value) : ((int?)null));
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Unidade>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar coordenações.", innerException);
		}
	}

	public void InserirUnidade(Unidade novaUnidade)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(novaUnidade);
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
			throw new Exception("Não foi possível salvar a unidade.", innerException);
		}
	}

	public void InserirUnidadeEResponsavel(Unidade novaUnidade, ResponsavelUnidade novoResponsavel)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(novaUnidade);
			IQuery query = session.CreateQuery("select r from ResponsavelUnidade r  where r.Unidade.UnidadeUID = :unidadeUID  order by r.DataInicial desc").SetParameter("unidadeUID", novaUnidade.UnidadeUID).SetMaxResults(1);
			ResponsavelUnidade responsavelUnidade = query.UniqueResult<ResponsavelUnidade>();
			if (responsavelUnidade != null)
			{
				if (novoResponsavel.DataInicial < responsavelUnidade.DataInicial)
				{
					throw new Exception("A data inicial do novo responsável é menor que a data inicial do responsável atual");
				}
				try
				{
					responsavelUnidade.DataFinal = novoResponsavel.DataInicial;
					SalveResponsavelUnidade(responsavelUnidade);
					return;
				}
				catch (Exception innerException)
				{
					throw new Exception("Não foi possível finalizar o responsável atual da unidade.", innerException);
				}
			}
			SalveResponsavelUnidade(novoResponsavel);
		}
		catch (Exception innerException2)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível salvar a unidade e o responsável.", innerException2);
		}
	}

	public IList<Unidade> GetUnidadesSuperiores(int? campusUID, string nomeParcial, string siglaParcial, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select u from Unidade u where (:campusUID is null or u.Campus.CampusUID = :campusUID)   and (u.UnidadeSuperior is null)   and (:nomeParcial is null or u.Nome like :nomeParcial)   and (:siglaParcial is null or u.Sigla like :siglaParcial)   and (:tipoUnidade is null or (u.CodigoTipoUnidade & :tipoUnidade) <> 0 ) order by u.Nome");
			query.SetParameter("campusUID", campusUID);
			query.SetParameter("nomeParcial", string.IsNullOrEmpty(nomeParcial) ? null : ('%' + nomeParcial + '%'));
			query.SetParameter("siglaParcial", string.IsNullOrEmpty(siglaParcial) ? null : ('%' + siglaParcial + '%'));
			query.SetParameter("tipoUnidade", tipoUnidade.HasValue ? new int?((int)tipoUnidade.Value) : ((int?)null));
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Unidade>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar coordenações.", innerException);
		}
	}

	public IList<Unidade> GetUnidadesPorResponsavel(long pessoaResponsavelUID, long? unidadeSuperiorUID, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows)
	{
		IQuery query = session.CreateQuery("select ru.Unidade from ResponsavelUnidade ru where ru.Pessoa.PessoaUID = :pessoaResponsavelUID   and (:unidadeSuperiorUID is null or ru.Unidade.UnidadeSuperior.UnidadeUID = :unidadeSuperiorUID)   and (:tipoUnidade is null or (ru.Unidade.CodigoTipoUnidade & :tipoUnidade) <> 0 )   and ru.DataFinal is null order by ru.Unidade.Nome").SetParameter("pessoaResponsavelUID", pessoaResponsavelUID).SetParameter("unidadeSuperiorUID", unidadeSuperiorUID)
			.SetParameter("tipoUnidade", tipoUnidade.HasValue ? new int?((int)tipoUnidade.Value) : ((int?)null));
		if (firstRowIndex.HasValue)
		{
			query.SetFirstResult(firstRowIndex.Value);
		}
		if (maximumRows.HasValue)
		{
			query.SetMaxResults(maximumRows.Value);
		}
		return query.List<Unidade>();
	}

	public Unidade GetUnidade(long unidadeUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select u from Unidade u where u.UnidadeUID = :unidadeUID").SetParameter("unidadeUID", unidadeUID);
			return query.UniqueResult<Unidade>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar unidade através de seu identificador único.", innerException);
		}
	}

	public ResponsavelUnidade DefinaResponsavel(long unidadeUID, long pessoaUID, DateTime dataInicio)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			IQuery query = session.CreateQuery("select r from ResponsavelUnidade r  where r.Unidade.UnidadeUID = :unidadeUID  order by r.DataInicial desc").SetParameter("unidadeUID", unidadeUID).SetMaxResults(1);
			ResponsavelUnidade responsavelUnidade = query.UniqueResult<ResponsavelUnidade>();
			if (responsavelUnidade != null)
			{
				if (dataInicio < responsavelUnidade.DataInicial)
				{
					throw new Exception("A data inicial do novo responsável é menor que a data inicial do responsável atual");
				}
				try
				{
					responsavelUnidade.DataFinal = dataInicio;
					SalveResponsavelUnidade(responsavelUnidade);
				}
				catch (Exception innerException)
				{
					throw new Exception("Não foi possível finalizar o responsável atual da unidade.", innerException);
				}
			}
			try
			{
				responsavelUnidade = new ResponsavelUnidade();
				responsavelUnidade.DataInicial = dataInicio;
				responsavelUnidade.Unidade = GetUnidade(unidadeUID);
				using (IPessoaBO pessoaBO = BusinessFactory.GetInstance<IPessoaBO>())
				{
					responsavelUnidade.Pessoa = pessoaBO.GetPessoa(pessoaUID);
				}
				SalveResponsavelUnidade(responsavelUnidade);
			}
			catch (Exception innerException2)
			{
				throw new Exception("Não foi possível definir o novo responsável pela unidade.", innerException2);
			}
			if (!isActive)
			{
				transaction.Commit();
			}
			return responsavelUnidade;
		}
		catch (Exception innerException3)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw new Exception("Não foi possível verificar se na unidade já existia um responsável.", innerException3);
		}
	}

	public void RemovaResponsavel(long unidadeUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select r from ResponsavelUnidade r  where r.Unidade.UnidadeUID = :unidadeUID  order by r.DataInicial desc").SetParameter("unidadeUID", unidadeUID).SetMaxResults(1);
			ResponsavelUnidade responsavelUnidade = query.UniqueResult<ResponsavelUnidade>();
			if (responsavelUnidade == null)
			{
				return;
			}
			ITransaction transaction = session.Transaction;
			bool isActive = transaction.IsActive;
			try
			{
				if (!isActive)
				{
					transaction = session.BeginTransaction();
				}
				session.Delete(responsavelUnidade);
				try
				{
					query = session.CreateQuery("select r from ResponsavelUnidade r  where r.Unidade.UnidadeUID = :unidadeUID  order by r.DataInicial desc").SetParameter("unidadeUID", unidadeUID).SetMaxResults(1);
					responsavelUnidade = query.UniqueResult<ResponsavelUnidade>();
					if (responsavelUnidade != null)
					{
						responsavelUnidade.DataFinal = null;
						SalveResponsavelUnidade(responsavelUnidade);
					}
				}
				catch (Exception innerException)
				{
					throw new Exception("Não foi possível habilitar o último responsável.", innerException);
				}
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
				throw new Exception("Não foi possível remover o responsável pela unidade.", innerException2);
			}
		}
		catch (Exception innerException3)
		{
			throw new Exception("Não foi possível verificar se na unidade já existia um responsável.", innerException3);
		}
	}

	public UnidadeAlocadora getUnidadeAlocadora(long unidadeUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ua from UnidadeAlocadora ua  where ua.Unidade.UnidadeUID = :unidadeUID ").SetParameter("unidadeUID", unidadeUID).SetMaxResults(1);
			return query.UniqueResult<UnidadeAlocadora>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a unidade alocadora", innerException);
		}
	}

	protected void SalveResponsavelUnidade(ResponsavelUnidade responsavelUnidade)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(responsavelUnidade);
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
			throw new Exception("Não foi possível salvar o responsável pela unidade.", innerException);
		}
	}

	public IList<ResponsavelUnidade> GetResponsaveis(string nomeResponsavelParcial, string nomeUnidadeParcial, string siglaUnidadeParcial, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select r from ResponsavelUnidade r  where (:nomeResponsavelParcial is null or r.Pessoa.Nome like :nomeResponsavelParcial)    and (:nomeUnidadeParcial is null or r.Unidade.Nome like :nomeUnidadeParcial)    and (:siglaUnidadeParcial is null or r.Unidade.Sigla like :siglaUnidadeParcial)   and (:tipoUnidade is null or (r.Unidade.CodigoTipoUnidade & :tipoUnidade) <> 0 ) order by r.DataInicial desc");
			query.SetParameter("nomeResponsavelParcial", string.IsNullOrEmpty(nomeResponsavelParcial) ? null : ('%' + nomeResponsavelParcial + '%'));
			query.SetParameter("nomeUnidadeParcial", string.IsNullOrEmpty(nomeUnidadeParcial) ? null : ('%' + nomeUnidadeParcial + '%'));
			query.SetParameter("siglaUnidadeParcial", string.IsNullOrEmpty(siglaUnidadeParcial) ? null : ('%' + siglaUnidadeParcial + '%'));
			query.SetParameter("tipoUnidade", tipoUnidade.HasValue ? new int?((int)tipoUnidade.Value) : ((int?)null));
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<ResponsavelUnidade>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os responsáveis pelas unidades.", innerException);
		}
	}

	public IList<ResponsavelUnidade> GetResponsaveis(int? campusUID, long? unidadeSuperiorUID, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select r from ResponsavelUnidade r  where (:campusUID is null or r.Unidade.Campus.CampusUID = :campusUID)   and (:unidadeSuperiorUID is null or r.Unidade.UnidadeSuperior.UnidadeUID = :unidadeSuperiorUID)   and (:tipoUnidade is null or r.Unidade.CodigoTipoUnidade & :tipoUnidade <> 0 ) order by r.DataInicial desc").SetParameter("campusUID", campusUID).SetParameter("unidadeSuperiorUID", unidadeSuperiorUID)
				.SetParameter("tipoUnidade", (int?)tipoUnidade);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<ResponsavelUnidade>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os responsáveis pelas unidades.", innerException);
		}
	}

	public ResponsavelUnidade GetResponsavel(long unidadeUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select r from ResponsavelUnidade r  where (r.Unidade.UnidadeUID = :unidadeUID)  order by r.DataInicial desc").SetParameter("unidadeUID", unidadeUID).SetMaxResults(1);
			return query.UniqueResult<ResponsavelUnidade>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o responsável pela unidade.", innerException);
		}
	}

	public Uf getUf(string sigla)
	{
		try
		{
			IQuery query = session.CreateQuery("select u from Uf u  where (u.UfUID = :sigla) ").SetParameter("sigla", sigla).SetMaxResults(1);
			return query.UniqueResult<Uf>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a UF.", innerException);
		}
	}

	public IList<Uf> getUfs(string nomeParcial)
	{
		try
		{
			IQuery query = session.CreateQuery("select u from Uf u  where (:nomeParcial is null or u.Nome like :nomeParcial) order by u.Nome ").SetParameter("nomeParcial", nomeParcial);
			return query.List<Uf>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os estados.", innerException);
		}
	}

	public Municipio getMunicipio(int municipioUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select m from Municipio m  where (m.MunicipioUID = :municipioUID) ").SetParameter("municipioUID", municipioUID).SetMaxResults(1);
			return query.UniqueResult<Municipio>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o município pelo seu código.", innerException);
		}
	}

	public IList<Municipio> getMunicipios(string uf)
	{
		try
		{
			IQuery query = session.CreateQuery("select m from Municipio m  where (m.Uf like :uf) order by m.Nome ").SetParameter("uf", uf);
			return query.List<Municipio>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os municípios pela UF indicada.", innerException);
		}
	}
}
