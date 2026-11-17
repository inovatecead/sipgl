using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.aluno.Base;

namespace ufmt.sipgl.View;

public class FrmAlterarSenha : AlunoBase
{
	protected HiddenField hddPreMatriculaPessoaUID;

	protected Panel pnlFormularioInscricao;

	protected HtmlGenericControl divFormulario;

	protected ValidationSummary ValidationSummary1;

	protected Label lbSenhaAntiga;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtSenhaAntiga;

	protected Label lbNovaSenha;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected CompareValidator CompareValidatorSenhas;

	protected TextBox txtNovaSenha;

	protected Label lbConfirmarSenha;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtConfirmarSenha;

	protected Button btnSalvar;

	protected Button btnVoltar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			hddPreMatriculaPessoaUID.Value = ((Page)this).Session["preMatriculaPessoaUID"].ToString();
			new PreMatriculaPessoaDAL().BuscarPreMatriculaPessoaPorID(long.Parse(hddPreMatriculaPessoaUID.Value));
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		long preMatriculaPessoaUID = long.Parse(hddPreMatriculaPessoaUID.Value);
		string text = txtSenhaAntiga.Text;
		string text2 = txtNovaSenha.Text;
		string text3 = txtConfirmarSenha.Text;
		resultadoOperacao = new PreMatriculaPessoaDAL().AlterarSenha(preMatriculaPessoaUID, text, text2, text3);
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/aluno/FrmListaInscricao.aspx");
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/FrmListaInscricao.aspx");
	}
}
