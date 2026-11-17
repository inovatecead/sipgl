using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoInstalacao
{
	public short tipoInstalacaoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoInstalacao> ProjetoInstalacao { get; set; }

	public TipoInstalacao()
	{
		ProjetoInstalacao = new HashSet<ProjetoInstalacao>();
	}
}
