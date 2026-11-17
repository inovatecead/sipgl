using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.View.aluno.Base;

namespace ufmt.sipgl.View;

public class FrmNovoUsuario : AlunoBase
{
	protected HyperLink HyperLink1;

	protected Panel PanelFormulario;

	protected TextBox txtcpf;

	protected TextBox txtdatanascimento;

	protected TextBox txtemail;

	protected ImageButton btSalvar;

	protected Panel panelAviso;

	protected Label lblAlerta;

	protected void Page_Load(object sender, EventArgs e)
	{
		_ = ((Page)this).IsPostBack;
	}

	protected void btSalvar_Click(object sender, ImageClickEventArgs e)
	{
		AutenticacaoBO autenticacaoBO = new AutenticacaoBO();
		try
		{
			if (autenticacaoBO.criaUsuario(txtcpf.Text, DateTime.Parse(txtdatanascimento.Text), txtemail.Text))
			{
				((Control)PanelFormulario).Visible = false;
				((Control)panelAviso).Visible = true;
				lblAlerta.Text = "Usuário Criado com Sucesso.";
			}
			else
			{
				((Control)panelAviso).Visible = true;
				lblAlerta.Text = "Erro ao criar o usuário.";
			}
		}
		catch (Exception ex)
		{
			((Control)panelAviso).Visible = true;
			lblAlerta.Text = ex.Message;
		}
	}
}
