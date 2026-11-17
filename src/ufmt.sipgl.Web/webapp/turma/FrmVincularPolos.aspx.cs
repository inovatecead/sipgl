using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmVincularPolos : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlFormularioInscricao;

	protected ValidationSummary ValidationSummary1;

	protected Label lbUnidade;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected DropDownList ddlUnidades;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtQuantidadeVagas;

	protected RegularExpressionValidator RegularExpressionValidator10;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("VincularUnidades_VincularNovaUnidade"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			lnkTitulo.Text = "[ Voltar para Unidades] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Vincular Unidades Adm./Acadêmicas";
			ListarUnidadesEnsino();
		}
	}

	public void ListarUnidadesEnsino()
	{
		EnderecoPoloPresencialEadBO enderecoPoloPresencialEadBO = new EnderecoPoloPresencialEadBO();
		((BaseDataBoundControl)ddlUnidades).DataSource = enderecoPoloPresencialEadBO.ListarTodosPolos();
		((ListControl)ddlUnidades).DataTextField = "identificacaoEndereco";
		((ListControl)ddlUnidades).DataValueField = "enderecoUID";
		((Control)ddlUnidades).DataBind();
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		int enderecoUID = int.Parse(((ListControl)ddlUnidades).SelectedValue);
		int quantidadeVagas = int.Parse(txtQuantidadeVagas.Text);
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		ResultadoOperacao resultadoOperacao = projetoTurmaBO.VincularPolo(enderecoUID, projetoTurmaUID, quantidadeVagas);
		if (!resultadoOperacao.Erro)
		{
			PopulateMessage(resultadoOperacao);
			((Page)this).Response.Redirect("FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
		}
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
	}
}
