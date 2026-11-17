using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.aluno.Base;
using ufmt.sipgl.View.componentes;

namespace ufmt.sipgl.View;

public class FrmCadastroPessoa : UsuarioExternoBase
{
	protected HiddenField hddCPF;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected HtmlGenericControl divFormulario;

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

	protected TextBox txtCpf;

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

	protected TextBox txtTelefoneFixo;

	protected MaskedEditExtender MaskedEditExtenderTelefone;

	protected Label Label15;

	protected RequiredFieldValidator RequiredFieldValidator24;

	protected TextBox txtTelefoneMovel;

	protected MaskedEditExtender MaskedEditExtender1;

	protected Label Label4;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtEmail;

	protected Label Label41;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected TextBox txtTituloEleitoral;

	protected Label Label42;

	protected RequiredFieldValidator RequiredFieldValidator18;

	protected TextBox txtZona;

	protected Label Label43;

	protected RequiredFieldValidator RequiredFieldValidator21;

	protected DropDownList ddlTituloEleitorUF;

	protected Label Label44;

	protected RequiredFieldValidator RequiredFieldValidator38;

	protected DropDownList ddlTituloEleitorMunicipio;

	protected Label Label25;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected DropDownList ddlNacionalidade;

	protected Label Label40;

	protected TextBox txtPassaporte;

	protected Label Label26;

	protected DropDownList ddlPaisNascimento;

	protected Label Label27;

	protected RequiredFieldValidator RequiredFieldValidator17;

	protected DropDownList ddlNaturalidadeUF;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected DropDownList ddlNaturalidadeMunicipio;

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

	protected DropDownList ddlEnderecoMunicipio;

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

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected DropDownList ddlTipoGraducao;

	protected Label Label28;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtCursoGraduacao;

	protected Label Label33;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtNumeroRegistroDiploma;

	protected Label Label23;

	protected RequiredFieldValidator RequiredFieldValidator34;

	protected DropDownList ddlInstituicaoEnsino;

	protected Label Label30;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected TextBox txtDataColacaoGrau;

	protected MaskedEditExtender txtDataColacaoGrau_MaskedEditExtender;

	protected MaskedEditValidator MaskedEditValidator2;

	protected Label Label36;

	protected TextBox txtProfissao;

	protected Label Label37;

	protected TextBox txtEmpresaTrabalho;

	protected Label Label16;

	protected TextBox txtTelefoneComercial;

	protected MaskedEditExtender MaskedEditExtender2;

	protected Label Label39;

	protected TextBox txtCelularComercial;

	protected MaskedEditExtender MaskedEditExtender3;

	protected Label Label38;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox txtEmailComercial;

	protected Label lblSenha;

	protected CompareValidator CompareValidator2;

	protected RequiredFieldValidator RequiredFieldValidator39;

	protected TextBox txtSenha;

	protected Label Label5;

	protected Label lbConfirmarSenha;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtConfirmarSenha;

	protected Button btnSalvar;

