namespace ufmt.sipgl.DataAccess;

public class EnderecoFuncionamentoCurso
{
	public long enderecoFuncionamentoCursoUID { get; set; }

	public long cursoUID { get; set; }

	public string logradouro { get; set; }

	public string numero { get; set; }

	public string complemento { get; set; }

	public string caixaPostal { get; set; }

	public string bairro { get; set; }

	public string cep { get; set; }

	public int municipioUID { get; set; }

	public string telefone { get; set; }

	public string fax { get; set; }

	public string email { get; set; }

	public string siteDoCurso { get; set; }

	public virtual Curso Curso { get; set; }

	public virtual Municipio Municipio { get; set; }
}
