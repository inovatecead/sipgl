using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sig.entity;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.relatorios;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.Frequencia;

public class FrmFrequencia : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Label lbCurso;

	protected TextBox txtCurso;

	protected Label lbTurma;

	protected TextBox txtTurma;

	protected Label Label1;

	protected DropDownList ddlPolo;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected Label Label2;

	protected DropDownList ddlDisciplina;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected Label Label3;

	protected DropDownList ddlEncontroPresencial;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected LinkButton lnkFiltrar;

	protected Panel panelDiscentes;

	protected Label lbDocentePrincipal;

	protected TextBox txtDocentePrincipal;

	protected Label lbDocenteSecundario;

	protected TextBox txtDocenteSecundario;

	protected Button gerarRelatorioPDF;

	protected GridView GridViewFrequencia;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Turma_Frequencia"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)gerarRelatorioPDF).Visible = (listaRecursos.Contains(((Control)gerarRelatorioPDF).SkinID) ? true : false);
		((Control)btnSalvar).Visible = (listaRecursos.Contains(((Control)btnSalvar).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lnkTitulo.Text = "[ Voltar para Turmas ]";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Frequência";
			ProjetoBO projetoBO = new ProjetoBO();
			ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
			ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
			txtCurso.Text = registroPorId.nomeCurso;
			ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(long.Parse(hddProjetoTurmaUID.Value));
			txtTurma.Text = projetoTurma.nome;
			((Control)panelDiscentes).Visible = false;
			PopularDropdowns();
		}
	}

	protected void PopularDropdowns()
	{
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		((BaseDataBoundControl)ddlPolo).DataSource = projetoTurmaBO.ListarPolosPorTurma(long.Parse(hddProjetoTurmaUID.Value));
		((ListControl)ddlPolo).DataTextField = "identificacaoEndereco";
		((ListControl)ddlPolo).DataValueField = "enderecoUID";
		((Control)ddlPolo).DataBind();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		AutenticacaoBO autenticacaoBO = new AutenticacaoBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		long usuarioUID = (long)((Page)this).Session["usuarioUID"];
		List<ProjetoDisciplina> list = projetoDisciplinaBO.ListarDisciplinasPorCursoTurma(long.Parse(hddProjetoCursoUID.Value), long.Parse(hddProjetoTurmaUID.Value));
		List<long> list2 = (List<long>)((Page)this).Session["listaPerfis"];
		if (list2.Contains(58L) || list2.Contains(59L) || list2.Contains(60L) || list2.Contains(61L))
		{
			((BaseDataBoundControl)ddlDisciplina).DataSource = list;
		}
		else if (list2.Contains(119L))
		{
			ufmt.sig.entity.Usuario usuario = autenticacaoBO.GetUsuario(usuarioUID);
			List<long> listaProjetoCorpoDocenteUID = projetoCorpoDocenteBO.BucarListaProjetoCorpoDocentesUID(usuario.Pessoa.Cpf);
			((BaseDataBoundControl)ddlDisciplina).DataSource = list.Where((ProjetoDisciplina c) => c.ProjetoTurmaDisciplina.Any((ProjetoTurmaDisciplina w) => listaProjetoCorpoDocenteUID.Contains(w.projetoCorpoDocenteUID) || listaProjetoCorpoDocenteUID.Contains(w.projetoCorpoDocenteSecundarioUID.GetValueOrDefault()))).ToList();
		}
		((ListControl)ddlDisciplina).DataTextField = "nome";
		((ListControl)ddlDisciplina).DataValueField = "projetoDisciplinaUID";
		((Control)ddlDisciplina).DataBind();
	}

	protected void lnkFiltrar_Click(object sender, EventArgs e)
	{
		int result = 0;
		int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result2);
		long result3 = 0L;
		long.TryParse(((ListControl)ddlEncontroPresencial).SelectedValue, out result3);
		long result4 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result4);
		long result5 = 0L;
		long.TryParse(hddProjetoCursoUID.Value, out result5);
		txtDocentePrincipal.Text = string.Empty;
		txtDocenteSecundario.Text = string.Empty;
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		ProjetoFrequenciaBO projetoFrequenciaBO = new ProjetoFrequenciaBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma = preMatriculaInscricaoBO.ListarViewPreMatriculaInscricaoTurma(result, result4);
		projetoDisciplinaBO.BuscarDisciplinaPorId(result2);
		ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(result4, result2);
		if (projetoTurmaDisciplina != null)
		{
			ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteUID);
			txtDocentePrincipal.Text = ((projetoCorpoDocenteDTO != null) ? projetoCorpoDocenteDTO.Nome : "");
			ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO2 = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteSecundarioUID.GetValueOrDefault());
			txtDocenteSecundario.Text = ((projetoCorpoDocenteDTO2 != null) ? projetoCorpoDocenteDTO2.Nome : "");
		}
		List<FrequenciaDTO> list = projetoFrequenciaBO.ListarFrequencias(listaViewPreMatriculaInscricaoTurma, result3);
		if (list.Count > 0)
		{
			((Control)panelDiscentes).Visible = true;
		}
		((BaseDataBoundControl)GridViewFrequencia).DataSource = list;
		((Control)GridViewFrequencia).DataBind();
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			List<FrequenciaDTO> list = new List<FrequenciaDTO>();
			int count = GridViewFrequencia.Rows.Count;
			for (int i = 0; i < count; i++)
			{
				FrequenciaDTO frequenciaDTO = new FrequenciaDTO();
				long num = long.Parse(((HiddenField)((Control)GridViewFrequencia.Rows[i]).FindControl("hddPreMatriculaInscricaoUID")).Value);
				long num2 = long.Parse(((ListControl)ddlEncontroPresencial).SelectedValue);
				DropDownList val = (DropDownList)((Control)GridViewFrequencia.Rows[i]).FindControl("ddlPresenca");
				if (num > 0 && num2 > 0)
				{
					frequenciaDTO.ProjetoEncontroPresencialUID = num2;
					frequenciaDTO.PreMatriculaInscricaoUID = num;
					if (!string.IsNullOrWhiteSpace(((ListControl)val).SelectedValue))
					{
						bool value = bool.Parse(((ListControl)val).SelectedValue);
						frequenciaDTO.isPresente = value;
					}
				}
				list.Add(frequenciaDTO);
			}
			ProjetoFrequenciaBO projetoFrequenciaBO = new ProjetoFrequenciaBO();
			string text = ((Page)this).Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (string.IsNullOrWhiteSpace(text))
			{
				text = ((Page)this).Request.ServerVariables["REMOTE_ADDR"];
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = ((Page)this).Request.UserHostAddress;
			}
			long usuarioUID = (long)((Page)this).Session["usuarioUID"];
			resultadoOperacao = projetoFrequenciaBO.AtualizarFrequencia(list, usuarioUID, text);
			PopularMensagemRegraNegocio(resultadoOperacao);
		}
		catch (Exception)
		{
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			PopularMensagemRegraNegocio(resultadoOperacao);
		}
	}

	protected void GridViewFrequencia_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		if ((int)e.Row.RowType != 2)
		{
			return;
		}
		string text = (string)DataBinder.Eval(e.Row.DataItem, "CPF");
		if (text != null)
		{
			((TableRow)e.Row).Cells[1].Text = text.FormatarCPF();
		}
		Control val = ((Control)e.Row).FindControl("ddlPresenca");
		DropDownList val2 = (DropDownList)(object)((val is DropDownList) ? val : null);
		if (val2 == null)
		{
			return;
		}
		((ListControl)val2).Items.Add(new ListItem("", ""));
		((ListControl)val2).Items.Add(new ListItem("Sim", "true"));
		((ListControl)val2).Items.Add(new ListItem("Não", "false"));
		if (DataBinder.Eval(e.Row.DataItem, "isPresente") != null)
		{
			if ((bool)DataBinder.Eval(e.Row.DataItem, "isPresente"))
			{
				((ListControl)val2).SelectedIndex = 1;
			}
			else
			{
				((ListControl)val2).SelectedIndex = 2;
			}
		}
	}

	protected void filtroEncontroPresencial_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		int result = 0;
		int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result2);
		long result3 = 0L;
		long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result3);
		if (result > 0 && result2 > 0 && result3 > 0)
		{
			ProjetoEncontroPresencialBO projetoEncontroPresencialBO = new ProjetoEncontroPresencialBO();
			((ListControl)ddlEncontroPresencial).Items.Clear();
			((ListControl)ddlEncontroPresencial).Items.Add(new ListItem("Selecione...", ""));
			((BaseDataBoundControl)ddlEncontroPresencial).DataSource = projetoEncontroPresencialBO.FiltrarEncontroPresencialPorDisciplinaTurmaPolo(result3, result2, result);
			((ListControl)ddlEncontroPresencial).DataTextFormatString = "{0:dd/MM/yyyy}";
			((ListControl)ddlEncontroPresencial).DataTextField = "dataEncontro";
			((ListControl)ddlEncontroPresencial).DataValueField = "projetoEncontroPresencialUID";
			((Control)ddlEncontroPresencial).DataBind();
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
	}

	protected void gerarRelatorioPDF_Click(object sender, EventArgs e)
	{
		((Page)this).Response.EscreverPdf(RelatorioBase(), "RelatorioFrequencia.pdf");
	}

	protected byte[] RelatorioBase()
	{
		ProjetoBO projetoBO = new ProjetoBO();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		ProjetoFrequenciaBO projetoFrequenciaBO = new ProjetoFrequenciaBO();
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		EnderecoPoloPresencialEadBO enderecoPoloPresencialEadBO = new EnderecoPoloPresencialEadBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		ProjetoEncontroPresencialBO projetoEncontroPresencialBO = new ProjetoEncontroPresencialBO();
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		int result = 0;
		int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result2);
		long result3 = 0L;
		long.TryParse(hddProjetoCursoUID.Value, out result3);
		long result4 = 0L;
		long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result4);
		long result5 = 0L;
		long.TryParse(((ListControl)ddlEncontroPresencial).SelectedValue, out result5);
		ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(result3);
		ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(result2);
		ViewEnderecoPoloEAD viewEnderecoPoloEAD = enderecoPoloPresencialEadBO.BuscarPorId(result);
		ProjetoDisciplina projetoDisciplina = projetoDisciplinaBO.BuscarDisciplinaPorId(result4);
		ProjetoEncontroPresencial projetoEncontroPresencial = projetoEncontroPresencialBO.BuscarEncontroPresencialPorId(result5);
		ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = null;
		ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(result2, result4);
		if (projetoTurmaDisciplina != null)
		{
			projetoCorpoDocenteDTO = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteUID);
		}
		List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma = preMatriculaInscricaoBO.ListarViewPreMatriculaInscricaoTurma(result, result2);
		List<FrequenciaDTO> list = projetoFrequenciaBO.ListarFrequencias(listaViewPreMatriculaInscricaoTurma, result5);
		foreach (FrequenciaDTO item in list)
		{
			item.CPF = item.CPF.FormatarCPF();
		}
		var cabecalho = new List<KeyValuePair<string, string>>
		{
			new("Curso", registroPorId.nomeCurso),
			new("Data de Emissão", DateTime.Today.ToString("dd/MM/yyyy")),
			new("Turma", projetoTurma.nome),
			new("Polo", viewEnderecoPoloEAD.identificacaoEndereco),
			new("Disciplina", projetoDisciplina.nome),
			new("Docente", (projetoCorpoDocenteDTO != null) ? projetoCorpoDocenteDTO.Nome : ""),
			new("Data do Encontro", projetoEncontroPresencial.dataEncontro.ToShortDateString()),
			new("Tipo de Encontro", projetoEncontroPresencial.isObrigatorio ? "Obrigatóro" : "Facultativo")
		};
		var colunas = new[] { "Nome", "CPF", "Situação", "Presença" };
		var linhas = list.Select(f => new[]
		{
			f.NomeDiscente,
			f.CPF,
			f.TipoSituacaoInscricao,
			f.isPresente == null ? "" : (f.isPresente == true ? "Sim" : "Não")
		}).ToList();

		return RelatorioPdfBuilder.Gerar("Relatório de Frequências", cabecalho, colunas, linhas);
	}
}
