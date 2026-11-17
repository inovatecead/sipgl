using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.projeto;

public class FrmAlterar : VerificaSession
{
	protected Label lblTitulo;

	protected HiddenField hddProjetoCursoUID;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelObjProjetoCurso;

	protected ValidationSummary ValidationSummary1;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected DropDownList ddlModalidade;

	protected Label Label105;

	protected RequiredFieldValidator RequiredFieldValidator87;

	protected DropDownList ddlGrandeArea;

	protected Label Label106;

	protected RequiredFieldValidator RequiredFieldValidator88;

	protected DropDownList ddlArea;

	protected Label Label107;

	protected RequiredFieldValidator RequiredFieldValidator89;

	protected DropDownList ddlSubArea;

	protected Label Label7;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected TextBox txtCodigoEMEC;

	protected Label Label34;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected TextBox txtNomeCurso;

	protected Panel pnlPeriodicidade;

	protected RequiredFieldValidator RequiredFieldValidator112;

	protected RadioButtonList rblPeriodicidade;

	protected Panel pnlPeriodicidadeDiario;

	protected RequiredFieldValidator RequiredFieldValidator109;

	protected TextBox txtCargaHorariaDiario;

	protected RegularExpressionValidator RegularExpressionValidator9;

	protected Panel pnlPeriodicidadeModular;

	protected RequiredFieldValidator RequiredFieldValidator110;

	protected TextBox txtCargaHorariaModular;

	protected RegularExpressionValidator RegularExpressionValidator10;

	protected RequiredFieldValidator RequiredFieldValidatorNomeCursoModular;

	protected TextBox txtNomeCursoModular;

	protected Label Label35;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtUnidadeProponente;

	protected Label lblNomeUnidade;

	protected HiddenField hddUnidadeUID;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected RequiredFieldValidator RequiredFieldValidator92;

	protected TextBox txtEndereco;

	protected RequiredFieldValidator RequiredFieldValidator90;

	protected TextBox txtCidade;

	protected RequiredFieldValidator RequiredFieldValidator91;

	protected TextBox txtCEPendereco;

	protected RequiredFieldValidator RequiredFieldValidator93;

	protected TextBox txtNumeroEndereco;

	protected RegularExpressionValidator RegularExpressionValidator11;

	protected TextBox txtComplementoEndereco;

	protected RequiredFieldValidator RequiredFieldValidator94;

	protected TextBox txtBairroEndereco;

	protected TextBox txtInfoReferenciaEndereco;

	protected Label Label57;

	protected RequiredFieldValidator RequiredFieldValidator48;

	protected TextBox txtTelefone;

	protected MaskedEditExtender MaskedEditExtenderTelefone;

	protected Label Label56;

	protected TextBox txtFax;

	protected Label Label36;

	protected RequiredFieldValidator RequiredFieldValidator111;

	protected TextBox txtEmail;

	protected Label Label37;

	protected TextBox txtSiteCurso;

	protected Label Label38;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected TextBox txtCoordenador;

	protected Label lblNomeCoordenador;

	protected HiddenField hddCoordenadorServidorUID;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected RequiredFieldValidator RequiredFieldValidator102;

	protected DropDownList ddlTitulacaoCoordenador;

	protected RequiredFieldValidator RequiredFieldValidator103;

	protected DropDownList ddlRegimeTabalhoCoordenador;

	protected TextBox txtTelefoneCoordenador;

	protected MaskedEditExtender MaskedEditExtender2;

	protected TextBox txtTelefoneCelularCoordenador;

	protected MaskedEditExtender MaskedEditExtender3;

	protected RequiredFieldValidator RequiredFieldValidator104;

	protected TextBox txtEmailCoordenador;

	protected Label Label10;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtViceCoordenador;

	protected Label lblNomeViceCoordenador;

	protected HiddenField hddViceCoordenadorServidorUID;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected Label Label6;

	protected RequiredFieldValidator RequiredFieldValidator105;

	protected DropDownList ddlTitulacaoViceCoordenador;

	protected RequiredFieldValidator RequiredFieldValidator106;

	protected DropDownList ddlRegimeTabalhoViceCoordenador;

	protected TextBox txtTelefoneViceCoordenador;

	protected MaskedEditExtender MaskedEditExtender5;

	protected TextBox txtTelefoneCelularViceCoordenador;

	protected MaskedEditExtender MaskedEditExtender4;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtEmailViceCoordenador;

	protected Label lbSecretario;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtSecretario;

	protected Label lbNomeSecretario;

	protected HiddenField hddSecretarioUID;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtEmailSecretario;

	protected TextBox txtCelularSecretario;

	protected MaskedEditExtender MaskedEditExtender6;

