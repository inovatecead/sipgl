using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.DataTransferObject;

namespace ufmt.sipgl.View;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(/*Could not decode attribute arguments.*/)]
[ScriptService]
public class WSConsulta : WebService
{
	[WebMethod]
	public List<PessoaIDBUFMTDTO> GetPessoaIDBUFMT(string nome)
	{
		List<PessoaIDBUFMT> list = new PessoaIDBUFMTDAL().ListarPessoaIDBUFMT(nome);
		List<PessoaIDBUFMTDTO> list2 = new List<PessoaIDBUFMTDTO>();
		foreach (PessoaIDBUFMT item in list)
		{
			PessoaIDBUFMTDTO pessoaIDBUFMTDTO = new PessoaIDBUFMTDTO();
			pessoaIDBUFMTDTO.PessoaUID = item.pessoaUID;
			pessoaIDBUFMTDTO.Cpf = item.cpf;
			pessoaIDBUFMTDTO.Nome = item.nome;
			list2.Add(pessoaIDBUFMTDTO);
		}
		return list2.OrderBy((PessoaIDBUFMTDTO e) => e.Nome).ToList();
	}

	[WebMethod]
	public List<ViewCoordenadorUFMT> GetCoordenador(string nome)
	{
		return (from m in new CoordenadorDAL().GetCoordenador()
			where m.nome.SemCaracteresEspeciais().ToLower().StartsWith(nome.SemCaracteresEspeciais().ToLower())
			select m).ToList();
	}

	[WebMethod]
	public List<ViewDocenteUFMT> GetDocente(string nome)
	{
		return (from m in new CoordenadorDAL().GetDocente()
			where m.nome.SemCaracteresEspeciais().ToLower().StartsWith(nome.SemCaracteresEspeciais().ToLower())
			select m).ToList();
	}

	[WebMethod]
	public List<ViewUnidade> GetUnidade(string nome)
	{
		return (from m in new UnidadeDAL().GetUnidade()
			where m.nome.SemCaracteresEspeciais().ToLower().Contains(nome.SemCaracteresEspeciais().ToLower())
			select m).ToList();
	}

	[WebMethod]
	public List<ViewUnidade> GetUnidadePorCampus(string nome, long campusUID)
	{
		return (from m in new UnidadeDAL().GetUnidadesPorCampus(campusUID)
			where m.nome.SemCaracteresEspeciais().ToLower().Contains(nome.SemCaracteresEspeciais().ToLower())
			select m).ToList();
	}

	[WebMethod]
	public List<ObjInstituicaoEnsinoSuperior> GetInstituicaoEnsinoSuperior(string nome)
	{
		return (from e in new CursoDAL().GetInstituicaoEnsinoSuperior()
			where e.Nome.SemCaracteresEspeciais().ToLower().Contains(nome.SemCaracteresEspeciais().ToLower())
			orderby e.Nome
			select e).ToList();
	}

	[WebMethod]
	public List<ViewMunicipio> GetMunicipio(string nome)
	{
		return (from e in new CursoDAL().GetMunicipio()
			where e.Nome.SemCaracteresEspeciais().ToLower().StartsWith(nome.SemCaracteresEspeciais().ToLower())
			orderby e.Nome
			select e).ToList();
	}

	[WebMethod]
	public List<ViewMunicipio> GetMunicipioPorEstado(string nome, string uf)
	{
		return new CursoDAL().GetMunicipioPorEstado(nome, uf);
	}

	[WebMethod]
	public List<ViewDadosCursoSiga> GetCursoSiga(string nome)
	{
		return (from m in new CursoDAL().GetCursoSiga()
			where m.siganomecursovest.SemCaracteresEspeciais().ToLower().StartsWith(nome.SemCaracteresEspeciais().ToLower())
			select m).ToList();
	}
}
