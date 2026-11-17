using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class CNPqGrandeAreaConhecimento
{
	public long CNPqGrandeAreaConhecimentoUID { get; set; }

	public string CNPqNumero { get; set; }

	public string nome { get; set; }

	public virtual ICollection<CNPqAreaConhecimento> CNPqAreaConhecimento { get; set; }

	public CNPqGrandeAreaConhecimento()
	{
		CNPqAreaConhecimento = new HashSet<CNPqAreaConhecimento>();
	}
}
