using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Permissao
{
	public long permissaoUID { get; set; }

	public long aplicacaoUID { get; set; }

	public string nome { get; set; }

	public string descricao { get; set; }

	public string urlRelativa { get; set; }

	public virtual ICollection<ProjetoPermissaoRecurso> ProjetoPermissaoRecurso { get; set; }

	public virtual ICollection<PermissaoUsuario> PermissaoUsuario { get; set; }

	public Permissao()
	{
		ProjetoPermissaoRecurso = new HashSet<ProjetoPermissaoRecurso>();
		PermissaoUsuario = new HashSet<PermissaoUsuario>();
	}
}
