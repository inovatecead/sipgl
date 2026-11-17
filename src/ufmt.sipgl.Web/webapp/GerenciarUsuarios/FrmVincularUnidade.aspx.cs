using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.GerenciarUsuarios;

public class FrmVincularUnidade : VerificaSession
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

	protected Label Label35;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtUnidadeProponente;

	protected Label lblNomeUnidade;

	protected HiddenField hddUnidadeUID;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected Button btnDesvincularUnidade;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuGerenciarUsuarios_VincularUnidadeAcademica"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		hddUsuarioUID.Value = ((Page)this).Request.QueryString["usuarioUID"];
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Gerencia ] ";
			lnkTitulo.NavigateUrl = "~/webapp/GerenciarUsuarios/FrmListar.aspx";
			lblTitulo.Text = "Vincular Unidades";
			popularDados(long.Parse(hddUsuarioUID.Value));
		}
	}

	protected void popularDados(long usuarioUID)
	{
		UsuarioBO usuarioBO = new UsuarioBO();
		UnidadeBO unidadeBO = new UnidadeBO();
		Usuario usuario = usuarioBO.BuscarUsuarioPorID(usuarioUID);
		txtNome.Text = usuario.Pessoa.nome;
		txtCPF.Text = usuario.Pessoa.cpf.FormatarCPF();
		ProjetoUsuarioUnidade projetoUsuarioUnidade = usuarioBO.BuscarVinculoUsuarioUnidade(usuarioUID);
		if (projetoUsuarioUnidade != null)
		{
			((Control)btnDesvincularUnidade).Visible = true;
			ViewUnidade unidadePorId = unidadeBO.GetUnidadePorId(projetoUsuarioUnidade.unidadeUID);
			if (unidadePorId != null)
			{
				txtUnidadeProponente.Text = unidadePorId.unidadeUID + " | " + unidadePorId.nomeConcatenado;
				hddUnidadeUID.Value = unidadePorId.unidadeUID.ToString();
			}
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			UsuarioBO usuarioBO = new UsuarioBO();
			if (!long.TryParse(txtUnidadeProponente.Text.Trim().Split(new char[1] { '|' })[0], out var result))
			{
				resultadoOperacao.TextMessage = "Unidade não foi selecionada corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtUnidadeProponente.Text = string.Empty;
				((Control)txtUnidadeProponente).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			resultadoOperacao = usuarioBO.VincularUnidades(long.Parse(hddUsuarioUID.Value), result);
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

	protected void btnDesvincularUnidade_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			resultadoOperacao = new UsuarioBO().DesvincularUnidade(long.Parse(hddUsuarioUID.Value));
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
}
