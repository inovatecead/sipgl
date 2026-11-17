using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class CNPqAreaConhecimento
{
	public long CNPqAreaConhecimentoUID { get; set; }

	public long CNPqGrandeAreaConhecimentoUID { get; set; }

	public string CNPqNumero { get; set; }

	public string nome { get; set; }

	public virtual CNPqGrandeAreaConhecimento CNPqGrandeAreaConhecimento { get; set; }

	public virtual ICollection<CNPqSubAreaConhecimento> CNPqSubAreaConhecimento { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public CNPqAreaConhecimento()
	{
		CNPqSubAreaConhecimento = new HashSet<CNPqSubAreaConhecimento>();
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}
