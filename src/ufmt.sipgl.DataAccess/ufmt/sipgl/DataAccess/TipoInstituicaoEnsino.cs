using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoInstituicaoEnsino
{
	public byte tipoInstituicaoEnsinoUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<InstituicaoEnsino> InstituicaoEnsino { get; set; }

	public TipoInstituicaoEnsino()
	{
		InstituicaoEnsino = new HashSet<InstituicaoEnsino>();
	}
}
