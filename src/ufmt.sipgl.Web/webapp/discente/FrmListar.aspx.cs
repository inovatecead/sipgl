using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.discente;

public class FrmListar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelFiltro;

	protected Label lblNomeCandidato;

	protected TextBox txtNomeCandidato;

	protected Label lblCPF;

	protected TextBox txtCPF;

	protected Label lblSituacaoInscricao;

	protected DropDownList ddlSituacaoInscricao;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected HyperLink lnkNovoRegistro;

	protected Panel PanelAcoes;

	protected HiddenField hddProjetoPoloCursoUID;

	protected Label lblResultadoConsulta;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	public int? ProReitoriaUID { get; set; }

	public string Criterio { get; set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			new DiscenteBO();
			new EnderecoPoloPresencialEadDAL();
			hddProjetoPoloCursoUID.Value = ((Page)this).Request.QueryString["projetoPoloCursoUID"];
			lblResultadoConsulta.Text = "<b>Mostrando Todos</b>";
			lnkTitulo.Text = "[ Voltar para Polos ]";
			lnkNovoRegistro.NavigateUrl = "~/webapp/discente/FrmListarCandidatos.aspx?projetoPoloCursoUID=" + hddProjetoPoloCursoUID.Value;
			PopularDDLSituacaoInscricao();
			PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, int.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue), visible: false, long.Parse(hddProjetoPoloCursoUID.Value));
		}
	}

	private void PopularDDLSituacaoInscricao()
	{
		TipoSituacaoInscricaoBO tipoSituacaoInscricaoBO = new TipoSituacaoInscricaoBO();
		List<TipoSituacaoInscricao> list = new List<TipoSituacaoInscricao>();
		list.Add(new TipoSituacaoInscricao());
		list.AddRange(tipoSituacaoInscricaoBO.ListaTipoSituacaoInscricao());
		((BaseDataBoundControl)ddlSituacaoInscricao).DataSource = list;
		((ListControl)ddlSituacaoInscricao).DataTextField = "nome";
		((ListControl)ddlSituacaoInscricao).DataValueField = "tipoSituacaoInscricaoUID";
		((Control)ddlSituacaoInscricao).DataBind();
		((ListControl)ddlSituacaoInscricao).SelectedValue = "0";
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, int.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue), visible: false, long.Parse(hddProjetoPoloCursoUID.Value));
	}

	protected void PreecherGridView(string nomeCandidato, string cpf, int tipoSituacaoInscricao, bool visible, long projetoPoloCursoUID)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		new DiscenteBO();
		List<ViewPreMatriculaInscricao> list = null;
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
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, int.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue), visible: false, long.Parse(hddProjetoPoloCursoUID.Value));
	}

	protected void lnkExcluirSelecionados_Click(object sender, EventArgs e)
	{
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, int.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue), visible: false, long.Parse(hddProjetoPoloCursoUID.Value));
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		txtNomeCandidato.Text = string.Empty;
		txtCPF.Text = string.Empty;
		((ListControl)ddlSituacaoInscricao).SelectedValue = "0";
		PreecherGridView(txtNomeCandidato.Text, txtCPF.Text, int.Parse(((ListControl)ddlSituacaoInscricao).SelectedValue), visible: false, long.Parse(hddProjetoPoloCursoUID.Value));
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			int num = 4;
			byte tipoSituacaoInscricaoUID = (byte)DataBinder.Eval(e.Row.DataItem, "tipoSituacaoInscricaoUID");
			LinkButton val = (LinkButton)((Control)e.Row).FindControl("lnkBtnAtualizarRegistro");
			Label val2 = (Label)((Control)e.Row).FindControl("lblDescricaoSituacaoInscricao");
			((Control)val).Visible = false;
			((Control)val2).Visible = true;
			TipoSituacaoInscricao tipoSituacaoInscricao = new DiscenteDAL().BuscarSituacaoInscricao(tipoSituacaoInscricaoUID);
			if (tipoSituacaoInscricao.nome == "Cursando")
			{
				((WebControl)((TableRow)e.Row).Cells[num]).BackColor = Color.Green;
				((WebControl)((TableRow)e.Row).Cells[num]).ForeColor = Color.White;
			}
			else if (tipoSituacaoInscricao.nome == "Correção Solicitada pelo Coordenador")
			{
				((Control)val).Visible = true;
				((Control)val2).Visible = false;
				((WebControl)((TableRow)e.Row).Cells[num]).BackColor = Color.Tomato;
				((WebControl)((TableRow)e.Row).Cells[num]).ForeColor = Color.White;
			}
			else if (tipoSituacaoInscricao.nome == "Desistente" || tipoSituacaoInscricao.nome == "Desvinculado")
			{
				((WebControl)((TableRow)e.Row).Cells[num]).BackColor = Color.Tomato;
				((WebControl)((TableRow)e.Row).Cells[num]).ForeColor = Color.White;
			}
			else
			{
				((WebControl)((TableRow)e.Row).Cells[num]).BackColor = Color.Tomato;
				((WebControl)((TableRow)e.Row).Cells[num]).ForeColor = Color.White;
			}
		}
	}

	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.Row.RowType == 2)
		{
			long preMatriculaInscricaoUID = ((ViewPreMatriculaInscricao)e.Row.DataItem).preMatriculaInscricaoUID;
			PreMatriculaInscricaoDAL preMatriculaInscricaoDAL = new PreMatriculaInscricaoDAL();
			new DiscenteDAL();
			if (!preMatriculaInscricaoDAL.IsDiscente(preMatriculaInscricaoUID))
			{
				HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkNota");
				((WebControl)val).Enabled = false;
				val.NavigateUrl = "";
				val.Text = "";
			}
		}
	}
}
