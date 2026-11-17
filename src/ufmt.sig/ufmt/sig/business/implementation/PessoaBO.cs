using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;

namespace ufmt.sig.business.implementation;

[Serializable]
public class PessoaBO : IPessoaBO, IDisposable
{
	private ISession session;

	internal PessoaBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public Pessoa GetPessoa(string cpf)
	{
		Pessoa pessoa = null;
		try
		{
			IQuery query = session.CreateQuery("select p from Pessoa p where p.Cpf = :cpf");
			query.SetParameter("cpf", cpf);
			return query.UniqueResult<Pessoa>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar pessoa.", innerException);
		}
	}

	public IList<Pessoa> GetPessoas(string Nome)
	{
		try
		{
			IQuery query = session.CreateQuery("select p from Pessoa p where p.Nome like :nome");
			query.SetParameter("nome", "%" + Nome + "%");
			return query.List<Pessoa>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a coleção de pessoas.", innerException);
		}
	}

	public Pessoa GetPessoa(long pessoaUID)
	{
		Pessoa pessoa = null;
		try
		{
			IQuery query = session.CreateQuery("select p from Pessoa p where p.PessoaUID = :pessoaUID");
			query.SetParameter("pessoaUID", pessoaUID);
			return query.UniqueResult<Pessoa>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar pessoa.", innerException);
		}
	}

