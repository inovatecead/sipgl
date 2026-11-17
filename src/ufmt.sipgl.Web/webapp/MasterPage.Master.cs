using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sig.entity;
using ufmt.sipgl.Business;

namespace ufmt.sipgl.View.webapp.bolsa;

public class MasterPage : System.Web.UI.MasterPage
{
	protected ContentPlaceHolder head;

	protected HtmlForm form1;

	protected ToolkitScriptManager ToolkitScriptManager1;

	protected HtmlGenericControl MenuCursos;

	protected Image imgProjeto;

	protected HtmlGenericControl MenuUnidades;

	protected Image imgPolo;

	protected HtmlGenericControl MenuDiscentes;

	protected Image imgInscritos;

	protected HtmlGenericControl MenuDocentes;

	protected Image imgDocentes;

	protected HtmlGenericControl MenuGerenciarUsuarios;

	protected Image Image1;

	protected HtmlGenericControl MenuPermissoes;

	protected Image imgPermissoes;

	protected HyperLink lnkSair;

	protected Image imgSair;

	protected Label logadoComo;

	protected Label usuarioLogado;

	protected Panel typeMessage;

	protected Label textMessage;

	protected ContentPlaceHolder ContentPlaceHolder1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((UserControl)this).IsPostBack)
		{
			try
			{
				lnkSair.NavigateUrl = "~/Logout.aspx?url=~/Default.aspx";
				long usuarioUID = long.Parse(((UserControl)this).Session["usuarioUID"].ToString());
				Usuario usuario = new AutenticacaoBO().GetUsuario(usuarioUID);
				usuarioLogado.Text = usuario.Pessoa.Nome;
			}
			catch (Exception)
			{
				((UserControl)this).Response.Redirect("~/Default.aspx");
			}
		}
	}
}
