using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class CoordenadorDAL
{
	public List<ProcedureObterCoordenadorCurso_Result> GetRegistros(int aplicacaoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return ((IEnumerable<ProcedureObterCoordenadorCurso_Result>)contextInstance.ProcedureObterCoordenadorCurso(aplicacaoUID)).Where((ProcedureObterCoordenadorCurso_Result c) => !c.dataLimite.HasValue).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProcedureObterCoordenadorCurso_Result> FindRegistros(string criterio, int aplicacaoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return ((IEnumerable<ProcedureObterCoordenadorCurso_Result>)contextInstance.ProcedureObterCoordenadorCurso(aplicacaoUID)).Where((ProcedureObterCoordenadorCurso_Result c) => c.Nome.ToUpper().Contains(criterio.ToUpper()) && !c.dataLimite.HasValue).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProcedureObterCoordenadorCurso_Result GetRegistroPorId(long id, int aplicacaoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return ((IEnumerable<ProcedureObterCoordenadorCurso_Result>)contextInstance.ProcedureObterCoordenadorCurso(aplicacaoUID)).Where((ProcedureObterCoordenadorCurso_Result c) => c.pessoaUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ViewCoordenadorUFMT> GetCoordenador()
	{
		return Contexto.GetContextInstance().ViewCoordenadorUFMT.OrderBy((ViewCoordenadorUFMT e) => e.nome).ToList();
	}

	public ViewCoordenadorUFMT GetCoordenadorPorSiape(string siape)
	{
		return Contexto.GetContextInstance().ViewCoordenadorUFMT.Where((ViewCoordenadorUFMT e) => e.siape == siape).FirstOrDefault();
	}

	public ViewCoordenadorUFMT GetCoordenadorPorId(long servidorUID)
	{
		return Contexto.GetContextInstance().ViewCoordenadorUFMT.Where((ViewCoordenadorUFMT e) => e.servidorUID == servidorUID).FirstOrDefault();
	}

	public List<ViewDocenteUFMT> GetDocente()
	{
		return Contexto.GetContextInstance().ViewDocenteUFMT.OrderBy((ViewDocenteUFMT c) => c.nome).ToList();
	}

	public ViewDocenteUFMT GetDocentePorSiape(string siape)
	{
		return Contexto.GetContextInstance().ViewDocenteUFMT.Where((ViewDocenteUFMT e) => e.siape == siape).FirstOrDefault();
	}

	public ViewDocenteUFMT GetDocentePorId(long servidorUID)
	{
		return Contexto.GetContextInstance().ViewDocenteUFMT.Where((ViewDocenteUFMT e) => e.servidorUID == servidorUID).FirstOrDefault();
	}

	public bool setCoordenador(Coordenador coordenador)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			contextInstance.Coordenador.Add(coordenador);
			contextInstance.SaveChanges();
			return true;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}
