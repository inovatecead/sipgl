using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.View.session;

namespace ufmt.sipgl.View.webapp.turma;

public class FrmAlterarVinculoPolos : VerificaSession
{
	protected HiddenField hddProjetoCursoUID;

	protected HiddenField hddProjetoTurmaUID;

	protected HiddenField hddEnderecoUID;

	protected UpdatePanel UpdatePanel1;

	protected HyperLink lnkTitulo;

	protected Label lblTitulo;

	protected Panel PanelMsgResultado;

	protected Label lblMsgResultado;

	protected Label lbPolo;

	protected TextBox txtPolo;

	protected Label Label8;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtQuantidadeVagas;

	protected RegularExpressionValidator RegularExpressionValidator10;

	protected Button btnVoltar;

	protected Button btnSalvar;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!listaRecursos.Contains("VincularUnidades_Editar"))
		{
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx");
		}
		if (!((Page)this).IsPostBack)
		{
			hddProjetoTurmaUID.Value = ((Page)this).Request.QueryString["projetoTurmaUID"];
			hddProjetoCursoUID.Value = ((Page)this).Request.QueryString["projetoCursoUID"];
			hddEnderecoUID.Value = ((Page)this).Request.QueryString["enderecoUID"];
			lnkTitulo.Text = "[ Voltar para Polos] ";
			lnkTitulo.NavigateUrl = "~/webapp/turma/FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value;
			lblTitulo.Text = "Editar Dados de Vinculo";
			ProjetoTurmaPolo projetoTurmaPolo = new ProjetoTurmaBO().BucarProjetoTurmaPolo(int.Parse(hddEnderecoUID.Value), long.Parse(hddProjetoTurmaUID.Value));
			txtPolo.Text = projetoTurmaPolo.EnderecoPoloApoioPresencialEAD.identificacaoEndereco;
			txtQuantidadeVagas.Text = projetoTurmaPolo.quantidadeVagas.ToString();
		}
	}

	protected void btnSalvar_Click(object sender, EventArgs e)
	{
		int enderecoUID = int.Parse(hddEnderecoUID.Value);
		long projetoTurmaUID = long.Parse(hddProjetoTurmaUID.Value);
		int quantidadeVagas = int.Parse(txtQuantidadeVagas.Text);
		ResultadoOperacao resultadoOperacao = new ProjetoTurmaBO().AlterarVinculoPolo(enderecoUID, projetoTurmaUID, quantidadeVagas);
		if (!resultadoOperacao.Erro)
		{
			PopulateMessage(resultadoOperacao);
			((Page)this).Response.Redirect("FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
		}
		PopularMensagemRegraNegocio(resultadoOperacao);
	}

	protected void btnVoltar_Click(object sender, EventArgs e)
	{
		((Page)this).Response.Redirect("FrmListarPolos.aspx?projetoTurmaUID=" + hddProjetoTurmaUID.Value + "&projetoCursoUID=" + hddProjetoCursoUID.Value);
	}
}
