using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.DataAccess.Utils;

namespace ufmt.sipgl.Business;

public class ProjetoImportarCandidatosProcessoSeleteivoBO
{
	public ProjetoImportarCandidatosProcessoSeleteivoDAL ProjetoImportarCandidatosProcessoSeleteivoDAL { get; set; }

	public ProjetoImportarCandidatosProcessoSeleteivoBO()
	{
		ProjetoImportarCandidatosProcessoSeleteivoDAL = new ProjetoImportarCandidatosProcessoSeleteivoDAL();
	}

	public ResultadoOperacao ImportarCandidatosProcessoSeletivo(Stream stream)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		new Util();
		PreMatriculaPessoaDAL preMatriculaPessoaDAL = new PreMatriculaPessoaDAL();
		string text = "";
		try
		{
			List<PreMatriculaPessoa> list = new List<PreMatriculaPessoa>();
			if (stream == null)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Erro ao importar alunos";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
				return resultadoOperacao;
			}
			using (IExcelDataReader self = ExcelReaderFactory.CreateReader(stream))
			{
				int? num = null;
				int? num2 = null;
				int? num3 = null;
				int? num4 = null;
				int? num5 = null;
				int? num6 = null;
				int? num7 = null;
				int? num8 = null;
				int? num9 = null;
				int? num10 = null;
				int? num11 = null;
				int? num12 = null;
				int? num13 = null;
				int? num14 = null;
				int? num15 = null;
				int? num16 = null;
				int? num17 = null;
				int? num18 = null;
				int? num19 = null;
				int? num20 = null;
				int? num21 = null;
				int? num22 = null;
				int? num23 = null;
				int? num24 = null;
				int? num25 = null;
				int? num26 = null;
				int? num27 = null;
				int? num28 = null;
				int? num29 = null;
				int? num30 = null;
				int? num31 = null;
				int? num32 = null;
				int? num33 = null;
				int? num34 = null;
				int? num35 = null;
				int? num36 = null;
				int? num37 = null;
				int? num38 = null;
				int? num39 = null;
				int? num40 = null;
				int? num41 = null;
				DataRowCollection rows = self.AsDataSet().Tables[0].Rows;
				DataRow dataRow = rows[0];
				for (int i = 0; i < dataRow.ItemArray.Length; i++)
				{
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "NOME")
					{
						num = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "SEXO")
					{
						num2 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "DATA_NASCIMENTO")
					{
						num3 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "NOME_MAE")
					{
						num4 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "NOME_PAI")
					{
						num5 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "CPF")
					{
						num6 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "RG")
					{
						num7 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "ORGAO_EXPEDIDOR")
					{
						num8 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "UF_ORGAO_EXPEDIDOR")
					{
						num9 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "DATA_EXPEDICAO")
					{
						num10 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "ESTADO_CIVIL")
					{
						num11 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "TELEFONE_FIXO")
					{
						num12 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "CELULAR")
					{
						num13 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "EMAIL")
					{
						num14 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "TITULO_ELEITORAL")
					{
						num15 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "ZONA")
					{
						num16 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "UF_TITULO_ELEITOR")
					{
						num17 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "MUNICIPIO_TITULO_ELEITOR")
					{
						num18 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "NACIONALIDADE")
					{
						num19 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "PASSAPORTE")
					{
						num20 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "PAIS_NASCIMENTO")
					{
						num21 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "UF_NATURALIDADE")
					{
						num22 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "MUNICIPIO_NATURALIDADE")
					{
						num23 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "LOGRADOURO")
					{
						num24 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "NUMERO")
					{
						num25 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "COMPLEMENTO")
					{
						num26 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "BAIRRO")
					{
						num27 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "CEP")
					{
						num28 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "UF_ENDERECO")
					{
						num29 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "MUNICIPIO_ENDERECO")
					{
						num30 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "UF_GRADUACAO")
					{
						num31 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "TIPO_GRADUACAO")
					{
						num32 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "CURSO_GRADUACAO")
					{
						num33 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "NUMERO_REGISTRO_DIPLOMA")
					{
						num34 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "INSTITUICAO_GRADUACAO")
					{
						num35 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "DATA_COLACAO_GRAU")
					{
						num36 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "PROFISSAO")
					{
						num37 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "EMPRESA")
					{
						num38 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "TELEFONE_EMPRESA")
					{
						num39 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "CELULAR_EMPRESA")
					{
						num40 = i;
					}
					if (dataRow.ItemArray[i].ToString().ToUpper().Trim() == "EMAIL_EMPRESA")
					{
						num41 = i;
					}
				}
				if (!num.HasValue || !num2.HasValue || !num3.HasValue || !num4.HasValue || !num5.HasValue || !num6.HasValue || !num7.HasValue || !num8.HasValue || !num9.HasValue || !num10.HasValue || !num11.HasValue || !num12.HasValue || !num13.HasValue || !num14.HasValue || !num15.HasValue || !num16.HasValue || !num17.HasValue || !num18.HasValue || !num19.HasValue || !num20.HasValue || !num21.HasValue || !num22.HasValue || !num23.HasValue || !num24.HasValue || !num25.HasValue || !num26.HasValue || !num27.HasValue || !num28.HasValue || !num29.HasValue || !num30.HasValue || !num31.HasValue || !num32.HasValue || !num33.HasValue || !num34.HasValue || !num35.HasValue || !num36.HasValue || !num37.HasValue || !num38.HasValue || !num39.HasValue || !num40.HasValue || !num41.HasValue)
				{
					resultadoOperacao.TextMessage = "Erro ao Identificar Cabecalho!";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					resultadoOperacao.Erro = true;
					return resultadoOperacao;
				}
				for (int j = 1; j < rows.Count; j++)
				{
					string text2 = rows[j].ItemArray[num.GetValueOrDefault()].ToString().Trim().ToUpper();
					string text3 = rows[j].ItemArray[num2.GetValueOrDefault()].ToString().Trim();
					string value = rows[j].ItemArray[num3.GetValueOrDefault()].ToString().Trim();
					string text4 = rows[j].ItemArray[num4.GetValueOrDefault()].ToString().Trim().ToUpper();
					string text5 = rows[j].ItemArray[num5.GetValueOrDefault()].ToString().Trim().ToUpper();
					string text6 = rows[j].ItemArray[num6.GetValueOrDefault()].ToString().Trim();
					string rgNumero = rows[j].ItemArray[num7.GetValueOrDefault()].ToString().Trim();
					string rgOrgaoExpedidor = rows[j].ItemArray[num8.GetValueOrDefault()].ToString().Trim();
					string rgUFUID = rows[j].ItemArray[num9.GetValueOrDefault()].ToString().Trim();
					string value2 = rows[j].ItemArray[num10.GetValueOrDefault()].ToString().Trim();
					string nome = rows[j].ItemArray[num11.GetValueOrDefault()].ToString().Trim();
					string telefoneFixo = rows[j].ItemArray[num12.GetValueOrDefault()].ToString().Trim();
					string text7 = rows[j].ItemArray[num13.GetValueOrDefault()].ToString().Trim();
					string email = rows[j].ItemArray[num14.GetValueOrDefault()].ToString().Trim();
					string text8 = rows[j].ItemArray[num15.GetValueOrDefault()].ToString().Trim();
					string text9 = rows[j].ItemArray[num16.GetValueOrDefault()].ToString().Trim();
					string text10 = rows[j].ItemArray[num17.GetValueOrDefault()].ToString().Trim();
					string text11 = rows[j].ItemArray[num18.GetValueOrDefault()].ToString().Trim();
					string nacionalidade = rows[j].ItemArray[num19.GetValueOrDefault()].ToString().Trim();
					string text12 = rows[j].ItemArray[num20.GetValueOrDefault()].ToString().Trim();
					string nome2 = rows[j].ItemArray[num21.GetValueOrDefault()].ToString().Trim();
					string text13 = rows[j].ItemArray[num22.GetValueOrDefault()].ToString().Trim();
					string nome3 = rows[j].ItemArray[num23.GetValueOrDefault()].ToString().Trim();
					string enderecoLogradouro = rows[j].ItemArray[num24.GetValueOrDefault()].ToString().Trim();
					string enderecoNumero = rows[j].ItemArray[num25.GetValueOrDefault()].ToString().Trim();
					string text14 = rows[j].ItemArray[num26.GetValueOrDefault()].ToString().Trim();
					string enderecoBairro = rows[j].ItemArray[num27.GetValueOrDefault()].ToString().Trim();
					string enderecoCEP = rows[j].ItemArray[num28.GetValueOrDefault()].ToString().Trim();
					string text15 = rows[j].ItemArray[num29.GetValueOrDefault()].ToString().Trim();
					string nome4 = rows[j].ItemArray[num30.GetValueOrDefault()].ToString().Trim();
					string text16 = rows[j].ItemArray[num31.GetValueOrDefault()].ToString().Trim();
					string nome5 = rows[j].ItemArray[num32.GetValueOrDefault()].ToString().Trim();
					string cursoGraduacao = rows[j].ItemArray[num33.GetValueOrDefault()].ToString().Trim();
					string numeroRegistroDiploma = rows[j].ItemArray[num34.GetValueOrDefault()].ToString().Trim();
					string instituicaoFormacao = rows[j].ItemArray[num35.GetValueOrDefault()].ToString().Trim();
					string value3 = rows[j].ItemArray[num36.GetValueOrDefault()].ToString().Trim();
					string text17 = rows[j].ItemArray[num37.GetValueOrDefault()].ToString().Trim();
					string text18 = rows[j].ItemArray[num38.GetValueOrDefault()].ToString().Trim();
					string text19 = rows[j].ItemArray[num39.GetValueOrDefault()].ToString().Trim();
					string text20 = rows[j].ItemArray[num40.GetValueOrDefault()].ToString().Trim();
					string text21 = rows[j].ItemArray[num41.GetValueOrDefault()].ToString().Trim();
					text = text6;
					PreMatriculaPessoa preMatriculaPessoa = new PreMatriculaPessoa();
					preMatriculaPessoa.nome = text2.ToUpper();
					preMatriculaPessoa.sexo = ((text3 == "Masculino") ? "M" : "F");
					preMatriculaPessoa.nascimentoData = Convert.ToDateTime(value);
					preMatriculaPessoa.nomeMae = text4.ToUpper();
					preMatriculaPessoa.nomePai = ((!string.IsNullOrWhiteSpace(text5)) ? text5.ToUpper() : null);
					preMatriculaPessoa.cpf = text6;
					preMatriculaPessoa.rgNumero = rgNumero;
					preMatriculaPessoa.rgOrgaoExpedidor = rgOrgaoExpedidor;
					preMatriculaPessoa.rgUFUID = rgUFUID;
					preMatriculaPessoa.rgDataExpedicao = Convert.ToDateTime(value2);
					preMatriculaPessoa.tipoEstadoCivilUID = BuscarEstadoCivil(nome);
					preMatriculaPessoa.telefoneFixo = telefoneFixo;
					preMatriculaPessoa.telefoneMovel = ((!string.IsNullOrWhiteSpace(text7)) ? text7 : null);
					preMatriculaPessoa.email = email;
					preMatriculaPessoa.tituloEleitoral = ((!string.IsNullOrWhiteSpace(text8)) ? text8 : null);
					preMatriculaPessoa.zona = ((!string.IsNullOrWhiteSpace(text9)) ? text9 : null);
					preMatriculaPessoa.tituloEleitoralUFUID = ((!string.IsNullOrWhiteSpace(text10)) ? text10.ToUpper() : null);
					preMatriculaPessoa.tituloEleitoralMunicipioUID = ((!string.IsNullOrWhiteSpace(text11)) ? BuscarMunicipioPorDescricao(text11) : ((int?)null));
					preMatriculaPessoa.nacionalidade = BuscarNacionalidade(nacionalidade);
					preMatriculaPessoa.passaporte = ((!string.IsNullOrWhiteSpace(text12)) ? text12 : null);
					preMatriculaPessoa.nascimentoPaisUID = BuscarPaisNascimento(nome2);
					preMatriculaPessoa.naturalidadeUFUID = text13.ToUpper();
					preMatriculaPessoa.naturalidadeMunicipioUID = BuscarMunicipioPorDescricao(nome3);
					preMatriculaPessoa.enderecoLogradouro = enderecoLogradouro;
					preMatriculaPessoa.enderecoNumero = enderecoNumero;
					preMatriculaPessoa.enderecoComplemento = ((!string.IsNullOrWhiteSpace(text14)) ? text14 : null);
					preMatriculaPessoa.enderecoBairro = enderecoBairro;
					preMatriculaPessoa.enderecoCEP = enderecoCEP;
					preMatriculaPessoa.enderecoUFUID = text15.ToUpper();
					preMatriculaPessoa.enderecoMunicipioUID = BuscarMunicipioPorDescricao(nome4).GetValueOrDefault();
					preMatriculaPessoa.graduacaoUFUID = text16.ToUpper();
					preMatriculaPessoa.projetoTipoGraduacaoUID = BuscarTipoGraduacao(nome5);
					preMatriculaPessoa.cursoGraduacao = cursoGraduacao;
					preMatriculaPessoa.numeroRegistroDiploma = numeroRegistroDiploma;
					preMatriculaPessoa.graduacaoInstituicaoEnsinoUID = BuscarInstituicaoEnsino(instituicaoFormacao);
					preMatriculaPessoa.graduacaoDataColacaoGrau = (string.IsNullOrWhiteSpace(value3) ? DateTime.Now : Convert.ToDateTime(value3));
					preMatriculaPessoa.diplomaGraduacaoExterior = false;
					preMatriculaPessoa.numeroRegistroApostilaRevalidacao = null;
					preMatriculaPessoa.profissao = ((!string.IsNullOrWhiteSpace(text17)) ? text17 : null);
					preMatriculaPessoa.localTrabalho = ((!string.IsNullOrWhiteSpace(text18)) ? text18 : null);
					preMatriculaPessoa.telefoneComercial = ((!string.IsNullOrWhiteSpace(text19)) ? text19 : null);
					preMatriculaPessoa.celularComercial = ((!string.IsNullOrWhiteSpace(text20)) ? text20 : null);
					preMatriculaPessoa.emailComercial = ((!string.IsNullOrWhiteSpace(text21)) ? text21 : null);
					preMatriculaPessoa.tipoFaixaRendaFamiliarUID = null;
					preMatriculaPessoa.tipoCorRacaUID = null;
					preMatriculaPessoa.dataHoraCadastro = DateTime.Now;
					preMatriculaPessoa.dataHoraUltimaAtualizacao = DateTime.Now;
					preMatriculaPessoa.senha = preMatriculaPessoaDAL.GetMD5Hash(text6 + DateTime.Now);
					preMatriculaPessoa.chaveValidacaoCadastro = null;
					preMatriculaPessoa.emailConfirmado = false;
					preMatriculaPessoa.chaveRecuperacaoSenha = null;
					preMatriculaPessoa.dataValidadeChave = null;
					list.Add(preMatriculaPessoa);
				}
			}
			resultadoOperacao = ProjetoImportarCandidatosProcessoSeleteivoDAL.ImportarCandidatosProcessoSeletivo(list);
			return resultadoOperacao;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao importar candidatos: Verifique dados do CPF " + text;
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			return resultadoOperacao;
		}
	}

	public int? BuscarInstituicaoEnsino(string instituicaoFormacao)
	{
		List<InstituicaoEnsino> list = new InstituicaoEnsinoBO().BuscarInstituicaoEnsinoPorDescricao(instituicaoFormacao);
		if (list != null && list.Count == 1)
		{
			return list.FirstOrDefault().instituicaoEnsinoUID;
		}
		return null;
	}

	public string BuscarPaisNascimento(string nome)
	{
		Pais pais = new PaisBO().BuscarPaisPorDescricao(nome);
		if (pais == null)
		{
			return "BRA";
		}
		return pais.paisUID;
	}

	public string BuscarNacionalidade(string nacionalidade)
	{
		if (nacionalidade.ToUpper() == "BRASILEIRO" || nacionalidade.ToUpper() == "BRASILEIRA")
		{
			return "B";
		}
		if (nacionalidade.ToUpper() == "ESTRANGEIRO" || nacionalidade.ToUpper() == "ESTRANGEIRA")
		{
			return "E";
		}
		return "B";
	}

	public int? BuscarMunicipioPorDescricao(string nome)
	{
		MunicipioDAL municipioDAL = new MunicipioDAL();
		Municipio municipio = null;
		try
		{
			int id = int.Parse(nome);
			municipio = municipioDAL.GetPorId(id);
		}
		catch (Exception)
		{
			municipio = municipioDAL.BuscarMunicipioPorDescricao(nome);
		}
		if (municipio != null)
		{
			return municipio.MunicipioUID;
		}
		throw new Exception();
	}

	public byte BuscarEstadoCivil(string nome)
	{
		if (nome.ToUpper() == "SOLTEIRO(A)")
		{
			return 1;
		}
		if (nome.ToUpper() == "CASADO(A) / MORA COM UM(A) COMPANHEIRO(A)" || nome.ToUpper() == "UNIÃO ESTÁVEL")
		{
			return 2;
		}
		if (nome.ToUpper() == "DIVORCIADO(A) / DESQUITADO(A) / SEPARADO(A)".ToUpper())
		{
			return 3;
		}
		if (nome.ToUpper() == "VIUVO(A)".ToUpper())
		{
			return 4;
		}
		return 1;
	}

	public long? BuscarTipoGraduacao(string nome)
	{
		if (nome.ToUpper() == "BACHARELADO")
		{
			return 1L;
		}
		if (nome.ToUpper() == "LICENCIATURA")
		{
			return 2L;
		}
		if (nome.ToUpper() == "TECNÓLOGO")
		{
			return 3L;
		}
		return null;
	}
}
