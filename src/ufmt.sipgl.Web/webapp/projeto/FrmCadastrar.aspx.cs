using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.projeto;

public class FrmCadastrar : VerificaSession
{
	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Panel PanelObjProjetoCurso;

	protected ValidationSummary ValidationSummary1;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected DropDownList ddlModalidade;

	protected Label Label105;

	protected RequiredFieldValidator RequiredFieldValidator87;

	protected DropDownList ddlGrandeArea;

	protected Label Label106;

	protected RequiredFieldValidator RequiredFieldValidator88;

	protected DropDownList ddlArea;

	protected Label Label107;

	protected RequiredFieldValidator RequiredFieldValidator89;

	protected DropDownList ddlSubArea;

	protected Label Label5;

	protected RequiredFieldValidator RequiredFieldValidator12;

	protected TextBox txtCodigoEMEC;

	protected Label Label34;

	protected RequiredFieldValidator RequiredFieldValidator25;

	protected TextBox txtNomeCurso;

	protected Panel pnlPeriodicidade;

	protected RequiredFieldValidator RequiredFieldValidator112;

	protected RadioButtonList rblPeriodicidade;

	protected Panel pnlPeriodicidadeDiario;

	protected RequiredFieldValidator RequiredFieldValidator109;

	protected TextBox txtCargaHorariaDiario;

	protected RegularExpressionValidator RegularExpressionValidator9;

	protected Panel pnlPeriodicidadeModular;

	protected RequiredFieldValidator RequiredFieldValidator110;

	protected TextBox txtCargaHorariaModular;

	protected RegularExpressionValidator RegularExpressionValidator10;

	protected RequiredFieldValidator RequiredFieldValidatorNomeCursoModular;

	protected TextBox txtNomeCursoModular;

	protected Label Label35;

	protected RequiredFieldValidator RequiredFieldValidator26;

	protected TextBox txtUnidadeProponente;

	protected Label lblNomeUnidade;

	protected HiddenField hddUnidadeUID;

	protected RequiredFieldValidator RequiredFieldValidator27;

	protected RequiredFieldValidator RequiredFieldValidator92;

	protected TextBox txtEndereco;

	protected RequiredFieldValidator RequiredFieldValidator90;

	protected TextBox txtCidade;

	protected RequiredFieldValidator RequiredFieldValidator91;

	protected TextBox txtCEPendereco;

	protected RequiredFieldValidator RequiredFieldValidator93;

	protected TextBox txtNumeroEndereco;

	protected RegularExpressionValidator RegularExpressionValidator11;

	protected TextBox txtComplementoEndereco;

	protected RequiredFieldValidator RequiredFieldValidator94;

	protected TextBox txtBairroEndereco;

	protected TextBox txtInfoReferenciaEndereco;

	protected Label Label57;

	protected RequiredFieldValidator RequiredFieldValidator48;

	protected TextBox txtTelefone;

	protected MaskedEditExtender MaskedEditExtenderTelefone;

	protected Label Label56;

	protected TextBox txtFax;

	protected Label Label36;

	protected RequiredFieldValidator RequiredFieldValidator111;

	protected TextBox txtEmail;

	protected Label Label37;

	protected TextBox txtSiteCurso;

	protected Label Label38;

	protected RequiredFieldValidator RequiredFieldValidator28;

	protected TextBox txtCoordenador;

	protected Label lblNomeCoordenador;

	protected HiddenField hddCoordenadorServidorUID;

	protected RequiredFieldValidator RequiredFieldValidator29;

	protected RequiredFieldValidator RequiredFieldValidator102;

	protected DropDownList ddlTitulacaoCoordenador;

	protected RequiredFieldValidator RequiredFieldValidator103;

	protected DropDownList ddlRegimeTabalhoCoordenador;

	protected TextBox txtTelefoneCoordenador;

	protected MaskedEditExtender MaskedEditExtender2;

	protected TextBox txtTelefoneCelularCoordenador;

	protected MaskedEditExtender MaskedEditExtender3;

	protected RequiredFieldValidator RequiredFieldValidator104;

	protected TextBox txtEmailCoordenador;

	protected Label Label10;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected TextBox txtViceCoordenador;

	protected Label lblNomeViceCoordenador;

