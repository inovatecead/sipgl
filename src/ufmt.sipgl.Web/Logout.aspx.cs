using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ufmt.sipgl.View;

public class Logout : Page
{
	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		((Page)this).Session.Abandon();
		string text = ((Page)this).Request.QueryString["url"];
		((Page)this).Response.Redirect(text);
	}
}
