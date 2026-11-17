using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.enderecoPoloApoioPresencialEAD;

public class FrmAlterar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected HiddenField hddEnderecoPoloUID;

	protected Panel pnlFormularioInscricao;

	protected ValidationSummary ValidationSummary1;

	protected Label lbTipoUnidadeEnsino;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected DropDownList ddlTipoUnidadeEnsino;

	protected Label lbDescricao;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtDescricao;

	protected Label Label27;

	protected RequiredFieldValidator RequiredFieldValidator17;

	protected DropDownList ddlEnderecoUF;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtMunicipio;

	protected Label lbLogradouro;

	protected RequiredFieldValidator RequiredFieldValidator92;

	protected TextBox txtLogradouro;

	protected Label lbCEP;

	protected RequiredFieldValidator RequiredFieldValidator91;

	protected TextBox txtCEPendereco;

	protected MaskedEditExtender MaskedEditExtender1;

	protected Label lbNumero;

	protected RequiredFieldValidator RequiredFieldValidator93;

	protected TextBox txtNumeroEndereco;

	protected Label lbComplemento;

	protected TextBox txtComplementoEndereco;

	protected Label lbBairro;

	protected RequiredFieldValidator RequiredFieldValidator94;

	protected TextBox txtBairroEndereco;

	protected Label lbInformacoesReferencia;

	protected TextBox txtInfoReferenciaEndereco;

	protected Label Label57;

	protected RequiredFieldValidator RequiredFieldValidator48;

	protected TextBox txtTelefone;

	protected MaskedEditExtender MaskedEditExtenderTelefone;

	protected Label lbFax;

	protected TextBox txtFax;

	protected Label lbEmail;

	protected TextBox txtEmail;

	protected Label lbSite;

	protected TextBox txtSite;

	protected Button btnVoltar;

	protected Button btnAlterar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuUnidades_Editar"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			lnkTitulo.Text = "[ Voltar para Polos] ";
			lnkTitulo.NavigateUrl = "~/webapp/enderecoPoloApoioPresencialEAD/FrmListar.aspx";
			lblTitulo.Text = "Editar Unidade";
			EnderecoPoloPresencialEadDAL enderecoPoloPresencialEadDAL = new EnderecoPoloPresencialEadDAL();
			CursoDAL cursoDAL = new CursoDAL();
			hddEnderecoPoloUID.Value = ((Page)this).Request.QueryString["enderecoPoloUID"];
			ViewEnderecoPoloEAD viewEnderecoPoloEAD = enderecoPoloPresencialEadDAL.BuscarViewEnderecoPoloEAD(int.Parse(hddEnderecoPoloUID.Value));
			txtMunicipio.Text = viewEnderecoPoloEAD.municipio;
			txtDescricao.Text = viewEnderecoPoloEAD.identificacaoEndereco;
			txtLogradouro.Text = viewEnderecoPoloEAD.logradouro;
			txtCEPendereco.Text = viewEnderecoPoloEAD.CEP;
			txtNumeroEndereco.Text = viewEnderecoPoloEAD.numeroEndereco.ToString();
			txtComplementoEndereco.Text = viewEnderecoPoloEAD.complementoBairro;
			txtBairroEndereco.Text = viewEnderecoPoloEAD.bairroEndereco;
			txtInfoReferenciaEndereco.Text = viewEnderecoPoloEAD.informacoesReferenciaEndereco;
			txtTelefone.Text = viewEnderecoPoloEAD.telefone;
			txtFax.Text = viewEnderecoPoloEAD.fax;
			txtEmail.Text = viewEnderecoPoloEAD.email;
			txtSite.Text = viewEnderecoPoloEAD.site;
			((BaseDataBoundControl)ddlTipoUnidadeEnsino).DataSource = EnumService.EnumList(typeof(EnumTipoUnidadeEnsino));
			((ListControl)ddlTipoUnidadeEnsino).DataValueField = "key";
			((ListControl)ddlTipoUnidadeEnsino).DataTextField = "value";
			((Control)ddlTipoUnidadeEnsino).DataBind();
			((ListControl)ddlTipoUnidadeEnsino).SelectedValue = viewEnderecoPoloEAD.tipoUnidadeEnsino.ToString();
			((BaseDataBoundControl)ddlEnderecoUF).DataSource = cursoDAL.GetUF();
			((ListControl)ddlEnderecoUF).DataTextField = "Nome";
			((ListControl)ddlEnderecoUF).DataValueField = "UFUID";
			((Control)ddlEnderecoUF).DataBind();
			((ListControl)ddlEnderecoUF).SelectedValue = viewEnderecoPoloEAD.enderecoUFUID;
		}
	}

	protected void btnAlterar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			resultadoOperacao = new EnderecoPoloPresencialEadDAL().Alterar(new EnderecoPoloApoioPresencialEAD
			{
				enderecoUID = int.Parse(hddEnderecoPoloUID.Value),
				tipoUnidadeEnsino = int.Parse(((ListControl)ddlTipoUnidadeEnsino).SelectedValue),
				logradouro = txtLogradouro.Text,
				CEP = txtCEPendereco.Text,
				numeroEndereco = int.Parse(txtNumeroEndereco.Text),
				complementoBairro = txtComplementoEndereco.Text,
				bairroEndereco = txtBairroEndereco.Text,
				informacoesReferenciaEndereco = txtInfoReferenciaEndereco.Text,
				telefone = txtTelefone.Text,
				fax = txtFax.Text,
				email = txtEmail.Text,
				site = txtSite.Text,
				identificacaoEndereco = txtDescricao.Text,
				enderecoUFUID = ((ListControl)ddlEnderecoUF).SelectedValue.ToString()
			});
			if (resultadoOperacao.Erro)
			{
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			PopulateMessage(resultadoOperacao);
			((Page)this).Response.Redirect("FrmListar.aspx", false);
		}
		catch (Exception)
		{
			resultadoOperacao.TextMessage = "Erro ao realizar a operação. Entre em contato com o administrador do sistema";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			PopulateMessage(resultadoOperacao);
			((Page)this).Response.Redirect("FrmCadastrar.aspx?enderecoPoloUID=" + hddEnderecoPoloUID.Value, false);
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx?");
	}
}
