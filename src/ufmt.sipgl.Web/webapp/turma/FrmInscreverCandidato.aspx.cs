using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmInscreverCandidato : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelAcoes;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HiddenField hddPreMatriculaPessoaUID;

	protected HiddenField hddTipoOperacao;

	protected ValidationSummary ValidationSummary1;

	protected TextBox txtNomeCurso;

	protected TextBox txtNomeCandidato;

	protected TextBox txtCPF;

	protected Label lbPolo;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList ddlPolo;

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

	protected Button btnInscrever;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			hddPreMatriculaPessoaUID.Value = ((Page)this).Request.QueryString["preMatriculaPessoaUID"];
			hddTipoOperacao.Value = ((Page)this).Request.QueryString["tipoOperacao"];
			new EnderecoPoloPresencialEadDAL();
			lnkTitulo.Text = "[ Voltar para Discentes ] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Inscrição de Candidato";
			PopularDadosInscrito(int.Parse(hddPreMatriculaPessoaUID.Value), long.Parse(hddProjetoTurmaUID.Value));
			PopularDropdowns();
		}
	}

	protected void btnInscrever_Click(object sender, EventArgs e)
	{
		long.Parse(hddProjetoTurmaUID.Value);
		long preMatriculaPessoaUID = long.Parse(hddPreMatriculaPessoaUID.Value);
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		byte b = byte.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue);
		byte tipoFormaIngressoUID = byte.Parse(((ListControl)ddlTipoFormaIngresso).SelectedValue);
		byte tipoPeridoIngressoUID = byte.Parse(((ListControl)ddlTipoPeriodoIngresso).SelectedValue);
		byte tipoReservaVagasUID = byte.Parse(((ListControl)ddlTipoReservaVagas).SelectedValue);
		long num = long.Parse(((ListControl)ddlPolo).SelectedValue);
		long usuarioUID = long.Parse(((Page)this).Session["usuarioUID"].ToString());
		string text = "";
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		if ((b == 3 || b == 7) && !preMatriculaInscricaoBO.HasVagasDisponiveis(num))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Não há mais vagas disponiveis";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			PopulateMessage(resultadoOperacao);
			if (hddTipoOperacao.Value.Equals("AprovacaoPreInscricao"))
			{
				((Page)this).Response.Redirect("FrmGerenciarPreInscricao.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
			}
			((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1");
			return;
		}
		PreMatriculaInscricao preMatriculaInscricao = new PreMatriculaInscricao();
		preMatriculaInscricao.preMatriculaPessoaUID = preMatriculaPessoaUID;
		preMatriculaInscricao.tipoSituacaoInscricaoUID = b;
		preMatriculaInscricao.projetoTurmaPoloUID = num;
		text = ((txtObservacao.Text.Length < 2048) ? txtObservacao.Text : txtObservacao.Text.Substring(0, 2048));
		ProjetoDiscente projetoDiscente = new ProjetoDiscente();
		projetoDiscente.tipoFormaIngressoUID = tipoFormaIngressoUID;
		projetoDiscente.tipoPeridoIngressoUID = tipoPeridoIngressoUID;
		projetoDiscente.tipoReservaVagasUID = tipoReservaVagasUID;
		projetoDiscente.dataIngresso = DateTime.Parse(txtDataIngresso.Text);
		projetoDiscente.periodo = int.Parse(txtPeriodoIngresso.Text);
		string text2 = ((Page)this).Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = ((Page)this).Request.ServerVariables["REMOTE_ADDR"];
		}
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = ((Page)this).Request.UserHostAddress;
		}
		resultadoOperacao = new DiscenteBO().InscreverCandidato(preMatriculaInscricao, projetoDiscente, text, usuarioUID, text2);
		PopulateMessage(resultadoOperacao);
		if (resultadoOperacao.Erro)
		{
			((Page)this).Response.Redirect("FrmInscriverCandidato.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&preMatriculaPessoaUID=" + hddPreMatriculaPessoaUID.Value);
			return;
		}
		if (hddTipoOperacao.Value.Equals("AprovacaoPreInscricao"))
		{
			((Page)this).Response.Redirect("FrmGerenciarPreInscricao.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
		}
		((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1");
	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		if (hddTipoOperacao.Value.Equals("AprovacaoPreInscricao"))
		{
			((Page)this).Response.Redirect("FrmGerenciarPreInscricao.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
		}
		((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1");
	}

	private void PopularDropdowns()
	{
		DiscenteDAL discenteDAL = new DiscenteDAL();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		((BaseDataBoundControl)ddlPolo).DataSource = projetoTurmaBO.BuscarDadosPolosVinculados(long.Parse(hddProjetoTurmaUID.Value));
		((ListControl)ddlPolo).DataTextField = "IdentificacaoEndereco";
		((ListControl)ddlPolo).DataValueField = "ProjetoTurmaPoloUID";
		((Control)ddlPolo).DataBind();
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
		((BaseDataBoundControl)ddlSituacaoInscricao).DataSource = discenteDAL.ListarTiposSituacaoInscricao();
		((ListControl)ddlSituacaoInscricao).DataTextField = "nome";
		((ListControl)ddlSituacaoInscricao).DataValueField = "tipoSituacaoInscricaoUID";
		((Control)ddlSituacaoInscricao).DataBind();
	}

	public void PopularDadosInscrito(int preMatriculaPessoaUID, long projetoTurmaUID)
	{
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		PreMatriculaPessoa preMatriculaPessoa = preMatriculaPessoaBO.BuscarPreMatriculaPessoaPorID(preMatriculaPessoaUID);
		ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(projetoTurmaUID);
		txtNomeCandidato.Text = preMatriculaPessoa.nome;
		txtCPF.Text = preMatriculaPessoa.cpf.FormatarCPF();
		txtNomeCurso.Text = projetoTurma.ProjetoCurso.nomeCurso;
		txtDataIngresso.Text = $"{DateTime.Now:dd/MM/yyyy}";
	}
}
