using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.matriculaPessoa;

public class FrmListar : VerificaSession
{
	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected Label lblNome;

	protected TextBox txtNome;

	protected Label lblCPF;

	protected TextBox txtCPF;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoRegistro;

	protected HyperLink lnkImportarCandidatos;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuDiscentes"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkNovoRegistro).Visible = (listaRecursos.Contains(((Control)lnkNovoRegistro).SkinID) ? true : false);
		((Control)lnkImportarCandidatos).Visible = (listaRecursos.Contains(((Control)lnkImportarCandidatos).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			lblTitulo.Text = "Discentes";
			lnkNovoRegistro.NavigateUrl = "~/webapp/matriculaPessoa/FrmCadastroPessoa.aspx";
			lnkImportarCandidatos.NavigateUrl = "~/webapp/ProcessoSeletivo/FrmImportarCandidatosProcessoSeletivo.aspx";
			((Control)GridView1).Visible = true;
			PreecherGridView("", "", visible: true);
		}
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtNome.Text, txtCPF.Text, visible: true);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		txtNome.Text = "";
		txtCPF.Text = "";
		PreecherGridView(txtNome.Text, txtCPF.Text, visible: true);
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtNome.Text, txtCPF.Text, visible: false);
	}

	protected void PreecherGridView(string nome, string cpf, bool visible)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		List<PreMatriculaPessoa> list = new PreMatriculaPessoaDAL().ListarPreMatriculaPessoa(nome, cpf);
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count > 0)
		{
			ImageButton val = (ImageButton)((Control)GridView1.BottomPagerRow).FindControl("cmdPrev");
			if (GridView1.PageIndex == 0)
			{
				((WebControl)val).Enabled = false;
			}
			else
			{
				((WebControl)val).Enabled = true;
			}
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			string cpf = (string)DataBinder.Eval(e.Row.DataItem, "CPF");
			((TableRow)e.Row).Cells[1].Text = cpf.FormatarCPF();
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkVisualizarMatriculas");
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkAtualizarRegistro");
			((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
		}
	}
}
