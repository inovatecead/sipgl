using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.aluno.Base;
using ufmt.sipgl.View.componentes;

namespace ufmt.sipgl.View.aluno;

public class SolicitarRecuperacaoSenha : UsuarioExternoBase
{
	protected Panel pnlFormularioInscricao;

	protected HtmlGenericControl divFormulario;

	protected Label lbCPF;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtCpf;

	protected MaskedEditExtender txtVerificarCpf_MaskedEditExtender;

	protected Button btnEnviar;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void btnSolicitarRecuperacaoSenha_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		string text = txtCpf.Text;
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		if (!preMatriculaPessoaBO.ValidarCPF(text))
		{
			resultadoOperacao.TextMessage = "O CPF informado é inválido. Verifique se digitou corretamente e tente novamente.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			resultadoOperacao.TextMessage = "O deve ser informado obrigatoriamente";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		resultadoOperacao = preMatriculaPessoaBO.SolicitarRecuperacaoSenha(text);
		if (resultadoOperacao.Erro)
		{
			resultadoOperacao.TextMessage = "Não há registro para o CPF informado. Verifique se digitou corretamente e tente novamente.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PreMatriculaPessoa preMatriculaPessoa = preMatriculaPessoaBO.BuscarPreMatriculaPessoaPorCPF(text);
		resultadoOperacao = new Email().EnviarRecuperacaoSenha(preMatriculaPessoa.email, preMatriculaPessoa.nome, preMatriculaPessoa.cpf, preMatriculaPessoa.chaveRecuperacaoSenha);
		if (!resultadoOperacao.Erro)
		{
			((Page)this).Response.Redirect("~/aluno/AvisoRecuperacaoSenha.aspx?emailRecuperacao=" + preMatriculaPessoa.email);
		}
		else
		{
			PopulateMessage(resultadoOperacao);
		}
	}

	public void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}
}
