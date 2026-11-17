using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sig.entity;
using ufmt.sipgl.Business;

namespace ufmt.sipgl.View;

public class LoginN : Page
{
	private int aplicacaoUID = int.Parse(WebConfigurationManager.AppSettings["aplicacaoUID"]);

	protected Panel panelAviso;

	protected Label lblAlerta;

	protected Panel pnlLogin;

	protected TextBox login;

	protected TextBox senha;

	protected ImageButton btEntrar;

	protected void Page_Load(object sender, EventArgs e)
	{
		_ = ((Page)this).IsPostBack;
	}

	protected void btEntrar_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string text = login.Text;
			string text2 = senha.Text;
			Usuario usuario = new AutenticacaoBO().Login(text, text2);
			if (usuario == null)
			{
				((Page)this).Response.Redirect("~/Default.aspx");
				return;
			}
			((Page)this).Session["usuarioUID"] = usuario.UsuarioUID;
			((Page)this).Response.Redirect("~/Login/AutenticarBase.aspx", false);
		}
		catch (Exception ex)
		{
			((Control)panelAviso).Visible = true;
			((Control)lblAlerta).Visible = true;
			lblAlerta.Text = ex.Message;
		}
	}
}
