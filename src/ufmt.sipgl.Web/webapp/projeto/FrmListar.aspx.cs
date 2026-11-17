using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sig.entity;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.projeto;

public class FrmListar : VerificaSession
{
	protected HiddenField hddServidorUID;

	protected HiddenField hddTipoSolicitanteUID;

	protected UpdatePanel UpdatePanel1;

	protected Label Label1;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lbCurso;

	protected TextBox txtCriterio;

	protected Label Label2;

	protected DropDownList ddlStatusTurma;

	protected LinkButton lnkConsultar;

	protected LinkButton lnkMostrarTodos;

	protected Panel PanelAcoes;

	protected HyperLink lnkNovoProjetoCurso;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuCursos"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)lnkNovoProjetoCurso).Visible = (listaRecursos.Contains(((Control)lnkNovoProjetoCurso).SkinID) ? true : false);
		if (!((Page)this).IsPostBack)
		{
			new ProjetoBO();
			new AutenticacaoBO();
			lnkNovoProjetoCurso.NavigateUrl = "FrmCadastrar.aspx";
			Label1.Text = "Cursos";
			((ListControl)ddlStatusTurma).SelectedValue = "0";
			PreecherGridView(txtCriterio.Text, isTurmaAtiva: false, visible: false);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		int value = Convert.ToInt32(((ListControl)ddlStatusTurma).SelectedValue);
		PreecherGridView(txtCriterio.Text, Convert.ToBoolean(value), visible: false);
	}