	protected Button btnVoltar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			string text = ((Page)this).Request.QueryString["cpf"];
			PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
			if (!preMatriculaPessoaBO.ValidarCPF(text))
			{
				((Page)this).Response.Redirect("~/aluno/Default.aspx");
			}
			if (preMatriculaPessoaBO.BuscarPreMatriculaPessoaPorCPF(text) != null)
			{
				((Page)this).Response.Redirect("~/aluno/Default.aspx");
			}
			hddCPF.Value = text;
			txtCpf.Text = text.FormatarCPF();
			CarregarDropDowns();
		}
	}

	protected void CarregarDropDowns()
	{
		CursoDAL cursoDAL = new CursoDAL();
		ProjetoTipoGraduacaoBO projetoTipoGraduacaoBO = new ProjetoTipoGraduacaoBO();
		InstituicaoEnsinoBO instituicaoEnsinoBO = new InstituicaoEnsinoBO();
		((BaseDataBoundControl)ddlEstadoCivil).DataSource = cursoDAL.GetEstadoCivil();
		((ListControl)ddlEstadoCivil).DataTextField = "nome";
		((ListControl)ddlEstadoCivil).DataValueField = "tipoEstadoCivilUID";
		((Control)ddlEstadoCivil).DataBind();
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
		((BaseDataBoundControl)ddlTipoGraducao).DataSource = projetoTipoGraduacaoBO.ListarProjetoTipoGraduacao();
		((ListControl)ddlTipoGraducao).DataTextField = "descricao";
		((ListControl)ddlTipoGraducao).DataValueField = "projetoTipoGraduacaoUID";
		((Control)ddlTipoGraducao).DataBind();
		((BaseDataBoundControl)ddlTituloEleitorUF).DataSource = cursoDAL.GetUF();
		((ListControl)ddlTituloEleitorUF).DataTextField = "Nome";
		((ListControl)ddlTituloEleitorUF).DataValueField = "UFUID";
		((Control)ddlTituloEleitorUF).DataBind();
		((BaseDataBoundControl)ddlInstituicaoEnsino).DataSource = instituicaoEnsinoBO.ListarTodos();
		((ListControl)ddlInstituicaoEnsino).DataTextField = "nome";
		((ListControl)ddlInstituicaoEnsino).DataValueField = "instituicaoEnsinoUID";
		((Control)ddlInstituicaoEnsino).DataBind();
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
			resultadoOperacao = preMatriculaPessoaBO.VerificarCPF(hddCPF.Value);
			if (resultadoOperacao.Erro)
			{
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			resultadoOperacao = preMatriculaPessoaBO.ValidarSenhas(txtSenha.Text, txtConfirmarSenha.Text);
			if (resultadoOperacao.Erro)
			{
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			PreMatriculaPessoa preMatriculaPessoa = new PreMatriculaPessoa();
			new DiscenteBO();
			preMatriculaPessoa.graduacaoInstituicaoEnsinoUID = int.Parse(((ListControl)ddlInstituicaoEnsino).Text);
			preMatriculaPessoa.nome = txtNome.Text;
			preMatriculaPessoa.sexo = ((ListControl)ddlSexo).SelectedValue.ToString();
			preMatriculaPessoa.nascimentoData = DateTime.Parse(txtDataNascimento.Text);
			preMatriculaPessoa.nomeMae = txtNomeMae.Text;
			preMatriculaPessoa.nomePai = txtNomePai.Text;
			preMatriculaPessoa.cpf = hddCPF.Value;
			preMatriculaPessoa.rgNumero = txtRgNumero.Text;
			preMatriculaPessoa.rgUFUID = ((ListControl)ddlUFOrgaoExpedidor).SelectedValue;
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
			preMatriculaPessoa.graduacaoDataColacaoGrau = DateTime.Parse(txtDataColacaoGrau.Text);
			preMatriculaPessoa.graduacaoUFUID = ((ListControl)ddlUFGraduacao).SelectedValue;
			preMatriculaPessoa.enderecoUFUID = ((ListControl)ddlEnderecoUF).SelectedValue;
			preMatriculaPessoa.naturalidadeUFUID = ((ListControl)ddlNaturalidadeUF).SelectedValue;
			preMatriculaPessoa.projetoTipoGraduacaoUID = long.Parse(((ListControl)ddlTipoGraducao).SelectedValue);
			preMatriculaPessoa.numeroRegistroDiploma = txtNumeroRegistroDiploma.Text;
			preMatriculaPessoa.cursoGraduacao = txtCursoGraduacao.Text;
			preMatriculaPessoa.enderecoMunicipioUID = int.Parse(((ListControl)ddlEnderecoMunicipio).SelectedValue);
			preMatriculaPessoa.naturalidadeMunicipioUID = int.Parse(((ListControl)ddlNaturalidadeMunicipio).SelectedValue);
			preMatriculaPessoa.tituloEleitoral = txtTituloEleitoral.Text;
			preMatriculaPessoa.zona = txtZona.Text;
			preMatriculaPessoa.tituloEleitoralUFUID = ((ListControl)ddlTituloEleitorUF).SelectedValue;
			preMatriculaPessoa.tituloEleitoralMunicipioUID = int.Parse(((ListControl)ddlTituloEleitorMunicipio).SelectedValue);
			preMatriculaPessoa.passaporte = txtPassaporte.Text;
			preMatriculaPessoa.profissao = txtProfissao.Text;
			preMatriculaPessoa.localTrabalho = txtEmpresaTrabalho.Text;
			preMatriculaPessoa.telefoneComercial = txtTelefoneComercial.Text;
			preMatriculaPessoa.celularComercial = txtCelularComercial.Text;
			preMatriculaPessoa.emailComercial = txtEmailComercial.Text;
			resultadoOperacao = preMatriculaPessoaBO.SalvarPreMatriculaPessoa(preMatriculaPessoa, txtSenha.Text);
			if (resultadoOperacao.Erro)
			{
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			PreMatriculaPessoa preMatriculaPessoa2 = preMatriculaPessoaBO.BuscarPreMatriculaPessoaPorCPF(hddCPF.Value);
			resultadoOperacao = new Email().EnviarConfirmacaoEmail(preMatriculaPessoa2.email, preMatriculaPessoa2.nome, preMatriculaPessoa2.cpf, preMatriculaPessoa2.chaveValidacaoCadastro);
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
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

	protected void ddlNaturalidadeUF_SelectedIndexChanged(object sender, EventArgs e)
	{
		CursoDAL cursoDAL = new CursoDAL();
		string selectedValue = ((ListControl)ddlNaturalidadeUF).SelectedValue;
		((ListControl)ddlNaturalidadeMunicipio).Items.Clear();
		((BaseDataBoundControl)ddlNaturalidadeMunicipio).DataSource = cursoDAL.GetMunicipioPorEstado(string.Empty, selectedValue);
		((ListControl)ddlNaturalidadeMunicipio).DataTextField = "Nome";
		((ListControl)ddlNaturalidadeMunicipio).DataValueField = "MunicipioUID";
		((Control)ddlNaturalidadeMunicipio).DataBind();
	}

	protected void ddlEnderecoUF_SelectedIndexChanged(object sender, EventArgs e)
	{
		CursoDAL cursoDAL = new CursoDAL();
		string selectedValue = ((ListControl)ddlEnderecoUF).SelectedValue;
		((ListControl)ddlEnderecoMunicipio).Items.Clear();
		((BaseDataBoundControl)ddlEnderecoMunicipio).DataSource = cursoDAL.GetMunicipioPorEstado(string.Empty, selectedValue);
		((ListControl)ddlEnderecoMunicipio).DataTextField = "Nome";
		((ListControl)ddlEnderecoMunicipio).DataValueField = "MunicipioUID";
		((Control)ddlEnderecoMunicipio).DataBind();
	}

	protected void ddlTituloEleitorUF_SelectedIndexChanged(object sender, EventArgs e)
	{
		CursoDAL cursoDAL = new CursoDAL();
		string selectedValue = ((ListControl)ddlTituloEleitorUF).SelectedValue;
		((ListControl)ddlTituloEleitorMunicipio).Items.Clear();
		((BaseDataBoundControl)ddlTituloEleitorMunicipio).DataSource = cursoDAL.GetMunicipioPorEstado(string.Empty, selectedValue);
		((ListControl)ddlTituloEleitorMunicipio).DataTextField = "Nome";
		((ListControl)ddlTituloEleitorMunicipio).DataValueField = "MunicipioUID";
		((Control)ddlTituloEleitorMunicipio).DataBind();
	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}
}
