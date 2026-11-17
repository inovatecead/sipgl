using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.aluno.Base;

namespace ufmt.sipgl.View;

public class FrmVerificarCadastro : UsuarioExternoBase
{
	protected Panel pnlFormularioInscricao;

	protected HtmlGenericControl divFormulario;

	protected Label lbCPF;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtCPF;

	protected MaskedEditExtender txtVerificarCpf_MaskedEditExtender;

	protected Button btnVerificarCadastro;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
		_ = ((Page)this).IsPostBack;
	}

	protected void btnVerificarCadastro_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		string text = txtCPF.Text;
		resultadoOperacao = preMatriculaPessoaBO.VerificarCPF(text);
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		if (preMatriculaPessoaBO.BuscarPreMatriculaPessoaPorCPF(text) == null)
		{
			((Page)this).Response.Redirect("~/aluno/FrmCadastroPessoa.aspx?cpf=" + text);
			return;
		}
		resultadoOperacao = new ResultadoOperacao();
		resultadoOperacao.TextMessage = "Já existe um registro no sistema com este CPF.";
		resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/aluno/Default.aspx");
	}
}
