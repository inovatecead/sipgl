using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmAlteracaoSituacao : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelAcoes;

	protected HiddenField hddPreMatriculaInscricaoUID;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HiddenField hddDDLPolo;

	protected HiddenField hddDDLTipoSituacaoInscricao;

	protected HiddenField hddPage;

	protected ValidationSummary ValidationSummary1;

	protected TextBox txtNomeCurso;

	protected TextBox txtPolo;

	protected TextBox txtNomeCandidato;

	protected TextBox txtCPF;

	protected Label lblTipoSituacaoInscricao;

	protected RequiredFieldValidator RequiredFieldTipoSituacaoInscricao;

	protected DropDownList ddlSituacaoInscricao;

	protected Label lblTipoFormaIngresso;

	protected RequiredFieldValidator RequiredFieldFormaIngresso;

	protected DropDownList ddlTipoFormaIngresso;

	protected Label lblDataIngresso;

	protected RequiredFieldValidator RequiredFieldDataIngresso;

	protected TextBox txtDataIngresso;

	protected CalendarExtender txtDataIngresso_CalendarExtender;

	protected MaskedEditExtender txtDataIngresso_MaskedEditExtender;

	protected MaskedEditValidator MEVData2;

	protected Label lblTipoPeriodoIngresso;

	protected RequiredFieldValidator RequiredFieldPeriodoIngresso;

	protected DropDownList ddlTipoPeriodoIngresso;

	protected Label lbPeriodoIngresso;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtPeriodoIngresso;

	protected MaskedEditExtender MaskedEditExtender1;

	protected Label lblTipoReservaVagas;

	protected RequiredFieldValidator RequiredFieldReservaVagas;

	protected DropDownList ddlTipoReservaVagas;

	protected Label lblObservacao;

	protected TextBox txtObservacao;

	protected Button btnAlterarSituacao;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Discentes_EditarSituacao"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			hddPreMatriculaInscricaoUID.Value = ((Page)this).Request.QueryString["preMatriculaInscricaoUID"];
			hddDDLPolo.Value = ((Page)this).Request.QueryString["ddlPolo"];
			hddDDLTipoSituacaoInscricao.Value = ((Page)this).Request.QueryString["ddlTipoSituacaoInscricao"];
			hddPage.Value = ((Page)this).Request.QueryString["page"];
			lnkTitulo.Text = "[ Voltar para Discentes ] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Alterar Situação do Discente";
			DiscenteDAL discenteDAL = new DiscenteDAL();
			ProjetoBO projetoBO = new ProjetoBO();
			new EnderecoPoloPresencialEadDAL();
			PreMatriculaInscricao preMatriculaInscricao = discenteDAL.BuscarPreMatriculaInscricao(long.Parse(hddPreMatriculaInscricaoUID.Value));
			ProjetoDiscente projetoDiscente = discenteDAL.BuscarDiscentePorMatriculaInscricao(long.Parse(hddPreMatriculaInscricaoUID.Value));
			ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
			PopularDadosInscrito(preMatriculaInscricao, projetoDiscente, registroPorId.nomeCurso, preMatriculaInscricao.ProjetoTurmaPolo.EnderecoPoloApoioPresencialEAD.identificacaoEndereco);
			PopularDropdowns(preMatriculaInscricao, projetoDiscente);
		}
	}

	protected void btnAlterarSituacao_Click(object sender, EventArgs e)
	{
		byte tipoSituacaoInscricaoUID = byte.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue);
		byte tipoFormaIngressoUID = byte.Parse(((ListControl)ddlTipoFormaIngresso).SelectedValue);
		byte tipoPeridoIngressoUID = byte.Parse(((ListControl)ddlTipoPeriodoIngresso).SelectedValue);
		byte tipoReservaVagasUID = byte.Parse(((ListControl)ddlTipoReservaVagas).SelectedValue);
		DateTime dataIngresso = DateTime.Parse(txtDataIngresso.Text);
		int periodo = int.Parse(txtPeriodoIngresso.Text);
		string text = "";
		long usuarioUID = long.Parse(((Page)this).Session["usuarioUID"].ToString());
		PreMatriculaInscricao preMatriculaInscricao = new PreMatriculaInscricao();
		preMatriculaInscricao.preMatriculaInscricaoUID = int.Parse(hddPreMatriculaInscricaoUID.Value);
		preMatriculaInscricao.tipoSituacaoInscricaoUID = tipoSituacaoInscricaoUID;
		text = ((txtObservacao.Text.Length < 2048) ? txtObservacao.Text : txtObservacao.Text.Substring(0, 2048));
		ProjetoDiscente projetoDiscente = new ProjetoDiscente();
		projetoDiscente.tipoFormaIngressoUID = tipoFormaIngressoUID;
		projetoDiscente.tipoPeridoIngressoUID = tipoPeridoIngressoUID;
		projetoDiscente.tipoReservaVagasUID = tipoReservaVagasUID;
		projetoDiscente.dataIngresso = dataIngresso;
		projetoDiscente.periodo = periodo;
		DiscenteDAL discenteDAL = new DiscenteDAL();
		string text2 = ((Page)this).Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = ((Page)this).Request.ServerVariables["REMOTE_ADDR"];
		}
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = ((Page)this).Request.UserHostAddress;
		}
		ResultadoOperacao resultadoOperacao = discenteDAL.AlterarSituacao(preMatriculaInscricao, projetoDiscente, text, usuarioUID, text2);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1&ddlPolo=" + hddDDLPolo.Value + "&ddlTipoSituacaoInscricao=" + hddDDLTipoSituacaoInscricao.Value + "&page=" + hddPage.Value);
	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1&ddlPolo=" + hddDDLPolo.Value + "&ddlTipoSituacaoInscricao=" + hddDDLTipoSituacaoInscricao.Value + "&page=" + hddPage.Value);
	}

	private void PopularDropdowns(PreMatriculaInscricao preMatriculaInscricao, ProjetoDiscente projetoDiscente)
	{
		DiscenteDAL discenteDAL = new DiscenteDAL();
		((BaseDataBoundControl)ddlTipoFormaIngresso).DataSource = discenteDAL.GetTipoFormaIngresso();
		((ListControl)ddlTipoFormaIngresso).DataTextField = "nome";
		((ListControl)ddlTipoFormaIngresso).DataValueField = "tipoFormaIngressoUID";
		((Control)ddlTipoFormaIngresso).DataBind();
		((BaseDataBoundControl)ddlTipoPeriodoIngresso).DataSource = discenteDAL.GetTipoPeriodoIngresso();
		((ListControl)ddlTipoPeriodoIngresso).DataTextField = "regime";
		((ListControl)ddlTipoPeriodoIngresso).DataValueField = "tipoPeriodoIngressoUID";
		((Control)ddlTipoPeriodoIngresso).DataBind();
		((BaseDataBoundControl)ddlTipoReservaVagas).DataSource = discenteDAL.GetTipoReservaVagas();
		((ListControl)ddlTipoReservaVagas).DataTextField = "nome";
		((ListControl)ddlTipoReservaVagas).DataValueField = "tipoReservaVagasUID";
		((Control)ddlTipoReservaVagas).DataBind();
		if (projetoDiscente != null)
		{
			((ListControl)ddlTipoFormaIngresso).SelectedValue = projetoDiscente.tipoFormaIngressoUID.ToString();
			((ListControl)ddlTipoPeriodoIngresso).SelectedValue = projetoDiscente.tipoPeridoIngressoUID.ToString();
			((ListControl)ddlTipoReservaVagas).SelectedValue = projetoDiscente.tipoReservaVagasUID.ToString();
		}
		((BaseDataBoundControl)ddlSituacaoInscricao).DataSource = discenteDAL.ListarTiposSituacaoInscricao();
		((ListControl)ddlSituacaoInscricao).DataTextField = "nome";
		((ListControl)ddlSituacaoInscricao).DataValueField = "tipoSituacaoInscricaoUID";
		((Control)ddlSituacaoInscricao).DataBind();
		((ListControl)ddlSituacaoInscricao).SelectedValue = preMatriculaInscricao.tipoSituacaoInscricaoUID.ToString();
	}

	public void PopularDadosInscrito(PreMatriculaInscricao preMatriculaInscricao, ProjetoDiscente projetoDiscente, string nomeCurso, string municipio)
	{
		txtNomeCandidato.Text = preMatriculaInscricao.PreMatriculaPessoa.nome;
		txtCPF.Text = preMatriculaInscricao.PreMatriculaPessoa.cpf.FormatarCPF();
		txtPolo.Text = municipio;
		txtNomeCurso.Text = nomeCurso;
		if (projetoDiscente != null)
		{
			txtDataIngresso.Text = $"{projetoDiscente.dataIngresso:dd/MM/yyyy}";
			txtPeriodoIngresso.Text = projetoDiscente.periodo.ToString();
		}
	}
}
