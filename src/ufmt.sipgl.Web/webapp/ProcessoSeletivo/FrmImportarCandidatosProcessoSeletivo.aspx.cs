using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmImportarCandidatosProcessoSeletivo : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Label lbImportarAlunosProcessoSeletivo;

	protected FileUpload FileUploadAlunosProcessoSeletivo;

	protected Button btnImportarCandidatos;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuDiscentes_ImportarCandidatos"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)btnImportarCandidatos).Visible = (listaRecursos.Contains("ImportarCandidatos_Importar") ? true : false);
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Discentes ]";
			lnkTitulo.NavigateUrl = "~/webapp/matriculaPessoa/FrmListar.aspx";
			lblTitulo.Text = "Importar Candidatos do Processo Seletivo";
		}
	}

	protected void importarAlunos_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		ProjetoImportarCandidatosProcessoSeleteivoBO projetoImportarCandidatosProcessoSeleteivoBO = new ProjetoImportarCandidatosProcessoSeleteivoBO();
		if (FileUploadAlunosProcessoSeletivo.HasFile)
		{
			if (FileUploadAlunosProcessoSeletivo.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
			{
				resultadoOperacao = projetoImportarCandidatosProcessoSeleteivoBO.ImportarCandidatosProcessoSeletivo(FileUploadAlunosProcessoSeletivo.PostedFile.InputStream);
				if (!resultadoOperacao.Erro)
				{
					PopulateMessage(resultadoOperacao);
					((Page)this).Response.Redirect("~/webapp/matriculaPessoa/FrmListar.aspx");
				}
			}
		}
		else
		{
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
			resultadoOperacao.TextMessage = "Nenhum arquivo encontrado.";
		}
		PopularMensagemRegraNegocio(resultadoOperacao);
	}
}
