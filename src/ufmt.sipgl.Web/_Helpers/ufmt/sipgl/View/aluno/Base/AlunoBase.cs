using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.View.aluno.Base;

public class AlunoBase : Page
{
	public AlunoBase()
	{
		this.Load += VerificaSessionPage_Load;
	}

	private void VerificaSessionPage_Load(object sender, EventArgs e)
	{
		VerificarAcesso();
		ApplyMessage();
		CleanMessage();
	}

	private void VerificarAcesso()
	{
		if (((Page)this).Session["preMatriculaPessoaUID"] == null)
		{
			((Control)this.Page.Master).FindControl("pnlMenu").Visible = false;
			((Page)this).Response.Redirect("~/aluno/Default.aspx");
		}
	}

	public void PopularMensagemRegraNegocio(ResultadoOperacao resultadoOperacao)
	{
		PopulateMessage(resultadoOperacao);
		ApplyMessage();
		CleanMessage();
	}

	public void PopulateMessage(ResultadoOperacao resultadoOperacao)
	{
		if (resultadoOperacao != null)
		{
			((Page)this).Session["message"] = resultadoOperacao.TextMessage;
			((Page)this).Session["type"] = resultadoOperacao.TypeMessageEnum.ToString();
		}
	}

	private void CleanMessage()
	{
		((Page)this).Session["message"] = "";
		((Page)this).Session["type"] = "";
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
}
