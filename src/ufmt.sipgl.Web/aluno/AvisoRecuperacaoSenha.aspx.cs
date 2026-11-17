using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ufmt.sipgl.View.aluno.Base;

namespace ufmt.sipgl.View.aluno;

public class AvisoRecuperacaoSenha : UsuarioExternoBase
{
	protected Panel pnlFormularioInscricao;

	protected HtmlGenericControl divFormulario;

	protected Label emailRecuperacaoMassage;

	protected Button btnVoltar;

	protected void Page_Load(object sender, EventArgs e)
	{
		string text = ((Page)this).Request.QueryString["emailRecuperacao"];
		if (string.IsNullOrWhiteSpace(text))
		{
			((Page)this).Response.Redirect("~/aluno/Default.aspx");
		}
		emailRecuperacaoMassage.Text = "Um e-mail com instruções para recuperação de senha foi enviado para " + text;
	}

	public void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}
}
