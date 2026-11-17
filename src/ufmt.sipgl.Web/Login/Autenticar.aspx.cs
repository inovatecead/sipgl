using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ufmt.sipgl.View.br.ufmt.sistemas;

namespace ufmt.sipgl.View.Login;

public class Autenticar : Page
{
	protected HtmlForm form1;

	public void Page_Load(object sender, EventArgs e)
	{
		HttpCookie val = ((Page)this).Request.Cookies["ciclope"];
		if (val != null)
		{
			string value = val.Value;
			Autenticacao autenticacao = new Autenticacao();
			try
			{
				UsuarioEntity usuarioEntity = autenticacao.ValidarToken(value);
				if (usuarioEntity == null)
				{
					((Page)this).Response.Redirect("https://sistemas.ufmt.br/ufmt.portalsistemas/Sistema/SemPermissao/19");
				}
				((Page)this).Session["usuarioUID"] = usuarioEntity.UsuarioUID;
				((Page)this).Response.Redirect("~/Login/AutenticarBase.aspx", false);
				return;
			}
			catch (Exception)
			{
				((Page)this).Response.Redirect("https://sistemas.ufmt.br/ufmt.portalsistemas/Sistema/SemPermissao/19");
				return;
			}
			finally
			{
				((IDisposable)autenticacao)?.Dispose();
			}
		}
		((Page)this).Response.Redirect("https://sistemas.ufmt.br/ufmt.portalsistemas/Sistema/SemPermissao/19");
	}
}
