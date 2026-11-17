using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class CNPqSubAreaConhecimento
{
	public long CNPqSubAreaConhecimentoUID { get; set; }

	public long CNPqAreaConhecimentoUID { get; set; }

	public string CNPqNumero { get; set; }

	public string nome { get; set; }

	public virtual CNPqAreaConhecimento CNPqAreaConhecimento { get; set; }

	public virtual ICollection<Curso> Curso { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public CNPqSubAreaConhecimento()
	{
		Curso = new HashSet<Curso>();
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}