	protected Label Label15;

	protected RequiredFieldValidator RequiredFieldValidator99;

	protected TextBox txtDataInicioRealizacao;

	protected CalendarExtender txtDataInicioRealizacao_CalendarExtender;

	protected MaskedEditExtender txtDataInicioRealizacao_MaskedEditExtender;

	protected MaskedEditValidator MEVData2;

	protected Label Label16;

	protected RequiredFieldValidator RequiredFieldValidator100;

	protected TextBox txtDataFimRealizacao;

	protected CalendarExtender CalendarExtender1;

	protected MaskedEditExtender MaskedEditExtender1;

	protected MaskedEditValidator MaskedEditValidator1;

	protected Label Label46;

	protected FileUpload FileUploadMinutaEdital;

	protected Button btnDownloadMinutaEdital;

	protected Label Label5;

	protected RequiredFieldValidator RequiredFieldValidator101;

	protected TextBox txtDataDocumentoAprovacaoCurso;

	protected CalendarExtender txtDataDocumentoAprovacaoCurso_CalendarExtender;

	protected MaskedEditExtender txtDataDocumentoAprovacaoCurso_MaskedEditExtender;

	protected MaskedEditValidator MEVData3;

	protected Label Label2;

	protected FileUpload FileUploaDocumentoAprovacaoCurso;

	protected Button btnDownloadDocumentoAprovacaoCurso;

	protected Label Label40;

	protected RequiredFieldValidator RequiredFieldValidator32;

	protected TextBox txtCargaHorariaTotal;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected Panel pnlTurnoOferta;

	protected RequiredFieldValidator RequiredFieldValidator108;

	protected DropDownList ddlTurnoOferta;

	protected RequiredFieldValidator RequiredFieldValidator97;

	protected TextBox txtQtdVagas;

	protected RegularExpressionValidator RegularExpressionValidator7;

	protected Label Label49;

	protected TextBox txtNotaMinimaAprovacao;

	protected Label Label50;

	protected TextBox txtFrequenciaMinimaAprovacao;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtJustificativaCurso;

	protected Label Label4;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtObjetivosCurso;

	protected Label Label58;

	protected RequiredFieldValidator RequiredFieldValidator50;

	protected TextBox txtPublicoAlvo;

	protected Label Label41;

	protected RequiredFieldValidator RequiredFieldValidator33;

	protected TextBox txtDescricaoInstalacoes;

	protected Label Label42;

	protected RequiredFieldValidator RequiredFieldValidator34;

	protected TextBox txtDescricaoEquipamentos;

	protected Label lblDescricaoMaterialBibliografico;

	protected RequiredFieldValidator RequiredFieldValidator35;

	protected TextBox txtDescricaoMaterialBibliografico;

	protected Label Label47;

	protected RequiredFieldValidator RequiredFieldValidator39;

	protected TextBox txtFormasAvaliacao;

