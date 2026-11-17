using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.vincularDisciplina;

public class FrmCadastrar : VerificaSession
{
	private string ProjetoCursoUID;

	private string ProjetoDisciplinaUID;

	private string ProjetoTurmaDisciplinaUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddCodigoRegistro;

	protected HiddenField hddProjetoCursoUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Literal LiteralDescricaoCurso;

	protected Literal LiteralDescricaoTurma;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected ListBox lstDisciplinas;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected ListBox lstDocentes;

	protected Button btnVoltar;

	protected Button btnSalvar;

	private string TurmaUID { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Obj, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected Obj, but got Unknown
		_ = ((Page)this).Request.QueryString["operacao"];
		string text = ((Page)this).Request.QueryString["projetoCursoUID"];
		string projetoDisciplinaUID = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
		string text2 = ((Page)this).Request.QueryString["curso"];
		string text3 = ((Page)this).Request.QueryString["turma"];
		string projetoTurmaDisciplinaUID = ((Page)this).Request.QueryString["registroUID"];
		string text4 = ((Page)this).Request.QueryString["turmaUID"];
		ProjetoCursoUID = text;
		ProjetoDisciplinaUID = projetoDisciplinaUID;
		ProjetoTurmaDisciplinaUID = projetoTurmaDisciplinaUID;
		TurmaUID = text4;
		if (((Page)this).IsPostBack)
		{
			return;
		}
		lnkTitulo.Text = "[ Voltar para Disciplinas ] ";
		lnkTitulo.NavigateUrl = "~/webapp/vincularDisciplina/FrmListar.aspx?projetoCursoUID=" + text + "&curso=" + text2 + "&turma=" + text3 + "&turmaUID=" + text4;
		lblTitulo.Text = "Gerenciar Disciplinas";
		DisciplinaDAL disciplinaDAL = new DisciplinaDAL();
		hddProjetoCursoUID.Value = text;
		LiteralDescricaoCurso.Text = text2;
		LiteralDescricaoTurma.Text = text3;
		((ListControl)lstDocentes).Items.Clear();
		((ListControl)lstDisciplinas).Items.Clear();
		foreach (ViewModelCorpoDocenteProjetoCurso item in disciplinaDAL.GetDocente())
		{
			((ListControl)lstDocentes).Items.Add(new ListItem("[" + item.Registro + "] " + item.Nome, item.ProjetoCorpoDocenteUID.ToString()));
		}
		foreach (ProjetoDisciplina item2 in disciplinaDAL.GetDisciplina())
		{
			((ListControl)lstDisciplinas).Items.Add(new ListItem("[" + item2.projetoDisciplinaUID + "] [ " + item2.cargaHoraria + " horas ] " + item2.nome, item2.projetoDisciplinaUID.ToString()));
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
	}

	private void CloseDialog(string dialogId)
	{
		string text = $"closeDialog('{dialogId}')";
		ScriptManager.RegisterStartupScript((Page)(object)this, typeof(Page), this.UniqueID, text, true);
	}

	private void CarregarJQuery()
	{
		ScriptManager.RegisterClientScriptBlock((Page)(object)this, typeof(Page), this.UniqueID, "carregarJQuery()", true);
	}

	private void ShowDialog(string dialogId)
	{
		string text = $"showDialog('{dialogId}')";
		ScriptManager.RegisterClientScriptBlock((Page)(object)this, typeof(Page), this.UniqueID, text, true);
	}
}
