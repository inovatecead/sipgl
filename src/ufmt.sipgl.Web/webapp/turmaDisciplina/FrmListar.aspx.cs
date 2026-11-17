using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.relatorios;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turmaDisciplina;

public class FrmListar : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected TextBox txtCriterio;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected Label lblTotalRegistros;

	protected Button gerarRelatorioPDF;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Turma_GerenciarDisciplinas"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)gerarRelatorioPDF).Visible = (listaRecursos.Contains("GerenciarDisciplinas_ExportarRelatorioPDF") ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			ProjetoCurso projetoCurso = new ProjetoDAL().BuscarProjetoCurso(long.Parse(hddProjetoCursoUID.Value));
			lblTitulo.Text = "Relação de Disciplinas do Curso " + projetoCurso.nomeCurso;
			lnkTitulo.Text = "[ Voltar para Turmas ]";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
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

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2 && DataBinder.Eval(e.Row.DataItem, "tipoDisciplina") != null)
		{
			int num = (int)DataBinder.Eval(e.Row.DataItem, "tipoDisciplina");
			Label val = (Label)((Control)e.Row).FindControl("lbTipoDisciplina");
			EnumTipoDisciplina enumTipoDisciplina = (EnumTipoDisciplina)num;
			val.Text = enumTipoDisciplina.ObterDescricao();
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkVincularDocentes");
			HyperLink val3 = (HyperLink)((Control)e.Row).FindControl("lnkEncontroPresencial");
			((Control)val2).Visible = (listaRecursos.Contains("GerenciarDisciplinas_VincularDocentes") ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains("GerenciarDisciplinas_EncontroPresencial") ? true : false);
		}
	}

	protected void gerarRelatorioPDF_Click(object sender, EventArgs e)
	{
		((Page)this).Response.EscreverPdf(RelatorioBase(), "RelatorioDisciplinas.pdf");
	}

	private byte[] RelatorioBase()
	{
		ProjetoBO projetoBO = new ProjetoBO();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		long result = 0L;
		long.TryParse(hddProjetoCursoUID.Value, out result);
		long result2 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result2);
		ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(result);
		ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(result2);
		List<ProjetoDisciplina> list = (from e in projetoDisciplinaBO.ListarDisciplinasPorCurso(long.Parse(hddProjetoCursoUID.Value))
			orderby e.nome
			select e).ToList();
		List<DisciplinaDTO> list2 = new List<DisciplinaDTO>();
		foreach (ProjetoDisciplina item in list)
		{
			DisciplinaDTO disciplinaDTO = new DisciplinaDTO();
			disciplinaDTO.ProjetoDisciplinaUID = item.projetoDisciplinaUID;
			disciplinaDTO.Nome = item.nome;
			disciplinaDTO.CargaHoraria = item.cargaHoraria;
			ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(result2, item.projetoDisciplinaUID);
			if (projetoTurmaDisciplina != null)
			{
				disciplinaDTO.DataInicio = projetoTurmaDisciplina.dataInicio.GetValueOrDefault().ToShortDateString();
				disciplinaDTO.DataTermino = projetoTurmaDisciplina.dataTermino.GetValueOrDefault().ToShortDateString();
				ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteUID);
				ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO2 = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteSecundarioUID.GetValueOrDefault());
				disciplinaDTO.NomeDocentePrincipal = ((projetoCorpoDocenteDTO != null) ? projetoCorpoDocenteDTO.Nome : "");
				disciplinaDTO.NomeDocenteSecundario = ((projetoCorpoDocenteDTO2 != null) ? projetoCorpoDocenteDTO2.Nome : "");
			}
			list2.Add(disciplinaDTO);
		}
		var cabecalho = new List<KeyValuePair<string, string>>
		{
			new("Curso", registroPorId.nomeCurso),
			new("Data de Emissão", DateTime.Today.ToString("dd/MM/yyyy")),
			new("Turma", projetoTurma.nome)
		};
		var colunas = new[] { "Disciplina", "Carga Horária", "Data de Início", "Data de Fim", "Docente Responsável" };
		var linhas = list2.Select(d => new[]
		{
			d.Nome,
			d.CargaHoraria + " horas",
			d.DataInicio,
			d.DataTermino,
			string.IsNullOrEmpty(d.NomeDocenteSecundario) ? d.NomeDocentePrincipal : d.NomeDocentePrincipal + "\n" + d.NomeDocenteSecundario
		}).ToList();

		return RelatorioPdfBuilder.Gerar("Relatório de Disciplinas", cabecalho, colunas, linhas);
	}
}
