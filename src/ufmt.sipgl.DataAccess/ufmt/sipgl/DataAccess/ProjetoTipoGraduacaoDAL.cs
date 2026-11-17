using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTipoGraduacaoDAL
{
	public List<ProjetoTipoGraduacao> ListarProjetoTipoGraduacao()
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoTipoGraduacao.OrderBy((ProjetoTipoGraduacao e) => e.descricao).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoTipoGraduacao>();
		}
	}
}
