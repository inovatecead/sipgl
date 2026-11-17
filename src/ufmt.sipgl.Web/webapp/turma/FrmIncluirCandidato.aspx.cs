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

public class FrmIncluirCandidato : VerificaSession
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

	protected LinkButton lnkConsultar;

	protected Panel PanelAcoes;

	protected HyperLink lnkCadastrarDiscente;

	protected Label lblTotalRegistros;

	protected GridView GridViewPessoas;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Discentes_IncluirDiscente"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkCadastrarDiscente).Visible = (listaRecursos.Contains("IncluirDiscente_CadastrarDiscente") ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			string text = ((Page)this).Request.QueryString["cpf"];
			lnkTitulo.Text = "[ Voltar para Discentes ]";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1";
			lblTitulo.Text = "Inclusão de Candidatos";
			lnkCadastrarDiscente.NavigateUrl = "~/webapp/turma/FrmCadastroPessoa.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			((BaseDataBoundControl)GridViewPessoas).DataSource = new List<PreMatriculaPessoa>();
			((Control)GridViewPessoas).DataBind();
			if (!string.IsNullOrWhiteSpace(text))
			{
				PreecherGridView(string.Empty, text);
			}
		}
	}

	protected void PreecherGridView(string nome, string cpf)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		List<PreMatriculaPessoa> list = null;
		list = preMatriculaPessoaBO.FiltrarPreMatriculaPessoa(nome, cpf);
		foreach (PreMatriculaPessoa item in list)
		{
			item.cpf = item.cpf.FormatarCPF();
		}
		((BaseDataBoundControl)GridViewPessoas).DataSource = list;
		((Control)GridViewPessoas).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count > 0)
		{
			ImageButton val = (ImageButton)((Control)GridViewPessoas.BottomPagerRow).FindControl("cmdPrev");
			if (GridViewPessoas.PageIndex == 0)
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
		PreecherGridView(txtNome.Text, txtCPF.Text);
	}

	protected void cmdIr2_Click(object sender, ImageClickEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		TextBox val = (TextBox)((Control)GridViewPessoas.BottomPagerRow).FindControl("txtPagina");
		GridViewPessoas.PageIndex = Convert.ToInt32(val.Text) - 1;
		PreecherGridView(txtNome.Text, txtCPF.Text);
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridViewPessoas.PageIndex = e.NewPageIndex;
		PreecherGridView(txtNome.Text, txtCPF.Text);
	}

	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType == 2)
		{
			long preMatriculaInscricaoUID = ((ViewPreMatriculaInscricao)e.Row.DataItem).preMatriculaInscricaoUID;
			PreMatriculaInscricaoDAL preMatriculaInscricaoDAL = new PreMatriculaInscricaoDAL();
			new DiscenteDAL();
			if (!preMatriculaInscricaoDAL.IsDiscente(preMatriculaInscricaoUID))
			{
				HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkNota");
				((WebControl)val).Enabled = false;
				val.NavigateUrl = "";
				val.Text = "";
			}
		}
	}

	protected void lnkIncluirDiscente_Click(object sender, CommandEventArgs e)
	{
		long preMatriculaPessoaUID = long.Parse(e.CommandArgument.ToString());
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (new PreMatriculaInscricaoBO().IsInscrito(preMatriculaPessoaUID, projetoTurmaUID))
		{
			resultadoOperacao.TextMessage = "A pessoa selecionada já é aluno deste curso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		((Page)this).Response.Redirect("~/webapp/turma/FrmInscreverCandidato.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&preMatriculaPessoaUID=" + preMatriculaPessoaUID);
	}

	protected void GridViewPessoas_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType == 2)
		{
			((Control)(LinkButton)((Control)e.Row).FindControl("lnkIncluirDiscente")).Visible = (listaRecursos.Contains("IncluirDiscente_IncluirCandidato") ? true : false);
		}
	}
}
