using System;
using System.Web.UI;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp;

public class FrmPrincipal : VerificaSession
{
	protected void Page_Load(object sender, EventArgs e)
	{
		_ = ((Page)this).IsPostBack;
	}
}
