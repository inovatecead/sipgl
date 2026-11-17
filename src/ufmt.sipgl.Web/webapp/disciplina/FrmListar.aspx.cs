using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.disciplina;

public class FrmListar : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected TextBox txtCriterio;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoRegistro;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		((Control)lnkNovoRegistro).Visible = (listaRecursos.Contains(((Control)lnkNovoRegistro).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			ProjetoCurso projetoCurso = new ProjetoDAL().BuscarProjetoCurso(long.Parse(hddProjetoCursoUID.Value));
			lblTitulo.Text = "Relação de Disciplinas do Curso " + projetoCurso.nomeCurso;
			lnkTitulo.Text = "[ Voltar para Cursos ]";
			lnkTitulo.NavigateUrl = "~/webapp/projeto/FrmListar.aspx";
			lnkNovoRegistro.NavigateUrl = "FrmCadastrar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value;
			PreecherGridView(txtCriterio.Text, visible: false);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtCriterio.Text, visible: false);
	}

	protected void PreecherGridView(string nome, bool visible)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		new DisciplinaDAL();
		List<ProjetoDisciplina> list = projetoDisciplinaBO.Filtrar(long.Parse(hddProjetoCursoUID.Value), nome);
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
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

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtCriterio.Text, visible: false);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(null, visible: false);
		txtCriterio.Text = string.Empty;
	}

	protected void lnkExcluir_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long projetoDisciplinaUID = long.Parse(((LinkButton)sender).CommandArgument.ToString());
		ResultadoOperacao resultadoOperacao = new ProjetoDisciplinaBO().Excluir(projetoDisciplinaUID);
		PreecherGridView("", visible: false);
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2 && DataBinder.Eval(e.Row.DataItem, "tipoDisciplina") != null)
		{
			int num = (int)DataBinder.Eval(e.Row.DataItem, "tipoDisciplina");
			Label val = (Label)((Control)e.Row).FindControl("lbTipoDisciplina");
			EnumTipoDisciplina enumTipoDisciplina = (EnumTipoDisciplina)num;
			val.Text = enumTipoDisciplina.ObterDescricao();
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkAtualizarRegistro");
			LinkButton val3 = (LinkButton)((Control)e.Row).FindControl("lnkExcluirRegistro");
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains(((Control)val3).SkinID) ? true : false);
		}
	}
}
