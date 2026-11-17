using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTipoGraduacao
{
	public long projetoTipoGraduacaoUID { get; set; }

	public string descricao { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public ProjetoTipoGraduacao()
	{
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
	}
}
