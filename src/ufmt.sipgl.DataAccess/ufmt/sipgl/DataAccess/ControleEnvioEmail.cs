namespace ufmt.sipgl.DataAccess;

public class ControleEnvioEmail
{
	public long controleEnvioEmailUID { get; set; }

	public short TipoAreaSistema { get; set; }

	public string mensagem { get; set; }

	public long destinatarioPessoaUID { get; set; }

	public long remetentePessoaUID { get; set; }
}
