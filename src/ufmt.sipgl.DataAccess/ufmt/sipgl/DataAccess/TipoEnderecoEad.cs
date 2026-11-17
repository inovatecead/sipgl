using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoEnderecoEad
{
	public byte tipoEnderecoEadUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoCursoComplementoEadEndereco> ProjetoCursoComplementoEadEndereco { get; set; }

	public TipoEnderecoEad()
	{
		ProjetoCursoComplementoEadEndereco = new HashSet<ProjetoCursoComplementoEadEndereco>();
	}
}
