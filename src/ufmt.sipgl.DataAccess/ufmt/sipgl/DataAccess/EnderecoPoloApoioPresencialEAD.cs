using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class EnderecoPoloApoioPresencialEAD
{
	public int enderecoUID { get; set; }

	public long? projetoCursoUID { get; set; }

	public string CEP { get; set; }

	public int municipioEnderecoUID { get; set; }

	public string logradouro { get; set; }

	public int? numeroEndereco { get; set; }

	public string complementoBairro { get; set; }

	public string bairroEndereco { get; set; }

	public string informacoesReferenciaEndereco { get; set; }

	public string telefone { get; set; }

	public string fax { get; set; }

	public string email { get; set; }

	public string site { get; set; }

	public string identificacaoEndereco { get; set; }

	public int? tipoUnidadeEnsino { get; set; }

	public string enderecoUFUID { get; set; }

	public virtual ICollection<ProjetoTurmaPolo> ProjetoTurmaPolo { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }

	public string Descricao { get; set; }

	public EnderecoPoloApoioPresencialEAD()
	{
		ProjetoTurmaPolo = new HashSet<ProjetoTurmaPolo>();
	}
}
