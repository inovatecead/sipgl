using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoComplementoPresencial
{
	public long projetoCursoComplementoPresencialUID { get; set; }

	public long projetoCursoUID { get; set; }

	public byte tipoTurnoOfertaUID { get; set; }

	public byte tipoPeriodicidadeUID { get; set; }

	public long enderecoUID { get; set; }

	public short cargaHorariaPeriodicidade { get; set; }

	public virtual ICollection<ProjetoCursoComplementoPresencialVagas> ProjetoCursoComplementoPresencialVagas { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }

	public ProjetoCursoComplementoPresencial()
	{
		ProjetoCursoComplementoPresencialVagas = new HashSet<ProjetoCursoComplementoPresencialVagas>();
	}
}
