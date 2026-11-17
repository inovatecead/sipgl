using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ufmt.sipgl.DataAccess;

public class HorarioDAL
{
	public List<ProjetoHorario> GetRegistrosHorarioTurmaDisciplina(long ID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return (from c in contextInstance.ProjetoHorario
				where c.turmaDisciplinaUID == ID
				orderby c.data
				select c).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public ProjetoHorario GetRegistroPorId(long ID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ProjetoHorario.Where((ProjetoHorario s) => s.horarioUID == ID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public bool Salvar(ProjetoHorario ph)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			if (ph.horarioUID == 0L)
			{
				contextInstance.ProjetoHorario.Add(ph);
				contextInstance.SaveChanges();
				return true;
			}
			ProjetoHorario projetoHorario = contextInstance.ProjetoHorario.Where((ProjetoHorario c) => c.horarioUID == ph.horarioUID).First();
			projetoHorario.horaInicio = ph.horaInicio;
			projetoHorario.horaFim = ph.horaFim;
			projetoHorario.data = ph.data;
			projetoHorario.turmaDisciplinaUID = ph.turmaDisciplinaUID;
			contextInstance.Entry(projetoHorario).State = (EntityState)16;
			contextInstance.SaveChanges();
			return true;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível salvar o registro.", innerException);
		}
	}

	public bool Excluir(long id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ProjetoHorario entity = contextInstance.ProjetoHorario.Where((ProjetoHorario c) => c.horarioUID == id).First();
			contextInstance.ProjetoHorario.Remove(entity);
			contextInstance.SaveChanges();
			return true;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível excluir o registro.", innerException);
		}
	}
}
