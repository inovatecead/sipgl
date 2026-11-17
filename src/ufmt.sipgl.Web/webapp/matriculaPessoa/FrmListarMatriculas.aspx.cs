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

namespace ufmt.sipgl.View.webapp.matriculaPessoa;

public class FrmListarMatriculas : VerificaSession
{
	protected HiddenField hddPreMatriculaPessoaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Label Label1;

	protected TextBox nomeDiscente;

	protected Label Label2;

	protected TextBox CPF;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuDiscentes_VisualizarMatriculas"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddPreMatriculaPessoaUID.Value = ((Page)this).Request.QueryString["preMatriculaPessoaUID"];
			lnkTitulo.Text = "[ Voltar para Discentes] ";
			lnkTitulo.NavigateUrl = "~/webapp/matriculaPessoa/FrmListar.aspx";
			lblTitulo.Text = "Lista de Matrículas";
			PreencherDetalhes(long.Parse(hddPreMatriculaPessoaUID.Value));
			PreecherGridView();
		}
	}

	private void PreencherDetalhes(long preMatriculaPessoaUID)
	{
		PreMatriculaPessoa preMatriculaPessoa = new PreMatriculaPessoaBO().BuscarPreMatriculaPessoaPorID(preMatriculaPessoaUID);
		nomeDiscente.Text = preMatriculaPessoa.nome.ToUpper();
		CPF.Text = preMatriculaPessoa.cpf.FormatarCPF();
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView();
	}

	protected void PreecherGridView()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		long preMatriculaPessoaUID = long.Parse(hddPreMatriculaPessoaUID.Value);
		List<ViewPreMatriculaInscricao> list = new PreMatriculaInscricaoBO().ListarMatriculasPorPessoa(preMatriculaPessoaUID);
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
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

	protected void DownloadHistoricoEscolar_Command(object sender, CommandEventArgs e)
	{
		if (!(e.CommandName == "preMatriculaInscricaoUID"))
		{
			return;
		}
		long preMatriculaInscricaoUID = long.Parse(e.CommandArgument.ToString());
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
