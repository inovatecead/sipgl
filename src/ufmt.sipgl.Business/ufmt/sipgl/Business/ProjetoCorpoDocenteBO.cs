using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoCorpoDocenteBO
{
	private ProjetoCorpoDocenteDAL ProjetoCorpoDocenteDAL;

	public ProjetoCorpoDocenteBO()
	{
		ProjetoCorpoDocenteDAL = new ProjetoCorpoDocenteDAL();
	}

	public ProjetoCorpoDocenteDTO BuscarDocenteDTOPorId(long projetoCorpoDocenteUID)
	{
		return ProjetoCorpoDocenteDAL.BuscarDocenteDTOPorId(projetoCorpoDocenteUID);
	}

	public List<long> BucarListaProjetoCorpoDocentesUID(string cpf)
	{
		return ProjetoCorpoDocenteDAL.BucarListaProjetoCorpoDocentesUID(cpf);
	}
}
