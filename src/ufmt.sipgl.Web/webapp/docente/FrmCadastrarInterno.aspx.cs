using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.docente;

public class FrmCadastrarInterno : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlFormularioInscricao;

	protected ValidationSummary ValidationSummary1;

	protected Label Label59;

	protected RequiredFieldValidator RequiredFieldValidator52;

	protected TextBox txtCorpoDocente;

	protected Button btnCadastrarDocenteInterno;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuDocentes_NovoDocenteInterno"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Docentes ] ";
			lnkTitulo.NavigateUrl = "~/webapp/docente/FrmListar.aspx";
			lblTitulo.Text = "Cadastrar Docente";
		}
	}

	protected void btnCadastrarDocenteInterno_Click(object sender, EventArgs e)
	{
		new CoordenadorDAL();
		ProjetoCorpoDocenteDAL projetoCorpoDocenteDAL = new ProjetoCorpoDocenteDAL();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		string[] array = txtCorpoDocente.Text.Trim().Split(new char[1] { '|' });
		resultadoOperacao = projetoCorpoDocenteDAL.CadastrarDocenteInterno(array[0]);
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
