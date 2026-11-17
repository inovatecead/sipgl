using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.GerenciarUsuarios;

public class FrmListar : VerificaSession
{
	protected UpdatePanel upGeral;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected Label lbNome;

	protected TextBox txtNome;

	protected Label lbCPF;

	protected TextBox txtCPF;

	protected Label lbPermissao;

	protected DropDownList ddlPermissao;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuGerenciarUsuarios"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			lblTitulo.Text = "Gerenciar Usuários";
			PreecherGridView(string.Empty, string.Empty, long.Parse(((ListControl)ddlPermissao).SelectedValue));
			popularDropdowns();
		}
	}

	protected void popularDropdowns()
	{
		List<Permissao> dataSource = new PermissaoBO().ListarPermissoesPorAplicacao();
		((BaseDataBoundControl)ddlPermissao).DataSource = dataSource;
		((ListControl)ddlPermissao).DataTextField = "nome";
		((ListControl)ddlPermissao).DataValueField = "permissaoUID";
		((Control)ddlPermissao).DataBind();
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtNome.Text, txtCPF.Text, long.Parse(((ListControl)ddlPermissao).SelectedValue));
	}

	protected void PreecherGridView(string nome, string cpf, long permissaoUID, bool visible = false)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		List<Usuario> list = new UsuarioBO().FiltrarUsuarios(nome, cpf, permissaoUID);
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

	protected void cmdIr2_Click(object sender, ImageClickEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		TextBox val = (TextBox)((Control)GridView1.BottomPagerRow).FindControl("txtPagina");
		GridView1.PageIndex = Convert.ToInt32(val.Text) - 1;
		PreecherGridView(txtNome.Text, txtCPF.Text, long.Parse(((ListControl)ddlPermissao).SelectedValue));
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtNome.Text, txtCPF.Text, long.Parse(((ListControl)ddlPermissao).SelectedValue));
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(null, null, 0L, visible: true);
		txtNome.Text = string.Empty;
		txtCPF.Text = string.Empty;
		((ListControl)ddlPermissao).SelectedValue = "0";
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
			string cpf = (string)DataBinder.Eval(e.Row.DataItem, "Pessoa.cpf");
			((TableRow)e.Row).Cells[2].Text = cpf.FormatarCPF();
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkVincularPermissao");
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkVincularUnidade");
			((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
		}
	}
}
