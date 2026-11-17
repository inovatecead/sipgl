using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.View;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(/*Could not decode attribute arguments.*/)]
[ScriptService]
public class WSUnidade : WebService
{
	[WebMethod]
	public List<ViewUnidade> GetUnidade(string nome)
	{
		return (from m in new UnidadeDAL().GetUnidade()
			where m.nome.SemCaracteresEspeciais().ToLower().Contains(nome.SemCaracteresEspeciais().ToLower())
			select m).ToList();
	}
}