	protected void PreecherGridView(string nome, bool isTurmaAtiva, bool visible)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		((Control)PanelMsgResultado).Visible = visible;
		List<ProjetoCurso> list = new ProjetoBO().FiltrarProjetoCurso(nome, isTurmaAtiva);
		((BaseDataBoundControl)GridView1).DataSource = ListarCursosPorPerfil(list);
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " registro(s) disponível(is)";
		if (list.Count >= 10 && GridView1.Rows.Count > 0)
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
		int value = Convert.ToInt32(((ListControl)ddlStatusTurma).SelectedValue);
		PreecherGridView(txtCriterio.Text, Convert.ToBoolean(value), visible: false);
	}

	protected void lnkConsultar_Click(object sender, EventArgs e)
	{
		int value = Convert.ToInt32(((ListControl)ddlStatusTurma).SelectedValue);
		PreecherGridView(txtCriterio.Text, Convert.ToBoolean(value), visible: false);
	}

	protected void lnkMostrarTodos_Click(object sender, EventArgs e)
	{
		PreecherGridView(null, isTurmaAtiva: true, visible: false);
		txtCriterio.Text = string.Empty;
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (((CommandEventArgs)e).CommandName != "Page")
		{
			new CursoBO();
			int num = Convert.ToInt32(((CommandEventArgs)e).CommandArgument);
			_ = GridView1.Rows[num];
			GridView1.DataKeys[num].Value.ToString();
			_ = string.Empty;
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		if ((int)e.Row.RowType == 2)
		{
			HyperLink val = (HyperLink)((Control)e.Row).FindControl("lnkAtualizarProjetoCurso");
			HyperLink val2 = (HyperLink)((Control)e.Row).FindControl("lnkTurma");
			HyperLink val3 = (HyperLink)((Control)e.Row).FindControl("lnkDisciplina");
			((Control)val).Visible = (listaRecursos.Contains(((Control)val).SkinID) ? true : false);
			((Control)val2).Visible = (listaRecursos.Contains(((Control)val2).SkinID) ? true : false);
			((Control)val3).Visible = (listaRecursos.Contains(((Control)val3).SkinID) ? true : false);
		}
	}

	private List<ProjetoCurso> ListarCursosPorPerfil(List<ProjetoCurso> registros)
	{
		try
		{
			long usuarioUID = (long)((Page)this).Session["usuarioUID"];
			AutenticacaoBO autenticacaoBO = new AutenticacaoBO();
			ProjetoCorpoDocenteBO projetoCorpoDocenteBO = new ProjetoCorpoDocenteBO();
			List<long> list = (List<long>)((Page)this).Session["listaPerfis"];
			List<ProjetoCurso> list2 = new List<ProjetoCurso>();
			List<ProjetoCurso> list3 = new List<ProjetoCurso>();
			List<ProjetoCurso> list4 = new List<ProjetoCurso>();
			List<ProjetoCurso> list5 = new List<ProjetoCurso>();
			List<ProjetoCurso> list6 = new List<ProjetoCurso>();
			if (list.Contains(58L) || list.Contains(127L))
			{
				return registros;
			}
			if (list.Contains(59L) || list.Contains(60L))
			{
				ufmt.sig.entity.Usuario usuario = autenticacaoBO.GetUsuario(usuarioUID);
				Servidor servidor = autenticacaoBO.GetServidorAtivo(usuario.Pessoa.PessoaUID);
				if (servidor != null)
				{
					list3 = registros.Where((ProjetoCurso c) => c.coordenadorServidorUID == servidor.ServidorUID || c.viceCoordenadorServidorUID == servidor.ServidorUID).ToList();
				}
			}
			if (list.Contains(61L))
			{
				ufmt.sig.entity.Usuario usuario2 = autenticacaoBO.GetUsuario(usuarioUID);
				list4 = registros.Where((ProjetoCurso c) => c.secretarioUID == usuario2.Pessoa.PessoaUID).ToList();
			}
			if (list.Contains(119L))
			{
				ufmt.sig.entity.Usuario usuario3 = autenticacaoBO.GetUsuario(usuarioUID);
				List<long> listaProjetoCorpoDocenteUID = projetoCorpoDocenteBO.BucarListaProjetoCorpoDocentesUID(usuario3.Pessoa.Cpf);
				list5 = registros.Where((ProjetoCurso c) => c.ProjetoTurma.Any((ProjetoTurma t) => t.ProjetoTurmaDisciplina.Any((ProjetoTurmaDisciplina w) => listaProjetoCorpoDocenteUID.Contains(w.projetoCorpoDocenteUID) || listaProjetoCorpoDocenteUID.Contains(w.projetoCorpoDocenteSecundarioUID.GetValueOrDefault())))).ToList();
			}
			if (list.Contains(178L))
			{
				UsuarioBO usuarioBO = new UsuarioBO();
				ProjetoUsuarioUnidade projetoUsuarioUnidade = usuarioBO.BuscarVinculoUsuarioUnidade(usuarioUID);
				if (projetoUsuarioUnidade != null)
				{
					list6 = registros.Where((ProjetoCurso e) => e.proponenteUnidadeUID == projetoUsuarioUnidade.unidadeUID).ToList();
				}
			}
			foreach (ProjetoCurso item in list3)
			{
				if (!list2.Select((ProjetoCurso e) => e.projetoCursoUID).Contains(item.projetoCursoUID))
				{
					list2.Add(item);
				}
			}
			foreach (ProjetoCurso item2 in list4)
			{
				if (!list2.Select((ProjetoCurso e) => e.projetoCursoUID).Contains(item2.projetoCursoUID))
				{
					list2.Add(item2);
				}
			}
			foreach (ProjetoCurso item3 in list5)
			{
				if (!list2.Select((ProjetoCurso e) => e.projetoCursoUID).Contains(item3.projetoCursoUID))
				{
					list2.Add(item3);
				}
			}
			foreach (ProjetoCurso item4 in list6)
			{
				if (!list2.Select((ProjetoCurso e) => e.projetoCursoUID).Contains(item4.projetoCursoUID))
				{
					list2.Add(item4);
				}
			}
			return list2;
		}
		catch (Exception)
		{
			return new List<ProjetoCurso>();
		}
	}
}
