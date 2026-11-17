using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class EnderecoPoloPresencialEadDAL
{
	public List<EnderecoPoloApoioPresencialEAD> GetRegistros(int projetoCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			List<EnderecoPoloApoioPresencialEAD> list = contextInstance.EnderecoPoloApoioPresencialEAD.Select((EnderecoPoloApoioPresencialEAD c) => c).ToList();
			MunicipioDAL municipioDAL = new MunicipioDAL();
			foreach (EnderecoPoloApoioPresencialEAD item in list)
			{
				Municipio porId = municipioDAL.GetPorId(item.municipioEnderecoUID);
				if (porId != null)
				{
					item.Descricao = porId.Nome + " | ";
				}
				item.Descricao += item.identificacaoEndereco;
			}
			return list;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoCurso> ListarTodosCursos()
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoCurso.ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ProjetoCurso> ListarTodosCursosPorModalidade(byte tipoModalidadeUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoCurso.Where((ProjetoCurso e) => e.tipoModalidadeUID == tipoModalidadeUID).ToList();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public EnderecoPoloApoioPresencialEAD GetPorId(int id)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.EnderecoPoloApoioPresencialEAD.Where((EnderecoPoloApoioPresencialEAD c) => c.enderecoUID == id).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public ResultadoOperacao Salvar(EnderecoPoloApoioPresencialEAD enderecoPoloApoioPresencialEAD)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			contextInstance.EnderecoPoloApoioPresencialEAD.Add(enderecoPoloApoioPresencialEAD);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao executar a operação. Contate o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	private ResultadoOperacao validarMunicipio(int municipioEnderecoUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			if (contextInstance.EnderecoPoloApoioPresencialEAD.Where((EnderecoPoloApoioPresencialEAD e) => e.municipioEnderecoUID == municipioEnderecoUID).FirstOrDefault() != null)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe um polo cadastrado para este município";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			return resultadoOperacao;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Não foi possível recuperar o registro.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
			return resultadoOperacao;
		}
	}

	public ResultadoOperacao Alterar(EnderecoPoloApoioPresencialEAD enderecoPoloApoioPresencialEAD)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EnderecoPoloApoioPresencialEAD enderecoPoloApoioPresencialEAD2 = contextInstance.EnderecoPoloApoioPresencialEAD.Where((EnderecoPoloApoioPresencialEAD c) => c.enderecoUID == enderecoPoloApoioPresencialEAD.enderecoUID).First();
			enderecoPoloApoioPresencialEAD2.tipoUnidadeEnsino = enderecoPoloApoioPresencialEAD.tipoUnidadeEnsino;
			enderecoPoloApoioPresencialEAD2.identificacaoEndereco = enderecoPoloApoioPresencialEAD.identificacaoEndereco;
			enderecoPoloApoioPresencialEAD2.logradouro = enderecoPoloApoioPresencialEAD.logradouro;
			enderecoPoloApoioPresencialEAD2.informacoesReferenciaEndereco = enderecoPoloApoioPresencialEAD.informacoesReferenciaEndereco;
			enderecoPoloApoioPresencialEAD2.numeroEndereco = enderecoPoloApoioPresencialEAD.numeroEndereco;
			enderecoPoloApoioPresencialEAD2.site = enderecoPoloApoioPresencialEAD.site;
			enderecoPoloApoioPresencialEAD2.telefone = enderecoPoloApoioPresencialEAD.telefone;
			enderecoPoloApoioPresencialEAD2.fax = enderecoPoloApoioPresencialEAD.fax;
			enderecoPoloApoioPresencialEAD2.bairroEndereco = enderecoPoloApoioPresencialEAD.bairroEndereco;
			enderecoPoloApoioPresencialEAD2.CEP = enderecoPoloApoioPresencialEAD.CEP;
			enderecoPoloApoioPresencialEAD2.complementoBairro = enderecoPoloApoioPresencialEAD.complementoBairro;
			enderecoPoloApoioPresencialEAD2.email = enderecoPoloApoioPresencialEAD.email;
			enderecoPoloApoioPresencialEAD2.enderecoUFUID = enderecoPoloApoioPresencialEAD.enderecoUFUID;
			contextInstance.Entry(enderecoPoloApoioPresencialEAD2).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Registro alterado com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Erro ao alterar o registro. Contate o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao Excluir(int enderecoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			EnderecoPoloApoioPresencialEAD entity = contextInstance.EnderecoPoloApoioPresencialEAD.Where((EnderecoPoloApoioPresencialEAD c) => c.enderecoUID == enderecoUID).First();
			if (contextInstance.ProjetoTurmaPolo.Where((ProjetoTurmaPolo e) => e.enderecoUID == enderecoUID).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Polo não pode ser excluido pois há cursos vinculados";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			contextInstance.EnderecoPoloApoioPresencialEAD.Remove(entity);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Polo excluído com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao executar a operação.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public List<EnderecoPoloApoioPresencialEAD> FindRegistros(string criterio, int projetoCursoUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			List<EnderecoPoloApoioPresencialEAD> list = contextInstance.EnderecoPoloApoioPresencialEAD.Where((EnderecoPoloApoioPresencialEAD c) => c.complementoBairro.Contains(criterio)).ToList();
			MunicipioDAL municipioDAL = new MunicipioDAL();
			foreach (EnderecoPoloApoioPresencialEAD item in list)
			{
				Municipio porId = municipioDAL.GetPorId(item.municipioEnderecoUID);
				if (porId != null)
				{
					item.Descricao = porId.Nome + " | ";
				}
				item.Descricao += item.identificacaoEndereco;
			}
			return list;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar os registros.", innerException);
		}
	}

	public List<ViewEnderecoPoloEAD> ListarPolos(string municipio, int? tipoUnidadeEnsino)
	{
		IQueryable<ViewEnderecoPoloEAD> source = Contexto.GetContextInstance().ViewEnderecoPoloEAD.AsQueryable();
		if (!string.IsNullOrWhiteSpace(municipio))
		{
			source = from e in source
				where e.municipio.ToUpper().Contains(municipio.ToUpper())
				orderby e.municipio
				select e;
		}
		if (tipoUnidadeEnsino.HasValue)
		{
			int unidadeEnsino = tipoUnidadeEnsino.GetValueOrDefault();
			source = source.Where((ViewEnderecoPoloEAD e) => e.tipoUnidadeEnsino == (int?)unidadeEnsino);
		}
		return source.OrderBy((ViewEnderecoPoloEAD e) => e.municipio).ToList();
	}

	public List<ViewEnderecoPoloEAD> ListarPolos()
	{
		return Contexto.GetContextInstance().ViewEnderecoPoloEAD.OrderBy((ViewEnderecoPoloEAD e) => e.municipio).ToList();
	}

	public ViewEnderecoPoloEAD BuscarViewEnderecoPoloEAD(int enderecoPoloUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewEnderecoPoloEAD.Where((ViewEnderecoPoloEAD e) => e.enderecoUID == enderecoPoloUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro", innerException);
		}
	}

	public ViewEnderecoPoloEAD BuscarViewEnderecoPoloEADPorIdentificacao(string identificacao)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewEnderecoPoloEAD.Where((ViewEnderecoPoloEAD e) => e.identificacaoEndereco.ToUpper().Contains(identificacao.ToUpper())).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro", innerException);
		}
	}
}
