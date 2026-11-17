using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.View.webapp.importacao;

public class FrmImportacao : Page
{
	protected TextBox Quantidade;

	protected LinkButton ImportarHomologados;

	protected Label Label1;

	protected Label TotalPessoas;

	protected Label Label2;

	protected Label TotalInscricoes;

	protected void Page_Load(object sender, EventArgs e)
	{
		Consultar();
	}

	protected void ImportarHomologados_Click(object sender, EventArgs e)
	{
		try
		{
			new ImportacaoDAL(((Page)this).Server.MapPath("~")).Homologados(Convert.ToInt32(Quantidade.Text));
			Consultar();
		}
		catch (Exception innerException)
		{
			throw new Exception("ERRO ao Importar Homologados...", innerException);
		}
	}

	private void Consultar()
	{
	}
}
