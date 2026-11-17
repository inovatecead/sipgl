using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class InstituicaoEnsino
{
	public int instituicaoEnsinoUID { get; set; }

	public byte tipoNivelInstituicaoEnsinoUID { get; set; }

	public byte? tipoOrganizacaoAcademicaIEUID { get; set; }

	public string nome { get; set; }

	public byte? tipoDependeciaAdministrativaUID { get; set; }

	public byte? tipoInstituicaoEnsinoUID { get; set; }

	public int municipioUID { get; set; }

	public byte? tipoCondicaoFuncionamentoIEUID { get; set; }

	public virtual Municipio Municipio { get; set; }

	public virtual TipoInstituicaoEnsino TipoInstituicaoEnsino { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public InstituicaoEnsino()
	{
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
	}
}
