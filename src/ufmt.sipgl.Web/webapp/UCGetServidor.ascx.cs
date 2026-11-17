using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ufmt.sig.entity;

namespace ufmt.sipgl.View.webapp;

public class UCGetServidor : UserControl
{
	public Servidor servidor;

	protected UpdatePanel updPnlListaServidores;

	protected Panel PanelMsgResultadoUC;

	protected Label lblMsgResultadoUC;

	protected Panel pnlCoordenadorAtual;

	protected Label lblnomeatual;

	protected Label lblcpfatual;

	protected Label lblmatriculaatual;

	protected HiddenField hdrespatual;

	protected Panel pnlInfoServidor;

	protected Label lblnome;

	protected Label lblcpf;

	protected Label lblmatricula;

	protected HiddenField hdrespnovo;

	protected Button btConfirmar;

	protected Panel pnlCoordenador;

	protected HtmlGenericControl divConsultaServidor;

	protected UpdateProgress UpdateProgress2;

	protected Label lblBuscaCoordenador;

	protected TextBox txtBuscaCoordenador;

	protected DropDownList ddlBuscaCoordenador;

	protected ImageButton ImageButton1;

	protected Panel pnlListaServidores;

	protected GridView gdrListaServidores;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((UserControl)this).IsPostBack)
		{
			InfoServidorResponsavel();
		}
	}

	public void InfoServidorResponsavel()
	{
	}

	protected void PreencherGridview(string criterio, string tipoCriterio, bool visible)
	{
	}
}
