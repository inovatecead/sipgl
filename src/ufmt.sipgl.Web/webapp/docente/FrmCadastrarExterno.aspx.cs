using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.docente;

public class FrmCadastrarExterno : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlFormularioInscricao;

	protected ValidationSummary ValidationSummary1;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList ddlTitulacao;

	protected Label Label108;

	protected RequiredFieldValidator RequiredFieldValidator113;

	protected TextBox txtNome;

	protected Label Label109;

	protected RequiredFieldValidator RequiredFieldValidator114;

	protected DropDownList ddlSexo;

	protected Label Label17;

	protected RequiredFieldValidator RequiredFieldValidator115;

	protected TextBox txtDataNascimento;

	protected MaskedEditExtender txtDataNascimento_MaskedEditExtender;

	protected MaskedEditValidator MaskedEditValidator3;

	protected Label Label110;

	protected RequiredFieldValidator RequiredFieldValidator116;

	protected TextBox txtNomeMae;

	protected Label Label111;

	protected RequiredFieldValidator RequiredFieldValidator117;

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

	protected DropDownList ddlOrgaoExpedidor;

	protected Label Label35;

	protected RequiredFieldValidator RequiredFieldValidator37;

	protected DropDownList ddlUFOrgaoExpedidor;

	protected Label Label20;

	protected RequiredFieldValidator RequiredFieldValidator118;

	protected TextBox txtDataExpedicao;

	protected MaskedEditExtender txtDataExpedicao_MaskedEditExtender;

	protected MaskedEditValidator MEVData1;

	protected Label Label14;

	protected TextBox txtTelefoneFixo;

	protected MaskedEditExtender MaskedEditExtenderTelefone;

	protected Label Label113;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtCelular;

	protected MaskedEditExtender MaskedEditExtender3;

	protected Label Label115;

	protected RequiredFieldValidator RequiredFieldValidator119;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtEmailPessoa;

	protected Button btnSalvarPessoa;

	protected Button btnCancelarPessoa;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuDocentes_NovoDocenteExterno"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Docentes ] ";
			lnkTitulo.NavigateUrl = "~/webapp/docente/FrmListar.aspx";
			lblTitulo.Text = "Cadastrar Docente Externo";
			CarregarDropdowns();
		}
	}

	public void CarregarDropdowns()
	{
		CursoDAL cursoDAL = new CursoDAL();
		((BaseDataBoundControl)ddlOrgaoExpedidor).DataSource = cursoDAL.GetOrgaoExpedidor();
		((ListControl)ddlOrgaoExpedidor).DataTextField = "nome";
		((ListControl)ddlOrgaoExpedidor).DataValueField = "tipoOrgaoExpedidorRgUID";
		((Control)ddlOrgaoExpedidor).DataBind();
		((BaseDataBoundControl)ddlUFOrgaoExpedidor).DataSource = cursoDAL.GetUF();
		((ListControl)ddlUFOrgaoExpedidor).DataTextField = "Nome";
		((ListControl)ddlUFOrgaoExpedidor).DataValueField = "UFUID";
		((Control)ddlUFOrgaoExpedidor).DataBind();
		((BaseDataBoundControl)ddlTitulacao).DataSource = cursoDAL.ListarTipoTitulacao();
		((ListControl)ddlTitulacao).DataTextField = "descricao";
		((ListControl)ddlTitulacao).DataValueField = "tipoTitulacaoUID";
		((Control)ddlTitulacao).DataBind();
	}

	protected void btnCadastrarDocenteExterno_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		ProjetoCorpoDocente projetoCorpoDocente = new ProjetoCorpoDocente();
		ProjetoCorpoDocenteDAL projetoCorpoDocenteDAL = new ProjetoCorpoDocenteDAL();
		projetoCorpoDocente.tipoTitulacaoUID = int.Parse(((ListControl)ddlTitulacao).SelectedValue);
		projetoCorpoDocente.nome = txtNome.Text.ToUpper();
		projetoCorpoDocente.sexo = ((ListControl)ddlSexo).SelectedItem.Value.ToUpper();
		projetoCorpoDocente.dataNascimento = DateTime.Parse(txtDataNascimento.Text);
		projetoCorpoDocente.nomePai = txtNomePai.Text.ToUpper();
		projetoCorpoDocente.nomeMae = txtNomeMae.Text.ToUpper();
		projetoCorpoDocente.cpf = txtCpf.Text;
		projetoCorpoDocente.rg = txtRgNumero.Text;
		projetoCorpoDocente.orgaoExpedidorUID = short.Parse(((ListControl)ddlOrgaoExpedidor).SelectedValue);
		projetoCorpoDocente.orgaoExpedidorUFUID = ((ListControl)ddlUFOrgaoExpedidor).SelectedValue;
		projetoCorpoDocente.dataExpedicao = DateTime.Parse(txtDataExpedicao.Text);
		projetoCorpoDocente.telefoneFixo = txtTelefoneFixo.Text;
		projetoCorpoDocente.celular = txtCelular.Text;
		projetoCorpoDocente.email = txtEmailPessoa.Text.ToUpper();
		resultadoOperacao = projetoCorpoDocenteDAL.CadastrarDocenteExterno(projetoCorpoDocente);
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/webapp/docente/FrmListar.aspx");
	}

	public void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/webapp/docente/FrmListar.aspx");
	}
}
