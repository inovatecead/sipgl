using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.aluno.Base;

namespace ufmt.sipgl.View.aluno;

public class RecuperacaoSenha : UsuarioExternoBase
{
	protected Panel pnlFormularioInscricao;

	protected ValidationSummary ValidationSummary1;

	protected HiddenField hddCPF;

	protected HiddenField hddChaveRecuperacaoSenha;

	protected HtmlGenericControl divFormulario;

	protected Label lbNovaSenha;

	protected CompareValidator CompareValidator1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtNovaSenha;

	protected Label lbQuantidadeCaracteres;

	protected Label lbConfirmarSenha;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtConfirmarSenha;

	protected Button btnAlterarSenha;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			string text = ((Page)this).Request.QueryString["cpf"];
			string text2 = ((Page)this).Request.QueryString["chave"];
			ResultadoOperacao resultadoOperacao = new PreMatriculaPessoaBO().ValidarDadosRecuperacaoSenha(text, text2);
			if (resultadoOperacao.Erro)
			{
				PopulateMessage(resultadoOperacao);
				((Page)this).Response.Redirect("~/aluno/Default.aspx");
			}
			hddCPF.Value = text;
			hddChaveRecuperacaoSenha.Value = text2;
		}
	}

	public void btnAlterarSenha_Click(object sender, EventArgs e)
	{
		string text = txtNovaSenha.Text;
		string text2 = txtConfirmarSenha.Text;
		ResultadoOperacao resultadoOperacao = new PreMatriculaPessoaBO().RecuperarSenha(text, text2, hddCPF.Value, hddChaveRecuperacaoSenha.Value);
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}

	public void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}
}