	protected HiddenField hddViceCoordenadorServidorUID;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected RequiredFieldValidator RequiredFieldValidator105;

	protected DropDownList ddlTitulacaoViceCoordenador;

	protected RequiredFieldValidator RequiredFieldValidator106;

	protected DropDownList ddlRegimeTabalhoViceCoordenador;

	protected TextBox txtTelefoneViceCoordenador;

	protected MaskedEditExtender MaskedEditExtender4;

	protected TextBox txtTelefoneCelularViceCoordenador;

	protected MaskedEditExtender MaskedEditExtender5;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox txtEmailViceCoordenador;

	protected Label lbSecretario;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox txtSecretario;

	protected Label lbNomeSecretario;

	protected HiddenField hddSecretarioUID;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtEmailSecretario;

	protected TextBox txtCelularSecretario;

	protected MaskedEditExtender MaskedEditExtender6;

	protected Label Label15;

	protected RequiredFieldValidator RequiredFieldValidator99;

	protected TextBox txtDataInicioRealizacao;

	protected CalendarExtender txtDataInicioRealizacao_CalendarExtender;

	protected MaskedEditExtender txtDataInicioRealizacao_MaskedEditExtender;

	protected MaskedEditValidator MEVData2;

	protected Label Label16;

	protected RequiredFieldValidator RequiredFieldValidator100;

	protected TextBox txtDataFimRealizacao;

	protected CalendarExtender CalendarExtender1;

	protected MaskedEditExtender MaskedEditExtender1;

	protected MaskedEditValidator MaskedEditValidator1;

	protected Label Label46;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected FileUpload FileUploadMinutaEdital;

	protected Label Label2;

	protected RequiredFieldValidator RequiredFieldValidator101;

	protected TextBox txtDataDocumentoAprovacaoCurso;

	protected CalendarExtender txtDataDocumentoAprovacaoCurso_CalendarExtender;

	protected MaskedEditExtender txtDataDocumentoAprovacaoCurso_MaskedEditExtender;

	protected MaskedEditValidator MEVData3;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected FileUpload FileUploaDocumentoAprovacaoCurso;

	protected Label Label40;

	protected RequiredFieldValidator RequiredFieldValidator32;

	protected TextBox txtCargaHorariaTotal;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected Panel pnlTurnoOferta;

	protected RequiredFieldValidator RequiredFieldValidator108;

	protected DropDownList ddlTurnoOferta;

	protected RequiredFieldValidator RequiredFieldValidator97;

	protected TextBox txtQtdVagas;

	protected RegularExpressionValidator RegularExpressionValidator7;

	protected Label Label49;

	protected TextBox txtNotaMinimaAprovacao;

	protected Label Label50;

	protected TextBox txtFrequenciaMinimaAprovacao;

	protected Label Label3;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox txtJustificativaCurso;

	protected Label Label4;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TextBox txtObjetivosCurso;

	protected Label Label58;

	protected RequiredFieldValidator RequiredFieldValidator50;

	protected TextBox txtPublicoAlvo;

	protected Label Label41;

	protected RequiredFieldValidator RequiredFieldValidator33;

	protected TextBox txtDescricaoInstalacoes;

	protected Label Label42;

	protected RequiredFieldValidator RequiredFieldValidator34;

	protected TextBox txtDescricaoEquipamentos;

	protected Label lblDescricaoMaterialBibliografico;

	protected RequiredFieldValidator RequiredFieldValidator35;

	protected TextBox txtDescricaoMaterialBibliografico;

	protected Label Label47;

	protected RequiredFieldValidator RequiredFieldValidator39;

	protected TextBox txtFormasAvaliacao;

	protected Panel pnlAVA;

