using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.aluno.Base;

namespace ufmt.sipgl.View.aluno;

public class ConfirmacaoEmail : UsuarioExternoBase
{
	protected Label lbPanelCofirmacaoEmail;

	protected Button btnVoltarHome;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			string cpf = ((Page)this).Request.QueryString["cpf"];
			string chave = ((Page)this).Request.QueryString["chave"];
			ResultadoOperacao resultadoOperacao = new PreMatriculaPessoaBO().ConfirmacaoEmail(cpf, chave);
			if (resultadoOperacao.Erro)
			{
				PopulateMessage(resultadoOperacao);
				((Page)this).Response.Redirect("~/aluno/Default.aspx");
			}
			lbPanelCofirmacaoEmail.Text = resultadoOperacao.TextMessage;
			((Control)lbPanelCofirmacaoEmail).Visible = true;
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}
}
