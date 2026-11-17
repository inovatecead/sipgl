using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.vincularDisciplina;

public class FrmListar : VerificaSession
{
	private string ProjetoCursoUID;

	protected UpdatePanel upCorrigir;

	protected Repeater rpCorrecoes;

	protected UpdatePanel upGeral;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected TextBox txtCriterio;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoRegistro;

	protected HiddenField hddOperacao;

	protected HiddenField hddProjetoDisciplinaUID;

	protected HtmlGenericControl divExcluir;

	protected LinkButton lnkExcluir;

	protected HtmlImage imgExcluir;

	protected Label lblResultadoConsulta;

	protected Label lblTotalRegistros;

	protected Literal LiteralDescricaoCurso;

	protected Literal LiteralDescricaoTurma;

	protected GridView GridView1;

	protected ModalPopupExtender ModalPopupExtender1;

	protected HyperLink lnkModal;

	protected Panel PanelDetalhes;

	protected Label Label2;

	protected ImageButton ImageButton1;

	protected LinkButton LinkButtonFechar;

	protected Panel pnlChat;

	protected Repeater rpChat;

	public int? ProReitoriaUID { get; set; }

	public string Criterio { get; set; }

	private string TurmaUID { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		ProjetoCursoUID = ((Page)this).Request.QueryString["projetoCursoUID"];
		string text = ((Page)this).Request.QueryString["curso"];
		string text2 = ((Page)this).Request.QueryString["turma"];
		TurmaUID = ((Page)this).Request.QueryString["turmaUID"];
		if (!((Page)this).IsPostBack)
		{
			new DiscenteBO();
			lblResultadoConsulta.Text = "<b>Mostrando todos</b>";
			lnkTitulo.Text = "[ Voltar para Turmas ]";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?turmaUID=" + TurmaUID + "&curso=" + text + "&turma=" + text2 + "&projetoCursoUID=" + ProjetoCursoUID;
			lblTitulo.Text = "Relação de Disciplinas";
			lnkNovoRegistro.NavigateUrl = "FrmCadastrar.aspx?operacao=cadastrar&turmaUID=" + TurmaUID + "&curso=" + text + "&turma=" + text2 + "&projetoCursoUID=" + ProjetoCursoUID;
			LiteralDescricaoCurso.Text = text;
			LiteralDescricaoTurma.Text = text2;
			PreecherGridView(txtCriterio.Text, visible: false);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtCriterio.Text, visible: false);
	}

	protected void PreecherGridView(string criterio, bool visible)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		new HorarioDAL();
		List<ViewModelProjetoHorarioDocenteDisciplina> list = null;
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = list.Count + " registro(s) disponível(is)";
		if (list.Count > 0)
		{
			ImageButton val = (ImageButton)((Control)GridView1.BottomPagerRow).FindControl("cmdPrev");
			if (GridView1.PageIndex == 0)
			{
				((WebControl)val).Enabled = false;
			}
			else
			{
				((WebControl)val).Enabled = true;
			}
			((Control)divExcluir).Visible = true;
		}
		else
		{
			((Control)divExcluir).Visible = false;
		}
	}

	protected void cmdIr2_Click(object sender, ImageClickEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		TextBox val = (TextBox)((Control)GridView1.BottomPagerRow).FindControl("txtPagina");
		GridView1.PageIndex = Convert.ToInt32(val.Text) - 1;
		PreecherGridView(txtCriterio.Text, visible: false);
	}

	protected void lnkExcluirSelecionados_Click(object sender, EventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		string text = "Dados excluídos com sucesso.";
		HorarioDAL horarioDAL = new HorarioDAL();
		try
		{
			for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
			{
				new CheckBox();
				CheckBox val = (CheckBox)((Control)GridView1.Rows[i]).FindControl("chkRegistro");
				Label val2 = (Label)((Control)GridView1.Rows[i]).FindControl("lblID");
				if (val.Checked)
				{
					horarioDAL.Excluir(int.Parse(val2.Text));
				}
			}
			ScriptManager.RegisterStartupScript(this.Page, ((object)this.Page).GetType(), Guid.NewGuid().ToString(), "alert('" + text + "');", true);
		}
		catch (Exception ex)
		{
			lblMsgResultado.Text = "Não foi possível excluir o(s) registro(s) selecionado(s).  Por favor, entre em contato com o administrador do sistema.<br />" + ex.Message.ToString();
			((WebControl)PanelMsgResultado).CssClass = "error";
		}
		((Control)PanelMsgResultado).Visible = true;
		PreecherGridView(txtCriterio.Text, visible: true);
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtCriterio.Text, visible: false);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(null, visible: false);
		txtCriterio.Text = string.Empty;
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (((CommandEventArgs)e).CommandName != "Page")
		{
			DiscenteDAL discenteDAL = new DiscenteDAL();
			if (((CommandEventArgs)e).CommandName == "showCorrecoes")
			{
				List<CorrecaoPreMatriculaInscricao> correcaoPreMatriculaInscricao = discenteDAL.GetCorrecaoPreMatriculaInscricao(long.Parse(((CommandEventArgs)e).CommandArgument.ToString()));
				rpCorrecoes.DataSource = correcaoPreMatriculaInscricao;
				((Control)rpCorrecoes).DataBind();
				this.ViewState["preMatriculaInscricaoUID"] = ((CommandEventArgs)e).CommandArgument.ToString();
				upCorrigir.Update();
				ShowDialog("janelaCorrecao");
			}
			PreecherGridView(txtCriterio.Text, visible: false);
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_ = e.Row.RowType;
		_ = 2;
	}

	private void CloseDialog(string dialogId)
	{
		string text = $"closeDialog('{dialogId}')";
		ScriptManager.RegisterStartupScript((Page)(object)this, typeof(Page), this.UniqueID, text, true);
	}

	private void CarregarJQuery()
	{
		ScriptManager.RegisterClientScriptBlock((Page)(object)this, typeof(Page), this.UniqueID, "carregarJQuery()", true);
	}

	private void ShowDialog(string dialogId)
	{
		string text = $"showDialog('{dialogId}')";
		ScriptManager.RegisterClientScriptBlock((Page)(object)this, typeof(Page), this.UniqueID, text, true);
	}
}
