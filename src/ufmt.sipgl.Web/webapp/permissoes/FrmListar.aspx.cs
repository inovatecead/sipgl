using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.permissoes;

public class FrmListar : VerificaSession
{
	protected UpdatePanel UpdatePanel1;

	protected Label lblTitulo;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuPermissoes"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			lblTitulo.Text = "Perfis";
			PreecherGridView();
		}
	}

	protected void PreecherGridView()
	{
		List<Permissao> dataSource = new ProjetoPermissaoBO().ListarPerfis();
		((BaseDataBoundControl)GridView1).DataSource = dataSource;
		((Control)GridView1).DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkVincularPermissoes");
			((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
		}
	}
}
