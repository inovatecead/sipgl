using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Municipio
{
	public int MunicipioUID { get; set; }

	public string Nome { get; set; }

	public string UF { get; set; }

	public virtual ICollection<EnderecoFuncionamentoCurso> EnderecoFuncionamentoCurso { get; set; }

	public virtual ICollection<ProjetoDiarias> ProjetoDiarias { get; set; }

	public virtual UF UF1 { get; set; }

	public virtual ICollection<InstituicaoEnsino> InstituicaoEnsino { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa1 { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa1 { get; set; }

	public Municipio()
	{
		EnderecoFuncionamentoCurso = new HashSet<EnderecoFuncionamentoCurso>();
		ProjetoDiarias = new HashSet<ProjetoDiarias>();
		InstituicaoEnsino = new HashSet<InstituicaoEnsino>();
		Pessoa = new HashSet<PessoaIDBUFMT>();
		Pessoa1 = new HashSet<PessoaIDBUFMT>();
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
		PreMatriculaPessoa1 = new HashSet<PreMatriculaPessoa>();
	}
}
