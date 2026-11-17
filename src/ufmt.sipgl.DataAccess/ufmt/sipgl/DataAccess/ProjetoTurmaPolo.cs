using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTurmaPolo
{
	public long projetoTurmaPoloUID { get; set; }

	public long projetoTurmaUID { get; set; }

	public int enderecoUID { get; set; }

	public int quantidadeVagas { get; set; }

	public virtual EnderecoPoloApoioPresencialEAD EnderecoPoloApoioPresencialEAD { get; set; }

	public virtual ICollection<ProjetoEncontroPresencial> ProjetoEncontroPresencial { get; set; }

	public virtual ICollection<PreMatriculaInscricao> PreMatriculaInscricao { get; set; }

	public virtual ProjetoTurma ProjetoTurma { get; set; }

	public ProjetoTurmaPolo()
	{
		ProjetoEncontroPresencial = new HashSet<ProjetoEncontroPresencial>();
		PreMatriculaInscricao = new HashSet<PreMatriculaInscricao>();
	}
}
