using System.Collections.Generic;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.Business;

public class ProjetoTipoGraduacaoBO
{
	public ProjetoTipoGraduacaoDAL ProjetoTipoGraduacaoDAL { get; set; }

	public ProjetoTipoGraduacaoBO()
	{
		ProjetoTipoGraduacaoDAL = new ProjetoTipoGraduacaoDAL();
	}

	public List<ProjetoTipoGraduacao> ListarProjetoTipoGraduacao()
	{
		return ProjetoTipoGraduacaoDAL.ListarProjetoTipoGraduacao();
	}
}
