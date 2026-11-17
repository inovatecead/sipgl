using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class DiscenteDAL
{
	public PreMatriculaInscricao BuscarPreMatriculaInscricao(long preMatriculaInscricaoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoDiscente BuscarDiscentePorMatriculaInscricao(long preMatriculaInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoDiscente.Where((ProjetoDiscente e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewPreMatriculaInscricao> FindRegistrosInscritos(string criterio, int projetoCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewPreMatriculaInscricao.Where((ViewPreMatriculaInscricao c) => c.pessoaNome.Contains(criterio) && c.projetoCursoUID == (long)projetoCursoUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ViewPreMatriculaPessoa GetRegistroPorId(long id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewPreMatriculaPessoa.Where((ViewPreMatriculaPessoa c) => c.preMatriculaPessoaUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public ViewPreMatriculaPessoa AtenticarPreDiscente(string cpf, string senha)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewPreMatriculaPessoa.FirstOrDefault((ViewPreMatriculaPessoa p) => p.cpf == cpf && p.senha == senha);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public int AlterarSenhaPreDiscente(string senha, long preMatriculaPessoaUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			contextInstance.PreMatriculaPessoa.First((PreMatriculaPessoa c) => c.preMatriculaPessoaUID == preMatriculaPessoaUID).senha = senha;
			return contextInstance.SaveChanges();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Salvar(PreMatriculaPessoa obj, byte operacao)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		Contexto.GetContextInstance();
		new DiscenteDAL();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (obj.preMatriculaPessoaUID != 0L)
			{
				_ = obj.preMatriculaPessoaUID;
			}
			ObjectParameter val = new ObjectParameter("erroSaida", typeof(string));
			new ObjectParameter("PreMatriculaPessoaUIDSaida", typeof(long));
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.Erro = false;
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
				if (operacao == 2)
				{
					resultadoOperacao.TextMessage = "Atualização efetuada com sucesso.";
				}
				else
				{
					resultadoOperacao.TextMessage = "Cadastro efetudado com sucesso.";
				}
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível salvar o registro. " + array[1];
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public TipoSituacaoInscricao BuscarSituacaoInscricao(byte tipoSituacaoInscricaoUID)
	{
		try
		{
			return Contexto.GetContextInstance().TipoSituacaoInscricao.Where((TipoSituacaoInscricao e) => e.tipoSituacaoInscricaoUID == tipoSituacaoInscricaoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoDiscente BuscarDiscentePorPreMatricula(long preMatriculaInscricaoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ProjetoDiscente.Where((ProjetoDiscente e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public Curso ValidarCodigoAcesso(string codigoAcesso)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.Curso.FirstOrDefault((Curso p) => p.codigoAcesso == codigoAcesso);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao AlterarSituacao(PreMatriculaInscricao preMatriculaInscricaoNovo, ProjetoDiscente projetoDiscenteNovo, string observacao, long usuarioUID, string ip)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaInscricao preMatriculaInscricao = contextInstance.PreMatriculaInscricao.Where((PreMatriculaInscricao e) => e.preMatriculaInscricaoUID == preMatriculaInscricaoNovo.preMatriculaInscricaoUID).FirstOrDefault();
			PreMatriculaInscricaoDAL preMatriculaInscricaoDAL = new PreMatriculaInscricaoDAL();
			if (preMatriculaInscricaoNovo.tipoSituacaoInscricaoUID == 3 && preMatriculaInscricao.tipoSituacaoInscricaoUID != 3 && !preMatriculaInscricaoDAL.HasVagasDisponiveis(preMatriculaInscricao.projetoTurmaPoloUID.GetValueOrDefault()))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não há mais vagas disponiveis";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			preMatriculaInscricao.tipoSituacaoInscricaoUID = preMatriculaInscricaoNovo.tipoSituacaoInscricaoUID;
			PreMatriculaInscricaoOcorrencia preMatriculaInscricaoOcorrencia = new PreMatriculaInscricaoOcorrencia();
			preMatriculaInscricaoOcorrencia.dataHoraOcorrencia = DateTime.Now;
			preMatriculaInscricaoOcorrencia.preMatriculaInscricaoUID = preMatriculaInscricao.preMatriculaInscricaoUID;
			preMatriculaInscricaoOcorrencia.observacao = observacao;
			preMatriculaInscricaoOcorrencia.tipoSituacaoInscricaoUID = preMatriculaInscricao.tipoSituacaoInscricaoUID;
			preMatriculaInscricaoOcorrencia.usuarioUID = usuarioUID;
			preMatriculaInscricaoOcorrencia.tipoFormaIngressoUID = projetoDiscenteNovo.tipoFormaIngressoUID;
			preMatriculaInscricaoOcorrencia.dataIngresso = projetoDiscenteNovo.dataIngresso;
			preMatriculaInscricaoOcorrencia.tipoPeriodoIngressoUID = projetoDiscenteNovo.tipoPeridoIngressoUID;
			preMatriculaInscricaoOcorrencia.tipoReservaVagasUID = projetoDiscenteNovo.tipoReservaVagasUID;
			preMatriculaInscricaoOcorrencia.periodo = projetoDiscenteNovo.periodo;
			preMatriculaInscricaoOcorrencia.ip = ip;
			contextInstance.Entry(preMatriculaInscricao).State = (EntityState)16;
			contextInstance.PreMatriculaInscricaoOcorrencia.Add(preMatriculaInscricaoOcorrencia);
			ProjetoDiscente projetoDiscente = contextInstance.ProjetoDiscente.Where((ProjetoDiscente e) => e.preMatriculaInscricaoUID == preMatriculaInscricao.preMatriculaInscricaoUID).FirstOrDefault();
			bool flag = false;
			if (projetoDiscente == null)
			{
				flag = true;
				projetoDiscente = new ProjetoDiscente();
				projetoDiscente.preMatriculaInscricaoUID = preMatriculaInscricao.preMatriculaInscricaoUID;
				projetoDiscente.registro = preMatriculaInscricaoDAL.GerarNumeroRegistroAluno(preMatriculaInscricao.projetoTurmaPoloUID.GetValueOrDefault());
			}
			projetoDiscente.dataIngresso = projetoDiscenteNovo.dataIngresso;
			projetoDiscente.tipoFormaIngressoUID = projetoDiscenteNovo.tipoFormaIngressoUID;
			projetoDiscente.tipoPeridoIngressoUID = projetoDiscenteNovo.tipoPeridoIngressoUID;
			projetoDiscente.tipoReservaVagasUID = projetoDiscenteNovo.tipoReservaVagasUID;
			projetoDiscente.periodo = projetoDiscenteNovo.periodo;
			if (flag)
			{
				contextInstance.ProjetoDiscente.Add(projetoDiscente);
			}
			else
			{
				contextInstance.Entry(projetoDiscente).State = (EntityState)16;
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Alteração efetuada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao efetuar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public PreMatriculaPessoa VerificarCpfPessoa(string cpf)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.PreMatriculaPessoa.FirstOrDefault((PreMatriculaPessoa p) => p.cpf == cpf);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public PreMatriculaInscricao GetDetalheMatricula(long preMatriculaId)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.PreMatriculaInscricao.FirstOrDefault((PreMatriculaInscricao p) => p.preMatriculaInscricaoUID == preMatriculaId);
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public long GerarNumeroPreMatriculaInscricao()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ObjectParameter val = new ObjectParameter("NumeroInscricaoSaida", typeof(int));
			contextInstance.ProcedureGerarNumeroPreMatriculaInscricao(val);
			return (int)val.Value;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao CancelarInscricao(long preMatriculaInscricaoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			PreMatriculaInscricao preMatriculaInscricao = contextInstance.PreMatriculaInscricao.Where((PreMatriculaInscricao c) => c.preMatriculaInscricaoUID == preMatriculaInscricaoUID).FirstOrDefault();
			if (preMatriculaInscricao.TipoSituacaoInscricao.nome.ToUpper().Equals("CURSANDO") || preMatriculaInscricao.TipoSituacaoInscricao.nome.ToUpper().Equals("FORMADO") || preMatriculaInscricao.TipoSituacaoInscricao.nome.ToUpper().Equals("TRANSFERIDO"))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "A inscrição para este curso não pode ser cancelada.<br />Entre em contato com a coordenação do seu curso.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			contextInstance.PreMatriculaInscricao.Remove(preMatriculaInscricao);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Cancelamento de inscrição efetuada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao efetuar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public List<ViewPreMatriculaInscricao> GetInscricoesPessoa(long preMatriculaPessoaUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewPreMatriculaInscricao.Where((ViewPreMatriculaInscricao c) => c.preMatriculaPessoaUID == preMatriculaPessoaUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewPreMatriculaInscricao> GetInscricoesCurso(int projetoCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewPreMatriculaInscricao.Where((ViewPreMatriculaInscricao c) => c.projetoCursoUID == (long)projetoCursoUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public int? GetInstituicaoEnsinoSuperiorPorId(long instituicaoEnsinoSuperiorUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.InstituicaoEnsino
				where (long)c.instituicaoEnsinoUID == instituicaoEnsinoSuperiorUID
				select c.instituicaoEnsinoUID).SingleOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CorrecaoPreMatriculaInscricao> GetCorrecaoPreMatriculaInscricao(long preMatriculaInscricaoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CorrecaoPreMatriculaInscricao.Where((CorrecaoPreMatriculaInscricao c) => c.preMatriculaInscricaoUID == preMatriculaInscricaoUID && c.correcaoConfirmada == false).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public int? GetMunicipioPorId(int municipioUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.Municipio
				where c.MunicipioUID == municipioUID
				select c.MunicipioUID).SingleOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoFormaIngresso> GetTipoFormaIngresso()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoFormaIngresso.OrderBy((TipoFormaIngresso c) => c.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoPeriodoIngresso> GetTipoPeriodoIngresso()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoPeriodoIngresso.OrderBy((TipoPeriodoIngresso c) => c.regime).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoReservaVagas> GetTipoReservaVagas()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoReservaVagas.OrderBy((TipoReservaVagas c) => c.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoSituacaoInscricao> GetTipoSituacaoInscricao()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoSituacaoInscricao.OrderBy((TipoSituacaoInscricao c) => c.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<TipoSituacaoInscricao> ListarTiposSituacaoInscricao()
	{
		try
		{
			return (from e in Contexto.GetContextInstance().TipoSituacaoInscricao
				where (uint)e.tipoSituacaoInscricaoUID > 2u
				orderby e.nome
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}
