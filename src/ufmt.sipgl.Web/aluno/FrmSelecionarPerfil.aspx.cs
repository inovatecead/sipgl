using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sig.entity;
using ufmt.sipgl.Business;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View;

public class FrmSelecionarPerfil : VerificaSession
{
	protected AutenticacaoBO aBO;

	protected Label lblProReitoria;

	protected Repeater rpPerfilAcesso;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			aBO = new AutenticacaoBO();
		}
	}

	protected void rpPerfilAcesso_ItemCommand(object source, RepeaterCommandEventArgs e)
	{
		if (((CommandEventArgs)e).CommandName == "SetPermissao")
		{
			Permissao permissao = new AutenticacaoBO().GetPermissao(long.Parse(((CommandEventArgs)e).CommandArgument.ToString()));
			((Page)this).Session["permissao"] = permissao.Nome;
			((Page)this).Session["administracao"] = "true";
			if (permissao.Nome.Contains("ADMINISTRADOR"))
			{
				((Page)this).Response.Redirect("~/webapp/editais/FrmListar.aspx");
			}
			else if (permissao.Nome.Contains("COORDENADOR"))
			{
				((Page)this).Response.Redirect("~/webapp/editais/FrmListar.aspx");
			}
			else
			{
				((Page)this).Response.Redirect("~/webapp/editais/FrmListar.aspx");
			}
		}
	}

	protected void rpPerfilAcesso_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Item.ItemType != 2)
		{
			_ = e.Item.ItemType;
			_ = 3;
		}
	}
}
