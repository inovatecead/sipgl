using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class EnderecoPoloPresencialEadBO
{
	public EnderecoPoloPresencialEadDAL EnderecoPoloPresencialEadDAL { get; set; }

	public EnderecoPoloPresencialEadBO()
	{
		EnderecoPoloPresencialEadDAL = new EnderecoPoloPresencialEadDAL();
	}

	public ViewEnderecoPoloEAD BuscarPorId(int enderecoUID)
	{
		return EnderecoPoloPresencialEadDAL.BuscarViewEnderecoPoloEAD(enderecoUID);
	}

	public ViewEnderecoPoloEAD BuscarPorIdentificacao(string identificacao)
	{
		return EnderecoPoloPresencialEadDAL.BuscarViewEnderecoPoloEADPorIdentificacao(identificacao);
	}

	public List<ViewEnderecoPoloEAD> ListarTodosPolos()
	{
		return EnderecoPoloPresencialEadDAL.ListarPolos();
	}
}
