using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoModalidade
{
	public byte tipoModalidadeUID { get; set; }

	public string nome { get; set; }

	public string SiglaSistema { get; set; }

	public virtual ICollection<Curso> Curso { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public TipoModalidade()
	{
		Curso = new HashSet<Curso>();
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}
