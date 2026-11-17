using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.disciplina;

public class FrmAlterar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoDisciplinaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtNome;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtCargaHoraria;

	protected RegularExpressionValidator RegularExpressionValidator9;

	protected Label lbTipoDisciplina;

	protected DropDownList ddlTipoDisciplina;

	protected Label Label4;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtEmenta;

	protected Label Label5;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected TextBox txtBibliografia;

	protected Button btnVoltar;

	protected Button btnAlterar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Disciplinas_Editar"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoDisciplinaUID.Value = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
			lnkTitulo.Text = "[ Voltar para Disciplinas ] ";
			lnkTitulo.NavigateUrl = "~/webapp/disciplina/FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Editar Disciplina";
			ProjetoDisciplina projetoDisciplina = new ProjetoDisciplinaBO().BuscarDisciplinaPorId(long.Parse(hddProjetoDisciplinaUID.Value));
			PopularDados(projetoDisciplina);
		}
	}

	protected void PopularDados(ProjetoDisciplina projetoDisciplina)
	{
		txtNome.Text = projetoDisciplina.nome;
		txtCargaHoraria.Text = projetoDisciplina.cargaHoraria.ToString();
		txtEmenta.Text = projetoDisciplina.ementa;
		txtBibliografia.Text = projetoDisciplina.bibliografia;
		((BaseDataBoundControl)ddlTipoDisciplina).DataSource = EnumService.EnumList(typeof(EnumTipoDisciplina));
		((ListControl)ddlTipoDisciplina).DataTextField = "Value";
		((ListControl)ddlTipoDisciplina).DataValueField = "Key";
		((Control)ddlTipoDisciplina).DataBind();
		((ListControl)ddlTipoDisciplina).SelectedValue = projetoDisciplina.tipoDisciplina.ToString();
	}

	protected void btnAlterar_Click(object sender, EventArgs e)
	{
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		resultadoOperacao = projetoDisciplinaBO.AlterarDisciplina(new ProjetoDisciplina
		{
			projetoDisciplinaUID = long.Parse(hddProjetoDisciplinaUID.Value),
			nome = txtNome.Text,
			cargaHoraria = short.Parse(txtCargaHoraria.Text),
			tipoDisciplina = int.Parse(((ListControl)ddlTipoDisciplina).SelectedValue),
			ementa = txtEmenta.Text,
			bibliografia = txtBibliografia.Text
		});
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value);
	}
}
