using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace ufmt.sipgl.View;

public class Default : MasterPage
{
	protected HtmlHead Head1;

	protected ContentPlaceHolder head;

	protected HtmlForm form1;

	protected ToolkitScriptManager ToolkitScriptManager1;

	protected Panel pnlMenu;

	protected HtmlGenericControl MenuMinhasInscricoes;

	protected Image imgMinhasInscricoes;

	protected HtmlGenericControl MenuPreMatricula;

	protected Image Image2;

	protected HtmlGenericControl MenuEditarCadastro;

	protected Image imgEditarCadastro;

	protected HtmlGenericControl MenuSair;

	protected HyperLink lnkSair;

	protected Image imgSair;

	protected HtmlGenericControl IdentificacaoUsuario;

	protected Label logadoComo;

	protected Label usuarioLogado;

	protected Panel typeMessage;

	protected Label textMessage;

	protected ContentPlaceHolder ContentPlaceHolder1;

	protected void Page_Load(object sender, EventArgs e)
	{
		lnkSair.NavigateUrl = "~/Logout.aspx?url=~/aluno/Default.aspx";
		((Control)pnlMenu).Visible = true;
		if (((UserControl)this).Session["preDiscenteAutenticado"] != null)
		{
			usuarioLogado.Text = ((UserControl)this).Session["nomePreDiscente"].ToString();
			((Control)MenuEditarCadastro).Visible = true;
			((Control)MenuSair).Visible = true;
			((Control)IdentificacaoUsuario).Visible = true;
			((Control)pnlMenu).Visible = true;
		}
		else
		{
			((Control)pnlMenu).Visible = false;
			((Control)MenuEditarCadastro).Visible = false;
			((Control)IdentificacaoUsuario).Visible = false;
			((Control)MenuSair).Visible = false;
		}
	}

	private void CloseDialog(string dialogId)
	{
		string text = $"closeDialogMaster('{dialogId}')";
		ScriptManager.RegisterStartupScript((Control)(object)this, typeof(Page), this.UniqueID, text, true);
	}

	private void CarregarJQuery()
	{
		ScriptManager.RegisterClientScriptBlock((Control)(object)this, typeof(Page), this.UniqueID, "carregarJQuery()", true);
	}

	private void ShowDialog(string dialogId)
	{
		string text = $"showDialogMaster('{dialogId}')";
		ScriptManager.RegisterClientScriptBlock((Control)(object)this, typeof(Page), this.UniqueID, text, true);
	}
}
