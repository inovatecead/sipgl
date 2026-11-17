using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.aluno.Base;
using ufmt.sipgl.View.componentes;

namespace ufmt.sipgl.View;

public class FrmLoginPreMatricula : UsuarioExternoBase
{
	protected Panel panelAviso;

	protected Label lblAlerta;

	protected HyperLink lnkCadastrar;

	protected HiddenField hddProjetoCursoUID;

	protected HyperLink lnkRecuperarSenha;

	protected Panel pnlLogin;

	protected TextBox login;

	protected TextBox senha;

	protected ImageButton btEntrar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			lnkCadastrar.NavigateUrl = "~/aluno/FrmVerificarCadastro.aspx";
			lnkRecuperarSenha.NavigateUrl = "~/aluno/SolicitarRecuperacaoSenha.aspx";
			if (((Page)this).Session["preDiscenteAutenticado"] != null)
			{
				((Page)this).Response.Redirect("~/aluno/FrmListaInscricao.aspx");
			}
		}
	}

	protected void btEntrar_Click(object sender, ImageClickEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(login.Text) || string.IsNullOrWhiteSpace(senha.Text))
		{
			((Control)panelAviso).Visible = true;
			((Control)lblAlerta).Visible = true;
			lblAlerta.Text = "Os campos de CPF e Senha não devem permanecer em branco. Verifique os dados e tente novamente.";
			return;
		}
		string text = login.Text;
		string mD5Hash = Util.getMD5Hash(senha.Text);
		ViewPreMatriculaPessoa viewPreMatriculaPessoa = new DiscenteBO().AtenticarPreDiscente(text, mD5Hash);
		if (viewPreMatriculaPessoa == null)
		{
			((Control)panelAviso).Visible = true;
			((Control)lblAlerta).Visible = true;
			lblAlerta.Text = "Dados não conferem.  Verifique os dados e tente novamente.";
		}
		else
		{
			((Page)this).Session["preDiscenteAutenticado"] = "true";
			((Page)this).Session["nomePreDiscente"] = viewPreMatriculaPessoa.nomeCandidato;
			((Page)this).Session["emailPreDiscente"] = viewPreMatriculaPessoa.email;
			((Page)this).Session["preMatriculaPessoaUID"] = viewPreMatriculaPessoa.preMatriculaPessoaUID;
			((Page)this).Response.Redirect("~/aluno/FrmListaInscricao.aspx");
		}
	}
}
