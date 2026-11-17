using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoEncontroPresencialBO
{
	private ProjetoEncontroPresencialDAL projetoEncontroPresencialDAL;

	public ProjetoEncontroPresencialBO()
	{
		projetoEncontroPresencialDAL = new ProjetoEncontroPresencialDAL();
	}

	public ProjetoEncontroPresencial BuscarEncontroPresencialPorId(long projetoEncontroPresencialUID)
	{
		return projetoEncontroPresencialDAL.BuscarEncontroPresencialPorId(projetoEncontroPresencialUID);
	}

	public List<ViewProjetoEncontroPresencial> FiltrarEncontroPresencialPorDisciplinaTurmaPolo(long projetoDisciplinaUID, long? projetoTurmaUID, int? enderecoUID)
	{
		return projetoEncontroPresencialDAL.FiltrarEncontroPresencialPorDisciplinaTurmaPolo(projetoDisciplinaUID, projetoTurmaUID, enderecoUID);
	}

	public List<ViewProjetoEncontroPresencial> ListarEncontroPresencialPorDisciplina(long projetoDisciplinaUID)
	{
		return projetoEncontroPresencialDAL.ListarEncontroPresencialPorDisciplina(projetoDisciplinaUID);
	}

	public ResultadoOperacao CadastrarEncontroPresencial(ProjetoEncontroPresencial projetoEncontroPresencial, long projetoTurmaUID, int enderecoUID)
	{
		return projetoEncontroPresencialDAL.CadastrarEncontroPresencial(projetoEncontroPresencial, projetoTurmaUID, enderecoUID);
	}

	public ResultadoOperacao AlterarEncontroPresencial(ProjetoEncontroPresencial projetoEncontroPresencial, long projetoTurmaUID, int enderecoUID)
	{
		return projetoEncontroPresencialDAL.AlterarEncontroPresencial(projetoEncontroPresencial, projetoTurmaUID, enderecoUID);
	}

	public ResultadoOperacao Excluir(long projetoEncontroPresencialUID)
	{
		return projetoEncontroPresencialDAL.Excluir(projetoEncontroPresencialUID);
	}
}
