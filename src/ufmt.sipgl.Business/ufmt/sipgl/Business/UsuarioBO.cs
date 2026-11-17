using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class UsuarioBO
{
	public UsuarioDAL UsuarioDAL { get; set; }

	public UsuarioBO()
	{
		UsuarioDAL = new UsuarioDAL();
	}

	public Usuario BuscarUsuarioPorID(long usuarioUID)
	{
		return UsuarioDAL.BuscarUsuarioPorID(usuarioUID);
	}

	public ProjetoUsuarioUnidade BuscarVinculoUsuarioUnidade(long usuarioUID)
	{
		return UsuarioDAL.BuscarVinculoUsuarioUnidade(usuarioUID);
	}

	public List<Usuario> FiltrarUsuarios(string nome, string cpf, long permissaoUID)
	{
		return UsuarioDAL.FiltrarUsuarios(nome, cpf, permissaoUID);
	}

	public ResultadoOperacao VincularUnidades(long usuarioUID, long unidadeUID)
	{
		return UsuarioDAL.VincularUnidades(usuarioUID, unidadeUID);
	}

	public ResultadoOperacao DesvincularUnidade(long usuarioUID)
	{
		return UsuarioDAL.DesvincularUnidade(usuarioUID);
	}
}
