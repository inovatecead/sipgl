using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turmaDisciplina;

public class FrmVincularDocentes : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlDetalheInscricao;

	protected Panel Panel1;

	protected Label lblMsgCadastro;

	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HiddenField hddProjetoDisciplinaUID;

	protected HiddenField hddProjetoTurmaDisciplinaUID;

	protected Panel pnlFormularioInscricao;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected ValidationSummary ValidationSummary1;

	protected Label lbNome;

	protected TextBox txtNome;

	protected Label lbCargaHoraria;

	protected TextBox txtCargaHoraria;

	protected Label lbDocentePrincipal;

	protected RequiredFieldValidator RequiredFieldValidator35;

	protected DropDownList ddlDocentePrincipal;

	protected Label lbRemuneracaoPrincipal;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected DropDownList ddlRemuneracaoDocentePrincipal;

	protected Panel pnlTipoRemuneracaoPrincipal;

	protected Label lbTipoRemuneracaoPrincipal;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected DropDownList ddlTipoRemuneracaoDocentePrincipal;

	protected Label lbQualPrincipal;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected TextBox txtOutraRemuneracaoPrincipal;

	protected Label lbDocenteSecundario;

	protected DropDownList ddlDocenteSecundario;

	protected Label lbRemuneracaoSecundario;

	protected DropDownList ddlRemuneracaoDocenteSecundario;

	protected Panel pnlTipoRemuneracaoSecundario;

	protected Label lbTipoRemuneracaoSecundario;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected DropDownList ddlTipoRemuneracaoDocenteSecundario;

	protected Label lbQualSecundario;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected TextBox txtOutraRemuneracaoSecundario;

	protected Label lbDataInicio;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtDataInicio;

	protected MaskedEditValidator MEVData2;

	protected MaskedEditExtender txtDataInicio_MaskedEditExtender;

	protected Label lbDataTermino;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtDataTermino;

	protected MaskedEditExtender txtDataTermino_MaskedEditExtender;

	protected MaskedEditValidator MEVData3;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("GerenciarDisciplinas_VincularDocentes"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		((Control)btnSalvar).Visible = (listaRecursos.Contains("VincularDocentes_Salvar") ? true : false);
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			hddProjetoDisciplinaUID.Value = ((Page)this).Request.QueryString["projetoDisciplinaUID"];
			hddProjetoTurmaDisciplinaUID.Value = ((Page)this).Request.QueryString["projetoTurmaDisciplinaUID"];
			lnkTitulo.Text = "[ Voltar para Gerenciamento de Disciplinas ] ";
			lnkTitulo.NavigateUrl = "~/webapp/turmaDisciplina/FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value;
			lblTitulo.Text = "Vincular Docentes";
			ProjetoDisciplinaBO projetoDisciplinaBO = new ProjetoDisciplinaBO();
			ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
			ProjetoDisciplina projetoDisciplina = projetoDisciplinaBO.BuscarDisciplinaPorId(long.Parse(hddProjetoDisciplinaUID.Value));
			ProjetoTurmaDisciplina projetoTurmaDisciplina = projetoTurmaDisciplinaBO.BuscarTurmaDisciplinaPorTurmaDisciplina(long.Parse(hddProjetoTurmaUID.Value), long.Parse(hddProjetoDisciplinaUID.Value));
			popularDropdowns();
			PopularDados(projetoDisciplina, projetoTurmaDisciplina);
		}
	}

	protected void PopularDados(ProjetoDisciplina projetoDisciplina, ProjetoTurmaDisciplina projetoTurmaDisciplina)
	{
		txtNome.Text = projetoDisciplina.nome;
		txtCargaHoraria.Text = projetoDisciplina.cargaHoraria.ToString();
		if (projetoTurmaDisciplina == null)
		{
			return;
		}
		txtDataInicio.Text = projetoTurmaDisciplina.dataInicio.ToString();
		txtDataTermino.Text = projetoTurmaDisciplina.dataTermino.ToString();
		((ListControl)ddlDocentePrincipal).SelectedValue = projetoTurmaDisciplina.projetoCorpoDocenteUID.ToString();
		((ListControl)ddlRemuneracaoDocentePrincipal).SelectedValue = projetoTurmaDisciplina.possuiRemuneracaoDocentePrincipal.ToString();
		((ListControl)ddlTipoRemuneracaoDocentePrincipal).SelectedValue = projetoTurmaDisciplina.tipoRemuneracaoDocentePrincipal.ToString();
		txtOutraRemuneracaoPrincipal.Text = projetoTurmaDisciplina.descricaoOutrosTiposRemuneracaoPrincipal;
		((ListControl)ddlDocenteSecundario).SelectedValue = projetoTurmaDisciplina.projetoCorpoDocenteSecundarioUID.ToString();
		((ListControl)ddlRemuneracaoDocenteSecundario).SelectedValue = projetoTurmaDisciplina.possuiRemuneracaoDocenteSecundario.ToString();
		((ListControl)ddlTipoRemuneracaoDocenteSecundario).SelectedValue = projetoTurmaDisciplina.tipoRemuneracaoDocenteSecundario.ToString();
		txtOutraRemuneracaoSecundario.Text = projetoTurmaDisciplina.descricaoOutrosTiposRemuneracaoSecundario;
		if (projetoTurmaDisciplina.possuiRemuneracaoDocentePrincipal == 1)
		{
			((Control)ddlTipoRemuneracaoDocentePrincipal).Visible = true;
			((Control)pnlTipoRemuneracaoPrincipal).Visible = true;
			if (projetoTurmaDisciplina.tipoRemuneracaoDocentePrincipal == 3)
			{
				((Control)txtOutraRemuneracaoPrincipal).Visible = true;
				((Control)lbQualPrincipal).Visible = true;
			}
		}
		if (projetoTurmaDisciplina.possuiRemuneracaoDocenteSecundario == 1)
		{
			((Control)ddlTipoRemuneracaoDocenteSecundario).Visible = true;
			((Control)pnlTipoRemuneracaoSecundario).Visible = true;
			if (projetoTurmaDisciplina.tipoRemuneracaoDocenteSecundario == 3)
			{
				((Control)txtOutraRemuneracaoSecundario).Visible = true;
				((Control)lbQualSecundario).Visible = true;
			}
		}
	}

	private void popularDropdowns()
	{
		List<ProjetoCorpoDocenteDTO> dataSource = new ProjetoDisciplinaDAL().ListarTodosDocentes();
		((BaseDataBoundControl)ddlDocentePrincipal).DataSource = dataSource;
		((ListControl)ddlDocentePrincipal).DataTextField = "nome";
		((ListControl)ddlDocentePrincipal).DataValueField = "projetoCorpoDocenteUID";
		((Control)ddlDocentePrincipal).DataBind();
		((BaseDataBoundControl)ddlDocenteSecundario).DataSource = dataSource;
		((ListControl)ddlDocenteSecundario).DataTextField = "nome";
		((ListControl)ddlDocenteSecundario).DataValueField = "projetoCorpoDocenteUID";
		((Control)ddlDocenteSecundario).DataBind();
		((BaseDataBoundControl)ddlRemuneracaoDocentePrincipal).DataSource = EnumService.EnumList(typeof(EnumConfirmacao));
		((ListControl)ddlRemuneracaoDocentePrincipal).DataValueField = "key";
		((ListControl)ddlRemuneracaoDocentePrincipal).DataTextField = "value";
		((Control)ddlRemuneracaoDocentePrincipal).DataBind();
		((BaseDataBoundControl)ddlRemuneracaoDocenteSecundario).DataSource = EnumService.EnumList(typeof(EnumConfirmacao));
		((ListControl)ddlRemuneracaoDocenteSecundario).DataValueField = "key";
		((ListControl)ddlRemuneracaoDocenteSecundario).DataTextField = "value";
		((Control)ddlRemuneracaoDocenteSecundario).DataBind();
		((BaseDataBoundControl)ddlTipoRemuneracaoDocentePrincipal).DataSource = EnumService.EnumList(typeof(EnumTipoRemuneracao));
		((ListControl)ddlTipoRemuneracaoDocentePrincipal).DataValueField = "key";
		((ListControl)ddlTipoRemuneracaoDocentePrincipal).DataTextField = "value";
		((Control)ddlTipoRemuneracaoDocentePrincipal).DataBind();
		((BaseDataBoundControl)ddlTipoRemuneracaoDocenteSecundario).DataSource = EnumService.EnumList(typeof(EnumTipoRemuneracao));
		((ListControl)ddlTipoRemuneracaoDocenteSecundario).DataValueField = "key";
		((ListControl)ddlTipoRemuneracaoDocenteSecundario).DataTextField = "value";
		((Control)ddlTipoRemuneracaoDocenteSecundario).DataBind();
	}

	protected void btnVincular_Click(object sender, EventArgs e)
	{
		ProjetoTurmaDisciplinaBO projetoTurmaDisciplinaBO = new ProjetoTurmaDisciplinaBO();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		ProjetoTurmaDisciplina projetoTurmaDisciplina = new ProjetoTurmaDisciplina();
		projetoTurmaDisciplina.projetoDisciplinaUID = long.Parse(hddProjetoDisciplinaUID.Value);
		projetoTurmaDisciplina.projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		projetoTurmaDisciplina.dataInicio = DateTime.Parse(txtDataInicio.Text);
		projetoTurmaDisciplina.dataTermino = DateTime.Parse(txtDataTermino.Text);
		projetoTurmaDisciplina.projetoCorpoDocenteUID = long.Parse(((ListControl)ddlDocentePrincipal).SelectedValue);
		projetoTurmaDisciplina.possuiRemuneracaoDocentePrincipal = int.Parse(((ListControl)ddlRemuneracaoDocentePrincipal).SelectedValue);
		if (int.Parse(((ListControl)ddlRemuneracaoDocentePrincipal).SelectedValue) == 1)
		{
			projetoTurmaDisciplina.tipoRemuneracaoDocentePrincipal = int.Parse(((ListControl)ddlTipoRemuneracaoDocentePrincipal).SelectedValue);
			if (int.Parse(((ListControl)ddlTipoRemuneracaoDocentePrincipal).SelectedValue) == 3)
			{
				projetoTurmaDisciplina.descricaoOutrosTiposRemuneracaoPrincipal = txtOutraRemuneracaoPrincipal.Text;
			}
		}
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlDocenteSecundario).SelectedValue))
		{
			projetoTurmaDisciplina.projetoCorpoDocenteSecundarioUID = long.Parse(((ListControl)ddlDocenteSecundario).SelectedValue);
		}
		if (!string.IsNullOrWhiteSpace(((ListControl)ddlRemuneracaoDocenteSecundario).SelectedValue))
		{
			projetoTurmaDisciplina.possuiRemuneracaoDocenteSecundario = int.Parse(((ListControl)ddlRemuneracaoDocenteSecundario).SelectedValue);
			if (int.Parse(((ListControl)ddlRemuneracaoDocenteSecundario).SelectedValue) == 1)
			{
				if (string.IsNullOrWhiteSpace(((ListControl)ddlTipoRemuneracaoDocenteSecundario).SelectedValue))
				{
					resultadoOperacao.TextMessage = "Obrigatório a seleção do tipo de remuneração para o docente secundário.";
					resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
					PopularMensagemRegraNegocio(resultadoOperacao);
					return;
				}
				projetoTurmaDisciplina.tipoRemuneracaoDocenteSecundario = int.Parse(((ListControl)ddlTipoRemuneracaoDocenteSecundario).SelectedValue);
				if (int.Parse(((ListControl)ddlTipoRemuneracaoDocenteSecundario).SelectedValue) == 3)
				{
					projetoTurmaDisciplina.descricaoOutrosTiposRemuneracaoSecundario = txtOutraRemuneracaoSecundario.Text;
				}
			}
		}
		resultadoOperacao = projetoTurmaDisciplinaBO.VincularDocente(projetoTurmaDisciplina);
		if (resultadoOperacao.Erro)
		{
			PopularMensagemRegraNegocio(resultadoOperacao);
			return;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx?projetoCursoUID=" + hddProjetoCursoUID.Value + "&projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoDisciplinaUID=" + hddProjetoDisciplinaUID.Value);
	}

	protected void ddlTipoRemuneracaoDocentePrincipal_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)ddlTipoRemuneracaoDocentePrincipal).SelectedValue == 3.ToString())
		{
			((Control)txtOutraRemuneracaoPrincipal).Visible = true;
			((Control)lbQualPrincipal).Visible = true;
		}
		else
		{
			((Control)txtOutraRemuneracaoPrincipal).Visible = false;
			txtOutraRemuneracaoPrincipal.Text = "";
			((Control)lbQualPrincipal).Visible = false;
		}
	}

	protected void ddlTipoRemuneracaoDocenteSecundario_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)ddlTipoRemuneracaoDocenteSecundario).SelectedValue == 3.ToString())
		{
			((Control)txtOutraRemuneracaoSecundario).Visible = true;
			((Control)lbQualSecundario).Visible = true;
		}
		else
		{
			((Control)txtOutraRemuneracaoSecundario).Visible = false;
			txtOutraRemuneracaoSecundario.Text = "";
			((Control)lbQualSecundario).Visible = false;
		}
	}

	protected void ddlRemuneracaoDocentePrincipal_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)ddlRemuneracaoDocentePrincipal).SelectedValue == 1.ToString())
		{
			((Control)pnlTipoRemuneracaoPrincipal).Visible = true;
			return;
		}
		((Control)pnlTipoRemuneracaoPrincipal).Visible = false;
		((ListControl)ddlTipoRemuneracaoDocentePrincipal).SelectedValue = "";
		((Control)txtOutraRemuneracaoPrincipal).Visible = false;
		txtOutraRemuneracaoPrincipal.Text = "";
		((Control)lbQualPrincipal).Visible = false;
	}

	protected void ddlRemuneracaoDocenteSecundario_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)ddlRemuneracaoDocenteSecundario).SelectedValue == 1.ToString())
		{
			((Control)pnlTipoRemuneracaoSecundario).Visible = true;
			return;
		}
		((Control)pnlTipoRemuneracaoSecundario).Visible = false;
		((ListControl)ddlTipoRemuneracaoDocenteSecundario).SelectedValue = "";
		((Control)txtOutraRemuneracaoSecundario).Visible = false;
		txtOutraRemuneracaoSecundario.Text = "";
		((Control)lbQualSecundario).Visible = false;
	}

	protected void ddlDocenteSecundario_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(((ListControl)ddlDocenteSecundario).SelectedValue))
		{
			((ListControl)ddlRemuneracaoDocenteSecundario).SelectedValue = "";
			ddlRemuneracaoDocenteSecundario_SelectedIndexChanged(sender, e);
		}
	}
}
