using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmIncluirLote : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Panel PanelAcoes;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected ValidationSummary ValidationSummary1;

	protected TextBox txtNomeCurso;

	protected TextBox txtDescricaoTurma;

	protected Label lbIncluirLote;

	protected FileUpload FileUploadIncluirLote;

	protected Button btnIncluirLote;

	protected Button btnVoltar;

	protected GridView listaResultadoOperacaoGridView;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("Discentes_IncluirLote"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)btnIncluirLote).Visible = (listaRecursos.Contains("IncluirLote_Salvar") ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			ProjetoBO projetoBO = new ProjetoBO();
			ProjetoTurmaBO projetoTurmaBO = new ProjetoTurmaBO();
			ProjetoCurso registroPorId = projetoBO.GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
			ProjetoTurma projetoTurma = projetoTurmaBO.BuscarTurma(long.Parse(hddProjetoTurmaUID.Value));
			lnkTitulo.Text = "[ Voltar para Discentes ] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			txtNomeCurso.Text = registroPorId.nomeCurso;
			txtDescricaoTurma.Text = projetoTurma.nome;
		}
	}

	protected void btnIncluirLote_Click(object sender, EventArgs e)
	{
		long.Parse(hddProjetoCursoUID.Value);
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		if (FileUploadIncluirLote.HasFile)
		{
			if (FileUploadIncluirLote.PostedFile.ContentType == "application/csv" || FileUploadIncluirLote.PostedFile.ContentType == "application/vnd.ms-excel")
			{
				long usuarioUID = long.Parse(((Page)this).Session["usuarioUID"].ToString());
				string text = ((Page)this).Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
				if (string.IsNullOrWhiteSpace(text))
				{
					text = ((Page)this).Request.ServerVariables["REMOTE_ADDR"];
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					text = ((Page)this).Request.UserHostAddress;
				}
				StreamReader streamReader = new StreamReader(FileUploadIncluirLote.PostedFile.InputStream);
				List<string> list = new List<string>();
				while (!streamReader.EndOfStream)
				{
					list.Add(streamReader.ReadLine());
				}
				List<string> list2 = new ProjetoIncluirLoteBO().IncluirLote(list, projetoTurmaUID, usuarioUID, text);
				if (list2.Count == 0)
				{
					resultadoOperacao.Erro = false;
					resultadoOperacao.TextMessage = "Alunos incluídos com sucesso.";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
				}
				else
				{
					resultadoOperacao.Erro = true;
					resultadoOperacao.TextMessage = "Alguns alunos não puderam ser incluídos. Veja a lista de erros.";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				}
				((BaseDataBoundControl)listaResultadoOperacaoGridView).DataSource = list2.Select((string t) => new
				{
					info = t
				});
				((Control)listaResultadoOperacaoGridView).DataBind();
			}
			else
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Formato de arquivo não compatível.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			}
		}
		else
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro na leitura do arquivo.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
		}
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListarDiscentes.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value + "&ActiveTab=1");
	}
}
