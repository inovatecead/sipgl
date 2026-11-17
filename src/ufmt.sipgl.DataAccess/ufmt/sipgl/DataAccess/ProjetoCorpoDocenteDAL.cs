using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.DataAccess.Utils;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCorpoDocenteDAL
{
	public List<ProjetoCorpoDocenteDTO> Filtrar(string nome, string cpf)
	{
		try
		{
			IQueryable<ProjetoCorpoDocente> source = Contexto.GetContextInstance().ProjetoCorpoDocente.AsQueryable();
			if (!string.IsNullOrWhiteSpace(nome))
			{
				source = source.Where((ProjetoCorpoDocente e) => e.nome.ToUpper().Contains(nome.ToUpper()) || e.Servidor.Pessoa.nome.ToUpper().Contains(nome.ToUpper()));
			}
			if (!string.IsNullOrWhiteSpace(cpf))
			{
				cpf = cpf.Replace(".", "");
				cpf = cpf.Replace("-", "");
				cpf = cpf.Trim();
				source = source.Where((ProjetoCorpoDocente e) => e.cpf == cpf || e.Servidor.Pessoa.cpf == cpf);
			}
			List<ProjetoCorpoDocente> list = (from e in source.Include((ProjetoCorpoDocente e) => e.TipoOrgaoExpedidorRg).Include((ProjetoCorpoDocente e) => e.TipoTitulacao).Include((ProjetoCorpoDocente e) => e.Servidor)
					.Include((ProjetoCorpoDocente e) => e.Servidor.Pessoa)
					.Include((ProjetoCorpoDocente e) => e.Servidor.Pessoa.UF2)
					.Include((ProjetoCorpoDocente e) => e.Servidor.Pessoa.TipoTitulacao)
				orderby e.nome
				select e).ToList();
			List<ProjetoCorpoDocenteDTO> list2 = new List<ProjetoCorpoDocenteDTO>();
			foreach (ProjetoCorpoDocente item in list)
			{
				ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = new ProjetoCorpoDocenteDTO();
				if (!item.servidorUID.HasValue)
				{
					projetoCorpoDocenteDTO.ProjetoCorpoDocenteUID = item.projetoCorpoDocenteUID;
					projetoCorpoDocenteDTO.Nome = item.nome;
					projetoCorpoDocenteDTO.Sexo = item.sexo;
					projetoCorpoDocenteDTO.DataNascimento = item.dataNascimento;
					projetoCorpoDocenteDTO.NomeMae = item.nomeMae;
					projetoCorpoDocenteDTO.NomePai = item.nomePai;
					projetoCorpoDocenteDTO.Cpf = item.cpf;
					projetoCorpoDocenteDTO.Rg = item.rg;
					projetoCorpoDocenteDTO.DataExpedicao = item.dataExpedicao;
					projetoCorpoDocenteDTO.TelefoneFixo = item.telefoneFixo;
					projetoCorpoDocenteDTO.Celular = item.celular;
					projetoCorpoDocenteDTO.Email = item.email;
					projetoCorpoDocenteDTO.TipoTitulacaoUID = item.tipoTitulacaoUID;
					projetoCorpoDocenteDTO.DescricaoTipoTitulacao = item.TipoTitulacao.descricao;
					projetoCorpoDocenteDTO.OrgaoExpedidorUID = item.orgaoExpedidorUID;
					projetoCorpoDocenteDTO.DescricaoOrgaoExpedidor = item.TipoOrgaoExpedidorRg.nome;
					projetoCorpoDocenteDTO.orgaoExpedidorUFUID = item.orgaoExpedidorUFUID;
					projetoCorpoDocenteDTO.DescricaoOrgaoExpedidorUF = item.UF.Nome;
				}
				else
				{
					projetoCorpoDocenteDTO.ProjetoCorpoDocenteUID = item.projetoCorpoDocenteUID;
					projetoCorpoDocenteDTO.ServidorUID = item.servidorUID;
					projetoCorpoDocenteDTO.Siape = item.Servidor.registro;
					projetoCorpoDocenteDTO.SiapeDV = item.Servidor.registroDV;
					projetoCorpoDocenteDTO.Nome = item.Servidor.Pessoa.nome;
					projetoCorpoDocenteDTO.Sexo = item.Servidor.Pessoa.sexo;
					projetoCorpoDocenteDTO.DataNascimento = item.Servidor.Pessoa.nascimentoData;
					projetoCorpoDocenteDTO.NomeMae = item.Servidor.Pessoa.nomeMae;
					projetoCorpoDocenteDTO.NomePai = item.Servidor.Pessoa.nomePai;
					projetoCorpoDocenteDTO.Cpf = item.Servidor.Pessoa.cpf;
					projetoCorpoDocenteDTO.Rg = item.Servidor.Pessoa.rg;
					projetoCorpoDocenteDTO.DataExpedicao = item.Servidor.Pessoa.rgDataExpedicao;
					projetoCorpoDocenteDTO.TelefoneFixo = item.Servidor.Pessoa.telefonePrimario;
					projetoCorpoDocenteDTO.Celular = item.Servidor.Pessoa.telefoneSecundario;
					projetoCorpoDocenteDTO.Email = item.Servidor.Pessoa.mail;
					projetoCorpoDocenteDTO.TipoTitulacaoUID = item.Servidor.Pessoa.tipoTitulacaoUID;
					projetoCorpoDocenteDTO.DescricaoTipoTitulacao = ((item.Servidor.Pessoa.TipoTitulacao == null) ? "" : item.Servidor.Pessoa.TipoTitulacao.descricao);
					projetoCorpoDocenteDTO.DescricaoOrgaoExpedidor = item.Servidor.Pessoa.rgOrgaoExpedidor;
					projetoCorpoDocenteDTO.orgaoExpedidorUFUID = item.Servidor.Pessoa.rgUF;
					projetoCorpoDocenteDTO.DescricaoOrgaoExpedidorUF = ((item.Servidor.Pessoa.UF2 == null) ? "" : item.Servidor.Pessoa.UF2.Nome);
				}
				list2.Add(projetoCorpoDocenteDTO);
			}
			return list2.OrderBy((ProjetoCorpoDocenteDTO e) => e.Nome).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoCorpoDocenteDTO>();
		}
	}

	public List<long> BucarListaProjetoCorpoDocentesUID(string cpf)
	{
		try
		{
			return (from e in Contexto.GetContextInstance().ProjetoCorpoDocente
				where e.Servidor.Pessoa.cpf == cpf || e.cpf == cpf
				select e.projetoCorpoDocenteUID).ToList();
		}
		catch (Exception)
		{
			return new List<long>();
		}
	}

	public List<ProjetoCorpoDocenteDTO> ListarTodos()
	{
		try
		{
			List<ProjetoCorpoDocente> list = (from e in Contexto.GetContextInstance().ProjetoCorpoDocente.Include((ProjetoCorpoDocente e) => e.TipoOrgaoExpedidorRg).Include((ProjetoCorpoDocente e) => e.TipoTitulacao).Include((ProjetoCorpoDocente e) => e.Servidor)
					.Include((ProjetoCorpoDocente e) => e.Servidor.Pessoa)
					.Include((ProjetoCorpoDocente e) => e.Servidor.Pessoa.UF2)
					.Include((ProjetoCorpoDocente e) => e.Servidor.Pessoa.TipoTitulacao)
				orderby e.nome
				select e).ToList();
			List<ProjetoCorpoDocenteDTO> list2 = new List<ProjetoCorpoDocenteDTO>();
			foreach (ProjetoCorpoDocente item2 in list)
			{
				ProjetoCorpoDocenteDTO item = ConverterProjetoCorpoDocenteParaDTO(item2);
				list2.Add(item);
			}
			return list2.OrderBy((ProjetoCorpoDocenteDTO e) => e.Nome).ToList();
		}
		catch (Exception)
		{
			return new List<ProjetoCorpoDocenteDTO>();
		}
	}

	public ProjetoCorpoDocente BuscarPorId(long projetoCorpoDocenteUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoCorpoDocente.Where((ProjetoCorpoDocente e) => e.projetoCorpoDocenteUID == projetoCorpoDocenteUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível recuperar o registro.", innerException);
		}
	}

	public bool VerificaRegistroProjetoCorpoDocente(long servidorUID)
	{
		try
		{
			return Contexto.GetContextInstance().ProjetoCorpoDocente.Where((ProjetoCorpoDocente e) => e.servidorUID == (long?)servidorUID).Any();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível salvar o registro.", innerException);
		}
	}

	public ResultadoOperacao CadastrarDocenteInterno(string txtServidorUID)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			if (!long.TryParse(txtServidorUID, out var result))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Docente não foi selecionado corretamente. Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ViewDocenteUFMT docentePorId = new CoordenadorDAL().GetDocentePorId(result);
			if (docentePorId == null)
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Docente não foi selecionado corretamente. Tente novamente efetuando nova consulta.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (VerificaRegistroProjetoCorpoDocente(docentePorId.servidorUID))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O Docente informado já está vinculado no sistema.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoCorpoDocente projetoCorpoDocente = new ProjetoCorpoDocente();
			projetoCorpoDocente.servidorUID = docentePorId.servidorUID;
			contextInstance.ProjetoCorpoDocente.Add(projetoCorpoDocente);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao CadastrarDocenteExterno(ProjetoCorpoDocente projetoCorpoDocente)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		Util util = new Util();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			if (!util.ValidarCPF(projetoCorpoDocente.cpf))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O CPF informado é inválido.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (contextInstance.ProjetoCorpoDocente.Where((ProjetoCorpoDocente e) => e.cpf == projetoCorpoDocente.cpf).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe um registro no sistema com este CPF.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			contextInstance.ProjetoCorpoDocente.Add(projetoCorpoDocente);
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao EditarDocenteExterno(ProjetoCorpoDocente novoProjetoCorpoDocente)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		Util util = new Util();
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			if (!util.ValidarCPF(novoProjetoCorpoDocente.cpf))
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "O CPF informado é inválido.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			if (contextInstance.ProjetoCorpoDocente.Where((ProjetoCorpoDocente e) => e.cpf == novoProjetoCorpoDocente.cpf && e.projetoCorpoDocenteUID != novoProjetoCorpoDocente.projetoCorpoDocenteUID).Any())
			{
				resultadoOperacao.Erro = true;
				resultadoOperacao.TextMessage = "Já existe um registro no sistema com este CPF.";
				resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Warning;
				return resultadoOperacao;
			}
			ProjetoCorpoDocente projetoCorpoDocente = contextInstance.ProjetoCorpoDocente.Where((ProjetoCorpoDocente e) => e.projetoCorpoDocenteUID == novoProjetoCorpoDocente.projetoCorpoDocenteUID).FirstOrDefault();
			projetoCorpoDocente.tipoTitulacaoUID = novoProjetoCorpoDocente.tipoTitulacaoUID;
			projetoCorpoDocente.nome = novoProjetoCorpoDocente.nome;
			projetoCorpoDocente.sexo = novoProjetoCorpoDocente.sexo;
			projetoCorpoDocente.dataNascimento = novoProjetoCorpoDocente.dataNascimento;
			projetoCorpoDocente.nomePai = novoProjetoCorpoDocente.nomePai;
			projetoCorpoDocente.nomeMae = novoProjetoCorpoDocente.nomeMae;
			projetoCorpoDocente.cpf = novoProjetoCorpoDocente.cpf;
			projetoCorpoDocente.rg = novoProjetoCorpoDocente.rg;
			projetoCorpoDocente.orgaoExpedidorUID = novoProjetoCorpoDocente.orgaoExpedidorUID;
			projetoCorpoDocente.orgaoExpedidorUFUID = novoProjetoCorpoDocente.orgaoExpedidorUFUID;
			projetoCorpoDocente.dataExpedicao = novoProjetoCorpoDocente.dataExpedicao;
			projetoCorpoDocente.telefoneFixo = novoProjetoCorpoDocente.telefoneFixo;
			projetoCorpoDocente.celular = novoProjetoCorpoDocente.celular;
			projetoCorpoDocente.email = novoProjetoCorpoDocente.email;
			contextInstance.Entry(projetoCorpoDocente).State = (EntityState)16;
			contextInstance.SaveChanges();
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Operação realizada com sucesso.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao realizar operação. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public void Excluir(long ID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			ProjetoCorpoDocente entity = contextInstance.ProjetoCorpoDocente.Where((ProjetoCorpoDocente c) => c.projetoCorpoDocenteUID == ID).First();
			contextInstance.ProjetoCorpoDocente.Remove(entity);
			contextInstance.SaveChanges();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível excluir o registro.", innerException);
		}
	}

	public ViewProjetoDocente BuscarDocentePorId(long projetoCorpoDocenteUID)
	{
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		try
		{
			return contextInstance.ViewProjetoDocente.Where((ViewProjetoDocente c) => c.projetoCorpoDocenteUID == projetoCorpoDocenteUID).FirstOrDefault();
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível excluir o registro.", innerException);
		}
	}

	public ProjetoCorpoDocenteDTO BuscarDocenteDTOPorId(long projetoCorpoDocenteUID)
	{
		try
		{
			EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
			ProjetoCorpoDocenteDTO result = new ProjetoCorpoDocenteDTO();
			ProjetoCorpoDocente projetoCorpoDocente = contextInstance.ProjetoCorpoDocente.Where((ProjetoCorpoDocente c) => c.projetoCorpoDocenteUID == projetoCorpoDocenteUID).FirstOrDefault();
			if (projetoCorpoDocente != null)
			{
				result = ConverterProjetoCorpoDocenteParaDTO(projetoCorpoDocente);
			}
			return result;
		}
		catch (Exception innerException)
		{
			throw new Exception("Não foi possível excluir o registro.", innerException);
		}
	}

	public ProjetoCorpoDocenteDTO ConverterProjetoCorpoDocenteParaDTO(ProjetoCorpoDocente projetoCorpoDocente)
	{
		ProjetoCorpoDocenteDTO projetoCorpoDocenteDTO = new ProjetoCorpoDocenteDTO();
		if (!projetoCorpoDocente.servidorUID.HasValue)
		{
			projetoCorpoDocenteDTO.ProjetoCorpoDocenteUID = projetoCorpoDocente.projetoCorpoDocenteUID;
			projetoCorpoDocenteDTO.Nome = projetoCorpoDocente.nome;
			projetoCorpoDocenteDTO.Sexo = projetoCorpoDocente.sexo;
			projetoCorpoDocenteDTO.DataNascimento = projetoCorpoDocente.dataNascimento;
			projetoCorpoDocenteDTO.NomeMae = projetoCorpoDocente.nomeMae;
			projetoCorpoDocenteDTO.NomePai = projetoCorpoDocente.nomePai;
			projetoCorpoDocenteDTO.Cpf = projetoCorpoDocente.cpf;
			projetoCorpoDocenteDTO.Rg = projetoCorpoDocente.rg;
			projetoCorpoDocenteDTO.DataExpedicao = projetoCorpoDocente.dataExpedicao;
			projetoCorpoDocenteDTO.TelefoneFixo = projetoCorpoDocente.telefoneFixo;
			projetoCorpoDocenteDTO.Celular = projetoCorpoDocente.celular;
			projetoCorpoDocenteDTO.Email = projetoCorpoDocente.email;
			projetoCorpoDocenteDTO.TipoTitulacaoUID = projetoCorpoDocente.tipoTitulacaoUID;
			projetoCorpoDocenteDTO.DescricaoTipoTitulacao = projetoCorpoDocente.TipoTitulacao.descricao;
			projetoCorpoDocenteDTO.OrgaoExpedidorUID = projetoCorpoDocente.orgaoExpedidorUID;
			projetoCorpoDocenteDTO.DescricaoOrgaoExpedidor = projetoCorpoDocente.TipoOrgaoExpedidorRg.nome;
			projetoCorpoDocenteDTO.orgaoExpedidorUFUID = projetoCorpoDocente.orgaoExpedidorUFUID;
			projetoCorpoDocenteDTO.DescricaoOrgaoExpedidorUF = projetoCorpoDocente.UF.Nome;
		}
		else
		{
			projetoCorpoDocenteDTO.ProjetoCorpoDocenteUID = projetoCorpoDocente.projetoCorpoDocenteUID;
			projetoCorpoDocenteDTO.ServidorUID = projetoCorpoDocente.servidorUID;
			projetoCorpoDocenteDTO.Siape = projetoCorpoDocente.Servidor.registro;
			projetoCorpoDocenteDTO.SiapeDV = projetoCorpoDocente.Servidor.registroDV;
			projetoCorpoDocenteDTO.Nome = projetoCorpoDocente.Servidor.Pessoa.nome;
			projetoCorpoDocenteDTO.Sexo = projetoCorpoDocente.Servidor.Pessoa.sexo;
			projetoCorpoDocenteDTO.DataNascimento = projetoCorpoDocente.Servidor.Pessoa.nascimentoData;
			projetoCorpoDocenteDTO.NomeMae = projetoCorpoDocente.Servidor.Pessoa.nomeMae;
			projetoCorpoDocenteDTO.NomePai = projetoCorpoDocente.Servidor.Pessoa.nomePai;
			projetoCorpoDocenteDTO.Cpf = projetoCorpoDocente.Servidor.Pessoa.cpf;
			projetoCorpoDocenteDTO.Rg = projetoCorpoDocente.Servidor.Pessoa.rg;
			projetoCorpoDocenteDTO.DataExpedicao = projetoCorpoDocente.Servidor.Pessoa.rgDataExpedicao;
			projetoCorpoDocenteDTO.TelefoneFixo = projetoCorpoDocente.Servidor.Pessoa.telefonePrimario;
			projetoCorpoDocenteDTO.Celular = projetoCorpoDocente.Servidor.Pessoa.telefoneSecundario;
			projetoCorpoDocenteDTO.Email = projetoCorpoDocente.Servidor.Pessoa.mail;
			projetoCorpoDocenteDTO.TipoTitulacaoUID = projetoCorpoDocente.Servidor.Pessoa.tipoTitulacaoUID;
			projetoCorpoDocenteDTO.DescricaoTipoTitulacao = ((projetoCorpoDocente.Servidor.Pessoa.TipoTitulacao == null) ? "" : projetoCorpoDocente.Servidor.Pessoa.TipoTitulacao.descricao);
			projetoCorpoDocenteDTO.DescricaoOrgaoExpedidor = projetoCorpoDocente.Servidor.Pessoa.rgOrgaoExpedidor;
			projetoCorpoDocenteDTO.orgaoExpedidorUFUID = projetoCorpoDocente.Servidor.Pessoa.rgUF;
			projetoCorpoDocenteDTO.DescricaoOrgaoExpedidorUF = ((projetoCorpoDocente.Servidor.Pessoa.UF2 == null) ? "" : projetoCorpoDocente.Servidor.Pessoa.UF2.Nome);
		}
		return projetoCorpoDocenteDTO;
	}
}
