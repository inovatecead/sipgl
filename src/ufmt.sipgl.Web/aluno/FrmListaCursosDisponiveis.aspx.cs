using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;
using ufmt.sipgl.View.aluno.Base;
using ufmt.sipgl.View.componentes;

namespace ufmt.sipgl.View;

public class FrmListaCursosDisponiveis : AlunoBase
{
	protected HiddenField hddPreMatriculaPessoaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lblTotalRegistros;

	protected GridView GridView1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!((Page)this).IsPostBack)
		{
			long preMatriculaPessoaUID = long.Parse(((Page)this).Session["preMatriculaPessoaUID"].ToString());
			PreecherGridView(preMatriculaPessoaUID);
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		PreecherGridView(long.Parse(((Page)this).Session["preMatriculaPessoaUID"].ToString()));
	}

	protected void PreecherGridView(long preMatriculaPessoaUID)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		List<PreInscricaoDTO> list = new ProjetoPreInscricaoBO().ListarInscricoesDisponiveis(preMatriculaPessoaUID);
		((BaseDataBoundControl)GridView1).DataSource = list;
		((Control)GridView1).DataBind();
		lblTotalRegistros.Text = "<b>Exibindo </b>" + list.Count + " Inscrições disponíveis";
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

	protected void GridViewListaInscricoes_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		if ((int)e.Row.RowType != 2)
		{
			return;
		}
		long projetoTurmaUID = long.Parse(DataBinder.Eval(e.Row.DataItem, "projetoTurmaUID").ToString());
		long preMatriculaPessoaUID = long.Parse(((Page)this).Session["preMatriculaPessoaUID"].ToString());
		ProjetoPreInscricao projetoPreInscricao = new ProjetoPreInscricaoBO().BuscarInscricaoPorTurmaPessoa(projetoTurmaUID, preMatriculaPessoaUID);
		if (projetoPreInscricao != null)
		{
			Label val = (Label)((Control)e.Row).FindControl("lblDescricaoSituacaoInscricao");
			EnumSituacaoPreInscricao situacaoPreInscricaoEnum = (EnumSituacaoPreInscricao)projetoPreInscricao.situacaoPreInscricaoEnum;
			val.Text = situacaoPreInscricaoEnum.ObterDescricao();
			LinkButton val2 = (LinkButton)((Control)e.Row).FindControl("lnkInscrever");
			((WebControl)val2).Enabled = false;
			switch (situacaoPreInscricaoEnum)
			{
			case EnumSituacaoPreInscricao.APROVADO:
				val2.Text = "Inscrito";
				((WebControl)val2).Enabled = false;
				val2.OnClientClick = null;
				break;
			case EnumSituacaoPreInscricao.CANCELADO:
				((Control)val2).Visible = false;
				break;
			case EnumSituacaoPreInscricao.PENDENTE:
				val2.Text = "Pré-Inscrito";
				((WebControl)val2).Enabled = false;
				val2.OnClientClick = null;
				break;
			}
		}
	}

	protected void lnkInscrever_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		long projetoTurmaUID = long.Parse(((LinkButton)sender).CommandArgument.ToString());
		long preMatriculaPessoaUID = long.Parse(((Page)this).Session["preMatriculaPessoaUID"].ToString());
		ResultadoOperacao resultadoOperacao = new ProjetoPreInscricaoBO().PreInscreverDiscente(preMatriculaPessoaUID, projetoTurmaUID);
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("~/aluno/FrmListaCursosDisponiveis.aspx");
	}
}
