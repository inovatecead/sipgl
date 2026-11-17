using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.View.aluno.Base;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.relatorios;

namespace ufmt.sipgl.View;

public class FrmListaInscricao : AlunoBase
{
	protected HiddenField hddPreMatriculaPessoaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			((Control)this.Page.Master).FindControl("pnlMenu").Visible = false;
			new DiscenteBO();
			this.ViewState["preMatriculaPessoaUID"] = ((Page)this).Session["preMatriculaPessoaUID"].ToString();
			PreecherGridView(long.Parse(this.ViewState["preMatriculaPessoaUID"].ToString()));
			hddPreMatriculaPessoaUID.Value = ((Page)this).Session["preMatriculaPessoaUID"].ToString();
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(long.Parse(this.ViewState["preMatriculaPessoaUID"].ToString()));
	}

	protected void PreecherGridView(long preMatriculaPessoaUID)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		List<ViewPreMatriculaInscricao> inscricoesPessoa = new DiscenteBO().GetInscricoesPessoa(preMatriculaPessoaUID);
		((BaseDataBoundControl)GridView1).DataSource = inscricoesPessoa;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + inscricoesPessoa.Count + " Inscrições disponíveis";
		if (inscricoesPessoa.Count > 0)
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

	protected void lnkExibirNotas_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long preMatriculaInscricaoUID = long.Parse(((LinkButton)sender).CommandArgument.ToString());
		ProjetoNotaBO projetoNotaBO = new ProjetoNotaBO();
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		PreMatriculaInscricao preMatriculaInscricao = preMatriculaInscricaoBO.BuscarPreMatriculaInscricaoPorUID(preMatriculaInscricaoUID);
		List<ProjetoDisciplina> list = projetoDisciplinaBO.ListarDisciplinasPorCurso(preMatriculaInscricao.ProjetoTurmaPolo.ProjetoTurma.projetoCursoUID);
		List<DisciplinaNotaDTO> list2 = new List<DisciplinaNotaDTO>();
		foreach (ProjetoDisciplina item in list)
		{
			DisciplinaNotaDTO disciplinaNotaDTO = new DisciplinaNotaDTO();
			disciplinaNotaDTO.NomeDisciplina = item.nome;
			disciplinaNotaDTO.Nota = projetoNotaBO.BuscarNotaPorDisciplinaDiscente(item.projetoDisciplinaUID, preMatriculaInscricaoUID)?.nota;
			list2.Add(disciplinaNotaDTO);
		}
		var cabecalho = new List<KeyValuePair<string, string>>
		{
			new("Curso", preMatriculaInscricao.ProjetoTurmaPolo.ProjetoTurma.ProjetoCurso.nomeCurso),
			new("Data de Emissão", DateTime.Today.ToString("dd/MM/yyyy")),
			new("Turma", preMatriculaInscricao.ProjetoTurmaPolo.ProjetoTurma.nome),
			new("Polo", preMatriculaInscricao.ProjetoTurmaPolo.EnderecoPoloApoioPresencialEAD.identificacaoEndereco),
			new("Discente", preMatriculaInscricao.PreMatriculaPessoa.nome),
			new("CPF", preMatriculaInscricao.PreMatriculaPessoa.cpf.FormatarCPF())
		};
		var colunas = new[] { "Disciplina", "Nota" };
		var linhas = list2.Select(d => new[] { d.NomeDisciplina, d.Nota?.ToString() ?? "" }).ToList();

		var pdf = RelatorioPdfBuilder.Gerar("Relatório de Notas", cabecalho, colunas, linhas);
		((Page)this).Response.EscreverPdf(pdf, "RelatorioNotas.pdf");
	}

	protected void lnkHistorico_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long preMatriculaInscricaoUID = long.Parse(((LinkButton)sender).CommandArgument.ToString());
		string value = "";
		string value2 = "";
		ProjetoNotaBO projetoNotaBO = new ProjetoNotaBO();
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		ProjetoBO projetoBO = new ProjetoBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		ProjetoFrequenciaBO projetoFrequenciaBO = new ProjetoFrequenciaBO();
		PreMatriculaInscricao preMatriculaInscricao = preMatriculaInscricaoBO.BuscarPreMatriculaInscricaoPorUID(preMatriculaInscricaoUID);
		ViewPreMatriculaPessoa viewPreMatriculaPessoa = preMatriculaPessoaBO.BuscarViewPreMatriculaPessoaPorID(preMatriculaInscricao.preMatriculaPessoaUID);
		ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(preMatriculaInscricao.ProjetoTurmaPolo.ProjetoTurma.projetoCursoUID);
		List<ProjetoDisciplina> list = projetoDisciplinaBO.ListarDisciplinasPorCurso(preMatriculaInscricao.ProjetoTurmaPolo.ProjetoTurma.projetoCursoUID);
		List<HistoricoEscolarDTO> list2 = new List<HistoricoEscolarDTO>();
		foreach (ProjetoDisciplina item in list)
		{
			ProjetoNota projetoNota = projetoNotaBO.BuscarNotaPorDisciplinaDiscente(item.projetoDisciplinaUID, preMatriculaInscricaoUID);
			if (item.tipoDisciplina == 2 && projetoNota != null)
			{
				value = projetoNota.descricaoTCC;
				value2 = (string.IsNullOrWhiteSpace(projetoNota.conceito) ? projetoNota.nota.ToString() : projetoNota.conceito);
			}
			HistoricoEscolarDTO historicoEscolarDTO = new HistoricoEscolarDTO();
			historicoEscolarDTO.NomeDisciplina = item.nome;
			historicoEscolarDTO.Nota = projetoNota?.nota;
			historicoEscolarDTO.CargaHoraria = item.cargaHoraria;
			ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(preMatriculaInscricao.ProjetoTurmaPolo.projetoTurmaUID, item.projetoDisciplinaUID);
			if (projetoTurmaDisciplina != null)
			{
				ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteUID);
				historicoEscolarDTO.NomeDocente = projetoCorpoDocenteDTO.Nome;
				historicoEscolarDTO.Titulacao = projetoCorpoDocenteDTO.DescricaoTipoTitulacao;
			}
			if (item.ProjetoCurso.tipoModalidadeUID == 1)
			{
				historicoEscolarDTO.Frequencia = projetoFrequenciaBO.CalcularFrequencia(viewPreMatriculaPessoa.preMatriculaPessoaUID, preMatriculaInscricao.ProjetoTurmaPolo.enderecoUID, item.projetoDisciplinaUID) + "%";
			}
			else
			{
				historicoEscolarDTO.Frequencia = "Não se aplica";
			}
			list2.Add(historicoEscolarDTO);
		}
		ViewUnidade viewUnidade = projetoBO.BuscarUnidadeProponente(registroPorId.proponenteUnidadeUID);
		var cabecalho = new List<KeyValuePair<string, string>>
		{
			new("Unidade Proponente", viewUnidade.nome),
			new("Nome do Curso", registroPorId.nomeCurso),
			new("Área de Conhecimento", registroPorId.CNPqAreaConhecimento.nome),
			new("Data de Início", registroPorId.realizacaoDataInicio.GetValueOrDefault().ToShortDateString()),
			new("Data de Término", registroPorId.realizacaoDataTermino.GetValueOrDefault().ToShortDateString()),
			new("Carga Horária Total do Curso", registroPorId.cargaHorariaTotal + " horas"),
			new("Câmpus/Local", "Cuiabá"),
			new("Discente", viewPreMatriculaPessoa.nomeCandidato),
			new("Nome da Mãe", viewPreMatriculaPessoa.nomeMae),
			new("Nome do Pai", viewPreMatriculaPessoa.nomePai),
			new("Data de Nascimento", viewPreMatriculaPessoa.nascimentoData.ToShortDateString()),
			new("Sexo", (viewPreMatriculaPessoa.sexo == "M") ? "Masculino" : "Feminino"),
			new("Naturalidade", viewPreMatriculaPessoa.naturalidadeNomeMunicipio + "-" + viewPreMatriculaPessoa.naturalidadeUFUID),
			new("RG/Órgão Emissor", viewPreMatriculaPessoa.rgNumero + " - " + viewPreMatriculaPessoa.rgOrgaoExpedidor + "/" + viewPreMatriculaPessoa.rgUFUID),
			new("CPF", viewPreMatriculaPessoa.cpf.FormatarCPF()),
			new("Diploma de", viewPreMatriculaPessoa.tipoGraduacao),
			new("Curso de Graduação em", viewPreMatriculaPessoa.cursoGraduacao),
			new("Data da Colação de Grau", viewPreMatriculaPessoa.graduacaoDataColacaoGrau.ToShortDateString()),
			new("Instituição de Ensino", viewPreMatriculaPessoa.graduacaoInstituicaoEnsino),
			new("Nº do Registro do Diploma", viewPreMatriculaPessoa.numeroRegistroDiploma),
			new("Título do Trabalho de Conclusão de Curso", value),
			new("Conceito", value2)
		};
		var colunas = new[] { "Disciplina", "Carga Horária", "Nota", "Frequência", "Docente Responsável", "Titulação" };
		var linhas = list2.Select(h => new[]
		{
			h.NomeDisciplina,
			h.CargaHoraria + " horas",
			h.Nota?.ToString() ?? "",
			h.Frequencia,
			h.NomeDocente,
			h.Titulacao
		}).ToList();

		var pdf = RelatorioPdfBuilder.Gerar("Histórico Escolar", cabecalho, colunas, linhas);
		((Page)this).Response.EscreverPdf(pdf, "HistoricoEscolar.pdf");
	}
}
