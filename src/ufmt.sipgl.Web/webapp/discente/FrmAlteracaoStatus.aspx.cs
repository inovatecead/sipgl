using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.discente;

public class FrmAlteracaoStatus : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelAcoes;

	protected HiddenField hddPreMatriculaInscricaoUID;

	protected HiddenField hddProjetoPoloCursoUID;

	protected HiddenField hddPreMatriculaPessoaUID;

	protected ValidationSummary ValidationSummary1;

	protected TextBox txtPolo;

	protected TextBox txtNomeCurso;

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

	protected Label lblTipoReservaVagas;

	protected RequiredFieldValidator RequiredFieldReservaVagas;

	protected DropDownList ddlTipoReservaVagas;

	protected Label lblObservacao;

	protected TextBox txtObservacao;

	protected Button btnAlterarSituacao;

	protected Button btnCancelar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			hddProjetoPoloCursoUID.Value = ((Page)this).Request.QueryString["projetoPoloCursoUID"];
			hddPreMatriculaInscricaoUID.Value = ((Page)this).Request.QueryString["preMatriculaInscricaoUID"];
			lnkTitulo.Text = "[ Voltar para Discentes ] ";
			lnkTitulo.NavigateUrl = "~/webapp/discente/FrmListar.aspx?projetoPoloCursoUID=" + hddProjetoPoloCursoUID.Value;
			lblTitulo.Text = "Alterar Situação do Discente";
			DiscenteDAL discenteDAL = new DiscenteDAL();
			new EnderecoPoloPresencialEadDAL();
			PreMatriculaInscricao preMatriculaInscricao = discenteDAL.BuscarPreMatriculaInscricao(long.Parse(hddPreMatriculaInscricaoUID.Value));
			hddPreMatriculaPessoaUID.Value = preMatriculaInscricao.preMatriculaPessoaUID.ToString();
		}
	}

	protected void btnAlterarSituacao_Click(object sender, EventArgs e)
	{
		byte tipoSituacaoInscricaoUID = byte.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue);
		byte tipoFormaIngressoUID = byte.Parse(((ListControl)ddlTipoFormaIngresso).SelectedValue);
		byte tipoPeridoIngressoUID = byte.Parse(((ListControl)ddlTipoPeriodoIngresso).SelectedValue);
		byte tipoReservaVagasUID = byte.Parse(((ListControl)ddlTipoPeriodoIngresso).SelectedValue);
		DateTime dataIngresso = DateTime.Parse(txtDataIngresso.Text);
		long.Parse(((Page)this).Session["usuarioUID"].ToString());
		new PreMatriculaInscricao
		{
			preMatriculaInscricaoUID = int.Parse(hddPreMatriculaInscricaoUID.Value),
			tipoSituacaoInscricaoUID = tipoSituacaoInscricaoUID
		};
		if ("".Length >= 2048)
		{
			txtObservacao.Text.Substring(0, 2048);
		}
		else
		{
			_ = txtObservacao.Text;
		}
		new ProjetoDiscente
		{
			tipoFormaIngressoUID = tipoFormaIngressoUID,
			tipoPeridoIngressoUID = tipoPeridoIngressoUID,
			tipoReservaVagasUID = tipoReservaVagasUID,
			dataIngresso = dataIngresso
		};
		new DiscenteDAL();
		((Page)this).Response.Redirect("FrmListar.aspx?&projetoPoloCursoUID= " + hddProjetoPoloCursoUID.Value);
	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx?&projetoPoloCursoUID= " + hddProjetoPoloCursoUID.Value);
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
		txtCPF.Text = preMatriculaInscricao.PreMatriculaPessoa.cpf;
		txtPolo.Text = municipio;
		txtNomeCurso.Text = nomeCurso;
		if (projetoDiscente != null)
		{
			txtDataIngresso.Text = $"{projetoDiscente.dataIngresso:dd/MM/yyyy}";
		}
	}
}
