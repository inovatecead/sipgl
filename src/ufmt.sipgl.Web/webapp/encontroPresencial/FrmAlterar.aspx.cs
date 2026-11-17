using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.encontroPresencial;

public class FrmAlterar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoDisciplinaUID;

	protected HiddenField hddProjetoEncontroPresencialUID;

	protected HiddenField hddProjetoTurmaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Label lbTurma;

	protected TextBox txtTurma;

	protected Label lbDisciplina;

	protected TextBox txtDisciplina;

	protected Label Label2;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList ddlUnidade;

	protected Label Label17;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected TextBox txtDataEncontroPresencial;

	protected MaskedEditExtender txtDataEncontroPresencial_MaskedEditExtender;

	protected MaskedEditValidator MaskedEditValidator1;

	protected Label Label1;

	protected CheckBox ckEncontroObrigatorio;

	protected Button btnVoltar;

	protected Button btnAlterar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("EncontroPresencial_Editar"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoDisciplinaUID.Value = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
			hddProjetoEncontroPresencialUID.Value = ((Page)this).Request.QueryString["projetoEncontroPresencialUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lnkTitulo.Text = "[ Voltar para Encontros Presenciais ] ";
			lnkTitulo.NavigateUrl = "~/webapp/encontroPresencial/FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value;
			lblTitulo.Text = "Editar Encontro Presencial";
			ProjetoEncontroPresencialBO projetoEncontroPresencialBO = new ProjetoEncontroPresencialBO();
			ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
			ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
			ProjetoDisciplina projetoDisciplina = projetoDisciplinaBO.BuscarDisciplinaPorId(long.Parse(hddProjetoDisciplinaUID.Value));
			ProjetoEncontroPresencial projetoEncontroPresencial = projetoEncontroPresencialBO.BuscarEncontroPresencialPorId(long.Parse(hddProjetoEncontroPresencialUID.Value));
			ProjetoTurmaPolo projetoTurmaPolo = projetoTurmaBO.BuscarTurmaPoloPorId(projetoEncontroPresencial.projetoTurmaPoloUID);
			ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(projetoEncontroPresencial.ProjetoTurmaPolo.projetoTurmaUID);
			txtDisciplina.Text = projetoDisciplina.nome;
			txtTurma.Text = projetoTurma.nome;
			txtDataEncontroPresencial.Text = projetoEncontroPresencial.dataEncontro.ToShortDateString();
			ckEncontroObrigatorio.Checked = projetoEncontroPresencial.isObrigatorio;
			((BaseDataBoundControl)ddlUnidade).DataSource = projetoTurmaBO.ListarPolosPorTurma(projetoTurmaPolo.projetoTurmaUID);
			((ListControl)ddlUnidade).DataTextField = "identificacaoEndereco";
			((ListControl)ddlUnidade).DataValueField = "enderecoUID";
			((Control)ddlUnidade).DataBind();
			((ListControl)ddlUnidade).SelectedValue = projetoTurmaPolo.enderecoUID.ToString();
		}
	}

	protected void btnAlterar_Click(object sender, EventArgs e)
	{
		ProjetoEncontroPresencialBO projetoEncontroPresencialBO = new ProjetoEncontroPresencialBO();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		resultadoOperacao = projetoEncontroPresencialBO.AlterarEncontroPresencial(new ProjetoEncontroPresencial
		{
			projetoDisciplinaUID = long.Parse(hddProjetoDisciplinaUID.Value),
			projetoEncontroPresencialUID = long.Parse(hddProjetoEncontroPresencialUID.Value),
			dataEncontro = DateTime.Parse(txtDataEncontroPresencial.Text),
			isObrigatorio = ckEncontroObrigatorio.Checked
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
