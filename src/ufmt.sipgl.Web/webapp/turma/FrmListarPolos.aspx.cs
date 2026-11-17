using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmListarPolos : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected UpdatePanel upGeral;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelAcoes;

	protected HyperLink lnkVincularPolos;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Turma_VincularUnidades"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkVincularPolos).Visible = (listaRecursos.Contains(((Control)lnkVincularPolos).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			lnkTitulo.Text = "[ Voltar para Turmas] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Unidades Administrativas/Acadêmicas Vinculadas";
			lnkVincularPolos.NavigateUrl = "~/webapp/turma/FrmVincularPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			PreecherGridView();
		}
	}

	protected void PreecherGridView(bool visible = false)
	{
		((Control)PanelMsgResultado).Visible = visible;
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		List<ViewProjetoTurmaPolo> list = new ProjetoTurmaBO().ListarPolosPorTurma(projetoTurmaUID);
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
	}

	protected void lnkExcluir_Click(object sender, CommandEventArgs e)
	{
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		int enderecoUID = int.Parse(e.CommandArgument.ToString());
		ResultadoOperacao resultadoOperacao = new ProjetoTurmaBO().Excluir(projetoTurmaUID, enderecoUID);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType == 2)
		{
			if (DataBinder.Eval(e.Row.DataItem, "tipoUnidadeEnsino") != null)
			{
				int num = (int)DataBinder.Eval(e.Row.DataItem, "tipoUnidadeEnsino");
				Label val = (Label)((Control)e.Row).FindControl("lbTipoUnidadeEnsino");
				EnumTipoUnidadeEnsino enumTipoUnidadeEnsino = (EnumTipoUnidadeEnsino)num;
				val.Text = enumTipoUnidadeEnsino.ObterDescricao();
			}
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkAtualizar");
			LinkButton val3 = (LinkButton)((Control)e.Row).FindControl("lnkExcluirRegistro");
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains(((Control)val3).SkinID) ? true : false);
		}
	}
}
