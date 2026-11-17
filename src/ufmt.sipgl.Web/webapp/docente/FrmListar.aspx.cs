using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.docente;

public class FrmListar : VerificaSession
{
	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected Label lbNome;

	protected TextBox txtNome;

	protected Label lbCpf;

	protected TextBox txtCPF;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkCadastrarDocenteInterno;

	protected HyperLink lnkCadastrarDocenteExterno;

	protected Label lblTotalRegistros;

	protected GridView GridViewCorpoDocente;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuDocentes"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkCadastrarDocenteInterno).Visible = (listaRecursos.Contains(((Control)lnkCadastrarDocenteInterno).SkinID) ? true : false);
		((Control)lnkCadastrarDocenteExterno).Visible = (listaRecursos.Contains(((Control)lnkCadastrarDocenteExterno).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			lblTitulo.Text = "Docentes";
			lnkCadastrarDocenteInterno.NavigateUrl = "~/webapp/docente/FrmCadastrarInterno.aspx?";
			lnkCadastrarDocenteExterno.NavigateUrl = "~/webapp/docente/FrmCadastrarExterno.aspx?";
			PreecherGridView(txtNome.Text, txtCPF.Text);
		}
	}

	protected void PreecherGridView(string nome, string cpf)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		List<ProjetoCorpoDocenteDTO> list = new ProjetoCorpoDocenteDAL().Filtrar(nome, cpf);
		((BaseDataBoundControl)GridViewCorpoDocente).DataSource = list;
		((Control)GridViewCorpoDocente).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count > 0)
		{
			ImageButton val = (ImageButton)((Control)GridViewCorpoDocente.BottomPagerRow).FindControl("cmdPrev");
			if (GridViewCorpoDocente.PageIndex == 0)
			{
				((WebControl)val).Enabled = false;
			}
			else
			{
				((WebControl)val).Enabled = true;
			}
		}
	}

	protected void cmdIr2_Click(object sender, ImageClickEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		TextBox val = (TextBox)((Control)GridViewCorpoDocente.BottomPagerRow).FindControl("txtPagina");
		GridViewCorpoDocente.PageIndex = Convert.ToInt32(val.Text) - 1;
		PreecherGridView(txtNome.Text, txtCPF.Text);
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtNome.Text, txtCPF.Text);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(null, null);
		txtNome.Text = string.Empty;
		txtCPF.Text = string.Empty;
	}

	protected void GridViewCorpoDocente_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridViewCorpoDocente.PageIndex = e.NewPageIndex;
		ProjetoCorpoDocenteDAL projetoCorpoDocenteDAL = new ProjetoCorpoDocenteDAL();
		((BaseDataBoundControl)GridViewCorpoDocente).DataSource = projetoCorpoDocenteDAL.Filtrar(txtNome.Text, txtCPF.Text);
		((Control)GridViewCorpoDocente).DataBind();
	}

	protected void GridViewCorpoDocente_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			string cpf = (string)DataBinder.Eval(e.Row.DataItem, "Cpf");
			((TableRow)e.Row).Cells[3].Text = cpf.FormatarCPF();
			string value = (string)DataBinder.Eval(e.Row.DataItem, "Siape");
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkEditarDocenteExterno");
			if (!string.IsNullOrWhiteSpace(value))
			{
				((Control)val).Visible = false;
			}
			else if (listaRecursos.Contains(((Control)val).SkinID))
			{
				((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
			}
		}
	}
}
