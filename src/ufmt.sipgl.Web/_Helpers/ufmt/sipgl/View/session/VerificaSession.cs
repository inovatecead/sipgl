using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.View.session;

public class VerificaSession : Page
{
	protected List<string> listaRecursos;

	public VerificaSession()
	{
		this.Load += VerificaSessionPage_Load;
	}

	private void VerificaSessionPage_Load(object sender, EventArgs e)
	{
		listaRecursos = (List<string>)((Page)this).Session["listaRecursos"];
		VerificaAcesso();
		ApplyMessage();
		CleanSession();
		if (((Page)this).IsPostBack)
		{
			CleanLabels();
		}
	}

	public void PopulateMessage(ResultadoOperacao resultadoOperacao)
	{
		if (resultadoOperacao != null)
		{
			((Page)this).Session["message"] = resultadoOperacao.TextMessage;
			((Page)this).Session["type"] = resultadoOperacao.TypeMessageEnum.ToString();
		}
	}

	public void PopularMensagemRegraNegocio(ResultadoOperacao resultadoOperacao)
	{
		PopulateMessage(resultadoOperacao);
		ApplyMessage();
		CleanSession();
	}

	private void ApplyMessage()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		string text = "";
		string text2 = "";
		if (((Page)this).Session["message"] != null)
		{
			text = ((Page)this).Session["message"].ToString();
		}
		if (((Page)this).Session["type"] != null)
		{
			text2 = ((Page)this).Session["type"].ToString();
		}
		if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		if (((Control)this.Page.Master).FindControl("textMessage") != null)
		{
			((Label)((Control)this.Page.Master).FindControl("textMessage")).Text = text;
		}
		if (((Control)this.Page.Master).FindControl("typeMessage") != null)
		{
			WebControl val = (WebControl)((Control)this.Page.Master).FindControl("typeMessage");
			if (text2 == TypeMessageEnum.Success.ToString())
			{
				val.CssClass = "successMessage";
			}
			if (text2 == TypeMessageEnum.Warning.ToString())
			{
				val.CssClass = "warningMessage";
			}
			if (text2 == TypeMessageEnum.Error.ToString())
			{
				val.CssClass = "errorMessage";
			}
			((Control)this.Page.Master).FindControl("typeMessage").Visible = true;
		}
	}

	private void CleanSession()
	{
		((Page)this).Session.Remove("message");
		((Page)this).Session.Remove("type");
	}

	private void CleanLabels()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		((Label)((Control)this.Page.Master).FindControl("textMessage")).Text = "";
		((Control)this.Page.Master).FindControl("typeMessage").Visible = false;
	}

	private void VerificaAcesso()
	{
		if (((Page)this).Session["autenticado"] == null)
		{
			((Page)this).Response.Redirect("~/Default.aspx");
			return;
		}
		Control val = ((Control)this.Page.Master).FindControl("MenuCursos");
		Control val2 = ((Control)this.Page.Master).FindControl("MenuUnidades");
		Control val3 = ((Control)this.Page.Master).FindControl("MenuDiscentes");
		Control val4 = ((Control)this.Page.Master).FindControl("MenuDocentes");
		Control val5 = ((Control)this.Page.Master).FindControl("MenuGerenciarUsuarios");
		Control val6 = ((Control)this.Page.Master).FindControl("MenuPermissoes");
		val.Visible = (listaRecursos.Contains(val.SkinID) ? true : false);
		val2.Visible = (((List<string>)((Page)this).Session["listaRecursos"]).Contains(val2.SkinID) ? true : false);
		val3.Visible = (((List<string>)((Page)this).Session["listaRecursos"]).Contains(val3.SkinID) ? true : false);
		val4.Visible = (((List<string>)((Page)this).Session["listaRecursos"]).Contains(val4.SkinID) ? true : false);
		val5.Visible = (((List<string>)((Page)this).Session["listaRecursos"]).Contains(val5.SkinID) ? true : false);
		val6.Visible = (((List<string>)((Page)this).Session["listaRecursos"]).Contains(val6.SkinID) ? true : false);
	}
}
