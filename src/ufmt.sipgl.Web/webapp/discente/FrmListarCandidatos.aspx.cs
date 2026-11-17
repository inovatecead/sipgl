using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.View.webapp.discente;

public class FrmListarCandidatos : Page
{
	protected HiddenField hddProjetoPoloCursoUID;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected Label lblNomeCandidato;

	protected TextBox txtNomeCandidato;

	protected Label lblCPF;

	protected TextBox txtCPF;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected Label lblResultadoConsulta;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		hddProjetoPoloCursoUID.Value = ((Page)this).Request.QueryString["projetoPoloCursoUID"];
		lnkTitulo.Text = "[ Voltar para Discentes ] ";
		lnkTitulo.NavigateUrl = "~/webapp/discente/FrmListar.aspx?projetoPoloCursoUID=" + hddProjetoPoloCursoUID.Value;
		lblTitulo.Text = "Lista de Candidatos";
		lblResultadoConsulta.Text = "<b>Mostrando Todos</b>";
		PreecherGridView("", "", visible: true);
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, visible: false);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, visible: true);
		txtNomeCandidato.Text = string.Empty;
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, visible: true);
	}

	protected void PreecherGridView(string nomeCandidato, string cpf, bool visible)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		PreMatriculaPessoaBO preMatriculaPessoaBO = new PreMatriculaPessoaBO();
		List<PreMatriculaPessoa> list = null;
		list = preMatriculaPessoaBO.ListarPreMatriculaPessoa(nomeCandidato, cpf);
		if (!string.IsNullOrEmpty(nomeCandidato))
		{
			((Control)lblResultadoConsulta).Visible = false;
		}
		else
		{
			((Control)lblResultadoConsulta).Visible = true;
		}
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = list.Count + " registro(s) disponível(is)";
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
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, visible: true);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
