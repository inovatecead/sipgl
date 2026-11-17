using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ufmt.sipgl.View.br.ufmt.sistemas;

namespace ufmt.sipgl.View.webapp.Login_Old;

public class Autenticar : Page
{
	protected HtmlForm form1;

	public void Page_Load(object sender, EventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Obj, but got Unknown
		HttpCookie val = new HttpCookie("ciclope", "942be60d-b4f8-4deb-8a73-e12656fd8873");
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
				((Page)this).Response.Redirect("~/webapp/Login/AutenticarBase.aspx", false);
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
