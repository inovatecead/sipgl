using System;

namespace ufmt.sipgl.DataAccess;

public class PermissaoUsuario
{
	public long permissaoUsuarioUID { get; set; }

	public long usuarioUID { get; set; }

	public long permissaoUID { get; set; }

	public DateTime? dataLimite { get; set; }

	public virtual Permissao Permissao { get; set; }

	public virtual Usuario Usuario { get; set; }
}
