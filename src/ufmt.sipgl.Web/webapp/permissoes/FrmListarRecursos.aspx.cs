using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.permissoes;

public class FrmListarRecursos : VerificaSession
{
	protected HiddenField hddPermissaoUID;

	protected UpdatePanel UpdatePanel1;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuPermissoes_VincularPermissoes"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		hddPermissaoUID.Value = ((Page)this).Request.QueryString["permissaoUID"];
		if (!((Page)this).IsPostBack)
		{
			Permissao permissao = new PermissaoBO().BuscarPermissaoPorID(long.Parse(hddPermissaoUID.Value));
			lnkTitulo.NavigateUrl = "~/webapp/permissoes/FrmListar.aspx";
			lblTitulo.Text = "Recursos vinculados ao " + permissao.nome;
			PreecherGridView();
		}
	}

	protected void PreecherGridView()
	{
		List<ProjetoRecurso> dataSource = new ProjetoRecursoBO().ListarRecursos();
		((BaseDataBoundControl)GridView1).DataSource = dataSource;
		((Control)GridView1).DataBind();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		if ((int)e.Row.RowType != 2)
		{
			return;
		}
		LinkButton val = (LinkButton)((Control)e.Row).FindControl("lnkVincular");
		LinkButton val2 = (LinkButton)((Control)e.Row).FindControl("lnkDesvincular");
		if (val != null)
		{
			long projetoRecursoUID = long.Parse(val.CommandArgument);
			long permissaoUID = long.Parse(hddPermissaoUID.Value);
			if (new ProjetoRecursoBO().IsRecursoVinculado(projetoRecursoUID, permissaoUID))
			{
				((Control)val).Visible = false;
				((Control)val2).Visible = true;
			}
			else
			{
				((Control)val).Visible = true;
				((Control)val2).Visible = false;
			}
		}
	}

	protected void lnkVincular_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long projetoRecursoUID = long.Parse(((LinkButton)sender).CommandArgument);
		long permissaoUID = long.Parse(hddPermissaoUID.Value);
		ResultadoOperacao resultadoOperacao = new ProjetoRecursoBO().VincularRecurso(projetoRecursoUID, permissaoUID);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/webapp/permissoes/FrmListarRecursos.aspx?permissaoUID=" + hddPermissaoUID.Value);
	}

	protected void lnkDesvincular_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long projetoRecursoUID = long.Parse(((LinkButton)sender).CommandArgument);
		long permissaoUID = long.Parse(hddPermissaoUID.Value);
		ResultadoOperacao resultadoOperacao = new ProjetoRecursoBO().DesvincularRecurso(projetoRecursoUID, permissaoUID);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/webapp/permissoes/FrmListarRecursos.aspx?permissaoUID=" + hddPermissaoUID.Value);
	}
}
