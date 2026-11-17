using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class PessoaIDBUFMTDAL
{
	public List<PessoaIDBUFMT> ListarPessoaIDBUFMT(string nome)
	{
		try
		{
			return Contexto.GetContextInstance().PessoaIDBUFMT.Where((PessoaIDBUFMT e) => e.nome.ToLower().Contains(nome.ToLower())).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public PessoaIDBUFMT BuscarPessoaPorCPF(string cpfSecretario)
	{
		try
		{
			return Contexto.GetContextInstance().PessoaIDBUFMT.Where((PessoaIDBUFMT e) => e.cpf == cpfSecretario).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public PessoaIDBUFMT BuscarPessoaPorUID(long pessoaUID)
	{
		try
		{
			return Contexto.GetContextInstance().PessoaIDBUFMT.Where((PessoaIDBUFMT e) => e.pessoaUID == pessoaUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}
