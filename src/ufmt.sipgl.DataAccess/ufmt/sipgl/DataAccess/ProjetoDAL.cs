using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoDAL
{
	public ProjetoCurso BuscarProjetoCurso(long projetoCursoUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoCurso.Where((ProjetoCurso e) => e.projetoCursoUID == projetoCursoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewEnderecoPoloEAD> ListarViewEnderecoPoloEAD(List<int> listaEnderecoUID)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ViewEnderecoPoloEAD
				where listaEnderecoUID.Contains(e.enderecoUID)
				orderby e.municipio
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoCurso> ListarProjetoCurso(string filtro)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			IQueryable<ProjetoCurso> source = contextInstance.ProjetoCurso.AsQueryable();
			if (!string.IsNullOrWhiteSpace(filtro))
			{
				source = source.Where((ProjetoCurso e) => e.nomeCurso.ToUpper().Contains(filtro.ToUpper()));
			}
			return source.OrderBy((ProjetoCurso e) => e.nomeCurso).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoCurso> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from e in contextInstance.ProjetoCurso
				orderby e.projetoCursoUID descending
				orderby e.nomeCurso
				select e).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoCurso GetRegistroPorId(long projetoCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ProjetoCurso.Where((ProjetoCurso e) => e.projetoCursoUID == projetoCursoUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ProjetoCurso> FiltrarProjetoCurso(string nomeCurso, bool isTurmaAtiva)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			IQueryable<ProjetoCurso> source = contextInstance.ProjetoCurso.AsQueryable();
			if (!string.IsNullOrWhiteSpace(nomeCurso))
			{
				source = source.Where((ProjetoCurso e) => e.nomeCurso.ToUpper().Contains(nomeCurso.ToUpper()));
			}
			if (isTurmaAtiva)
			{
				source = source.Where((ProjetoCurso e) => e.ProjetoTurma.Any((ProjetoTurma t) => t.isAtivo == true));
			}
			return source.OrderBy((ProjetoCurso e) => e.nomeCurso).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ResultadoOperacao Salvar(ProjetoCurso projetoCurso)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			contextInstance.ProjetoCurso.Add(projetoCurso);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação efetuada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao AlterarProjetoCurso(ProjetoCurso projetoCurso)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			ProjetoCurso projetoCurso2 = contextInstance.ProjetoCurso.Where((ProjetoCurso e) => e.projetoCursoUID == projetoCurso.projetoCursoUID).FirstOrDefault();
			projetoCurso2.tipoModalidadeUID = projetoCurso.tipoModalidadeUID;
			projetoCurso2.codigoEMEC = projetoCurso.codigoEMEC;
			projetoCurso2.nomeCurso = projetoCurso.nomeCurso;
			projetoCurso2.CNPqAreaConhecimentoUID = projetoCurso.CNPqAreaConhecimentoUID;
			projetoCurso2.proponenteUnidadeUID = projetoCurso.proponenteUnidadeUID;
			projetoCurso2.telefone = projetoCurso.telefone;
			projetoCurso2.fax = projetoCurso.fax;
			projetoCurso2.email = projetoCurso.email;
			projetoCurso2.siteCurso = projetoCurso.siteCurso;
			projetoCurso2.coordenadorServidorUID = projetoCurso.coordenadorServidorUID;
			projetoCurso2.titulacaoCoordenadorUID = projetoCurso.titulacaoCoordenadorUID;
			projetoCurso2.regimeTrabalhoCoordenadorUID = projetoCurso.regimeTrabalhoCoordenadorUID;
			projetoCurso2.telefoneResidencialCoordenador = projetoCurso.telefoneResidencialCoordenador;
			projetoCurso2.telefoneCelularCoordenador = projetoCurso.telefoneCelularCoordenador;
			projetoCurso2.emailCoordenador = projetoCurso.emailCoordenador;
			projetoCurso2.viceCoordenadorServidorUID = projetoCurso.viceCoordenadorServidorUID;
			projetoCurso2.titulacaoViceCoordenadorUID = projetoCurso.titulacaoViceCoordenadorUID;
			projetoCurso2.regimeTrabalhoViceCoordenadorUID = projetoCurso.regimeTrabalhoViceCoordenadorUID;
			projetoCurso2.telefoneResidencialViceCoordenador = projetoCurso.telefoneResidencialViceCoordenador;
			projetoCurso2.telefoneCelularViceCoordenador = projetoCurso.telefoneCelularViceCoordenador;
			projetoCurso2.emailViceCoordenador = projetoCurso.emailViceCoordenador;
			projetoCurso2.secretarioUID = projetoCurso.secretarioUID;
			projetoCurso2.emailSecretario = projetoCurso.emailSecretario;
			projetoCurso2.celularSecretario = projetoCurso.celularSecretario;
			projetoCurso2.realizacaoDataInicio = projetoCurso.realizacaoDataInicio;
			projetoCurso2.realizacaoDataTermino = projetoCurso.realizacaoDataTermino;
			projetoCurso2.cargaHorariaTotal = projetoCurso.cargaHorariaTotal;
			projetoCurso2.turnoOfertaUID = projetoCurso.turnoOfertaUID;
			projetoCurso2.periodicidadeUID = projetoCurso.periodicidadeUID;
			projetoCurso2.cargaHorariaDiario = projetoCurso.cargaHorariaDiario;
			projetoCurso2.cargaHorariaModular = projetoCurso.cargaHorariaModular;
			projetoCurso2.nomeCursoModular = projetoCurso.nomeCursoModular;
			projetoCurso2.publicoAlvo = projetoCurso.publicoAlvo;
			projetoCurso2.descricaoInstalacoes = projetoCurso.descricaoInstalacoes;
			projetoCurso2.descricaoEquipamentos = projetoCurso.descricaoEquipamentos;
			projetoCurso2.descricaoMaterialBibliografico = projetoCurso.descricaoMaterialBibliografico;
			projetoCurso2.justificativaCurso = projetoCurso.justificativaCurso;
			projetoCurso2.objetivosCurso = projetoCurso.objetivosCurso;
			projetoCurso2.minutaEdital = projetoCurso.minutaEdital;
			projetoCurso2.formasAvaliacao = projetoCurso.formasAvaliacao;
			projetoCurso2.caracteristicasMonografiaTcc = projetoCurso.caracteristicasMonografiaTcc;
			projetoCurso2.notaMinimaAprovacao = projetoCurso.notaMinimaAprovacao;
			projetoCurso2.frequenciaMinimaAprovacao = projetoCurso.frequenciaMinimaAprovacao;
			projetoCurso2.financiamentoCurso = projetoCurso.financiamentoCurso;
			projetoCurso2.termoConvenio = projetoCurso.termoConvenio;
			projetoCurso2.tipoFinanciamentoUID = projetoCurso.tipoFinanciamentoUID;
			projetoCurso2.tipoGestaoFinanceiraUID = projetoCurso.tipoGestaoFinanceiraUID;
			projetoCurso2.planoAplicacaoSuperavit = projetoCurso.planoAplicacaoSuperavit;
			projetoCurso2.quantidadeVagas = projetoCurso.quantidadeVagas;
			projetoCurso2.dataDocumentoRealizacaoCurso = projetoCurso.dataDocumentoRealizacaoCurso;
			projetoCurso2.documentoRealizacaoCurso = projetoCurso.documentoRealizacaoCurso;
			projetoCurso2.CEP = projetoCurso.CEP;
			projetoCurso2.municipioEnderecoUID = projetoCurso.municipioEnderecoUID;
			projetoCurso2.identificacaoEndereco = projetoCurso.identificacaoEndereco;
			projetoCurso2.numeroEndereco = projetoCurso.numeroEndereco;
			projetoCurso2.complementoBairro = projetoCurso.complementoBairro;
			projetoCurso2.bairroEndereco = projetoCurso.bairroEndereco;
			projetoCurso2.informacoesReferenciaEndereco = projetoCurso.informacoesReferenciaEndereco;
			projetoCurso2.CNPqSubAreaConhecimentoUID = projetoCurso.CNPqSubAreaConhecimentoUID;
			projetoCurso2.descricaoAva = projetoCurso.descricaoAva;
			contextInstance.Entry(projetoCurso2).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
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