	protected Label Label1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtAmbienteVirtualAprendizagem;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected Obj, but got Unknown
		if (!listaRecursos.Contains("MenuCursos_NovoCurso"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			GrandeAreaBO grandeAreaBO = new GrandeAreaBO();
			TipoModalidadeBO tipoModalidadeBO = new TipoModalidadeBO();
			((BaseDataBoundControl)ddlModalidade).DataSource = tipoModalidadeBO.GetRegistros();
			((ListControl)ddlModalidade).DataTextField = "nome";
			((ListControl)ddlModalidade).DataValueField = "tipoModalidadeUID";
			((Control)ddlModalidade).DataBind();
			((ListControl)ddlModalidade).SelectedValue = "2";
			ConfiguracaoInterfaceModalidade(((ListControl)ddlModalidade).SelectedIndex);
			((ListControl)ddlGrandeArea).Items.Insert(0, new ListItem(string.Empty, string.Empty));
			((ListControl)ddlGrandeArea).SelectedIndex = 0;
			List<CNPqGrandeAreaConhecimento> registros = grandeAreaBO.GetRegistros();
			for (int i = 0; i < registros.Count; i++)
			{
				((ListControl)ddlGrandeArea).Items.Insert(i + 1, new ListItem(registros[i].nome, registros[i].CNPqGrandeAreaConhecimentoUID.ToString()));
			}
			((ListControl)ddlGrandeArea).DataTextField = "nome";
			((ListControl)ddlGrandeArea).DataValueField = "CNPqGrandeAreaConhecimentoUID";
			((Control)ddlGrandeArea).DataBind();
			((BaseDataBoundControl)ddlTurnoOferta).DataSource = EnumService.EnumList(typeof(EnumTurnoOferta));
			((ListControl)ddlTurnoOferta).DataValueField = "key";
			((ListControl)ddlTurnoOferta).DataTextField = "value";
			((Control)ddlTurnoOferta).DataBind();
			((ListControl)ddlTurnoOferta).SelectedValue = "1";
			((BaseDataBoundControl)ddlTitulacaoCoordenador).DataSource = EnumService.EnumList(typeof(EnumTitulacao));
			((ListControl)ddlTitulacaoCoordenador).DataValueField = "key";
			((ListControl)ddlTitulacaoCoordenador).DataTextField = "value";
			((Control)ddlTitulacaoCoordenador).DataBind();
			((BaseDataBoundControl)ddlRegimeTabalhoCoordenador).DataSource = EnumService.EnumList(typeof(EnumRegimeTrabalho));
			((ListControl)ddlRegimeTabalhoCoordenador).DataValueField = "key";
			((ListControl)ddlRegimeTabalhoCoordenador).DataTextField = "value";
			((Control)ddlRegimeTabalhoCoordenador).DataBind();
			((BaseDataBoundControl)ddlTitulacaoViceCoordenador).DataSource = EnumService.EnumList(typeof(EnumTitulacao));
			((ListControl)ddlTitulacaoViceCoordenador).DataValueField = "key";
			((ListControl)ddlTitulacaoViceCoordenador).DataTextField = "value";
			((Control)ddlTitulacaoViceCoordenador).DataBind();
			((BaseDataBoundControl)ddlRegimeTabalhoViceCoordenador).DataSource = EnumService.EnumList(typeof(EnumRegimeTrabalho));
			((ListControl)ddlRegimeTabalhoViceCoordenador).DataValueField = "key";
			((ListControl)ddlRegimeTabalhoViceCoordenador).DataTextField = "value";
			((Control)ddlRegimeTabalhoViceCoordenador).DataBind();
			((BaseDataBoundControl)rblPeriodicidade).DataSource = EnumService.EnumList(typeof(EnumPeriodicidade));
			((ListControl)rblPeriodicidade).DataValueField = "key";
			((ListControl)rblPeriodicidade).DataTextField = "value";
			((Control)rblPeriodicidade).DataBind();
			((ListControl)rblPeriodicidade).Items[0].Selected = true;
			((Control)pnlPeriodicidadeDiario).Visible = true;
			((Control)pnlPeriodicidadeModular).Visible = false;
			txtCargaHorariaModular.Text = "";
			txtNomeCursoModular.Text = "";
		}
	}

