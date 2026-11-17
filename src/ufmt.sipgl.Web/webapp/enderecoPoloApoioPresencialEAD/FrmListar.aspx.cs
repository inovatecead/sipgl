using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.enderecoPoloApoioPresencialEAD;

public class FrmListar : VerificaSession
{
	protected UpdatePanel upGeral;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected Label lbDescricao;

	protected TextBox txtCriterio;

	protected Label lbTipoUnidadeEnsino;

	protected DropDownList ddlTipoUnidadeEnsino;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoRegistro;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuUnidades"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkNovoRegistro).Visible = (listaRecursos.Contains(((Control)lnkNovoRegistro).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			lblTitulo.Text = "Unidades Administrativas/Acadêmicas";
			lnkNovoRegistro.NavigateUrl = "~/webapp/enderecoPoloApoioPresencialEAD/FrmCadastrar.aspx";
			((BaseDataBoundControl)ddlTipoUnidadeEnsino).DataSource = EnumService.EnumList(typeof(EnumTipoUnidadeEnsino));
			((ListControl)ddlTipoUnidadeEnsino).DataValueField = "key";
			((ListControl)ddlTipoUnidadeEnsino).DataTextField = "value";
			((Control)ddlTipoUnidadeEnsino).DataBind();
			PreecherGridView(txtCriterio.Text, null);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		int? tipoUnidadeEnsino = null;
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlTipoUnidadeEnsino).SelectedValue))
		{
			tipoUnidadeEnsino = int.Parse(((ListControl)ddlTipoUnidadeEnsino).SelectedValue);
		}
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtCriterio.Text, tipoUnidadeEnsino);
	}

	protected void PreecherGridView(string municipio, int? tipoUnidadeEnsino, bool visible = false)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		List<ViewEnderecoPoloEAD> list = new EnderecoPoloPresencialEadDAL().ListarPolos(municipio, tipoUnidadeEnsino);
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
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		int? tipoUnidadeEnsino = null;
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlTipoUnidadeEnsino).SelectedValue))
		{
			tipoUnidadeEnsino = int.Parse(((ListControl)ddlTipoUnidadeEnsino).SelectedValue);
		}
		TextBox val = (TextBox)((Control)GridView1.BottomPagerRow).FindControl("txtPagina");
		GridView1.PageIndex = Convert.ToInt32(val.Text) - 1;
		PreecherGridView(txtCriterio.Text, tipoUnidadeEnsino);
	}

	protected void lnkExcluir_Click(object sender, CommandEventArgs e)
	{
		int enderecoUID = int.Parse(e.CommandArgument.ToString());
		ResultadoOperacao resultadoOperacao = new EnderecoPoloPresencialEadDAL().Excluir(enderecoUID);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListar.aspx");
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		int? tipoUnidadeEnsino = null;
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlTipoUnidadeEnsino).SelectedValue))
		{
			tipoUnidadeEnsino = int.Parse(((ListControl)ddlTipoUnidadeEnsino).SelectedValue);
		}
		PreecherGridView(txtCriterio.Text, tipoUnidadeEnsino);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(null, null, visible: true);
		txtCriterio.Text = string.Empty;
		((ListControl)ddlTipoUnidadeEnsino).SelectedValue = "";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType == 2)
		{
			if (DataBinder.Eval(e.Row.DataItem, "tipoUnidadeEnsino") != null)
			{
				int num = (int)DataBinder.Eval(e.Row.DataItem, "tipoUnidadeEnsino");
				Label val = (Label)((Control)e.Row).FindControl("lbTipoUnidadeEnsino");
				EnumTipoUnidadeEnsino enumTipoUnidadeEnsino = (EnumTipoUnidadeEnsino)num;
				val.Text = enumTipoUnidadeEnsino.ObterDescricao();
			}
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkAlterarRegistro");
			LinkButton val3 = (LinkButton)((Control)e.Row).FindControl("lnkExcluirRegistro");
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains(((Control)val3).SkinID) ? true : false);
		}
	}
}
