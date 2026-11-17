using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ProjetoImportarCandidatosProcessoSeleteivoDAL
{
	public ResultadoOperacao ImportarCandidatosProcessoSeletivo(List<PreMatriculaPessoa> listaPreMatriculaPessoa)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		string text = string.Empty;
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			foreach (PreMatriculaPessoa item in listaPreMatriculaPessoa)
			{
				text = item.cpf;
				PreMatriculaPessoa preMatriculaPessoa = contextInstance.PreMatriculaPessoa.Where((PreMatriculaPessoa e) => e.cpf == item.cpf).FirstOrDefault();
				if (preMatriculaPessoa == null)
				{
					contextInstance.PreMatriculaPessoa.Add(item);
					continue;
				}
				preMatriculaPessoa.nome = item.nome;
				preMatriculaPessoa.sexo = item.sexo;
				preMatriculaPessoa.nascimentoData = item.nascimentoData;
				preMatriculaPessoa.nomeMae = item.nomeMae;
				preMatriculaPessoa.nomePai = item.nomePai;
				preMatriculaPessoa.rgNumero = item.rgNumero;
				preMatriculaPessoa.rgOrgaoExpedidor = item.rgOrgaoExpedidor;
				preMatriculaPessoa.rgUFUID = item.rgUFUID;
				preMatriculaPessoa.rgDataExpedicao = item.rgDataExpedicao;
				preMatriculaPessoa.tipoEstadoCivilUID = item.tipoEstadoCivilUID;
				preMatriculaPessoa.telefoneFixo = item.telefoneFixo;
				preMatriculaPessoa.telefoneMovel = item.telefoneMovel;
				preMatriculaPessoa.email = item.email;
				preMatriculaPessoa.tituloEleitoral = item.tituloEleitoral;
				preMatriculaPessoa.zona = item.zona;
				preMatriculaPessoa.tituloEleitoralUFUID = item.tituloEleitoralUFUID;
				preMatriculaPessoa.tituloEleitoralMunicipioUID = item.tituloEleitoralMunicipioUID;
				preMatriculaPessoa.nacionalidade = item.nacionalidade;
				preMatriculaPessoa.passaporte = item.passaporte;
				preMatriculaPessoa.nascimentoPaisUID = item.nascimentoPaisUID;
				preMatriculaPessoa.naturalidadeUFUID = item.naturalidadeUFUID;
				preMatriculaPessoa.naturalidadeMunicipioUID = item.naturalidadeMunicipioUID;
				preMatriculaPessoa.enderecoLogradouro = item.enderecoLogradouro;
				preMatriculaPessoa.enderecoNumero = item.enderecoNumero;
				preMatriculaPessoa.enderecoComplemento = item.enderecoComplemento;
				preMatriculaPessoa.enderecoBairro = item.enderecoBairro;
				preMatriculaPessoa.enderecoCEP = item.enderecoCEP;
				preMatriculaPessoa.enderecoUFUID = item.enderecoUFUID;
				preMatriculaPessoa.enderecoMunicipioUID = item.enderecoMunicipioUID;
				preMatriculaPessoa.graduacaoUFUID = item.graduacaoUFUID;
				preMatriculaPessoa.projetoTipoGraduacaoUID = item.projetoTipoGraduacaoUID;
				preMatriculaPessoa.cursoGraduacao = item.cursoGraduacao;
				preMatriculaPessoa.numeroRegistroDiploma = item.numeroRegistroDiploma;
				preMatriculaPessoa.graduacaoInstituicaoEnsinoUID = item.graduacaoInstituicaoEnsinoUID;
				preMatriculaPessoa.graduacaoDataColacaoGrau = item.graduacaoDataColacaoGrau;
				preMatriculaPessoa.diplomaGraduacaoExterior = item.diplomaGraduacaoExterior;
				preMatriculaPessoa.numeroRegistroApostilaRevalidacao = item.numeroRegistroApostilaRevalidacao;
				preMatriculaPessoa.dataHoraUltimaAtualizacao = item.dataHoraUltimaAtualizacao;
				preMatriculaPessoa.profissao = item.profissao;
				preMatriculaPessoa.localTrabalho = item.localTrabalho;
				preMatriculaPessoa.telefoneComercial = item.telefoneComercial;
				preMatriculaPessoa.celularComercial = item.celularComercial;
				preMatriculaPessoa.emailComercial = item.emailComercial;
				contextInstance.Entry(preMatriculaPessoa).State = (EntityState)16;
			}
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Candidatos importados com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao importar Candidatos. CPF: " + text;
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}
}
