using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class CursoDAL
{
	public List<ViewCurso> GetRegistros(long? servidorUID, string tipoServidor)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			List<ViewCurso> list = null;
			if (servidorUID.HasValue)
			{
				return (from c in contextInstance.ViewCurso
					where c.excluido == false && c.coordenadorServidorUID == servidorUID
					orderby c.cursoUID descending
					select c).Union(from c in contextInstance.ViewCurso
					where c.excluido == false && c.ViceCoordenadorServidorUID == servidorUID
					orderby c.cursoUID descending
					select c).ToList();
			}
			return (from c in contextInstance.ViewCurso
				where c.excluido == false
				orderby c.cursoUID descending
				select c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ViewCurso GetRegistroPorId(long id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewCurso.Where((ViewCurso c) => c.cursoUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public CorrecaoCurso GetCorrecaoCurso(long cursoUID, long tipoSolicitanteCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CorrecaoCurso.Where((CorrecaoCurso c) => c.cursoUID == cursoUID && (long)c.tipoSolicitanteCorrecaoCursoUID == tipoSolicitanteCursoUID && c.correcaoConfirmada == false).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<CorrecaoCurso> GetCorrecaoCurso(long cursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.CorrecaoCurso
				where c.cursoUID == cursoUID
				orderby c.dataHoraSolicitacaoCorrecao descending
				select c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ViewCurso> FindRegistros(string criterio, long? servidorUID, string tipoServidor)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		List<ViewCurso> list = null;
		try
		{
			if (servidorUID.HasValue)
			{
				return (from c in contextInstance.ViewCurso
					where c.nomeCurso.Contains(criterio) && c.excluido == false && c.coordenadorServidorUID == servidorUID
					orderby c.nomeCurso
					select c).Union(from c in contextInstance.ViewCurso
					where c.nomeCurso.Contains(criterio) && c.excluido == false && c.ViceCoordenadorServidorUID == servidorUID
					orderby c.nomeCurso
					select c).ToList();
			}
			return contextInstance.ViewCurso.Where((ViewCurso c) => c.nomeCurso.Contains(criterio) && c.excluido == false).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewCurso> GetCursoHomologado()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewCurso.Where((ViewCurso c) => c.excluido == false && c.tipoStatusHomologacaoUID == 4 && c.tipoStatusCursoUID == 2).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewCurso> FindRegistrosHomologado(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.ViewCurso
				where c.nomeCurso.Contains(criterio) && c.excluido == false && c.tipoStatusHomologacaoUID == 4 && c.tipoStatusCursoUID == 2
				orderby c.nomeCurso
				select c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ViewUnidade BuscarUnidadeProponente(long proponenteUnidadeUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewUnidade.Where((ViewUnidade e) => e.unidadeUID == proponenteUnidadeUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<CorrecaoCurso> GetDescricaoCorrecao(long cursoUID, byte tipoSolicitanteUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.CorrecaoCurso.Where((CorrecaoCurso c) => c.cursoUID == cursoUID && c.correcaoConfirmada == false && c.tipoSolicitanteCorrecaoCursoUID == tipoSolicitanteUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Excluir(int id)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ObjectParameter val = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureExcluirCurso(id, val);
			ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.TextMessage = "Registro(s) excluído(s) com sucesso.";
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.TextMessage = "Não foi possível excluir o registro. " + array[1];
			}
			return resultadoOperacao;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível excluir o registro.", innerException);
		}
	}

	public ResultadoOperacao Salvar(Curso obj, long coordenadorUID, long viceCoordenadorUID, DateTime? dataInicioInscricao, DateTime? dataFimInscricao, DateTime? dataIncioEstrutura, DateTime? dataFimEstrutura)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		new CoordenadorDAL();
		long? cursoUID = null;
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (obj.cursoUID != 0L)
			{
				cursoUID = obj.cursoUID;
			}
			ObjectParameter val = new ObjectParameter("CodigoCursoSaida", typeof(int));
			ObjectParameter val2 = new ObjectParameter("CursoUIDSaida", typeof(long));
			ObjectParameter val3 = new ObjectParameter("EstruturaCurricularUIDSaida", typeof(long));
			ObjectParameter val4 = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureInserirEditarCurso(cursoUID, obj.unidadeUID, obj.CNPqSubAreaConhecimentoUID, obj.nome, obj.tipoModalidadeUID, obj.cargaHoraria, obj.numeroResolucaoConsepe, obj.dataResolucaoConsepe, obj.numeroPortariaPropg, obj.dataPortariaPropg, obj.tipoStatusCursoUID, obj.descricaoCancelamento, coordenadorUID, viceCoordenadorUID, val2, val, dataIncioEstrutura, dataFimEstrutura, val3, dataInicioInscricao, dataFimInscricao, obj.tipoStatusHomologacaoUID, obj.codigoAcesso, val4);
			if (string.IsNullOrEmpty(val4.Value.ToString()))
			{
				if (cursoUID.HasValue)
				{
					resultadoOperacao.TextMessage = "Operação efetuada com sucesso.";
				}
				else
				{
					resultadoOperacao.CodigoCursoSaida = (int)val.Value;
					resultadoOperacao.CursoUIDSaida = (long)val2.Value;
					resultadoOperacao.EstruturaCurricularUIDSaida = (long)val3.Value;
					resultadoOperacao.TextMessage = "Operação efetuada com sucesso. Cadastre em seguida a área do curso (caso necessário).";
				}
			}
			else
			{
				string[] array = val4.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.TextMessage = array[1];
			}
			return resultadoOperacao;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Homologar(long cursoUID, string descricaoCorrecao, DateTime dataHoraUltimaAtualizacao, byte? tipoSolicitanteCorrecaoCursoUID)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ObjectParameter val = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureHomologarCurso(cursoUID, tipoSolicitanteCorrecaoCursoUID, descricaoCorrecao, dataHoraUltimaAtualizacao, val);
			ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.TextMessage = "Operação efetuada com sucesso.";
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.TextMessage = array[1];
			}
			return resultadoOperacao;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao ConfirmarCorrecaoCurso(long cursoUID, byte? tipoSolicitanteCorrecaoCursoUID)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ObjectParameter val = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureConfirmarCorrecaoCurso(cursoUID, tipoSolicitanteCorrecaoCursoUID, val);
			ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.TextMessage = "Operação efetuada com sucesso.";
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.TextMessage = array[1];
			}
			return resultadoOperacao;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<Especialidade> GetEspecialidadeEstruturaCurricular(long estruturaCurricularUID, int? numeroEspecialidade)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		List<Especialidade> list = null;
		try
		{
			if (numeroEspecialidade > 1)
			{
				return contextInstance.Especialidade.Where((Especialidade c) => c.estruturaCurricularUID == estruturaCurricularUID && c.tipoEspecialidadeUID == "E" && c.excluida == false).ToList();
			}
			return contextInstance.Especialidade.Where((Especialidade c) => c.estruturaCurricularUID == estruturaCurricularUID && c.excluida == false).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ObjInstituicaoEnsinoSuperior> GetInstituicaoEnsinoSuperior()
	{
		List<ObjInstituicaoEnsinoSuperior> list = new List<ObjInstituicaoEnsinoSuperior>();
		foreach (ViewInstituicaoEnsinoSuperior item in Contexto.GetContextInstance().ViewInstituicaoEnsinoSuperior.Select((ViewInstituicaoEnsinoSuperior c) => c))
		{
			ObjInstituicaoEnsinoSuperior objInstituicaoEnsinoSuperior = new ObjInstituicaoEnsinoSuperior();
			objInstituicaoEnsinoSuperior.Nome = item.nome;
			objInstituicaoEnsinoSuperior.InstituicaoEnsinoSuperiorUID = item.instituicaoEnsinoUID;
			list.Add(objInstituicaoEnsinoSuperior);
		}
		return list;
	}

	public List<ViewMunicipio> GetMunicipio()
	{
		List<ViewMunicipio> list = new List<ViewMunicipio>();
		foreach (ViewMunicipio item in Contexto.GetContextInstance().ViewMunicipio.Select((ViewMunicipio c) => c))
		{
			ViewMunicipio viewMunicipio = new ViewMunicipio();
			viewMunicipio.Nome = item.Nome;
			viewMunicipio.UF = item.UF;
			viewMunicipio.MunicipioUID = item.MunicipioUID;
			list.Add(viewMunicipio);
		}
		return list;
	}

	public List<ViewMunicipio> GetMunicipioPorEstado(string nome, string uf)
	{
		if (!string.IsNullOrWhiteSpace(uf))
		{
			IQueryable<ViewMunicipio> source = Contexto.GetContextInstance().ViewMunicipio.AsQueryable();
			source = source.Where((ViewMunicipio e) => e.UF.Equals(uf));
			if (!string.IsNullOrWhiteSpace(nome))
			{
				string nomeSemCaratareresEspeciais = nome.SemCaracteresEspeciais();
				source = source.Where((ViewMunicipio e) => e.Nome.ToUpper().Contains(nomeSemCaratareresEspeciais.ToUpper()));
			}
			return source.OrderBy((ViewMunicipio e) => e.Nome).ToList();
		}
		return new List<ViewMunicipio>();
	}

	public GetDiretorUnidade GetDiretorUnidade(long pessoaUID)
	{
		return Contexto.GetContextInstance().GetDiretorUnidade.Where((GetDiretorUnidade c) => c.pessoaUID == pessoaUID).FirstOrDefault();
	}

	public List<ViewDadosCursoSiga> GetCursoSiga()
	{
		List<ViewDadosCursoSiga> list = new List<ViewDadosCursoSiga>();
		foreach (ViewDadosCursoSiga item in Contexto.GetContextInstance().ViewDadosCursoSiga.Select((ViewDadosCursoSiga c) => c))
		{
			ViewDadosCursoSiga viewDadosCursoSiga = new ViewDadosCursoSiga();
			viewDadosCursoSiga.siganomecursovest = item.siganomecursovest;
			viewDadosCursoSiga.sigacodcursosiga = item.sigacodcursosiga;
			list.Add(viewDadosCursoSiga);
		}
		return list;
	}

	public List<TipoOrgaoExpedidorRg> GetOrgaoExpedidor()
	{
		return Contexto.GetContextInstance().TipoOrgaoExpedidorRg.Select((TipoOrgaoExpedidorRg c) => c).ToList();
	}

	public List<TipoEstadoCivil> GetEstadoCivil()
	{
		return Contexto.GetContextInstance().TipoEstadoCivil.Select((TipoEstadoCivil c) => c).ToList();
	}

	public List<TipoFaixaRendaFamiliar> GetFaixaRendaFamiliar()
	{
		return Contexto.GetContextInstance().TipoFaixaRendaFamiliar.Select((TipoFaixaRendaFamiliar c) => c).ToList();
	}

	public List<TipoCorRaca> GetTipoCorRaca()
	{
		return Contexto.GetContextInstance().TipoCorRaca.Select((TipoCorRaca c) => c).ToList();
	}

	public List<Pais> GetPais()
	{
		return Contexto.GetContextInstance().Pais.Select((Pais c) => c).ToList();
	}

	public List<UF> GetUF()
	{
		return (from e in Contexto.GetContextInstance().UF.Select((UF c) => c).ToList()
			orderby e.Nome
			select e).ToList();
	}

	public List<TipoTitulacao> ListarTipoTitulacao()
	{
		try
		{
			return Contexto.GetContextInstance().TipoTitulacao.OrderBy((TipoTitulacao e) => e.descricao).ToList();
		}
		catch (Exception)
		{
			return new List<TipoTitulacao>();
		}
	}
}
