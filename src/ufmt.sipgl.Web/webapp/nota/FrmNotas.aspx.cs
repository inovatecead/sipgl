using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sig.entity;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.componentes;
using ufmt.sipgl.View.relatorios;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.nota;

public class FrmNotas : VerificaSession
{
	protected HiddenField hddProjetoTurmaUID;

	protected HiddenField hddProjetoCursoUID;

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

	protected LinkButton lnkFiltrar;

	protected Panel panelDiscentes;

	protected Label lbDocentePrincipal;

	protected TextBox txtDocentePrincipal;

	protected Label lbDocenteSecundario;

	protected TextBox txtDocenteSecundario;

	protected Button gerarRelatorioPDF;

	protected Button btnOpenPopUp;

	protected GridView GridViewNotas;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected Label lblHidden;

	protected ModalPopupExtender mpePopUp;

	protected Panel pnlImportarNotas;

	protected Label lblImportarNotas;

	protected Label Label46;

	protected FileUpload FileUploadDocumentoNotas;

	protected Button importarNotas;

	protected Button fecharModal;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Turma_Notas"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)gerarRelatorioPDF).Visible = (listaRecursos.Contains(((Control)gerarRelatorioPDF).SkinID) ? true : false);
		((Control)btnOpenPopUp).Visible = (listaRecursos.Contains(((Control)btnOpenPopUp).SkinID) ? true : false);
		((Control)btnSalvar).Visible = (listaRecursos.Contains(((Control)btnSalvar).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			lnkTitulo.Text = "[ Voltar para Turmas ]";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Notas";
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
		long result = 0L;
		long.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result2);
		long result3 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result3);
		long result4 = 0L;
		long.TryParse(hddProjetoCursoUID.Value, out result4);
		txtDocentePrincipal.Text = string.Empty;
		txtDocenteSecundario.Text = string.Empty;
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		ProjetoNotaBO projetoNotaBO = new ProjetoNotaBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma = preMatriculaInscricaoBO.ListarViewPreMatriculaInscricaoTurma(result, result3);
		projetoDisciplinaBO.BuscarDisciplinaPorId(result2);
		ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(result3, result2);
		if (projetoTurmaDisciplina != null)
		{
			ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteUID);
			txtDocentePrincipal.Text = ((projetoCorpoDocenteDTO != null) ? projetoCorpoDocenteDTO.Nome : "");
			ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO2 = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteSecundarioUID.GetValueOrDefault());
			txtDocenteSecundario.Text = ((projetoCorpoDocenteDTO2 != null) ? projetoCorpoDocenteDTO2.Nome : "");
		}
		List<NotaDTO> list = projetoNotaBO.ListarNotas(listaViewPreMatriculaInscricaoTurma, result2);
		if (list.Count > 0)
		{
			((Control)panelDiscentes).Visible = true;
		}
		((BaseDataBoundControl)GridViewNotas).DataSource = list;
		((Control)GridViewNotas).DataBind();
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected Obj, but got Unknown
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			List<NotaDTO> list = new List<NotaDTO>();
			int count = GridViewNotas.Rows.Count;
			for (int i = 0; i < count; i++)
			{
				NotaDTO notaDTO = new NotaDTO();
				long num = long.Parse(((HiddenField)((Control)GridViewNotas.Rows[i]).FindControl("hddPreMatriculaInscricaoUID")).Value);
				long num2 = long.Parse(((ListControl)ddlDisciplina).SelectedValue);
				TextBox val = (TextBox)((Control)GridViewNotas.Rows[i]).FindControl("txtNota");
				if (num > 0 && num2 > 0)
				{
					notaDTO.ProjetoDisciplinaUID = num2;
					notaDTO.PreMatriculaInscricaoUID = num;
					if (!string.IsNullOrWhiteSpace(val.Text))
					{
						decimal value = decimal.Parse(val.Text, NumberStyles.Float);
						notaDTO.Nota = value;
					}
					if (new ProjetoDisciplinaDAL().BuscarDisciplinaPorId(num2).tipoDisciplina == 2)
					{
						DropDownList val2 = (DropDownList)((Control)GridViewNotas.Rows[i]).FindControl("ddlConceito");
						TextBox val3 = (TextBox)((Control)GridViewNotas.Rows[i]).FindControl("txtTituloTCC");
						if (val2 != null)
						{
							notaDTO.Conceito = ((ListControl)val2).SelectedValue;
						}
						if (val3 != null)
						{
							notaDTO.TituloTCC = val3.Text;
						}
					}
				}
				list.Add(notaDTO);
			}
			ProjetoNotaBO projetoNotaBO = new ProjetoNotaBO();
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
			resultadoOperacao = projetoNotaBO.AtualizarNotaPorDisciplina(list, usuarioUID, text);
			PopularMensagemRegraNegocio(resultadoOperacao);
			lnkFiltrar_Click(sender, e);
		}
		catch (Exception)
		{
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			PopularMensagemRegraNegocio(resultadoOperacao);
		}
	}

	protected void GridViewNotas_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected Obj, but got Unknown
		if ((int)e.Row.RowType != 2)
		{
			return;
		}
		string cpf = (string)DataBinder.Eval(e.Row.DataItem, "CPF");
		((TableRow)e.Row).Cells[1].Text = cpf.FormatarCPF();
		long result = 0L;
		long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result);
		ProjetoDisciplina projetoDisciplina = new ProjetoDisciplinaBO().BuscarDisciplinaPorId(result);
		if (projetoDisciplina == null)
		{
			return;
		}
		if (projetoDisciplina.tipoDisciplina == 2)
		{
			GridViewNotas.Columns[4].Visible = true;
			GridViewNotas.Columns[5].Visible = true;
			DropDownList val = (DropDownList)((Control)((TableRow)e.Row).Cells[4]).FindControl("ddlConceito");
			if (val != null)
			{
				string selectedValue = (string)DataBinder.Eval(e.Row.DataItem, "conceito");
				((ListControl)val).SelectedValue = selectedValue;
			}
		}
		else
		{
			GridViewNotas.Columns[4].Visible = false;
			GridViewNotas.Columns[5].Visible = false;
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/webapp/turma/FrmListar.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
	}

	protected void gerarRelatorioPDF_Click(object sender, EventArgs e)
	{
		((Page)this).Response.EscreverPdf(RelatorioBase(), "RelatorioNotas.pdf");
	}

	protected byte[] RelatorioBase()
	{
		ProjetoBO projetoBO = new ProjetoBO();
		ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
		ProjetoNotaBO projetoNotaBO = new ProjetoNotaBO();
		PreMatriculaInscricaoBO preMatriculaInscricaoBO = new PreMatriculaInscricaoBO();
		EnderecoPoloPresencialEadBO enderecoPoloPresencialEadBO = new EnderecoPoloPresencialEadBO();
		ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
		ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		int result = 0;
		int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
		long result2 = 0L;
		long.TryParse(hddProjetoTurmaUID.Value, out result2);
		long result3 = 0L;
		long.TryParse(hddProjetoCursoUID.Value, out result3);
		long result4 = 0L;
		long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result4);
		ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(result3);
		ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(result2);
		ViewEnderecoPoloEAD viewEnderecoPoloEAD = enderecoPoloPresencialEadBO.BuscarPorId(result);
		ProjetoDisciplina projetoDisciplina = projetoDisciplinaBO.BuscarDisciplinaPorId(result4);
		ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = null;
		ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(result2, result4);
		if (projetoTurmaDisciplina != null)
		{
			projetoCorpoDocenteDTO = projetoCorpoDocenteBO.BuscarDocenteDTOPorId(projetoTurmaDisciplina.projetoCorpoDocenteUID);
		}
		List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma = preMatriculaInscricaoBO.ListarViewPreMatriculaInscricaoTurma(result, result2);
		List<NotaDTO> list = projetoNotaBO.ListarNotas(listaViewPreMatriculaInscricaoTurma, result4);
		foreach (NotaDTO item in list)
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
			new("Docente", (projetoCorpoDocenteDTO != null) ? projetoCorpoDocenteDTO.Nome : "")
		};
		var colunas = new[] { "Nome", "CPF", "Situação", "Nota" };
		var linhas = list.Select(n => new[] { n.NomeDiscente, n.CPF, n.TipoSituacaoInscricao, n.Nota?.ToString() ?? "" }).ToList();

		return RelatorioPdfBuilder.Gerar("Relatório de Notas", cabecalho, colunas, linhas);
	}

	protected void btnOpenPopUp_Click(object sender, EventArgs e)
	{
		mpePopUp.Show();
	}

	protected void importarNotas_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (FileUploadDocumentoNotas.HasFile)
		{
			if (FileUploadDocumentoNotas.PostedFile.ContentType == "text/csv")
			{
				int result = 0;
				int.TryParse(((ListControl)ddlPolo).SelectedValue, out result);
				long result2 = 0L;
				long.TryParse(hddProjetoTurmaUID.Value, out result2);
				long result3 = 0L;
				long.TryParse(hddProjetoCursoUID.Value, out result3);
				long result4 = 0L;
				long.TryParse(((ListControl)ddlDisciplina).SelectedValue, out result4);
				ProjetoNotaBO projetoNotaBO = new ProjetoNotaBO();
				List<ViewPreMatriculaInscricaoTurma> listaViewPreMatriculaInscricaoTurma = new PreMatriculaInscricaoBO().ListarViewPreMatriculaInscricaoTurma(result, result2);
				List<NotaDTO> listaNotaDTO = projetoNotaBO.ListarNotas(listaViewPreMatriculaInscricaoTurma, result4);
				List<string> list = new List<string>();
				StreamReader streamReader = new StreamReader(FileUploadDocumentoNotas.PostedFile.InputStream);
				while (streamReader.Peek() >= 0)
				{
					list.Add(streamReader.ReadLine());
				}
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
				resultadoOperacao = projetoNotaBO.ImportarNotas(list, listaNotaDTO, usuarioUID, text);
			}
			else
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O arquivo selecionado possui formato inválido. Apenas arquivos CSV são aceitos.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
		}
		else
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Nenhum arquivo selecionado.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		}
		PopularMensagemRegraNegocio(resultadoOperacao);
		lnkFiltrar_Click(sender, e);
		mpePopUp.Hide();
	}
}
