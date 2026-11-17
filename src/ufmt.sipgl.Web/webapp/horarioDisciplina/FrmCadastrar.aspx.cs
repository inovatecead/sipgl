using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.horarioDisciplina;

public class FrmCadastrar : VerificaSession
{
	private string ProjetoCursoUID;

	private string ProjetoDisciplinaUID;

	private string ProjetoHorarioUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddCodigoRegistro;

	protected HiddenField hddProjetoCursoUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado0;

	protected Label lblMsgResultado0;

	protected ValidationSummary ValidationSummary2;

	protected Literal LiteralDescricaoCurso;

	protected Literal LiteralDescricaoDisciplina;

	protected Literal LiteralTurma;

	protected Label Label2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtData;

	protected MaskedEditValidator MEVData2;

	protected MaskedEditExtender txtData_MaskedEditExtender;

	protected Label Label4;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtHoraInicio;

	protected MaskedEditValidator MaskedEditValidatorHoraInicio;

	protected MaskedEditExtender txtHoraInicio_MaskedEditExtender;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtHoraTermino;

	protected MaskedEditValidator MaskedEditValidatorTxtHoraTermino;

	protected MaskedEditExtender txtHoraTermino_MaskedEditExtender;

	protected Button btnVoltar0;

	protected Button btnSalvar;

	private string ProjetoTurmaDisciplinaUID { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		string text = ((Page)this).Request.QueryString["operacao"];
		string text2 = ((Page)this).Request.QueryString["projetoCursoUID"];
		string projetoDisciplinaUID = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
		string text3 = ((Page)this).Request.QueryString["curso"];
		string text4 = ((Page)this).Request.QueryString["turma"];
		string text5 = ((Page)this).Request.QueryString["turmaUID"];
		string text6 = ((Page)this).Request.QueryString["disciplina"];
		string text7 = ((Page)this).Request.QueryString["registroUID"];
		ProjetoCursoUID = text2;
		ProjetoDisciplinaUID = projetoDisciplinaUID;
		ProjetoHorarioUID = text7;
		ProjetoTurmaDisciplinaUID = ((Page)this).Request.QueryString["projetoTurmaDisciplinaUID"];
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Disciplinas ] ";
			lnkTitulo.NavigateUrl = "~/webapp/vincularDisciplina/FrmListar.aspx?projetoCursoUID=" + text2 + "&curso=" + text3 + "&turma=" + text4 + "&turmaUID=" + text5;
			lblTitulo.Text = "Gerenciar Horários";
			new DisciplinaDAL();
			hddProjetoCursoUID.Value = text2;
			LiteralDescricaoCurso.Text = text3;
			LiteralDescricaoDisciplina.Text = text6;
			LiteralTurma.Text = text4;
			if (text == "editar")
			{
				HorarioDAL horarioDAL = new HorarioDAL();
				hddCodigoRegistro.Value = text7;
				btnSalvar.Text = "Atualizar Dados";
				ProjetoHorario registroPorId = horarioDAL.GetRegistroPorId(long.Parse(ProjetoHorarioUID));
				txtData.Text = registroPorId.data.ToString();
				txtHoraInicio.Text = registroPorId.horaInicio.ToString().Substring(0, 5);
				txtHoraTermino.Text = registroPorId.horaFim.ToString().Substring(0, 5);
			}
			else
			{
				btnSalvar.Text = "Confirmar Cadastro";
				hddCodigoRegistro.Value = string.Empty;
			}
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		try
		{
			HorarioDAL horarioDAL = new HorarioDAL();
			ProjetoHorario projetoHorario = new ProjetoHorario();
			if (string.IsNullOrEmpty(ProjetoHorarioUID))
			{
				projetoHorario.horarioUID = 0L;
			}
			else
			{
				projetoHorario.horarioUID = long.Parse(ProjetoHorarioUID);
			}
			string text2 = txtHoraInicio.Text;
			string text3 = txtHoraTermino.Text;
			TimeSpan timeOfDay = DateTime.Parse(text2, CultureInfo.InvariantCulture).TimeOfDay;
			TimeSpan timeOfDay2 = DateTime.Parse(text3, CultureInfo.InvariantCulture).TimeOfDay;
			projetoHorario.horaInicio = timeOfDay;
			projetoHorario.horaFim = timeOfDay2;
			projetoHorario.turmaDisciplinaUID = long.Parse(ProjetoTurmaDisciplinaUID);
			projetoHorario.data = DateTime.Parse(txtData.Text);
			if (horarioDAL.Salvar(projetoHorario))
			{
				ScriptManager.RegisterStartupScript(this.Page, ((object)this.Page).GetType(), Guid.NewGuid().ToString(), "alert('Horário cadastrado com sucesso!');", true);
			}
			else
			{
				ScriptManager.RegisterStartupScript(this.Page, ((object)this.Page).GetType(), Guid.NewGuid().ToString(), "alert('Ocorreu um erro na inserção dos dados.  Entre em contato com o administrador do sistema.');", true);
			}
		}
		catch (Exception ex)
		{
			text = "Não foi possível efetuar a operação.  Por favor, entre em contato com o administrador do sistema.<br />" + ex.Message.ToString();
		}
		ScriptManager.RegisterStartupScript(this.Page, ((object)this.Page).GetType(), Guid.NewGuid().ToString(), "alert('" + text + "');window.location='FrmListar.aspx'", true);
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
