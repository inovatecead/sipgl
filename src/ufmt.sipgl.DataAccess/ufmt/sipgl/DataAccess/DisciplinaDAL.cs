using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class DisciplinaDAL
{
	public List<ViewProjetoDocente> ListarProjetoDocente()
	{
		try
		{
			return Contexto.GetContextInstance().ViewProjetoDocente.OrderBy((ViewProjetoDocente e) => e.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewModelCorpoDocenteProjetoCurso> GetDocente()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from ordenarPor in (from se in contextInstance.ServidorIDBUFMT
					join pe in contextInstance.PessoaIDBUFMT on se.pessoaUID equals pe.pessoaUID
					join cd in contextInstance.ProjetoCorpoDocente on se.servidorUID equals cd.servidorUID
					select new ViewModelCorpoDocenteProjetoCurso
					{
						Nome = pe.nome,
						PessoaUID = pe.pessoaUID,
						Registro = se.registro,
						ProjetoCorpoDocenteUID = cd.projetoCorpoDocenteUID
					}).Distinct()
				orderby ordenarPor.Nome
				select ordenarPor).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoDisciplina> GetDisciplina()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from ordenarPor in contextInstance.ProjetoDisciplina.Select((ProjetoDisciplina t) => t).Distinct()
				orderby ordenarPor.nome
				select ordenarPor).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public List<ProjetoDisciplina> GetRegistros()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ProjetoDisciplina.OrderBy((ProjetoDisciplina d) => d.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoDisciplina> FindRegistros(string criterio)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from d in contextInstance.ProjetoDisciplina
				where d.nome.Contains(criterio)
				orderby d.nome
				select d).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public bool VerificaRegistro(string nome, short cargaHoraria)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			if (contextInstance.ProjetoDisciplina.Where((ProjetoDisciplina c) => c.nome.ToUpper() == nome.ToUpper() && c.cargaHoraria == cargaHoraria).FirstOrDefault() != null)
			{
				return true;
			}
			return false;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível salvar o registro.", innerException);
		}
	}

	public List<TipoReservaVagas> GetTipoReservaVagas()
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.TipoReservaVagas.OrderBy((TipoReservaVagas c) => c.nome).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}
}
