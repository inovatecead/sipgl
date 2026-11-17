using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sig.entity;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmListar : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected UpdatePanel UpdatePanel1;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lbCurso;

	protected TextBox txtCriterio;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoRegistro;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuCursos_Turmas"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkNovoRegistro).Visible = (listaRecursos.Contains(((Control)lnkNovoRegistro).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			lnkTitulo.Text = "[ Voltar para Cursos] ";
			lnkTitulo.NavigateUrl = "~/webapp/projeto/FrmListar.aspx";
			lblTitulo.Text = "Turmas";
			lnkNovoRegistro.NavigateUrl = "~/webapp/turma/FrmCadastrar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value;
			PreecherGridView(long.Parse(hddProjetoCursoUID.Value), txtCriterio.Text, visible: false);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(long.Parse(hddProjetoCursoUID.Value), txtCriterio.Text, visible: false);
	}

	protected void PreecherGridView(long projetoCursoUID, string nome, bool visible)
	{
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected Obj, but got Unknown
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		AutenticacaoBO autenticacaoBO = new AutenticacaoBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		long usuarioUID = (long)((Page)this).Session["usuarioUID"];
		List<ProjetoTurma> list = projetoTurmaBO.FiltrarTurma(projetoCursoUID, nome);
		List<long> list2 = (List<long>)((Page)this).Session["listaPerfis"];
		if (list2.Contains(58L) || list2.Contains(59L) || list2.Contains(60L) || list2.Contains(61L) || list2.Contains(127L))
		{
			((BaseDataBoundControl)GridView1).DataSource = list;
		}
		else if (list2.Contains(119L))
		{
			ufmt.sig.entity.Usuario usuario = autenticacaoBO.GetUsuario(usuarioUID);
			List<long> listaProjetoCorpoDocenteUID = projetoCorpoDocenteBO.BucarListaProjetoCorpoDocentesUID(usuario.Pessoa.Cpf);
			((BaseDataBoundControl)GridView1).DataSource = list.Where((ProjetoTurma c) => c.ProjetoTurmaDisciplina.Any((ProjetoTurmaDisciplina w) => listaProjetoCorpoDocenteUID.Contains(w.projetoCorpoDocenteUID) || listaProjetoCorpoDocenteUID.Contains(w.projetoCorpoDocenteSecundarioUID.GetValueOrDefault()))).ToList();
		}
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count >= 10 && GridView1.Rows.Count > 0)
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
		PreecherGridView(long.Parse(hddProjetoCursoUID.Value), txtCriterio.Text, visible: false);
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(long.Parse(hddProjetoCursoUID.Value), txtCriterio.Text, visible: false);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		txtCriterio.Text = string.Empty;
		PreecherGridView(long.Parse(hddProjetoCursoUID.Value), txtCriterio.Text, visible: false);
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (((CommandEventArgs)e).CommandName != "Page")
		{
			int num = Convert.ToInt32(((CommandEventArgs)e).CommandArgument);
			_ = GridView1.Rows[num];
			GridView1.DataKeys[num].Value.ToString();
			_ = string.Empty;
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType == 2)
		{
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkAtualizarTurma");
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkVincularPolos");
			HyperLink val3 = (HyperLink)((Control)e.Row).FindControl("lnkListarDiscentes");
			HyperLink val4 = (HyperLink)((Control)e.Row).FindControl("lnkDisciplina");
			HyperLink val5 = (HyperLink)((Control)e.Row).FindControl("lnkNotas");
			HyperLink val6 = (HyperLink)((Control)e.Row).FindControl("lnkFrequencia");
			((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains(((Control)val3).SkinID) ? true : false);
			((Control)val4).Visible = (listaRecursos.Contains(((Control)val4).SkinID) ? true : false);
			((Control)val5).Visible = (listaRecursos.Contains(((Control)val5).SkinID) ? true : false);
			((Control)val6).Visible = (listaRecursos.Contains(((Control)val6).SkinID) ? true : false);
			((Label)((Control)e.Row).FindControl("lbStatus")).Text = (bool.Parse(DataBinder.Eval(e.Row.DataItem, "isAtivo").ToString()) ? "Ativo" : "Inativo");
			Label val7 = (Label)((Control)e.Row).FindControl("lbTurno");
			int num = int.Parse(DataBinder.Eval(e.Row.DataItem, "turno").ToString());
			val7.Text = ((EnumTurnoOferta)num).ObterDescricao();
		}
	}
}
