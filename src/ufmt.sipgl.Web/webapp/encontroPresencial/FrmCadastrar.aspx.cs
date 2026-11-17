using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.encontroPresencial;

public class FrmCadastrar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoDisciplinaUID;

	protected HiddenField hddProjetoTurmaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Label Label27;

	protected TextBox txtTurma;

	protected Label lbDisciplina;

	protected TextBox txtDisciplina;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList ddlUnidade;

	protected Label Label17;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtDataEncontroPresencial;

	protected MaskedEditExtender txtDataEncontroPresencial_MaskedEditExtender;

	protected MaskedEditValidator MaskedEditValidator1;

	protected CheckBox ckEncontroObrigatorio;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("EncontroPresencial_NovoEncontro"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoDisciplinaUID.Value = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lnkTitulo.Text = "[ Voltar para Encontros Presenciais ] ";
			lnkTitulo.NavigateUrl = "~/webapp/encontroPresencial/FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value;
			lblTitulo.Text = "Novo Encontro Presencial";
			ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
			ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
			ProjetoDisciplina projetoDisciplina = projetoDisciplinaBO.BuscarDisciplinaPorId(long.Parse(hddProjetoDisciplinaUID.Value));
			ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(long.Parse(hddProjetoTurmaUID.Value));
			txtTurma.Text = projetoTurma.nome;
			txtDisciplina.Text = projetoDisciplina.nome;
			List<ViewProjetoTurmaPolo> dataSource = projetoTurmaBO.ListarPolosPorTurma(long.Parse(hddProjetoTurmaUID.Value));
			((BaseDataBoundControl)ddlUnidade).DataSource = dataSource;
			((ListControl)ddlUnidade).DataTextField = "identificacaoEndereco";
			((ListControl)ddlUnidade).DataValueField = "enderecoUID";
			((Control)ddlUnidade).DataBind();
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ProjetoEncontroPresencialBO projetoEncontroPresencialBO = new ProjetoEncontroPresencialBO();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		resultadoOperacao = projetoEncontroPresencialBO.CadastrarEncontroPresencial(new ProjetoEncontroPresencial
		{
			dataEncontro = DateTime.Parse(txtDataEncontroPresencial.Text),
			isObrigatorio = ckEncontroObrigatorio.Checked,
			projetoDisciplinaUID = long.Parse(hddProjetoDisciplinaUID.Value)
		}, long.Parse(hddProjetoTurmaUID.Value), int.Parse(((ListControl)ddlUnidade).SelectedValue));
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value);
	}
}
