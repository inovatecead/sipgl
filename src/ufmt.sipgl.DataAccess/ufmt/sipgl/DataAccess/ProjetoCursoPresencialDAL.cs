using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoPresencialDAL
{
	public List<ViewProjetoCursoPresencial> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewProjetoCursoPresencial.OrderByDescending((ViewProjetoCursoPresencial c) => c.projetoCursoUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ViewProjetoCursoPresencial GetRegistroPorId(long id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewProjetoCursoPresencial.Where((ViewProjetoCursoPresencial c) => c.projetoCursoUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ViewProjetoCursoPresencial> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewProjetoCursoPresencial.Where((ViewProjetoCursoPresencial c) => c.Nome_do_Curso.Contains(criterio)).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Excluir(int id)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			ObjectParameter val = new ObjectParameter("ErroSaida", typeof(string));
			contextInstance.ProcedureExcluirProjetoCurso(id, val);
			if (string.IsNullOrEmpty(val.Value.ToString()))
			{
				resultadoOperacao.Erro = false;
				resultadoOperacao.TextMessage = "Registro(s) excluído(s) com sucesso.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
			}
			else
			{
				string[] array = val.Value.ToString().Split(new char[1] { '|' });
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Não foi possível excluir o registro. " + array[1];
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operção. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		}
		return resultadoOperacao;
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
		foreach (ViewInstituicaoEnsinoSuperior item in Contexto.GetContextInstance().ViewInstituicaoEnsinoSuperior.Select((ViewInstituicaoEnsinoSuperior c) => c).Take(1000))
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
			viewMunicipio.MunicipioUID = item.MunicipioUID;
			list.Add(viewMunicipio);
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
		return Contexto.GetContextInstance().UF.Select((UF c) => c).ToList();
	}
}
