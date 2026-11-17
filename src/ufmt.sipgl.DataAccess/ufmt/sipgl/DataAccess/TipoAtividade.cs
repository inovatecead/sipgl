using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoAtividade
{
	public byte tipoAtividadeUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoPessoalEncargos> ProjetoPessoalEncargos { get; set; }

	public TipoAtividade()
	{
		ProjetoPessoalEncargos = new HashSet<ProjetoPessoalEncargos>();
	}
}