	protected Panel pnlAVA;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtAmbienteVirtualAprendizagem;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuCursos_EditarCurso"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (((Page)this).IsPostBack)
		{
			return;
		}
		new AutenticacaoBO();
		hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
		ProjetoCurso projetoCurso = new ProjetoCurso();
		ProjetoBO projetoBO = new ProjetoBO();
		GrandeAreaBO grandeAreaBO = new GrandeAreaBO();
		AreaBO areaBO = new AreaBO();
		TipoModalidadeBO tipoModalidadeBO = new TipoModalidadeBO();
		CursoDAL cursoDAL = new CursoDAL();
		CoordenadorDAL coordenadorDAL = new CoordenadorDAL();
		UnidadeDAL unidadeDAL = new UnidadeDAL();
		PessoaIDBUFMTDAL pessoaIDBUFMTDAL = new PessoaIDBUFMTDAL();
		if (string.IsNullOrEmpty(hddProjetoCursoUID.Value))
		{
			return;
		}
		projetoCurso = projetoBO.GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
		hddViceCoordenadorServidorUID.Value = projetoCurso.viceCoordenadorServidorUID.GetValueOrDefault().ToString();
		txtCodigoEMEC.Text = projetoCurso.codigoEMEC;
		txtNomeCurso.Text = projetoCurso.nomeCurso;
		((WebControl)txtNomeCurso).Enabled = true;
		txtCargaHorariaTotal.Text = projetoCurso.cargaHorariaTotal.GetValueOrDefault().ToString();
		txtCargaHorariaTotal.Text = projetoCurso.cargaHorariaTotal.GetValueOrDefault().ToString();
		txtPublicoAlvo.Text = projetoCurso.publicoAlvo;
		txtDescricaoInstalacoes.Text = projetoCurso.descricaoInstalacoes;
		txtDescricaoMaterialBibliografico.Text = projetoCurso.descricaoMaterialBibliografico;
		txtDescricaoEquipamentos.Text = projetoCurso.descricaoEquipamentos;
		txtJustificativaCurso.Text = projetoCurso.justificativaCurso;
		txtObjetivosCurso.Text = projetoCurso.objetivosCurso;
		txtFormasAvaliacao.Text = projetoCurso.formasAvaliacao;
		txtCEPendereco.Text = projetoCurso.CEP;
		txtEndereco.Text = projetoCurso.bairroEndereco;
		txtNumeroEndereco.Text = (projetoCurso.numeroEndereco.HasValue ? projetoCurso.numeroEndereco.ToString() : string.Empty);
		txtComplementoEndereco.Text = projetoCurso.complementoBairro;
		txtBairroEndereco.Text = projetoCurso.bairroEndereco;
		txtInfoReferenciaEndereco.Text = projetoCurso.informacoesReferenciaEndereco;
		txtQtdVagas.Text = (projetoCurso.quantidadeVagas.HasValue ? projetoCurso.quantidadeVagas.ToString() : string.Empty);
		txtDataDocumentoAprovacaoCurso.Text = (projetoCurso.dataDocumentoRealizacaoCurso.HasValue ? $"{projetoCurso.dataDocumentoRealizacaoCurso:dd/MM/yyyy}" : string.Empty);
		txtTelefoneCoordenador.Text = projetoCurso.telefoneResidencialCoordenador;
		txtTelefoneCelularCoordenador.Text = projetoCurso.telefoneCelularCoordenador;
		txtEmailCoordenador.Text = projetoCurso.emailCoordenador;
		txtTelefoneViceCoordenador.Text = projetoCurso.telefoneResidencialViceCoordenador;
		txtTelefoneCelularViceCoordenador.Text = projetoCurso.telefoneCelularViceCoordenador;
		txtEmailViceCoordenador.Text = projetoCurso.emailViceCoordenador;
		txtEmailSecretario.Text = projetoCurso.emailSecretario;
		txtCelularSecretario.Text = projetoCurso.celularSecretario;
		txtCargaHorariaDiario.Text = projetoCurso.cargaHorariaDiario.GetValueOrDefault().ToString();
		txtCargaHorariaModular.Text = projetoCurso.cargaHorariaModular.GetValueOrDefault().ToString();
		txtNomeCursoModular.Text = projetoCurso.nomeCursoModular;
		txtTelefone.Text = projetoCurso.telefone;
		txtFax.Text = projetoCurso.fax;
		txtEmail.Text = projetoCurso.email;
		txtSiteCurso.Text = projetoCurso.siteCurso;
		txtAmbienteVirtualAprendizagem.Text = projetoCurso.descricaoAva;
		DetalheAreaConhecimento detalhesAreaConhecimento = areaBO.getDetalhesAreaConhecimento(projetoCurso.projetoCursoUID);
		((BaseDataBoundControl)ddlModalidade).DataSource = tipoModalidadeBO.GetRegistros();
		((ListControl)ddlModalidade).DataTextField = "nome";
		((ListControl)ddlModalidade).DataValueField = "tipoModalidadeUID";
		((Control)ddlModalidade).DataBind();
		((ListControl)ddlModalidade).SelectedValue = projetoCurso.tipoModalidadeUID.ToString();
		((WebControl)ddlModalidade).Enabled = !projetoCurso.ProjetoTurma.Any();
		ConfiguracaoInterfaceModalidade(((ListControl)ddlModalidade).SelectedIndex);
		((BaseDataBoundControl)ddlGrandeArea).DataSource = grandeAreaBO.GetRegistros();
		((ListControl)ddlGrandeArea).DataTextField = "nome";
		((ListControl)ddlGrandeArea).DataValueField = "CNPqGrandeAreaConhecimentoUID";
		((Control)ddlGrandeArea).DataBind();
		((ListControl)ddlGrandeArea).SelectedValue = detalhesAreaConhecimento.CNPqGrandeAreaConhecimentoUID.ToString();
		((BaseDataBoundControl)ddlArea).DataSource = areaBO.GetRegistros(detalhesAreaConhecimento.CNPqGrandeAreaConhecimentoUID);
		((ListControl)ddlArea).DataTextField = "nome";
		((ListControl)ddlArea).DataValueField = "CNPqAreaConhecimentoUID";
		((Control)ddlArea).DataBind();
		((ListControl)ddlArea).SelectedValue = detalhesAreaConhecimento.CNPqAreaConhecimentoUID.ToString();
		((BaseDataBoundControl)ddlSubArea).DataSource = areaBO.GetRegistrosSubArea(detalhesAreaConhecimento.CNPqAreaConhecimentoUID);
		((ListControl)ddlSubArea).DataTextField = "nome";
		((ListControl)ddlSubArea).DataValueField = "CNPqSubAreaConhecimentoUID";
		((Control)ddlSubArea).DataBind();
		((ListControl)ddlSubArea).SelectedValue = projetoCurso.CNPqSubAreaConhecimentoUID.ToString();
		((BaseDataBoundControl)ddlTurnoOferta).DataSource = EnumService.EnumList(typeof(EnumTurnoOferta));
		((ListControl)ddlTurnoOferta).DataValueField = "key";
		((ListControl)ddlTurnoOferta).DataTextField = "value";
		((Control)ddlTurnoOferta).DataBind();
		((ListControl)ddlTurnoOferta).SelectedValue = projetoCurso.turnoOfertaUID.GetValueOrDefault().ToString();
		((BaseDataBoundControl)ddlTitulacaoCoordenador).DataSource = EnumService.EnumList(typeof(EnumTitulacao));
		((ListControl)ddlTitulacaoCoordenador).DataValueField = "key";
		((ListControl)ddlTitulacaoCoordenador).DataTextField = "value";
		((Control)ddlTitulacaoCoordenador).DataBind();
		((ListControl)ddlTitulacaoCoordenador).SelectedValue = projetoCurso.titulacaoCoordenadorUID.GetValueOrDefault().ToString();
		((BaseDataBoundControl)ddlRegimeTabalhoCoordenador).DataSource = EnumService.EnumList(typeof(EnumRegimeTrabalho));
		((ListControl)ddlRegimeTabalhoCoordenador).DataValueField = "key";
		((ListControl)ddlRegimeTabalhoCoordenador).DataTextField = "value";
		((Control)ddlRegimeTabalhoCoordenador).DataBind();
		((ListControl)ddlRegimeTabalhoCoordenador).SelectedValue = projetoCurso.regimeTrabalhoCoordenadorUID.GetValueOrDefault().ToString();
		((BaseDataBoundControl)ddlTitulacaoViceCoordenador).DataSource = EnumService.EnumList(typeof(EnumTitulacao));
		((ListControl)ddlTitulacaoViceCoordenador).DataValueField = "key";
		((ListControl)ddlTitulacaoViceCoordenador).DataTextField = "value";
		((Control)ddlTitulacaoViceCoordenador).DataBind();
		((ListControl)ddlTitulacaoViceCoordenador).SelectedValue = projetoCurso.titulacaoViceCoordenadorUID.GetValueOrDefault().ToString();
		((BaseDataBoundControl)ddlRegimeTabalhoViceCoordenador).DataSource = EnumService.EnumList(typeof(EnumRegimeTrabalho));
		((ListControl)ddlRegimeTabalhoViceCoordenador).DataValueField = "key";
		((ListControl)ddlRegimeTabalhoViceCoordenador).DataTextField = "value";
		((Control)ddlRegimeTabalhoViceCoordenador).DataBind();
		((ListControl)ddlRegimeTabalhoViceCoordenador).SelectedValue = projetoCurso.regimeTrabalhoViceCoordenadorUID.GetValueOrDefault().ToString();
		((BaseDataBoundControl)rblPeriodicidade).DataSource = EnumService.EnumList(typeof(EnumPeriodicidade));
		((ListControl)rblPeriodicidade).DataValueField = "key";
		((ListControl)rblPeriodicidade).DataTextField = "value";
		((Control)rblPeriodicidade).DataBind();
		((ListControl)rblPeriodicidade).SelectedValue = projetoCurso.periodicidadeUID.ToString();
		((Control)btnDownloadMinutaEdital).Visible = false;
		if (projetoCurso.minutaEdital != null)
		{
			((Control)btnDownloadMinutaEdital).Visible = true;
		}
		((Control)btnDownloadDocumentoAprovacaoCurso).Visible = false;
		if (projetoCurso.documentoRealizacaoCurso != null)
		{
			((Control)btnDownloadDocumentoAprovacaoCurso).Visible = true;
		}
		if (projetoCurso.periodicidadeUID == 1)
		{
			((Control)pnlPeriodicidadeDiario).Visible = true;
			((Control)pnlPeriodicidadeModular).Visible = false;
		}
		else
		{
			((Control)pnlPeriodicidadeDiario).Visible = false;
			((Control)pnlPeriodicidadeModular).Visible = true;
		}
		ViewCoordenadorUFMT coordenadorPorId = coordenadorDAL.GetCoordenadorPorId(long.Parse(projetoCurso.coordenadorServidorUID.ToString()));
		if (coordenadorPorId != null)
		{
			txtCoordenador.Text = coordenadorPorId.siape + " | " + coordenadorPorId.nome;
			hddCoordenadorServidorUID.Value = coordenadorPorId.servidorUID.ToString();
			((WebControl)txtCoordenador).Enabled = true;
		}
		ViewCoordenadorUFMT coordenadorPorId2 = coordenadorDAL.GetCoordenadorPorId(long.Parse(projetoCurso.viceCoordenadorServidorUID.GetValueOrDefault().ToString()));
		if (coordenadorPorId2 != null)
		{
			txtViceCoordenador.Text = coordenadorPorId2.siape + " | " + coordenadorPorId2.nome;
			hddViceCoordenadorServidorUID.Value = coordenadorPorId2.servidorUID.ToString();
			((WebControl)txtViceCoordenador).Enabled = true;
		}
		PessoaIDBUFMT pessoaIDBUFMT = pessoaIDBUFMTDAL.BuscarPessoaPorUID(projetoCurso.secretarioUID.GetValueOrDefault());
		if (pessoaIDBUFMT != null)
		{
			txtSecretario.Text = pessoaIDBUFMT.cpf + " | " + pessoaIDBUFMT.nome;
			((WebControl)txtSecretario).Enabled = true;
		}
		ViewUnidade unidadePorId = unidadeDAL.GetUnidadePorId(projetoCurso.proponenteUnidadeUID);
		if (unidadePorId != null)
		{
			txtUnidadeProponente.Text = unidadePorId.unidadeUID + " | " + unidadePorId.nomeConcatenado;
			hddUnidadeUID.Value = unidadePorId.unidadeUID.ToString();
		}
		if (projetoCurso.realizacaoDataInicio.HasValue)
		{
			txtDataInicioRealizacao.Text = $"{projetoCurso.realizacaoDataInicio:dd/MM/yyyy}";
		}
		if (projetoCurso.realizacaoDataTermino.HasValue)
		{
			txtDataFimRealizacao.Text = $"{projetoCurso.realizacaoDataTermino:dd/MM/yyyy}";
		}
		if (projetoCurso.municipioEnderecoUID.GetValueOrDefault() > 0)
		{
			ViewMunicipio viewMunicipio = (from c in cursoDAL.GetMunicipio()
				where c.MunicipioUID == projetoCurso.municipioEnderecoUID
				select c).FirstOrDefault();
			txtCidade.Text = viewMunicipio.MunicipioUID + " | " + viewMunicipio.Nome;
		}
		else
		{
			txtCidade.Text = string.Empty;
		}
	}

	private byte[] ConvertStreamToByeBuffer(FileStream imgStream)
	{
		MemoryStream memoryStream = new MemoryStream();
		int num;
		while ((num = imgStream.ReadByte()) != -1)
		{
			memoryStream.WriteByte((byte)num);
		}
		return memoryStream.ToArray();
	}

	private byte[] ReadFile(HttpPostedFile file)
	{
		byte[] array = new byte[file.ContentLength];
		file.InputStream.Read(array, 0, file.ContentLength);
		return array;
	}

	private Stream ConverterParaStream(byte[] dados)
	{
		return new MemoryStream(dados);
	}

	protected void btnAlterar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			ProjetoBO projetoBO = new ProjetoBO();
			new UnidadeDAL();
			CoordenadorDAL coordenadorDAL = new CoordenadorDAL();
			PessoaIDBUFMTDAL pessoaIDBUFMTDAL = new PessoaIDBUFMTDAL();
			ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
			string[] array = txtCidade.Text.Trim().Split(new char[1] { '|' });
			string[] array2 = txtCoordenador.Text.Trim().Split(new char[1] { '|' });
			string[] array3 = txtViceCoordenador.Text.Trim().Split(new char[1] { '|' });
			string[] array4 = txtSecretario.Text.Trim().Split(new char[1] { '|' });
			string[] array5 = txtUnidadeProponente.Text.Trim().Split(new char[1] { '|' });
			if (!long.TryParse(array5[0], out var _))
			{
				txtUnidadeProponente.Text = string.Empty;
				((Control)txtUnidadeProponente).Focus();
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Unidade não foi selecionada corretamente. Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!long.TryParse(array2[0], out var _))
			{
				txtCoordenador.Text = string.Empty;
				((Control)txtCoordenador).Focus();
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Coordenador não foi adicionado corretamente. Tente novamente efetuando nova cosulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!long.TryParse(array3[0], out var _))
			{
				resultadoOperacao.TextMessage = "Vice-Coordenador não foi adicionado corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtViceCoordenador.Text = string.Empty;
				((Control)txtViceCoordenador).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (string.IsNullOrWhiteSpace(array4[0].Trim()))
			{
				resultadoOperacao.TextMessage = "Secretário não foi adicionado corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtSecretario.Text = string.Empty;
				((Control)txtSecretario).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!long.TryParse(array[0], out var _))
			{
				txtCidade.Text = string.Empty;
				((Control)txtCidade).Focus();
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Municipio não foi selecionado corretamente. Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!FileUploadMinutaEdital.HasFile)
			{
				if (registroPorId.minutaEdital == null)
				{
					((Control)FileUploadMinutaEdital).Focus();
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "O arquivo da minuta do edital é obrigatório. Por favor, anexe o arquivo para continuar.";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					PopularMensagemRegraNegocio(resultadoOperacao);
					return;
				}
			}
			else
			{
				HttpPostedFile postedFile = FileUploadMinutaEdital.PostedFile;
				if (postedFile.ContentType != "application/pdf")
				{
					((Control)FileUploadMinutaEdital).Focus();
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "O arquivo da minuta do edital deve ser obrigatoriamente do tipo .pdf";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					PopularMensagemRegraNegocio(resultadoOperacao);
					return;
				}
				byte[] minutaEdital = ReadFile(postedFile);
				registroPorId.minutaEdital = minutaEdital;
			}
			if (!FileUploaDocumentoAprovacaoCurso.HasFile)
			{
				if (registroPorId.documentoRealizacaoCurso == null)
				{
					((Control)FileUploaDocumentoAprovacaoCurso).Focus();
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "O arquivo de aprovação do curso é obrigatório. Por favor, anexe o arquivo para continuar.";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					PopularMensagemRegraNegocio(resultadoOperacao);
					return;
				}
			}
			else
			{
				HttpPostedFile postedFile2 = FileUploaDocumentoAprovacaoCurso.PostedFile;
				if (postedFile2.ContentType != "application/pdf")
				{
					((Control)FileUploaDocumentoAprovacaoCurso).Focus();
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "O arquivo da minuta do edital deve ser obrigatoriamente do tipo .pdf";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					PopularMensagemRegraNegocio(resultadoOperacao);
					return;
				}
				byte[] documentoRealizacaoCurso = ReadFile(postedFile2);
				registroPorId.documentoRealizacaoCurso = documentoRealizacaoCurso;
			}
			if (int.Parse(txtCargaHorariaTotal.Text) < 360)
			{
				((Control)txtCargaHorariaTotal).Focus();
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Carga horária total não pode ser inferior a 360 horas.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			ViewCoordenadorUFMT coordenadorPorSiape = coordenadorDAL.GetCoordenadorPorSiape(array2[0]);
			ViewCoordenadorUFMT coordenadorPorSiape2 = coordenadorDAL.GetCoordenadorPorSiape(array3[0]);
			PessoaIDBUFMT pessoaIDBUFMT = pessoaIDBUFMTDAL.BuscarPessoaPorCPF(array4[0]);
			registroPorId.projetoCursoUID = long.Parse(hddProjetoCursoUID.Value);
			registroPorId.tipoModalidadeUID = byte.Parse(((ListControl)ddlModalidade).SelectedValue);
			registroPorId.codigoEMEC = txtCodigoEMEC.Text;
			registroPorId.nomeCurso = txtNomeCurso.Text;
			registroPorId.CNPqAreaConhecimentoUID = long.Parse(((ListControl)ddlArea).SelectedValue);
			registroPorId.CNPqSubAreaConhecimentoUID = long.Parse(((ListControl)ddlSubArea).SelectedValue);
			registroPorId.proponenteUnidadeUID = long.Parse(array5[0]);
			registroPorId.telefone = txtTelefone.Text;
			registroPorId.fax = txtFax.Text;
			registroPorId.email = txtEmail.Text;
			registroPorId.siteCurso = txtSiteCurso.Text;
			registroPorId.coordenadorServidorUID = long.Parse(coordenadorPorSiape.servidorUID.ToString());
			registroPorId.titulacaoCoordenadorUID = int.Parse(((ListControl)ddlTitulacaoCoordenador).SelectedValue);
			registroPorId.regimeTrabalhoCoordenadorUID = int.Parse(((ListControl)ddlRegimeTabalhoCoordenador).SelectedValue);
			registroPorId.telefoneResidencialCoordenador = txtTelefoneCoordenador.Text;
			registroPorId.telefoneCelularCoordenador = txtTelefoneCelularCoordenador.Text;
			registroPorId.emailCoordenador = txtEmailCoordenador.Text;
			registroPorId.viceCoordenadorServidorUID = long.Parse(coordenadorPorSiape2.servidorUID.ToString());
			registroPorId.titulacaoViceCoordenadorUID = int.Parse(((ListControl)ddlTitulacaoViceCoordenador).SelectedValue);
			registroPorId.regimeTrabalhoViceCoordenadorUID = int.Parse(((ListControl)ddlRegimeTabalhoViceCoordenador).SelectedValue);
			registroPorId.telefoneResidencialViceCoordenador = txtTelefoneViceCoordenador.Text;
			registroPorId.telefoneCelularViceCoordenador = txtTelefoneCelularViceCoordenador.Text;
			registroPorId.emailViceCoordenador = txtEmailViceCoordenador.Text;
			registroPorId.secretarioUID = pessoaIDBUFMT.pessoaUID;
			registroPorId.emailSecretario = txtEmailSecretario.Text;
			registroPorId.celularSecretario = txtCelularSecretario.Text;
			string s = $"{txtDataInicioRealizacao.Text:dd/MM/yyyy}";
			string s2 = $"{txtDataFimRealizacao.Text:dd/MM/yyyy}";
			registroPorId.realizacaoDataInicio = DateTime.Parse(s);
			registroPorId.realizacaoDataTermino = DateTime.Parse(s2);
			registroPorId.cargaHorariaTotal = short.Parse(txtCargaHorariaTotal.Text);
			registroPorId.turnoOfertaUID = int.Parse(((ListControl)ddlTurnoOferta).SelectedValue);
			if (((ListControl)ddlModalidade).Items[0].Selected)
			{
				registroPorId.periodicidadeUID = int.Parse(((ListControl)rblPeriodicidade).SelectedValue);
				if (((ListControl)rblPeriodicidade).Items[0].Selected)
				{
					registroPorId.cargaHorariaDiario = int.Parse(txtCargaHorariaDiario.Text);
					registroPorId.cargaHorariaModular = null;
					registroPorId.nomeCursoModular = null;
				}
				else
				{
					registroPorId.cargaHorariaModular = int.Parse(txtCargaHorariaModular.Text);
					registroPorId.nomeCursoModular = txtNomeCursoModular.Text;
					registroPorId.cargaHorariaDiario = null;
				}
			}
			registroPorId.publicoAlvo = txtPublicoAlvo.Text;
			registroPorId.descricaoInstalacoes = txtDescricaoInstalacoes.Text;
			registroPorId.descricaoEquipamentos = txtDescricaoEquipamentos.Text;
			registroPorId.descricaoMaterialBibliografico = txtDescricaoMaterialBibliografico.Text;
			registroPorId.justificativaCurso = txtJustificativaCurso.Text;
			registroPorId.objetivosCurso = txtObjetivosCurso.Text;
			registroPorId.formasAvaliacao = txtFormasAvaliacao.Text;
			registroPorId.financiamentoCurso = null;
			registroPorId.termoConvenio = null;
			registroPorId.planoAplicacaoSuperavit = null;
			registroPorId.tipoFinanciamentoUID = (byte)4;
			registroPorId.tipoGestaoFinanceiraUID = (byte)1;
			registroPorId.quantidadeVagas = int.Parse(txtQtdVagas.Text);
			registroPorId.dataDocumentoRealizacaoCurso = DateTime.Parse($"{txtDataDocumentoAprovacaoCurso.Text:dd/MM/yyyy}");
			registroPorId.CEP = txtCEPendereco.Text;
			registroPorId.municipioEnderecoUID = int.Parse(array[0]);
			registroPorId.identificacaoEndereco = txtEndereco.Text;
			registroPorId.numeroEndereco = int.Parse(txtNumeroEndereco.Text);
			registroPorId.complementoBairro = txtComplementoEndereco.Text;
			registroPorId.bairroEndereco = txtBairroEndereco.Text;
			registroPorId.informacoesReferenciaEndereco = txtInfoReferenciaEndereco.Text;
			registroPorId.descricaoAva = txtAmbienteVirtualAprendizagem.Text;
			resultadoOperacao = projetoBO.AlterarProjetoCurso(registroPorId);
			if (resultadoOperacao.Erro)
			{
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListar.aspx");
	}

	protected void ddlGrandeArea_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		((ListControl)ddlArea).Items.Clear();
		((ListControl)ddlSubArea).Items.Clear();
		if (!string.IsNullOrEmpty(((ListControl)ddlGrandeArea).SelectedValue))
		{
			List<CNPqAreaConhecimento> registros = new AreaBO().GetRegistros(long.Parse(((ListControl)ddlGrandeArea).SelectedValue));
			((ListControl)ddlArea).Items.Insert(0, new ListItem(string.Empty, string.Empty));
			((ListControl)ddlArea).SelectedIndex = 0;
			for (int i = 0; i < registros.Count; i++)
			{
				((ListControl)ddlArea).Items.Insert(i + 1, new ListItem(registros[i].nome, registros[i].CNPqAreaConhecimentoUID.ToString()));
			}
			((ListControl)ddlArea).DataTextField = "nome";
			((ListControl)ddlArea).DataValueField = "CNPqAreaConhecimentoUID";
			((Control)ddlArea).DataBind();
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx");
	}

	protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
	{
		((ListControl)ddlSubArea).Items.Clear();
		if (!string.IsNullOrEmpty(((ListControl)ddlArea).SelectedValue))
		{
			AreaBO areaBO = new AreaBO();
			((BaseDataBoundControl)ddlSubArea).DataSource = areaBO.GetRegistrosSubArea(long.Parse(((ListControl)ddlArea).SelectedValue));
			((ListControl)ddlSubArea).DataTextField = "nome";
			((ListControl)ddlSubArea).DataValueField = "CNPqSubAreaConhecimentoUID";
			((Control)ddlSubArea).DataBind();
		}
	}

	private void ConfiguracaoInterfaceModalidade(int index)
	{
		if (((ListControl)ddlModalidade).Items[index].Value == "1")
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Bibliográfico:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "75%";
			((Control)pnlPeriodicidade).Visible = true;
			((Control)pnlAVA).Visible = false;
			((Control)pnlTurnoOferta).Visible = true;
		}
		else
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Didático Textual e Multimídia:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "100%";
			((Control)pnlPeriodicidade).Visible = false;
			((Control)pnlAVA).Visible = true;
			((Control)pnlTurnoOferta).Visible = false;
		}
	}

	protected void ddlModalidade_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)ddlModalidade).Items[0].Selected)
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Bibliográfico:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "75%";
			((Control)pnlPeriodicidade).Visible = true;
			((Control)pnlAVA).Visible = false;
			((Control)pnlTurnoOferta).Visible = true;
		}
		else if (((ListControl)ddlModalidade).Items[1].Selected)
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Didático Textual e Multimídia:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "100%";
			((Control)pnlPeriodicidade).Visible = false;
			((Control)pnlAVA).Visible = true;
			((Control)pnlTurnoOferta).Visible = false;
		}
	}

	protected void rblPeriodicidade_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)rblPeriodicidade).Items[0].Selected)
		{
			((Control)pnlPeriodicidadeDiario).Visible = true;
			((Control)pnlPeriodicidadeModular).Visible = false;
			txtCargaHorariaModular.Text = "";
			txtNomeCursoModular.Text = "";
		}
		else
		{
			((Control)pnlPeriodicidadeDiario).Visible = false;
			((Control)pnlPeriodicidadeModular).Visible = true;
			txtCargaHorariaDiario.Text = "";
		}
	}

	protected void DownloadMinutaEdital_Click(object sender, EventArgs e)
	{
		((Page)this).Header.Title = "Download de Minuta de Edital";
		ProjetoCurso registroPorId = new ProjetoBO().GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
		if (registroPorId != null)
		{
			byte[] minutaEdital = registroPorId.minutaEdital;
			((Page)this).Response.Buffer = true;
			((Page)this).Response.ContentType = "application/pdf";
			((Page)this).Response.BinaryWrite(minutaEdital);
			((Page)this).Response.AddHeader("Content-Type", "application/pdf");
			((Page)this).Response.AddHeader("Content-Transfer-Encoding", "Binary");
			((Page)this).Response.AddHeader("Content-disposition", "attachment; filename=\"Minuta de Edital.pdf\"");
			((Page)this).Response.Flush();
			((Page)this).Response.End();
		}
	}

	protected void DownloadDocumentoAprovacao_Click(object sender, EventArgs e)
	{
		ProjetoCurso registroPorId = new ProjetoBO().GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
		((Page)this).Header.Title = "Download de Documento de Aprovação de Curso";
		if (registroPorId != null)
		{
			byte[] documentoRealizacaoCurso = registroPorId.documentoRealizacaoCurso;
			((Page)this).Response.Buffer = true;
			((Page)this).Response.ContentType = "application/pdf";
			((Page)this).Response.BinaryWrite(documentoRealizacaoCurso);
			((Page)this).Response.AddHeader("Content-Type", "application/pdf");
			((Page)this).Response.AddHeader("Content-Transfer-Encoding", "Binary");
			((Page)this).Response.AddHeader("Content-disposition", "attachment; filename=\"Documento Aprovação.pdf\"");
			((Page)this).Response.Flush();
			((Page)this).Response.End();
		}
	}
}
