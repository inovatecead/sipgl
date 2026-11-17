using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoFaixaRendaFamiliar
{
	public byte tipoFaixaRendaFamiliarUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public TipoFaixaRendaFamiliar()
	{
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
	}
}
