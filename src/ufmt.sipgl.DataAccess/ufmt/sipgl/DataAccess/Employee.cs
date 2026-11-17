using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class Employee
{
	public int ID { get; set; }

	public string Email { get; set; }

	public List<ViewCandidatoCoordenador> GetCoordenador()
	{
		return Contexto.GetContextInstance().ViewCandidatoCoordenador.Select((ViewCandidatoCoordenador c) => c).ToList();
	}
}
