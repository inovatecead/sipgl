using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.relatorios;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmListarDiscentes : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected TabContainer tabControle;

	protected TabPanel tabGeral;

	protected Panel pnlFormularioInscricao;

	protected Label Label1;

	protected TextBox txtNomeCurso;

	protected Label lbQuantidadePolos;

	protected TextBox txtQuantidadePolos;

	protected Label lbTotalAlunosMatriculados;

	protected TextBox txtTotalAlunosMatriculados;

	protected Label lbTotalPreInscricoes;

	protected TextBox txtTotalPreInscricoes;

	protected Label lbQuantidadeVagas;

	protected TextBox txtQuantidadeVagas;

	protected Label lbTotalAlunosAtivos;

	protected TextBox txtTotalAlunosAtivos;

	protected Label lbTotalPreInscricoesPendentes;

	protected TextBox txtTotalPreInscricoesPendentes;

	protected Label Label4;

	protected TextBox txtDataInicio;

	protected Label lbTotalAlunosInativos;

	protected TextBox txtTotalAlunosInativos;

	protected Label lbTotalPreInscricoesAprovadas;

	protected TextBox txtTotalPreInscricoesAprovadas;

	protected Label Label5;

	protected TextBox txtDataFinal;

	protected Label lbTotalAlunosFormados;

	protected TextBox txtTotalAlunosFormados;

	protected Label lbTotalPreInscricoesCanceladas;

	protected TextBox txtTotalPreInscricoesCanceladas;

	protected GridView GridViewPolos;

	protected TabPanel tabAlunos;

	protected Panel PanelFiltro;

	protected Label lbPolo;

	protected DropDownList ddlPolo;

	protected Label lbTipoSituacaoInscricao;

	protected DropDownList ddlTipoSituacaoInscricao;

	protected LinkButton lnkConsultar;

	protected Panel PanelAcoes;

	protected HyperLink lnkIncluirDiscente;

	protected HyperLink lnkIncluirLote;

	protected HyperLink lnkGerenciarPreInscricao;

	protected Button gerarRelatorioPDF;

	protected Button gerarRelatorioExcel;

	protected Label lblTotalRegistros;

	protected GridView GridViewListaDiscentes;

	protected Button btnDummy;

	protected ModalPopupExtender modalHistorico;

	protected Panel modalPanel;

	protected Label lbTituloHistoricoAlteracoes;

	protected GridView GridViewHistoricoSituacao;

	protected Button fecharModal;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Turma_Discentes"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkIncluirDiscente).Visible = (listaRecursos.Contains("Discentes_IncluirDiscente") ? true : false);
		((Control)lnkIncluirLote).Visible = (listaRecursos.Contains("Discentes_IncluirLote") ? true : false);
		((Control)lnkGerenciarPreInscricao).Visible = (listaRecursos.Contains("Discentes_GerenciarPreInscricao") ? true : false);
		((Control)gerarRelatorioPDF).Visible = (listaRecursos.Contains("Discentes_RelatorioPDF") ? true : false);
		((Control)gerarRelatorioExcel).Visible = (listaRecursos.Contains("Discentes_RelatorioXLS") ? true : false);
		if (((Page)this).IsPostBack)
		{
			return;
		}
		hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
		hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		new ProjetoBO();
		TipoSituacaoInscricaoBO tipoSituacaoInscricaoBO = new TipoSituacaoInscricaoBO();
		new ProjetoPreInscricaoBO();
		ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(long.Parse(hddProjetoTurmaUID.Value));
		lnkTitulo.Text = "[ Voltar para Turmas ] ";
		lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
		lblTitulo.Text = projetoTurma.ProjetoCurso.nomeCurso;
		lnkIncluirDiscente.NavigateUrl = "~/webapp/turma/FrmIncluirCandidato.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
		lnkIncluirLote.NavigateUrl = "~/webapp/turma/FrmIncluirLote.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
		lnkGerenciarPreInscricao.NavigateUrl = "~/webapp/turma/FrmGerenciarPreInscricao.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
		txtNomeCurso.Text = projetoTurma.ProjetoCurso.nomeCurso;
		txtQuantidadePolos.Text = projetoTurma.ProjetoTurmaPolo.Count.ToString();
		txtQuantidadeVagas.Text = projetoTurma.ProjetoTurmaPolo.Select((ProjetoTurmaPolo t) => t.quantidadeVagas).Sum().ToString();
		txtDataInicio.Text = projetoTurma.DataInicio.GetValueOrDefault().ToShortDateString();
		txtDataFinal.Text = projetoTurma.DataFim.GetValueOrDefault().ToShortDateString();
		txtTotalAlunosMatriculados.Text = projetoTurma.ProjetoTurmaPolo.SelectMany((ProjetoTurmaPolo x) => x.PreMatriculaInscricao.Where((PreMatriculaInscricao y) => y.tipoSituacaoInscricaoUID > 2)).Count().ToString();
		txtTotalAlunosAtivos.Text = projetoTurma.ProjetoTurmaPolo.SelectMany((ProjetoTurmaPolo x) => x.PreMatriculaInscricao.Where((PreMatriculaInscricao y) => y.tipoSituacaoInscricaoUID == 3)).Count().ToString();
		txtTotalAlunosInativos.Text = projetoTurma.ProjetoTurmaPolo.SelectMany((ProjetoTurmaPolo x) => x.PreMatriculaInscricao.Where((PreMatriculaInscricao y) => y.tipoSituacaoInscricaoUID == 4 || y.tipoSituacaoInscricaoUID == 5)).Count().ToString();
		txtTotalAlunosFormados.Text = projetoTurma.ProjetoTurmaPolo.SelectMany((ProjetoTurmaPolo x) => x.PreMatriculaInscricao.Where((PreMatriculaInscricao y) => y.tipoSituacaoInscricaoUID == 7)).Count().ToString();
		txtTotalPreInscricoes.Text = Enumerable.Count(projetoTurma.ProjetoPreInscricao).ToString();
		txtTotalPreInscricoesPendentes.Text = projetoTurma.ProjetoPreInscricao.Where((ProjetoPreInscricao x) => x.situacaoPreInscricaoEnum == 1).Count().ToString();
		txtTotalPreInscricoesAprovadas.Text = projetoTurma.ProjetoPreInscricao.Where((ProjetoPreInscricao x) => x.situacaoPreInscricaoEnum == 2).Count().ToString();
		txtTotalPreInscricoesCanceladas.Text = projetoTurma.ProjetoPreInscricao.Where((ProjetoPreInscricao x) => x.situacaoPreInscricaoEnum == 3).Count().ToString();
		List<PoloDTO> dataSource = projetoTurmaBO.BuscarDadosPolosVinculados(long.Parse(hddProjetoTurmaUID.Value));
		List<PreMatriculaInscricao> list = new List<PreMatriculaInscricao>();
		((BaseDataBoundControl)GridViewListaDiscentes).DataSource = list;
		((Control)GridViewListaDiscentes).DataBind();
		((BaseDataBoundControl)GridViewPolos).DataSource = dataSource;
		((Control)GridViewPolos).DataBind();
		((BaseDataBoundControl)ddlPolo).DataSource = (from t in projetoTurma.ProjetoTurmaPolo
			select t.EnderecoPoloApoioPresencialEAD into w
			orderby w.identificacaoEndereco
			select w).ToList();
		((ListControl)ddlPolo).DataValueField = "enderecoUID";
		((ListControl)ddlPolo).DataTextField = "identificacaoEndereco";
		((Control)ddlPolo).DataBind();
		((BaseDataBoundControl)ddlTipoSituacaoInscricao).DataSource = tipoSituacaoInscricaoBO.ListaTipoSituacaoInscricaoFiltro();
		((ListControl)ddlTipoSituacaoInscricao).DataValueField = "tipoSituacaoInscricaoUID";
		((ListControl)ddlTipoSituacaoInscricao).DataTextField = "nome";
		((Control)ddlTipoSituacaoInscricao).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		int result = 0;
		int.TryParse(((Page)this).Request.QueryString["ActiveTab"], out result);
		if (result > 0)
		{
			tabControle.ActiveTabIndex = result;
		}
		if (((Page)this).Request.QueryString["ddlPolo"] != null)
		{
			((ListControl)ddlPolo).SelectedValue = ((Page)this).Request.QueryString["ddlPolo"];
		}
		if (((Page)this).Request.QueryString["ddlTipoSituacaoInscricao"] != null)
		{
			((ListControl)ddlTipoSituacaoInscricao).SelectedValue = ((Page)this).Request.QueryString["ddlTipoSituacaoInscricao"];
		}
		if (((Page)this).Request.QueryString["page"] != null)
		{
			int result2 = 0;
			int.TryParse(((Page)this).Request.QueryString["page"], out result2);
			GridViewListaDiscentes.PageIndex = result2;
			PreecherGridView();
		}
	}

	protected void GridViewListaDiscentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridViewListaDiscentes.PageIndex = e.NewPageIndex;
		PreecherGridView();
	}

	protected void PreecherGridView()
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		int result = 0;
		int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(((ListControl)ddlTipoSituacaoInscricao).SelectedValue, out result2);
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		List<ViewPreMatriculaInscricaoTurma> list = new PreMatriculaInscricaoBO().FiltrarInscricoes(projetoTurmaUID, result, result2);
		foreach (ViewPreMatriculaInscricaoTurma item in list)
		{
			item.CPF = item.CPF.FormatarCPF();
		}
		((BaseDataBoundControl)GridViewListaDiscentes).DataSource = list;
		((Control)GridViewListaDiscentes).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count >= 10 && GridViewListaDiscentes.Rows.Count > 0)
		{
			ImageButton val = (ImageButton)((Control)GridViewListaDiscentes.BottomPagerRow).FindControl("cmdPrev");
			if (GridViewListaDiscentes.PageIndex == 0)
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
		TextBox val = (TextBox)((Control)GridViewListaDiscentes.BottomPagerRow).FindControl("txtPagina");
		GridViewListaDiscentes.PageIndex = Convert.ToInt32(val.Text) - 1;
		PreecherGridView();
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView();
	}

	protected void abrirModal_Click(object sender, GridViewCommandEventArgs e)
	{
		long num = 0L;
		if (((CommandEventArgs)e).CommandName == "preMatriculaInscricaoUID")
		{
			num = long.Parse(((CommandEventArgs)e).CommandArgument.ToString());
			string text = "";
			List<ViewPreMatriculaInscricaoOcorrencia> list = new PreMatriculaInscricaoBO().ListarViewHistoricoAlteracao(num);
			if (list.Count > 0)
			{
				text = list.First().nome;
			}
			lbTituloHistoricoAlteracoes.Text = "Histórico de Alterações - " + text;
			modalHistorico.Show();
			((BaseDataBoundControl)GridViewHistoricoSituacao).DataSource = list;
			((Control)GridViewHistoricoSituacao).DataBind();
		}
	}

	protected void GridViewListaDiscentes_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			LinkButton val = (LinkButton)((Control)e.Row).FindControl("lnkExcluirRegistroDiscente");
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkEditarSituacaoAluno");
			ImageButton val3 = (ImageButton)((Control)e.Row).FindControl("lnkVisualizarHistorico");
			((Control)val).Visible = (listaRecursos.Contains("Discentes_ExcluirDiscente") ? true : false);
			((Control)val2).Visible = (listaRecursos.Contains("Discentes_EditarSituacao") ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains("Discentes_VisualizarHistorico") ? true : false);
		}
	}

	protected void gerarRelatorioPDF_Click(object sender, EventArgs e)
	{
		var (cabecalho, colunas, linhas) = DadosRelatorio();
		var pdf = RelatorioPdfBuilder.Gerar("Relatório de Discentes", cabecalho, colunas, linhas);
		((Page)this).Response.EscreverPdf(pdf, "RelatorioDiscentes.pdf");
	}

	protected void gerarRelatorioExcel_Click(object sender, EventArgs e)
	{
		var (_, colunas, linhas) = DadosRelatorio();
		var excel = RelatorioExcelBuilder.Gerar("Discentes", colunas, linhas);
		((Page)this).Response.EscreverExcel(excel, "RelatorioDiscentes.xlsx");
	}

	private (List<KeyValuePair<string, string>> Cabecalho, string[] Colunas, List<string[]> Linhas) DadosRelatorio()
	{
		ProjetoBO projetoBO = new ProjetoBO();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		int result = 0;
		int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(((ListControl)ddlTipoSituacaoInscricao).SelectedValue, out result2);
		long result3 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result3);
		long result4 = 0L;
		long.TryParse(hddProjetoCursoUID.Value, out result4);
		ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(result4);
		ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(result3);
		List<ViewPreMatriculaInscricaoTurma> list = preMatriculaInscricaoBO.FiltrarInscricoes(result3, result, result2);
		foreach (ViewPreMatriculaInscricaoTurma item in list)
		{
			item.CPF = item.CPF.FormatarCPF();
		}

		var cabecalho = new List<KeyValuePair<string, string>>
		{
			new("Curso", registroPorId.nomeCurso),
			new("Turma", projetoTurma.nome),
			new("Data de Emissão", DateTime.Today.ToString("dd/MM/yyyy"))
		};
		var colunas = new[] { "Polo", "Nome", "CPF", "E-mail", "Situação" };
		var linhas = list
			.Select(v => new[] { v.identificacaoEndereco, v.nome, v.CPF, v.email, v.tipoSituacaoInscricao })
			.ToList();

		return (cabecalho, colunas, linhas);
	}

	protected void lnkExcluir_Click(object sender, CommandEventArgs e)
	{
		_ = new string[2];
		string[] array = e.CommandArgument.ToString().Split(new char[1] { ';' });
		int preMatriculaInscricaoUID = int.Parse(array[0]);
		int num = int.Parse(array[1]);
		ResultadoOperacao resultadoOperacao = new PreMatriculaInscricaoBO().ExcluirDiscenteTurma(preMatriculaInscricaoUID);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1&page=" + num);
	}
}
