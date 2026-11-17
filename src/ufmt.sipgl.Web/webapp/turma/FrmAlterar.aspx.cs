using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmAlterar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtNome;

	protected Label Label6;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected TextBox txtAno;

	protected RegularExpressionValidator RegularExpressionValidator9;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtPeriodo;

	protected RegularExpressionValidator RegularExpressionValidator10;

	protected Label lbTurno;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected DropDownList ddlTurno;

	protected Label lbDataInicio;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtDataInicio;

	protected MaskedEditExtender txtDataInicio_MaskedEditExtender;

	protected MaskedEditValidator txtDataInicio_MaskedEditValidator;

	protected Label lbDataFim;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtDataFim;

	protected MaskedEditExtender txtDataFim_MaskedEditExtender;

	protected MaskedEditValidator txtDataFim_MaskedEditValidator;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected DropDownList ddlStatusTurma;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Turma_EditarTurma"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lnkTitulo.Text = "[ Voltar para Turmas ] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = " Editar Turma";
			ProjetoTurma projetoTurma = new ProjetoTurmaBO().BuscarTurma(long.Parse(hddProjetoTurmaUID.Value));
			popularDropdown();
			txtNome.Text = projetoTurma.nome;
			txtAno.Text = projetoTurma.ano.ToString();
			txtPeriodo.Text = projetoTurma.periodo.ToString();
			((ListControl)ddlTurno).SelectedValue = projetoTurma.turno.ToString();
			txtDataInicio.Text = projetoTurma.DataInicio.GetValueOrDefault().ToShortDateString();
			txtDataFim.Text = projetoTurma.DataFim.GetValueOrDefault().ToShortDateString();
			((ListControl)ddlStatusTurma).SelectedValue = (projetoTurma.isAtivo ? "1" : "0");
		}
	}

	protected void popularDropdown()
	{
		((BaseDataBoundControl)ddlTurno).DataSource = EnumService.EnumList(typeof(EnumTurnoOferta));
		((ListControl)ddlTurno).DataValueField = "key";
		((ListControl)ddlTurno).DataTextField = "value";
		((Control)ddlTurno).DataBind();
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			resultadoOperacao = new ProjetoTurmaBO().Alterar(new ProjetoTurma
			{
				projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value),
				nome = txtNome.Text,
				ano = int.Parse(txtAno.Text),
				periodo = byte.Parse(txtPeriodo.Text),
				turno = byte.Parse(((ListControl)ddlTurno).SelectedValue),
				DataInicio = DateTime.Parse(txtDataInicio.Text),
				DataFim = DateTime.Parse(txtDataFim.Text),
				isAtivo = !(((ListControl)ddlStatusTurma).SelectedValue == "0")
			});
			if (!resultadoOperacao.Erro)
			{
				PopulateMessage(resultadoOperacao);
				((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value);
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
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value);
	}
}
