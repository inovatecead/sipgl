using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmGerenciarPreInscricao : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelFiltro;

	protected Label lbFiltroNome;

	protected TextBox txtNome;

	protected Label lbFiltroCPF;

	protected TextBox txtCPF;

	protected Label Label2;

	protected DropDownList ddlSituacaoPreInscricao;

	protected LinkButton lnkConsultar;

	protected Panel PanelAcoes;

	protected Label lblTotalRegistros;

	protected GridView GridViewPreInscritos;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Discentes_GerenciarPreInscricao"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lnkTitulo.Text = "[ Voltar para Discentes ]";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1";
			lblTitulo.Text = "Gerenciar Pré-Inscrições";
			((BaseDataBoundControl)GridViewPreInscritos).DataSource = new List<ProjetoPreInscricao>();
			((Control)GridViewPreInscritos).DataBind();
			((BaseDataBoundControl)ddlSituacaoPreInscricao).DataSource = EnumService.EnumList(typeof(EnumSituacaoPreInscricao));
			((ListControl)ddlSituacaoPreInscricao).DataValueField = "key";
			((ListControl)ddlSituacaoPreInscricao).DataTextField = "value";
			((Control)ddlSituacaoPreInscricao).DataBind();
			PreecherGridView(long.Parse(hddProjetoTurmaUID.Value), string.Empty, string.Empty, null);
		}
	}

	protected void PreecherGridView(long projetoTurmaUID, string nome, string cpf, int? situacaoPreInscricao)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		ProjetoPreInscricaoBO projetoPreInscricaoBO = new ProjetoPreInscricaoBO();
		List<ProjetoPreInscricao> list = null;
		list = projetoPreInscricaoBO.ListarPreInscricoesPorTurma(projetoTurmaUID, txtNome.Text, txtCPF.Text, situacaoPreInscricao);
		foreach (ProjetoPreInscricao item in list)
		{
			item.PreMatriculaPessoa.cpf = item.PreMatriculaPessoa.cpf.FormatarCPF();
		}
		((BaseDataBoundControl)GridViewPreInscritos).DataSource = list;
		((Control)GridViewPreInscritos).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count > 0)
		{
			ImageButton val = (ImageButton)((Control)GridViewPreInscritos.BottomPagerRow).FindControl("cmdPrev");
			if (GridViewPreInscritos.PageIndex == 0)
			{
				((WebControl)val).Enabled = false;
			}
			else
			{
				((WebControl)val).Enabled = true;
			}
		}
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		int? situacaoPreInscricao = (string.IsNullOrEmpty(((ListControl)ddlSituacaoPreInscricao).SelectedValue) ? ((int?)null) : new int?(int.Parse(((ListControl)ddlSituacaoPreInscricao).SelectedValue)));
		PreecherGridView(long.Parse(hddProjetoTurmaUID.Value), txtNome.Text, txtCPF.Text, situacaoPreInscricao);
	}

	protected void cmdIr2_Click(object sender, ImageClickEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		TextBox val = (TextBox)((Control)GridViewPreInscritos.BottomPagerRow).FindControl("txtPagina");
		GridViewPreInscritos.PageIndex = Convert.ToInt32(val.Text) - 1;
		int? situacaoPreInscricao = (string.IsNullOrEmpty(((ListControl)ddlSituacaoPreInscricao).SelectedValue) ? ((int?)null) : new int?(int.Parse(((ListControl)ddlSituacaoPreInscricao).SelectedValue)));
		PreecherGridView(long.Parse(hddProjetoTurmaUID.Value), txtNome.Text, txtCPF.Text, situacaoPreInscricao);
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridViewPreInscritos.PageIndex = e.NewPageIndex;
		int? situacaoPreInscricao = (string.IsNullOrEmpty(((ListControl)ddlSituacaoPreInscricao).SelectedValue) ? ((int?)null) : new int?(int.Parse(((ListControl)ddlSituacaoPreInscricao).SelectedValue)));
		PreecherGridView(long.Parse(hddProjetoTurmaUID.Value), txtNome.Text, txtCPF.Text, situacaoPreInscricao);
	}

	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		_ = e.Row.RowType;
		_ = 2;
	}

	protected void lnkAprovarPreInscricao_Click(object sender, CommandEventArgs e)
	{
		long projetoPreInscricaoUID = long.Parse(e.CommandArgument.ToString());
		long.Parse(hddProjetoTurmaUID.Value);
		long.Parse(hddProjetoCursoUID.Value);
		ProjetoPreInscricaoBO projetoPreInscricaoBO = new ProjetoPreInscricaoBO();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (projetoPreInscricaoBO.ValidarPreInscricaoPorSituacao(projetoPreInscricaoUID, EnumSituacaoPreInscricao.APROVADO))
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Pré-Inscrição já se encontra Aprovada.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			PopularMensagemRegraNegocio(resultadoOperacao);
			int? situacaoPreInscricao = (string.IsNullOrEmpty(((ListControl)ddlSituacaoPreInscricao).SelectedValue) ? ((int?)null) : new int?(int.Parse(((ListControl)ddlSituacaoPreInscricao).SelectedValue)));
			PreecherGridView(long.Parse(hddProjetoTurmaUID.Value), txtNome.Text, txtCPF.Text, situacaoPreInscricao);
		}
		else
		{
			ProjetoPreInscricao projetoPreInscricao = projetoPreInscricaoBO.BuscarPreInscricaoPorUID(projetoPreInscricaoUID);
			((Page)this).Response.Redirect("~/webapp/turma/FrmInscreverCandidato.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&preMatriculaPessoaUID=" + projetoPreInscricao.PreMatriculaPessoa.preMatriculaPessoaUID + "&tipoOperacao=AprovacaoPreInscricao");
		}
	}

	protected void lnkCancelarPreInscricao_Click(object sender, CommandEventArgs e)
	{
		long projetoPreInscricaoUID = long.Parse(e.CommandArgument.ToString());
		long.Parse(hddProjetoTurmaUID.Value);
		long usuarioUID = long.Parse(((Page)this).Session["usuarioUID"].ToString());
		ProjetoPreInscricaoBO projetoPreInscricaoBO = new ProjetoPreInscricaoBO();
		string text = ((Page)this).Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
		if (string.IsNullOrWhiteSpace(text))
		{
			text = ((Page)this).Request.ServerVariables["REMOTE_ADDR"];
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = ((Page)this).Request.UserHostAddress;
		}
		ResultadoOperacao resultadoOperacao = projetoPreInscricaoBO.CancelarPreInscricao(projetoPreInscricaoUID, usuarioUID, text);
		PopularMensagemRegraNegocio(resultadoOperacao);
		int? situacaoPreInscricao = (string.IsNullOrEmpty(((ListControl)ddlSituacaoPreInscricao).SelectedValue) ? ((int?)null) : new int?(int.Parse(((ListControl)ddlSituacaoPreInscricao).SelectedValue)));
		PreecherGridView(long.Parse(hddProjetoTurmaUID.Value), txtNome.Text, txtCPF.Text, situacaoPreInscricao);
	}

	protected void GridViewPreInscritos_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType != 2)
		{
			return;
		}
		long projetoPreInscricaoUID = ((ProjetoPreInscricao)e.Row.DataItem).projetoPreInscricaoUID;
		LinkButton val = (LinkButton)((Control)e.Row).FindControl("lnkAprovarPreInscricao");
		LinkButton val2 = (LinkButton)((Control)e.Row).FindControl("lnkCancelarPreInscricao");
		((Control)val).Visible = false;
		((Control)val2).Visible = false;
		bool flag = (listaRecursos.Contains("GerenciarPreInscricao_Aprovar") ? true : false);
		bool flag2 = (listaRecursos.Contains("GerenciarPreInscricao_Cancelar") ? true : false);
		bool flag3 = false;
		bool flag4 = false;
		ProjetoPreInscricaoBO projetoPreInscricaoBO = new ProjetoPreInscricaoBO();
		if (projetoPreInscricaoBO.ValidarPreInscricaoPorSituacao(projetoPreInscricaoUID, EnumSituacaoPreInscricao.CANCELADO))
		{
			flag3 = true;
		}
		if (projetoPreInscricaoBO.ValidarPreInscricaoPorSituacao(projetoPreInscricaoUID, EnumSituacaoPreInscricao.APROVADO))
		{
			flag4 = true;
		}
		if (!flag4 && !flag3)
		{
			((Control)val).Visible = true;
			((Control)val2).Visible = true;
			if (!flag)
			{
				((Control)val).Visible = false;
			}
			if (!flag2)
			{
				((Control)val2).Visible = false;
			}
		}
		if (flag4)
		{
			((Control)val).Visible = false;
			((Control)val2).Visible = false;
			if (!flag)
			{
				((Control)val).Visible = false;
			}
			if (!flag2)
			{
				((Control)val2).Visible = false;
			}
		}
		if (flag3)
		{
			((Control)val).Visible = true;
			((Control)val2).Visible = false;
			if (!flag)
			{
				((Control)val).Visible = false;
			}
			if (!flag2)
			{
				((Control)val2).Visible = false;
			}
		}
		int num = (int)DataBinder.Eval(e.Row.DataItem, "situacaoPreInscricaoEnum");
		((Label)((Control)e.Row).FindControl("lbSituacaoPreInscricao")).Text = ((EnumSituacaoPreInscricao)num).ObterDescricao();
	}
}
