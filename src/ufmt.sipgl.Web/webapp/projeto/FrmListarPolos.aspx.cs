using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.View.webapp.projeto;

public class FrmListarPolos : Page
{
	protected HyperLink lnkTitulo;

	protected Label lbTitulo;

	protected UpdatePanel upGeral;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lbDescricao;

	protected TextBox txtCriterio;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HiddenField hddProjetoCursoUID;

	protected Label lblResultadoConsulta;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			ProjetoCurso registroPorId = new ProjetoBO().GetRegistroPorId(long.Parse(hddProjetoCursoUID.Value));
			lbTitulo.Text = "Unidade de Ensino Ofertantes do Curso de " + registroPorId.nomeCurso;
			lnkTitulo.Text = "[ Voltar para Cursos ]";
			lnkTitulo.NavigateUrl = "~/webapp/projeto/FrmListar.aspx";
			PreecherGridView(txtCriterio.Text, visible: false);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtCriterio.Text, visible: false);
	}

	protected void PreecherGridView(string filtro, bool visible)
	{
		((Control)PanelMsgResultado).Visible = visible;
		new EnderecoPoloPresencialEadDAL();
		((Control)lblResultadoConsulta).Visible = false;
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
		PreecherGridView(null, visible: true);
		txtCriterio.Text = string.Empty;
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
