using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.enderecoPoloApoioPresencialEAD;

public class FrmCadastrar : VerificaSession
{
	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel pnlFormularioInscricao;

	protected HiddenField hddProjetoCursoUID;

	protected ValidationSummary ValidationSummary1;

	protected Label lbTipoUnidadeEnsino;

	protected RequiredFieldValidator RequiredFieldValidator2;

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

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("MenuUnidades_NovaUnidade"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["ProjetoCursoUID"];
			lnkTitulo.Text = "[ Voltar para Polos ] ";
			lnkTitulo.NavigateUrl = "~/webapp/enderecoPoloApoioPresencialEAD/FrmListar.aspx?ProjetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Nova Unidade";
			CursoDAL cursoDAL = new CursoDAL();
			((BaseDataBoundControl)ddlEnderecoUF).DataSource = cursoDAL.GetUF();
			((ListControl)ddlEnderecoUF).DataTextField = "Nome";
			((ListControl)ddlEnderecoUF).DataValueField = "UFUID";
			((Control)ddlEnderecoUF).DataBind();
			((BaseDataBoundControl)ddlTipoUnidadeEnsino).DataSource = EnumService.EnumList(typeof(EnumTipoUnidadeEnsino));
			((ListControl)ddlTipoUnidadeEnsino).DataValueField = "key";
			((ListControl)ddlTipoUnidadeEnsino).DataTextField = "value";
			((Control)ddlTipoUnidadeEnsino).DataBind();
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EnderecoPoloPresencialEadDAL enderecoPoloPresencialEadDAL = new EnderecoPoloPresencialEadDAL();
			EnderecoPoloApoioPresencialEAD enderecoPoloApoioPresencialEAD = new EnderecoPoloApoioPresencialEAD();
			string[] array = txtMunicipio.Text.Trim().Split(new char[1] { '|' });
			if (!long.TryParse(array[0], out var _))
			{
				txtMunicipio.Text = string.Empty;
				((Control)txtMunicipio).Focus();
				resultadoOperacao.TextMessage = "Municipio não foi selecionado corretamente. Tente novamente efetuando nova consulta";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			enderecoPoloApoioPresencialEAD.tipoUnidadeEnsino = int.Parse(((ListControl)ddlTipoUnidadeEnsino).SelectedValue);
			enderecoPoloApoioPresencialEAD.identificacaoEndereco = txtDescricao.Text;
			enderecoPoloApoioPresencialEAD.logradouro = txtLogradouro.Text;
			enderecoPoloApoioPresencialEAD.municipioEnderecoUID = int.Parse(array[0]);
			enderecoPoloApoioPresencialEAD.CEP = txtCEPendereco.Text;
			enderecoPoloApoioPresencialEAD.numeroEndereco = int.Parse(txtNumeroEndereco.Text);
			enderecoPoloApoioPresencialEAD.complementoBairro = txtComplementoEndereco.Text;
			enderecoPoloApoioPresencialEAD.bairroEndereco = txtBairroEndereco.Text;
			enderecoPoloApoioPresencialEAD.informacoesReferenciaEndereco = txtInfoReferenciaEndereco.Text;
			enderecoPoloApoioPresencialEAD.telefone = txtTelefone.Text;
			enderecoPoloApoioPresencialEAD.fax = txtFax.Text;
			enderecoPoloApoioPresencialEAD.email = txtEmail.Text;
			enderecoPoloApoioPresencialEAD.site = txtSite.Text;
			enderecoPoloApoioPresencialEAD.enderecoUFUID = ((ListControl)ddlEnderecoUF).SelectedValue.ToString();
			resultadoOperacao = enderecoPoloPresencialEadDAL.Salvar(enderecoPoloApoioPresencialEAD);
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
			resultadoOperacao.TextMessage = "Erro ao realizar a operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			PopulateMessage(resultadoOperacao);
			((Page)this).Response.Redirect("FrmCadastrar.aspx?ProjetoCursoUID=" + hddProjetoCursoUID.Value, false);
		}
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx");
	}
}
