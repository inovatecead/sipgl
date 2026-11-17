using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.GerenciarUsuarios;

public class FrmVincularPermissao : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected HiddenField hddUsuarioUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lbNome;

	protected TextBox txtNome;

	protected Label lbCPF;

	protected TextBox txtCPF;

	protected Label Label1;

	protected CheckBoxList cbxPermissoes;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuGerenciarUsuarios_VincularPermissao"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		hddUsuarioUID.Value = ((Page)this).Request.QueryString["usuarioUID"];
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Gerencia ] ";
			lnkTitulo.NavigateUrl = "~/webapp/GerenciarUsuarios/FrmListar.aspx";
			lblTitulo.Text = "Vincular Permissões";
			popularDadosUsuario(long.Parse(hddUsuarioUID.Value));
			popularCheckBoxList();
		}
	}

	protected void popularDadosUsuario(long usuarioUID)
	{
		Usuario usuario = new UsuarioBO().BuscarUsuarioPorID(usuarioUID);
		txtNome.Text = usuario.Pessoa.nome;
		txtCPF.Text = usuario.Pessoa.cpf.FormatarCPF();
	}

	protected void popularCheckBoxList()
	{
		PermissaoBO permissaoBO = new PermissaoBO();
		List<Permissao> dataSource = permissaoBO.ListarPermissoesPorAplicacao();
		List<long> list = (from e in permissaoBO.ListarPermissoesPorUsuario(long.Parse(hddUsuarioUID.Value), isAtivas: true)
			select e.permissaoUID).ToList();
		((BaseDataBoundControl)cbxPermissoes).DataSource = dataSource;
		((ListControl)cbxPermissoes).DataValueField = "permissaoUID";
		((ListControl)cbxPermissoes).DataTextField = "nome";
		((Control)cbxPermissoes).DataBind();
		for (int num = 0; num < ((ListControl)cbxPermissoes).Items.Count; num++)
		{
			if (list.Contains(long.Parse(((ListControl)cbxPermissoes).Items[num].Value)))
			{
				((ListControl)cbxPermissoes).Items[num].Selected = true;
			}
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			List<long> list = new List<long>();
			for (int i = 0; i < ((ListControl)cbxPermissoes).Items.Count; i++)
			{
				if (((ListControl)cbxPermissoes).Items[i].Selected)
				{
					list.Add(long.Parse(((ListControl)cbxPermissoes).Items[i].Value));
				}
			}
			resultadoOperacao = new PermissaoBO().VincularPermissoes(list, long.Parse(hddUsuarioUID.Value));
			if (!resultadoOperacao.Erro)
			{
				PopulateMessage(resultadoOperacao);
				((Page)this).Response.Redirect("FrmListar.aspx");
			}
		}
		catch (Exception)
		{
			resultadoOperacao.TextMessage = "Não foi possível efetuar a operação. Por favor, entre em contato com o administrador do sistema.";
		}
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx");
	}
}