	public void SalvePessoa(Pessoa pessoa)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(pessoa);
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
			throw new Exception("Não foi possível salvar pessoa", innerException);
		}
	}

	public Servidor GetServidorAtivo(long pessoaUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select s from Servidor s where s.Pessoa.PessoaUID=:pessoaUID and s.SituacaoServidor.SituacaoServidorUID=1").SetParameter("pessoaUID", pessoaUID);
			return query.UniqueResult<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar servidor.", innerException);
		}
	}

	public Servidor GetServidor(long servidorUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select s from Servidor s where s.ServidorUID = :servidorUID").SetParameter("servidorUID", servidorUID);
			return query.UniqueResult<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar servidor.", innerException);
		}
	}

	public Servidor GetServidor(string registro, char tipoRegistro)
	{
		try
		{
			IQuery query = session.CreateQuery("select s from Servidor s where s.Registro = :registro and s.TipoRegistro = :tipoRegistro").SetParameter("registro", registro).SetParameter("tipoRegistro", tipoRegistro);
			return query.UniqueResult<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar servidor.", innerException);
		}
	}

	public IList<Servidor> GetServidores(string nomeParcial, string registro, bool? apenasDocente, int? firstRowIndex, int? maximumRows)
	{
		return GetServidores(nomeParcial, registro, apenasAtivos: true, apenasDocente, firstRowIndex, maximumRows);
	}

	public IList<Pessoa> GetPessoas(string Nome, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select p from Pessoa p where (:Nome is null or ilike(p.Nome, :Nome)) order by p.Nome").SetParameter("Nome", string.IsNullOrEmpty(Nome) ? null : ("%" + Nome + "%"));
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Pessoa>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a coleção de pessoas.", innerException);
		}
	}

	public int CountPessoas(string Nome, int? firstRowIndex, int? maximumRows)
	{
		try
		{
			IQuery query = session.CreateQuery("select count(p) from Pessoa p where (:Nome is null or ilike(p.Nome, :Nome))").SetParameter("Nome", string.IsNullOrEmpty(Nome) ? null : ("%" + Nome + "%"));
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.UniqueResult<int>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a coleção de pessoas.", innerException);
		}
	}

	public IList<Servidor> GetServidores(string nomeParcial, string registro, bool apenasAtivos, bool? apenasDocente, int? firstRowIndex, int? maximumRows)
	{
		string text = "'3100651', '1054583'";
		try
		{
			IQuery query = session.CreateQuery("select se from Servidor se where (:nomeParcial is null or ilike(se.Pessoa.Nome, :nomeParcial))   and (:registro is null or se.Registro like :registro)   and (:ativo is null or se.SituacaoServidor.Descricao = :ativo)   and (:apenasDocente is null or :apenasDocente = false or (se.Cargo.TipoSiape in (2,3) or se.Registro in ( " + text + " ))) order by se.Pessoa.Nome").SetParameter("nomeParcial", string.IsNullOrEmpty(nomeParcial) ? null : ("%" + nomeParcial + "%")).SetParameter("registro", string.IsNullOrEmpty(registro) ? null : ("%" + registro))
				.SetParameter("apenasDocente", apenasDocente)
				.SetParameter("ativo", apenasAtivos ? "ATIVO" : null);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os servidores.", innerException);
		}
	}

	public IList<Servidor> GetServidoresPorUnidadeLotacional(long unidadeLotacaoUID, string nomeParcial, string registro, bool? apenasDocente, int? firstRowIndex, int? maximumRows)
	{
		return GetServidoresPorUnidadeLotacional(unidadeLotacaoUID, nomeParcial, registro, apenasAtivos: true, apenasDocente, firstRowIndex, maximumRows);
	}

	public IList<Servidor> GetServidoresPorUnidadeLotacional(long unidadeLotacaoUID, string nomeParcial, string registro, bool apenasAtivos, bool? apenasDocente, int? firstRowIndex, int? maximumRows)
	{
		string text = "'3100651', '1054583'";
		try
		{
			IQuery query = session.CreateQuery("select s from Servidor s where s.UnidadeLotacao.UnidadeUID = :unidadeLotacaoUID   and (:nomeParcial is null or s.Pessoa.Nome like :nomeParcial)   and (:registro is null or s.Registro like :registro)   and (:apenasDocente is null or :apenasDocente = false or (s.Cargo.TipoSiape in (2,3) or s.Registro in ( " + text + " )))   and (:ativo is null or s.SituacaoServidor.Descricao in ('ATIVO' , 'ALUNO')) order by s.Pessoa.Nome").SetParameter("unidadeLotacaoUID", unidadeLotacaoUID).SetParameter("nomeParcial", string.IsNullOrEmpty(nomeParcial) ? null : ("%" + nomeParcial + "%"))
				.SetParameter("registro", string.IsNullOrEmpty(registro) ? null : ("%" + registro))
				.SetParameter("apenasDocente", apenasDocente)
				.SetParameter("ativo", apenasAtivos ? "ATIVO" : null);
			if (firstRowIndex.HasValue)
			{
				query.SetFirstResult(firstRowIndex.Value);
			}
			if (maximumRows.HasValue)
			{
				query.SetMaxResults(maximumRows.Value);
			}
			return query.List<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar servidores por unidade lotacional.", innerException);
		}
	}

	public int CountGetServidores(string nomeParcial, string registro, bool? apenasDocente, int? firstRowIndex, int? maximumRows)
	{
		return CountGetServidores(nomeParcial, registro, apenasAtivos: true, apenasDocente, firstRowIndex, maximumRows);
	}

	public int CountGetServidores(string nomeParcial, string registro, bool apenasAtivos, bool? apenasDocente, int? firstRowIndex, int? maximumRows)
	{
		string text = "'3100651', '1054583'";
		try
		{
			IQuery query = session.CreateQuery("select count(se) from Servidor se where (:nomeParcial is null or ilike(se.Pessoa.Nome, :nomeParcial))   and (:registro is null or se.Registro like :registro)   and (:ativo is null or se.SituacaoServidor.Descricao = :ativo)   and (:apenasDocente is null or :apenasDocente = false or (se.Cargo.TipoSiape in (2,3) or se.Registro in ( " + text + " )))").SetParameter("nomeParcial", string.IsNullOrEmpty(nomeParcial) ? null : ("%" + nomeParcial + "%")).SetParameter("registro", string.IsNullOrEmpty(registro) ? null : ("%" + registro))
				.SetParameter("apenasDocente", apenasDocente)
				.SetParameter("ativo", apenasAtivos ? "ATIVO" : null);
			return query.UniqueResult<int>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os servidores.", innerException);
		}
	}

	public IList<Servidor> GetVinculosDocenciaPorPessoa(long pessoaUID)
	{
		string text = "'3100651', '1054583'";
		try
		{
			IQuery query = session.CreateQuery("select s from Servidor s where s.Pessoa.PessoaUID = :pessoaUID   and ( s.Cargo.TipoSiape in (2,3) or s.Registro in ( " + text + " ))").SetParameter("pessoaUID", pessoaUID);
			return query.List<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar servidores através de pessoa.", innerException);
		}
	}

	public IList<Servidor> GetVinculosPorPessoa(long pessoaUID, bool apenasAtivos)
	{
		try
		{
			IQuery query = session.CreateQuery("select s from Servidor s where s.Pessoa.PessoaUID = :pessoaUID   and ((:ativo = 'true' and s.SituacaoServidor.SituacaoServidorUID = 1) or (:ativo = 'false'))").SetParameter("pessoaUID", pessoaUID).SetParameter("ativo", apenasAtivos);
			return query.List<Servidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar servidores através de pessoa.", innerException);
		}
	}

	public void SalveServidor(Servidor servidor)
	{
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			session.SaveOrUpdate(servidor);
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
			throw new Exception("Não foi possível salvar servidor.", innerException);
		}
	}

	public void AltereLotacaoServidor(long servidorUID, long? unidadeLotacionalUID)
	{
		Servidor servidor = GetServidor(servidorUID);
		Unidade unidade = null;
		if (servidor == null)
		{
			throw new Exception("Não foi possível recuperar servidor com identificador informado para alteração de lotação.");
		}
		using (ILocalizacaoBO localizacaoBO = BusinessFactory.GetInstance<ILocalizacaoBO>())
		{
			if (unidadeLotacionalUID.HasValue)
			{
				unidade = localizacaoBO.GetUnidade(unidadeLotacionalUID.Value);
				if (unidade == null)
				{
					throw new Exception("Não foi possível recuperar unidade com identificador informado para alteração de lotação de servidor.");
				}
			}
		}
		servidor.UnidadeLotacao = unidade;
		SalveServidor(servidor);
	}

	public void AlteraStatusServidorAluno(long servidorUID, bool status)
	{
		Servidor servidor = GetServidor(servidorUID);
		if (servidor == null)
		{
			throw new Exception("Não foi possível recuperar servidor com identificador informado para alteração do status do servidor.");
		}
		if (status)
		{
			if (servidor.SituacaoServidor.SituacaoServidorUID != 1)
			{
				throw new Exception("O servidor precisa estar ATIVO para ser aluno!");
			}
			servidor.SituacaoServidor = GetSituacaoServidor("ALUNO");
		}
		else
		{
			if (servidor.SituacaoServidor.SituacaoServidorUID != 6)
			{
				throw new Exception("O servidor precisa ser ALUNO!");
			}
			servidor.SituacaoServidor = GetSituacaoServidor("ATIVO");
		}
		SalveServidor(servidor);
	}

	public IList<TipoOcorrenciaServidor> GetTiposOcorrenciaServidor(CategoriaOcorrenciaEnum? categoriaOcorrencia)
	{
		short? val = ((!categoriaOcorrencia.HasValue) ? ((short?)null) : ((short?)categoriaOcorrencia));
		IQuery query = session.CreateQuery("select tos from TipoOcorrenciaServidor tos where (:categoriaOcorrenciaUID is null or tos.TipoOcorrenciaSiape = :categoriaOcorrenciaUID) order by tos.Descricao").SetParameter("categoriaOcorrenciaUID", val);
		return query.List<TipoOcorrenciaServidor>();
	}

	public TipoOcorrenciaServidor GetTipoOcorrenciaServidor(long tipoOcorrenciaServidorUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select tos from TipoOcorrenciaServidor tos where tos.TipoOcorrenciaServidorUID = :tipoOcorrenciaServidorUID").SetParameter("tipoOcorrenciaServidorUID", tipoOcorrenciaServidorUID);
			return query.UniqueResult<TipoOcorrenciaServidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar Tipo de Ocorrência do Servidor.", innerException);
		}
	}

	public List<OcorrenciaServidor> GetOcorrenciaServidor(long servidorUID)
	{
		return GetOcorrenciaServidor(servidorUID, null);
	}

	public List<OcorrenciaServidor> GetOcorrenciaServidor(long servidorUID, long? tipoOcorrenciaServidorUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select tos from OcorrenciaServidor tos where tos.Servidor.ServidorUID = :servidorUID").SetParameter("servidorUID", servidorUID);
			if (tipoOcorrenciaServidorUID.HasValue)
			{
				query = session.CreateQuery(query.QueryString + " and tos.TipoOcorrenciaServidor.TipoOcorrenciaServidorUID=:tipoOcorrenciaServidorUID").SetParameter("servidorUID", servidorUID).SetParameter("tipoOcorrenciaServidorUID", tipoOcorrenciaServidorUID.Value);
			}
			return query.List<OcorrenciaServidor>().ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar Tipo de Ocorrência do Servidor.", innerException);
		}
	}

	public IList<TipoTitulacao> GetTiposTitulacao()
	{
		IQuery query = session.CreateQuery("select tt from TipoTitulacao tt");
		return query.List<TipoTitulacao>();
	}

	public SituacaoServidor GetSituacaoServidor(string situacaoServidor)
	{
		try
		{
			IQuery query = session.CreateQuery("select ss from SituacaoServidor ss where ss.Descricao = :situacaoServidor").SetParameter("situacaoServidor", situacaoServidor);
			return query.UniqueResult<SituacaoServidor>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a Situação do Servidor.", innerException);
		}
	}

	public IList<TipoNecessidadeEspecial> getTiposNecessidadeEspecial()
	{
		IQuery query = session.CreateQuery("select tne from TipoNecessidadeEspecial tne");
		return query.List<TipoNecessidadeEspecial>();
	}

	public IList<NecessidadeEspecial> getNecessidadesEspeciais(long pessoaUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ne from NecessidadeEspecial ne where ne.Pessoa.PessoaUID = :pessoaUID").SetParameter("pessoaUID", pessoaUID);
			return query.List<NecessidadeEspecial>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar as necessidades especiais da pessoa.", innerException);
		}
	}

	private TipoNecessidadeEspecial getTipoNecessidadeEspecial(string tipoNecessidadeEspecialUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select tne from TipoNecessidadeEspecial tne where tne.TipoNecessidadeEspecialUID = :tipoNecessidadeEspecialUID").SetParameter("tipoNecessidadeEspecialUID", tipoNecessidadeEspecialUID);
			return query.UniqueResult<TipoNecessidadeEspecial>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o tipo de necessidade especial.", innerException);
		}
	}

	public void setNecessidadeEspecial(long pessoaUID, string tipoNecessidadeEspecialUID)
	{
		Pessoa pessoa = GetPessoa(pessoaUID);
		if (pessoa == null)
		{
			throw new Exception("Não foi possível recuperar a pessoa com a identificação informada para definir uma necessidade.");
		}
		TipoNecessidadeEspecial tipoNecessidadeEspecial = getTipoNecessidadeEspecial(tipoNecessidadeEspecialUID);
		if (tipoNecessidadeEspecial == null)
		{
			throw new Exception("Não foi possível recuperar o tipo de necessidade especial com a identificação informada para definir uma necessidade.");
		}
		NecessidadeEspecial necessidadeEspecial = getNecessidadeEspecial(pessoa.PessoaUID, tipoNecessidadeEspecial.TipoNecessidadeEspecialUID);
		if (necessidadeEspecial != null)
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
			necessidadeEspecial = new NecessidadeEspecial();
			necessidadeEspecial.Pessoa = pessoa;
			necessidadeEspecial.TipoNecessidadeEspecial = tipoNecessidadeEspecial;
			session.SaveOrUpdate(necessidadeEspecial);
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
			throw new Exception("Não foi possível definir a necessidade especial para a pessoa.", innerException);
		}
	}

	private NecessidadeEspecial getNecessidadeEspecial(long pessoaUID, string tipoNecessidadeEspecialUID)
	{
		try
		{
			IQuery query = session.CreateQuery("select ne from NecessidadeEspecial ne where ne.Pessoa.PessoaUID = :pessoaUID and ne.TipoNecessidadeEspecial.TipoNecessidadeEspecialUID = :tipoNecessidadeEspecialUID").SetParameter("pessoaUID", pessoaUID).SetParameter("tipoNecessidadeEspecialUID", tipoNecessidadeEspecialUID);
			return query.UniqueResult<NecessidadeEspecial>();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar a necessidade especial.", innerException);
		}
	}

	public void removerNecessidadeEspecial(long pessoaUID, string tipoNecessidadeEspecialUID)
	{
		NecessidadeEspecial necessidadeEspecial = getNecessidadeEspecial(pessoaUID, tipoNecessidadeEspecialUID);
		if (necessidadeEspecial == null)
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
			session.Delete(necessidadeEspecial);
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
			throw new Exception("Não foi possível remover a necessidade especial.", innerException);
		}
	}
}
