using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class UF
{
	public string UFUID { get; set; }

	public string Nome { get; set; }

	public byte CodigoExterno { get; set; }

	public virtual ICollection<Municipio> Municipio { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa1 { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa2 { get; set; }

	public virtual ICollection<PessoaIDBUFMT> Pessoa3 { get; set; }

	public virtual ICollection<ProjetoCorpoDocente> ProjetoCorpoDocente { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public virtual ICollection<PreMatriculaPessoa> PreMatriculaPessoa1 { get; set; }

	public UF()
	{
		Municipio = new HashSet<Municipio>();
		Pessoa = new HashSet<PessoaIDBUFMT>();
		Pessoa1 = new HashSet<PessoaIDBUFMT>();
		Pessoa2 = new HashSet<PessoaIDBUFMT>();
		Pessoa3 = new HashSet<PessoaIDBUFMT>();
		ProjetoCorpoDocente = new HashSet<ProjetoCorpoDocente>();
		PreMatriculaPessoa = new HashSet<PreMatriculaPessoa>();
		PreMatriculaPessoa1 = new HashSet<PreMatriculaPessoa>();
	}
}
