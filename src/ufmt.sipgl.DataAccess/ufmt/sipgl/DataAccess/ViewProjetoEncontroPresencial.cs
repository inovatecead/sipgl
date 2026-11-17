using System;

namespace ufmt.sipgl.DataAccess;

public class ViewProjetoEncontroPresencial
{
	public long projetoEncontroPresencialUID { get; set; }

	public DateTime dataEncontro { get; set; }

	public bool isObrigatorio { get; set; }

	public int enderecoUID { get; set; }

	public string identificacaoEndereco { get; set; }

	public long projetoTurmaUID { get; set; }

	public string nomeTurma { get; set; }

	public long projetoDisciplinaUID { get; set; }

	public string nomeDisciplina { get; set; }
}
