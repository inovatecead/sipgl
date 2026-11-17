using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class TipoServicoTerceirosPessoaJuridica
{
	public short tipoServicoTerceirosPessoaJuridicaUID { get; set; }

	public string nome { get; set; }

	public virtual ICollection<ProjetoServicoTerceirosPessoJuridica> ProjetoServicoTerceirosPessoJuridica { get; set; }

	public TipoServicoTerceirosPessoaJuridica()
	{
		ProjetoServicoTerceirosPessoJuridica = new HashSet<ProjetoServicoTerceirosPessoJuridica>();
	}
}
