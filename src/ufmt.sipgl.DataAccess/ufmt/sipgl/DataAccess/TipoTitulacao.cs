using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoTitulacao
{
	public int tipoTitulacaoUID { get; set; }

	public string descricao { get; set; }

	public int? titulacaoSiape { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa { get; set; }

	public virtual ICollection<ProjetoCorpoDocente> ProjetoCorpoDocente { get; set; }

	public TipoTitulacao()
	{
		Pessoa = new HashSet<PessoaIDBUFMT>();
		ProjetoCorpoDocente = new HashSet<ProjetoCorpoDocente>();
	}
}