	private void ConfiguracaoInterfaceModalidade(int index)
	{
		if (((ListControl)ddlModalidade).Items[index].Value == "1")
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Bibliográfico:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "75%";
			((Control)pnlPeriodicidade).Visible = true;
			((Control)pnlAVA).Visible = false;
			((Control)pnlTurnoOferta).Visible = true;
		}
		else
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Didático Textual e Multimídia:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "100%";
			((Control)pnlPeriodicidade).Visible = false;
			((Control)pnlAVA).Visible = true;
			((Control)pnlTurnoOferta).Visible = false;
		}
	}

	public void SetPerfilUsuario(byte tipoStatusHomologacaoUID, byte tipoSolicitanteCorrecao)
	{
		new ProjetoBO();
		((Control)btnSalvar).Visible = true;
	}

	private byte[] ConvertStreamToByeBuffer(FileStream imgStream)
	{
		MemoryStream memoryStream = new MemoryStream();
		int num;
		while ((num = imgStream.ReadByte()) != -1)
		{
			memoryStream.WriteByte((byte)num);
		}
		return memoryStream.ToArray();
	}

	private byte[] ReadFile(HttpPostedFile file)
	{
		byte[] array = new byte[file.ContentLength];
		file.InputStream.Read(array, 0, file.ContentLength);
		return array;
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		ProjetoBO projetoBO = new ProjetoBO();
		new UnidadeDAL();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		ProjetoCurso projetoCurso = new ProjetoCurso();
		byte[] array = new byte[1] { 32 };
		projetoCurso.projetoCursoUID = 0L;
		projetoCurso.tipoModalidadeUID = 0;
		projetoCurso.nomeCurso = string.Empty;
		projetoCurso.CNPqAreaConhecimentoUID = 0L;
		projetoCurso.CNPqSubAreaConhecimentoUID = 0L;
		projetoCurso.proponenteUnidadeUID = 0L;
		projetoCurso.telefone = string.Empty;
		projetoCurso.fax = string.Empty;
		projetoCurso.email = string.Empty;
		projetoCurso.siteCurso = string.Empty;
		projetoCurso.coordenadorServidorUID = 0L;
		projetoCurso.viceCoordenadorServidorUID = 0L;
		projetoCurso.secretarioUID = 0L;
		projetoCurso.realizacaoDataInicio = DateTime.Now;
		projetoCurso.realizacaoDataTermino = DateTime.Now;
		projetoCurso.cargaHorariaTotal = 0;
		projetoCurso.publicoAlvo = string.Empty;
		projetoCurso.descricaoInstalacoes = string.Empty;
		projetoCurso.descricaoEquipamentos = string.Empty;
		projetoCurso.descricaoMaterialBibliografico = string.Empty;
		projetoCurso.justificativaCurso = string.Empty;
		projetoCurso.objetivosCurso = string.Empty;
		projetoCurso.minutaEdital = array;
		projetoCurso.formasAvaliacao = string.Empty;
		projetoCurso.caracteristicasMonografiaTcc = string.Empty;
		projetoCurso.notaMinimaAprovacao = 0;
		projetoCurso.frequenciaMinimaAprovacao = 0;
		projetoCurso.financiamentoCurso = array;
		projetoCurso.termoConvenio = array;
		projetoCurso.tipoFinanciamentoUID = 0;
		projetoCurso.tipoGestaoFinanceiraUID = 0;
		projetoCurso.planoAplicacaoSuperavit = array;
		projetoCurso.quantidadeVagas = 0;
		projetoCurso.dataDocumentoRealizacaoCurso = DateTime.Now;
		projetoCurso.documentoRealizacaoCurso = null;
		projetoCurso.CEP = string.Empty;
		projetoCurso.municipioEnderecoUID = 0;
		projetoCurso.identificacaoEndereco = string.Empty;
		projetoCurso.numeroEndereco = 0;
		projetoCurso.complementoBairro = string.Empty;
		projetoCurso.bairroEndereco = string.Empty;
		projetoCurso.informacoesReferenciaEndereco = string.Empty;
		try
		{
			string[] array2 = txtCidade.Text.Trim().Split(new char[1] { '|' });
			string[] array3 = txtCoordenador.Text.Trim().Split(new char[1] { '|' });
			string[] array4 = txtViceCoordenador.Text.Trim().Split(new char[1] { '|' });
			string[] array5 = txtSecretario.Text.Trim().Split(new char[1] { '|' });
			string[] array6 = txtUnidadeProponente.Text.Trim().Split(new char[1] { '|' });
			if (!long.TryParse(array6[0], out var _))
			{
				resultadoOperacao.TextMessage = "Unidade não foi selecionada corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtUnidadeProponente.Text = string.Empty;
				((Control)txtUnidadeProponente).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!long.TryParse(array3[0], out var _))
			{
				resultadoOperacao.TextMessage = "Coordenador não foi adicionado corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtCoordenador.Text = string.Empty;
				((Control)txtCoordenador).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!long.TryParse(array4[0], out var _))
			{
				resultadoOperacao.TextMessage = "Vice-Coordenador não foi adicionado corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtViceCoordenador.Text = string.Empty;
				((Control)txtViceCoordenador).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (string.IsNullOrWhiteSpace(array5[0].Trim()))
			{
				resultadoOperacao.TextMessage = "Secretário não foi adicionado corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtSecretario.Text = string.Empty;
				((Control)txtSecretario).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (!long.TryParse(array2[0], out var _))
			{
				resultadoOperacao.TextMessage = "Municipio não foi selecionado corretamente.  Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				txtCidade.Text = string.Empty;
				((Control)txtCidade).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (DateTime.Parse(txtDataInicioRealizacao.Text) > DateTime.Parse("04/06/2014") && !FileUploadMinutaEdital.HasFile)
			{
				resultadoOperacao.TextMessage = "A data de início de atividades do curso é posterior a 04/06/2014. O arquivo da minuta do edital é obrigatório. Por favor, selecione o arquivo da minuta do edital para continuar.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				((Control)FileUploadMinutaEdital).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			if (int.Parse(txtCargaHorariaTotal.Text) < 360)
			{
				resultadoOperacao.TextMessage = "Carga horária total não pode ser inferior a 360 horas.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				((Control)txtCargaHorariaTotal).Focus();
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			CoordenadorDAL coordenadorDAL = new CoordenadorDAL();
			PessoaIDBUFMTDAL pessoaIDBUFMTDAL = new PessoaIDBUFMTDAL();
			ViewCoordenadorUFMT coordenadorPorSiape = coordenadorDAL.GetCoordenadorPorSiape(array3[0]);
			ViewCoordenadorUFMT coordenadorPorSiape2 = coordenadorDAL.GetCoordenadorPorSiape(array4[0]);
			PessoaIDBUFMT pessoaIDBUFMT = pessoaIDBUFMTDAL.BuscarPessoaPorCPF(array5[0]);
			hddCoordenadorServidorUID.Value = coordenadorPorSiape.servidorUID.ToString();
			hddViceCoordenadorServidorUID.Value = coordenadorPorSiape2.servidorUID.ToString();
			hddUnidadeUID.Value = array6[0];
			projetoCurso.tipoModalidadeUID = byte.Parse(((ListControl)ddlModalidade).SelectedValue);
			projetoCurso.codigoEMEC = txtCodigoEMEC.Text;
			projetoCurso.nomeCurso = txtNomeCurso.Text;
			projetoCurso.CNPqAreaConhecimentoUID = long.Parse(((ListControl)ddlArea).SelectedValue);
			projetoCurso.CNPqSubAreaConhecimentoUID = long.Parse(((ListControl)ddlSubArea).SelectedValue);
			projetoCurso.proponenteUnidadeUID = long.Parse(hddUnidadeUID.Value);
			projetoCurso.telefone = txtTelefone.Text;
			projetoCurso.fax = txtFax.Text;
			projetoCurso.email = txtEmail.Text;
			projetoCurso.siteCurso = txtSiteCurso.Text;
			projetoCurso.coordenadorServidorUID = long.Parse(hddCoordenadorServidorUID.Value);
			projetoCurso.titulacaoCoordenadorUID = int.Parse(((ListControl)ddlTitulacaoCoordenador).SelectedValue);
			projetoCurso.regimeTrabalhoCoordenadorUID = int.Parse(((ListControl)ddlRegimeTabalhoCoordenador).SelectedValue);
			projetoCurso.telefoneResidencialCoordenador = txtTelefoneCoordenador.Text;
			projetoCurso.telefoneCelularCoordenador = txtTelefoneCelularCoordenador.Text;
			projetoCurso.emailCoordenador = txtEmailCoordenador.Text;
			projetoCurso.viceCoordenadorServidorUID = long.Parse(hddViceCoordenadorServidorUID.Value);
			projetoCurso.titulacaoViceCoordenadorUID = int.Parse(((ListControl)ddlTitulacaoViceCoordenador).SelectedValue);
			projetoCurso.regimeTrabalhoViceCoordenadorUID = int.Parse(((ListControl)ddlRegimeTabalhoViceCoordenador).SelectedValue);
			projetoCurso.telefoneResidencialViceCoordenador = txtTelefoneViceCoordenador.Text;
			projetoCurso.telefoneCelularViceCoordenador = txtTelefoneCelularViceCoordenador.Text;
			projetoCurso.emailViceCoordenador = txtEmailViceCoordenador.Text;
			projetoCurso.secretarioUID = pessoaIDBUFMT.pessoaUID;
			projetoCurso.emailSecretario = txtEmailSecretario.Text;
			projetoCurso.celularSecretario = txtCelularSecretario.Text;
			string s = $"{txtDataInicioRealizacao.Text:dd/MM/yyyy}";
			string s2 = $"{txtDataFimRealizacao.Text:dd/MM/yyyy}";
			projetoCurso.realizacaoDataInicio = DateTime.Parse(s);
			projetoCurso.realizacaoDataTermino = DateTime.Parse(s2);
			projetoCurso.cargaHorariaTotal = short.Parse(txtCargaHorariaTotal.Text);
			projetoCurso.turnoOfertaUID = int.Parse(((ListControl)ddlTurnoOferta).SelectedValue);
			if (((ListControl)ddlModalidade).Items[0].Selected)
			{
				projetoCurso.periodicidadeUID = int.Parse(((ListControl)rblPeriodicidade).SelectedValue);
				if (((ListControl)rblPeriodicidade).Items[0].Selected)
				{
					projetoCurso.cargaHorariaDiario = int.Parse(txtCargaHorariaDiario.Text);
					projetoCurso.cargaHorariaModular = null;
					projetoCurso.nomeCursoModular = null;
				}
				else
				{
					projetoCurso.cargaHorariaModular = int.Parse(txtCargaHorariaModular.Text);
					projetoCurso.nomeCursoModular = txtNomeCursoModular.Text;
					projetoCurso.cargaHorariaDiario = null;
				}
			}
			projetoCurso.publicoAlvo = txtPublicoAlvo.Text;
			projetoCurso.descricaoInstalacoes = txtDescricaoInstalacoes.Text;
			projetoCurso.descricaoEquipamentos = txtDescricaoEquipamentos.Text;
			projetoCurso.descricaoMaterialBibliografico = txtDescricaoMaterialBibliografico.Text;
			projetoCurso.justificativaCurso = txtJustificativaCurso.Text;
			projetoCurso.objetivosCurso = txtObjetivosCurso.Text;
			if (!FileUploadMinutaEdital.HasFile)
			{
				((Control)FileUploadMinutaEdital).Focus();
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O arquivo da minuta do edital é obrigatório. Por favor, anexe o arquivo para continuar.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			HttpPostedFile postedFile = FileUploadMinutaEdital.PostedFile;
			byte[] minutaEdital = ReadFile(postedFile);
			projetoCurso.minutaEdital = minutaEdital;
			if (!FileUploaDocumentoAprovacaoCurso.HasFile)
			{
				((Control)FileUploaDocumentoAprovacaoCurso).Focus();
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O arquivo de aprovação do curso é obrigatório. Por favor, anexe o arquivo para continuar.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
			HttpPostedFile postedFile2 = FileUploaDocumentoAprovacaoCurso.PostedFile;
			byte[] documentoRealizacaoCurso = ReadFile(postedFile2);
			projetoCurso.documentoRealizacaoCurso = documentoRealizacaoCurso;
			projetoCurso.formasAvaliacao = txtFormasAvaliacao.Text;
			projetoCurso.financiamentoCurso = null;
			projetoCurso.termoConvenio = null;
			projetoCurso.planoAplicacaoSuperavit = null;
			projetoCurso.tipoFinanciamentoUID = (byte)4;
			projetoCurso.tipoGestaoFinanceiraUID = (byte)1;
			projetoCurso.quantidadeVagas = int.Parse(txtQtdVagas.Text);
			projetoCurso.dataDocumentoRealizacaoCurso = DateTime.Parse($"{txtDataDocumentoAprovacaoCurso.Text:dd/MM/yyyy}");
			projetoCurso.CEP = txtCEPendereco.Text;
			projetoCurso.municipioEnderecoUID = int.Parse(array2[0]);
			projetoCurso.identificacaoEndereco = txtEndereco.Text;
			projetoCurso.numeroEndereco = int.Parse(txtNumeroEndereco.Text);
			projetoCurso.complementoBairro = txtComplementoEndereco.Text;
			projetoCurso.bairroEndereco = txtBairroEndereco.Text;
			projetoCurso.informacoesReferenciaEndereco = txtInfoReferenciaEndereco.Text;
			projetoCurso.descricaoAva = txtAmbienteVirtualAprendizagem.Text;
			long value = (long)((Page)this).Session["usuarioUID"];
			projetoCurso.usuarioCriacaoUID = value;
			projetoCurso.dataCriacao = DateTime.Now;
			resultadoOperacao = projetoBO.SalvarProjetoCurso(projetoCurso);
			if (resultadoOperacao.Erro)
			{
				PopularMensagemRegraNegocio(resultadoOperacao);
				return;
			}
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		PopulateMessage(resultadoOperacao);
		((Page)this).Response.Redirect("FrmListar.aspx");
	}

	protected void ddlGrandeArea_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		((ListControl)ddlArea).Items.Clear();
		((ListControl)ddlSubArea).Items.Clear();
		if (!string.IsNullOrEmpty(((ListControl)ddlGrandeArea).SelectedValue))
		{
			List<CNPqAreaConhecimento> registros = new AreaBO().GetRegistros(long.Parse(((ListControl)ddlGrandeArea).SelectedValue));
			((ListControl)ddlArea).Items.Insert(0, new ListItem(string.Empty, string.Empty));
			((ListControl)ddlArea).SelectedIndex = 0;
			for (int i = 0; i < registros.Count; i++)
			{
				((ListControl)ddlArea).Items.Insert(i + 1, new ListItem(registros[i].nome, registros[i].CNPqAreaConhecimentoUID.ToString()));
			}
			((ListControl)ddlArea).DataTextField = "nome";
			((ListControl)ddlArea).DataValueField = "CNPqAreaConhecimentoUID";
			((Control)ddlArea).DataBind();
		}
	}

	protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
	{
		((ListControl)ddlSubArea).Items.Clear();
		if (!string.IsNullOrEmpty(((ListControl)ddlArea).SelectedValue))
		{
			AreaBO areaBO = new AreaBO();
			((BaseDataBoundControl)ddlSubArea).DataSource = areaBO.GetRegistrosSubArea(long.Parse(((ListControl)ddlArea).SelectedValue));
			((ListControl)ddlSubArea).DataTextField = "nome";
			((ListControl)ddlSubArea).DataValueField = "CNPqSubAreaConhecimentoUID";
			((Control)ddlSubArea).DataBind();
		}
	}

	protected void ddlModalidade_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)ddlModalidade).Items[0].Selected)
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Bibliográfico:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "75%";
			((Control)pnlPeriodicidade).Visible = true;
			((Control)pnlAVA).Visible = false;
			((Control)pnlTurnoOferta).Visible = true;
		}
		else if (((ListControl)ddlModalidade).Items[1].Selected)
		{
			lblDescricaoMaterialBibliografico.Text = "Descrição do Material Didático Textual e Multimídia:";
			txtNotaMinimaAprovacao.Text = "7.0";
			txtFrequenciaMinimaAprovacao.Text = "100%";
			((Control)pnlPeriodicidade).Visible = false;
			((Control)pnlAVA).Visible = true;
			((Control)pnlTurnoOferta).Visible = false;
		}
	}

	protected void rblPeriodicidade_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (((ListControl)rblPeriodicidade).Items[0].Selected)
		{
			((Control)pnlPeriodicidadeDiario).Visible = true;
			((Control)pnlPeriodicidadeModular).Visible = false;
			txtCargaHorariaModular.Text = "";
			txtNomeCursoModular.Text = "";
		}
		else
		{
			((Control)pnlPeriodicidadeDiario).Visible = false;
			((Control)pnlPeriodicidadeModular).Visible = true;
			txtCargaHorariaDiario.Text = "";
		}
	}

	protected void lnkBtnDownloadMinutaEdital_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("~/webapp/lerArquivoBinario.aspx");
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListar.aspx");
	}
}
