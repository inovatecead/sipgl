using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.discente;

public class FrmCadastroPessoa : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected Button btnSalvar;

	protected Button btnCancelar;

	protected HiddenField hddCodigoRegistro;

	protected HiddenField hddCursoUID;

	protected HiddenField hddPreMatriculaInscricaoUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtNome;

	protected Label Label2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected DropDownList ddlSexo;

	protected Label Label17;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtDataNascimento;

	protected MaskedEditExtender txtDataNascimento_MaskedEditExtender;

	protected MaskedEditValidator MaskedEditValidator1;

	protected Label Label6;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected TextBox txtNomeMae;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtNomePai;

	protected Label Label13;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtCpf;

	protected MaskedEditExtender MaskedEditExtenderCpf;

	protected Label Label18;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected TextBox txtRgNumero;

	protected Label Label19;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected TextBox txtOrgaoExpedidor;

	protected Label Label35;

	protected RequiredFieldValidator RequiredFieldValidator37;

	protected DropDownList ddlUFOrgaoExpedidor;

	protected Label Label20;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected TextBox txtDataExpedicao;

	protected MaskedEditExtender txtDataExpedicao_MaskedEditExtender;

	protected MaskedEditValidator MEVData1;

	protected Label Label21;

	protected RequiredFieldValidator RequiredFieldValidator13;

	protected DropDownList ddlEstadoCivil;

	protected Label Label14;

	protected RequiredFieldValidator RequiredFieldValidator24;

	protected TextBox txtTelefoneFixo;

	protected MaskedEditExtender MaskedEditExtenderTelefone;

	protected Label Label15;

	protected TextBox txtTelefoneMovel;

	protected MaskedEditExtender MaskedEditExtender1;

	protected Label Label16;

	protected TextBox txtTelefoneComercial;

	protected MaskedEditExtender MaskedEditExtender2;

	protected Label Label4;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtEmail;

	protected Label Label25;

	protected DropDownList ddlNacionalidade;

	protected Label Label26;

	protected DropDownList ddlPaisNascimento;

	protected Label Label27;

	protected RequiredFieldValidator RequiredFieldValidator17;

	protected DropDownList ddlNaturalidadeUF;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtMunicipio;

	protected Label Label7;

	protected RequiredFieldValidator RequiredFieldValidator19;

	protected TextBox txtEndereco;

	protected Label Label22;

	protected RequiredFieldValidator RequiredFieldValidator20;

	protected TextBox txtEnderecoNumero;

	protected Label Label9;

	protected TextBox txtEnderecoComplemento;

	protected Label Label10;

	protected RequiredFieldValidator RequiredFieldValidator22;

	protected TextBox txtBairro;

	protected Label Label11;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected TextBox txtCep;

	protected MaskedEditExtender MaskedEditExtenderCep;

	protected Label Label34;

	protected RequiredFieldValidator RequiredFieldValidator32;

	protected DropDownList ddlEnderecoUF;

	protected Label Label12;

	protected RequiredFieldValidator RequiredFieldValidator33;

	protected TextBox txtEnderecoMunicipio;

	protected Label Label31;

	protected RadioButtonList rblGraduacaoExterior;

	protected Panel pnlNumeroRegistroApostilaRevalidacao;

	protected Label Label32;

	protected RequiredFieldValidator RequiredFieldValidator36;

	protected TextBox txtNumeroRegistroApostilaRevalidacao;

	protected Panel pnlInstituicaoSuperior;

	protected Label Label29;

	protected RequiredFieldValidator RequiredFieldValidator35;

	protected DropDownList ddlUFGraduacao;

	protected Label lbTipoGraduacao;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected DropDownList ddlTipoGraducao;

	protected Label Label37;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtCursoGraduacao;

	protected Label Label38;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtNumeroRegistroDiploma;

	protected Label Label23;

	protected RequiredFieldValidator RequiredFieldValidator34;

	protected TextBox txtInstituicaoEnsinoSuperior;

	protected Label Label30;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected TextBox txtDataColacaoGrau;

	protected MaskedEditExtender txtDataColacaoGrau_MaskedEditExtender;

	protected MaskedEditValidator MaskedEditValidator2;

	protected Label Label5;

	protected RequiredFieldValidator RequiredFieldValidator30;

	protected DropDownList ddlTipoFaixaRendaFamiliar;

	protected Label Label24;

	protected RequiredFieldValidator RequiredFieldValidator31;

	protected DropDownList ddlTipoCorRaca;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			_ = ((Page)this).Request.QueryString["operacao"];
			string text = ((Page)this).Request.QueryString["nomeCurso"];
			string text2 = ((Page)this).Request.QueryString["preMatriculaPessoaUID"];
			string text3 = ((Page)this).Request.QueryString["preMatriculaInscricaoUID"];
			string text4 = ((Page)this).Request.QueryString["cursoUID"];
			string text5 = ((Page)this).Request.QueryString["dt"];
			lnkTitulo.Text = "[ Voltar para Inscritos ] ";
			lnkTitulo.NavigateUrl = "~/webapp/discente/FrmListar.aspx?&obj=ProjetoTurma&projetoCursoUID=" + text4 + "&nomeCurso=" + text;
			lblTitulo.Text = "Detalhes do Candidato - " + text;
			DiscenteDAL discenteDAL = new DiscenteDAL();
			hddCodigoRegistro.Value = text2;
			hddPreMatriculaInscricaoUID.Value = text3;
			PreMatriculaInscricao detalheMatricula = discenteDAL.GetDetalheMatricula(long.Parse(text3));
			if (detalheMatricula.tipoSituacaoInscricaoUID == 4 || detalheMatricula.tipoSituacaoInscricaoUID == 5)
			{
				((Control)btnCancelar).Visible = false;
			}
			else
			{
				((Control)btnCancelar).Visible = true;
			}
			hddCursoUID.Value = text4;
			this.ViewState["descricao"] = text;
			this.ViewState["dataHoraUltimaAtualizacao"] = text5;
			this.ViewState["servidorUID"] = ((Page)this).Session["servidorUID"];
			ViewPreMatriculaPessoa registroPorId = discenteDAL.GetRegistroPorId(long.Parse(text2));
			txtNome.Text = registroPorId.nomeCandidato;
			txtDataNascimento.Text = $"{registroPorId.nascimentoData:dd/MM/yyyy}";
			txtNomeMae.Text = registroPorId.nomeMae;
			txtNomePai.Text = registroPorId.nomePai;
			txtCpf.Text = registroPorId.cpf;
			txtDataExpedicao.Text = $"{registroPorId.rgDataExpedicao:dd/MM/yyyy}";
			txtTelefoneFixo.Text = registroPorId.telefoneFixo;
			txtTelefoneMovel.Text = registroPorId.telefoneMovel;
			txtTelefoneComercial.Text = registroPorId.telefoneComercial;
			txtMunicipio.Text = registroPorId.naturalidadeMunicipioUID + " | " + registroPorId.enderecoNomeMunicipio;
			txtRgNumero.Text = registroPorId.rgNumero;
			txtEmail.Text = registroPorId.email;
			txtEndereco.Text = registroPorId.enderecoLogradouro;
			txtEnderecoNumero.Text = registroPorId.enderecoNumero;
			txtEnderecoComplemento.Text = registroPorId.enderecoComplemento;
			txtBairro.Text = registroPorId.enderecoBairro;
			txtCep.Text = registroPorId.enderecoCEP;
			txtEnderecoMunicipio.Text = registroPorId.enderecoMunicipioUID + " | " + registroPorId.enderecoNomeMunicipio;
			if (registroPorId.diplomaGraduacaoExterior)
			{
				((ListControl)rblGraduacaoExterior).Items[0].Selected = true;
				((Control)pnlInstituicaoSuperior).Visible = false;
				((Control)pnlNumeroRegistroApostilaRevalidacao).Visible = true;
				txtNumeroRegistroApostilaRevalidacao.Text = registroPorId.numeroRegistroApostilaRevalidacao;
			}
			else
			{
				((ListControl)rblGraduacaoExterior).Items[1].Selected = true;
				((Control)pnlInstituicaoSuperior).Visible = true;
				((Control)pnlNumeroRegistroApostilaRevalidacao).Visible = false;
				txtInstituicaoEnsinoSuperior.Text = registroPorId.graduacaoInstituicaoEnsino;
			}
			txtDataColacaoGrau.Text = $"{registroPorId.graduacaoDataColacaoGrau:dd/MM/yyyy}";
			this.ViewState["senha"] = registroPorId.senha;
			CarregarDropDowns();
		}
	}

	protected void CarregarDropDowns()
	{
		CursoDAL cursoDAL = new CursoDAL();
		((BaseDataBoundControl)ddlEstadoCivil).DataSource = cursoDAL.GetEstadoCivil();
		((ListControl)ddlEstadoCivil).DataTextField = "nome";
		((ListControl)ddlEstadoCivil).DataValueField = "tipoEstadoCivilUID";
		((Control)ddlEstadoCivil).DataBind();
		((BaseDataBoundControl)ddlTipoFaixaRendaFamiliar).DataSource = cursoDAL.GetFaixaRendaFamiliar();
		((ListControl)ddlTipoFaixaRendaFamiliar).DataTextField = "nome";
		((ListControl)ddlTipoFaixaRendaFamiliar).DataValueField = "tipoFaixaRendaFamiliarUID";
		((Control)ddlTipoFaixaRendaFamiliar).DataBind();
		((BaseDataBoundControl)ddlTipoCorRaca).DataSource = cursoDAL.GetTipoCorRaca();
		((ListControl)ddlTipoCorRaca).DataTextField = "nome";
		((ListControl)ddlTipoCorRaca).DataValueField = "tipoCorRacaUID";
		((Control)ddlTipoCorRaca).DataBind();
		((BaseDataBoundControl)ddlPaisNascimento).DataSource = cursoDAL.GetPais();
		((ListControl)ddlPaisNascimento).DataTextField = "nome";
		((ListControl)ddlPaisNascimento).DataValueField = "paisUID";
		((Control)ddlPaisNascimento).DataBind();
		((BaseDataBoundControl)ddlUFOrgaoExpedidor).DataSource = cursoDAL.GetUF();
		((ListControl)ddlUFOrgaoExpedidor).DataTextField = "Nome";
		((ListControl)ddlUFOrgaoExpedidor).DataValueField = "UFUID";
		((Control)ddlUFOrgaoExpedidor).DataBind();
		((BaseDataBoundControl)ddlNaturalidadeUF).DataSource = cursoDAL.GetUF();
		((ListControl)ddlNaturalidadeUF).DataTextField = "Nome";
		((ListControl)ddlNaturalidadeUF).DataValueField = "UFUID";
		((Control)ddlNaturalidadeUF).DataBind();
		((BaseDataBoundControl)ddlEnderecoUF).DataSource = cursoDAL.GetUF();
		((ListControl)ddlEnderecoUF).DataTextField = "Nome";
		((ListControl)ddlEnderecoUF).DataValueField = "UFUID";
		((Control)ddlEnderecoUF).DataBind();
		((BaseDataBoundControl)ddlUFGraduacao).DataSource = cursoDAL.GetUF();
		((ListControl)ddlUFGraduacao).DataTextField = "Nome";
		((ListControl)ddlUFGraduacao).DataValueField = "UFUID";
		((Control)ddlUFGraduacao).DataBind();
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			DiscenteBO discenteBO = new DiscenteBO();
			PreMatriculaPessoa preMatriculaPessoa = new PreMatriculaPessoa();
			string[] array = txtMunicipio.Text.Trim().Split(new char[1] { '|' });
			string[] array2 = txtEnderecoMunicipio.Text.Trim().Split(new char[1] { '|' });
			int? municipioPorId = discenteBO.GetMunicipioPorId(int.Parse(array[0]));
			int? municipioPorId2 = discenteBO.GetMunicipioPorId(int.Parse(array2[0]));
			if (municipioPorId.HasValue)
			{
				preMatriculaPessoa.naturalidadeMunicipioUID = int.Parse(municipioPorId.ToString());
			}
			else
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Município inválido.  Faça nova consulta para continuar.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
			if (municipioPorId2.HasValue)
			{
				preMatriculaPessoa.enderecoMunicipioUID = int.Parse(municipioPorId2.ToString());
			}
			else
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Município de endereço inválido.  Faça nova consulta para continuar.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
			if (!resultadoOperacao.Erro)
			{
				preMatriculaPessoa.preMatriculaPessoaUID = long.Parse(hddCodigoRegistro.Value);
				preMatriculaPessoa.senha = this.ViewState["senha"].ToString();
				preMatriculaPessoa.nome = txtNome.Text;
				preMatriculaPessoa.sexo = ((ListControl)ddlSexo).SelectedValue.ToString();
				preMatriculaPessoa.nascimentoData = DateTime.Parse(txtDataNascimento.Text);
				preMatriculaPessoa.nomeMae = txtNomeMae.Text;
				preMatriculaPessoa.nomePai = txtNomePai.Text;
				preMatriculaPessoa.cpf = txtCpf.Text;
				preMatriculaPessoa.rgNumero = txtRgNumero.Text;
				preMatriculaPessoa.rgOrgaoExpedidor = txtOrgaoExpedidor.Text;
				preMatriculaPessoa.rgDataExpedicao = DateTime.Parse(txtDataExpedicao.Text);
				preMatriculaPessoa.tipoEstadoCivilUID = byte.Parse(((ListControl)ddlEstadoCivil).SelectedValue.ToString());
				preMatriculaPessoa.nacionalidade = ((ListControl)ddlNacionalidade).SelectedValue.ToString();
				preMatriculaPessoa.nascimentoPaisUID = ((ListControl)ddlPaisNascimento).SelectedItem.Value.ToString();
				preMatriculaPessoa.email = txtEmail.Text;
				preMatriculaPessoa.enderecoLogradouro = txtEndereco.Text;
				preMatriculaPessoa.enderecoNumero = txtEnderecoNumero.Text;
				preMatriculaPessoa.enderecoComplemento = txtEnderecoComplemento.Text;
				preMatriculaPessoa.enderecoBairro = txtBairro.Text;
				preMatriculaPessoa.enderecoCEP = txtCep.Text;
				preMatriculaPessoa.telefoneFixo = txtTelefoneFixo.Text;
				preMatriculaPessoa.telefoneMovel = txtTelefoneMovel.Text;
				preMatriculaPessoa.telefoneComercial = txtTelefoneComercial.Text;
				preMatriculaPessoa.tipoFaixaRendaFamiliarUID = byte.Parse(((ListControl)ddlTipoFaixaRendaFamiliar).SelectedValue.ToString());
				preMatriculaPessoa.tipoCorRacaUID = byte.Parse(((ListControl)ddlTipoCorRaca).SelectedValue.ToString());
				preMatriculaPessoa.graduacaoDataColacaoGrau = DateTime.Parse(txtDataColacaoGrau.Text);
				preMatriculaPessoa.rgUFUID = ((ListControl)ddlUFOrgaoExpedidor).SelectedValue.ToString();
				preMatriculaPessoa.enderecoUFUID = ((ListControl)ddlEnderecoUF).SelectedValue.ToString();
				preMatriculaPessoa.graduacaoUFUID = ((ListControl)ddlUFGraduacao).SelectedValue.ToString();
				preMatriculaPessoa.naturalidadeUFUID = ((ListControl)ddlNaturalidadeUF).SelectedValue.ToString();
				resultadoOperacao = discenteBO.Salvar(preMatriculaPessoa, 2);
			}
		}
		catch (Exception)
		{
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/webapp/discente/FrmListar.aspx?&obj=ProjetoTurma&projetoCursoUID=" + ((Page)this).Request.QueryString["cursoUID"] + "&curso=" + ((Page)this).Request.QueryString["curso"]);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx?registroUID=" + hddCursoUID.Value + "&descricao=" + this.ViewState["descricao"].ToString());
	}

	protected void rblGraduacaoExterior_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)rblGraduacaoExterior).SelectedValue == "true")
		{
			((Control)pnlNumeroRegistroApostilaRevalidacao).Visible = true;
			((Control)pnlInstituicaoSuperior).Visible = false;
		}
		else
		{
			((Control)pnlInstituicaoSuperior).Visible = true;
			((Control)pnlNumeroRegistroApostilaRevalidacao).Visible = false;
		}
	}

	protected void btnHomologarCandidato_Click(object sender, EventArgs e)
	{
	}

	private void CloseDialog(string dialogId)
	{
		string text = $"closeDialog('{dialogId}')";
		ScriptManager.RegisterStartupScript((Page)(object)this, typeof(Page), this.UniqueID, text, true);
	}

	private void CarregarJQuery()
	{
		ScriptManager.RegisterClientScriptBlock((Page)(object)this, typeof(Page), this.UniqueID, "carregarJQuery()", true);
	}

	private void ShowDialog(string dialogId)
	{
		string text = $"showDialog('{dialogId}')";
		ScriptManager.RegisterClientScriptBlock((Page)(object)this, typeof(Page), this.UniqueID, text, true);
	}

	protected void btnModalSolicitarCorrecao_Click(object sender, EventArgs e)
	{
		ScriptManager.RegisterStartupScript(this.Page, ((object)this.Page).GetType(), Guid.NewGuid().ToString(), "alert('Correção solicitada com sucesso.');window.location='" + lnkTitulo.NavigateUrl + "'", true);
	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		new DiscenteDAL().CancelarInscricao(long.Parse(hddPreMatriculaInscricaoUID.Value));
		((Page)this).Response.Redirect("~/webapp/discente/FrmListar.aspx?&obj=ProjetoTurma&projetoCursoUID=" + ((Page)this).Request.QueryString["cursoUID"] + "&curso=" + ((Page)this).Request.QueryString["curso"]);
	}

	protected void btnDesfazerCancelamento_Click(object sender, EventArgs e)
	{
		((Control)btnCancelar).Visible = true;
	}
}
