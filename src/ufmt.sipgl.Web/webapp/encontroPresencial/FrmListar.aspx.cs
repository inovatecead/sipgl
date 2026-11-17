using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.encontroPresencial;

public class FrmListar : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoDisciplinaUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label Label2;

	protected DropDownList ddlUnidade;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoRegistro;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("GerenciarDisciplinas_EncontroPresencial"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkNovoRegistro).Visible = (listaRecursos.Contains(((Control)lnkNovoRegistro).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoDisciplinaUID.Value = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lblTitulo.Text = "Relação de Encontros Presenciais";
			lnkTitulo.Text = "[ Voltar para Disciplinas ]";
			lnkTitulo.NavigateUrl = "~/webapp/turmaDisciplina/FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value;
			lnkNovoRegistro.NavigateUrl = "FrmCadastrar.aspx?projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value;
			PopularDropdowns();
			PreecherGridView(long.Parse(hddProjetoDisciplinaUID.Value), long.Parse(hddProjetoTurmaUID.Value), null, visible: false);
		}
	}

	private void PopularDropdowns()
	{
		List<ViewProjetoTurmaPolo> dataSource = new ProjetoTurmaBO().ListarPolosPorTurma(long.Parse(hddProjetoTurmaUID.Value));
		((BaseDataBoundControl)ddlUnidade).DataSource = dataSource;
		((ListControl)ddlUnidade).DataTextField = "identificacaoEndereco";
		((ListControl)ddlUnidade).DataValueField = "enderecoUID";
		((Control)ddlUnidade).DataBind();
	}

	protected void PreecherGridView(long projetoDisciplinaUID, long projetoTurmaUID, int? enderecoUID, bool visible)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		List<ViewProjetoEncontroPresencial> list = new ProjetoEncontroPresencialBO().FiltrarEncontroPresencialPorDisciplinaTurmaPolo(projetoDisciplinaUID, projetoTurmaUID, enderecoUID);
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

	protected void lnkExcluirRegistro_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long projetoEncontroPresencialUID = long.Parse(((LinkButton)sender).CommandArgument.ToString());
		ResultadoOperacao resultadoOperacao = new ProjetoEncontroPresencialBO().Excluir(projetoEncontroPresencialUID);
		long projetoDisciplinaUID = long.Parse(hddProjetoDisciplinaUID.Value);
		int? enderecoUID = null;
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlUnidade).SelectedValue))
		{
			enderecoUID = int.Parse(((ListControl)ddlUnidade).SelectedValue);
		}
		PreecherGridView(projetoDisciplinaUID, long.Parse(hddProjetoTurmaUID.Value), enderecoUID, visible: false);
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		long projetoDisciplinaUID = long.Parse(hddProjetoDisciplinaUID.Value);
		int? enderecoUID = null;
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlUnidade).SelectedValue))
		{
			enderecoUID = int.Parse(((ListControl)ddlUnidade).SelectedValue);
		}
		PreecherGridView(projetoDisciplinaUID, long.Parse(hddProjetoTurmaUID.Value), enderecoUID, visible: false);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		((ListControl)ddlUnidade).Items.Clear();
		((ListControl)ddlUnidade).Items.Add(new ListItem("Selecione...", ""));
		((ListControl)ddlUnidade).SelectedValue = "";
		PopularDropdowns();
		PreecherGridView(long.Parse(hddProjetoDisciplinaUID.Value), long.Parse(hddProjetoTurmaUID.Value), null, visible: false);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkAtualizarRegistro");
			LinkButton val2 = (LinkButton)((Control)e.Row).FindControl("lnkExcluirRegistro");
			((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
		}
	}
}
