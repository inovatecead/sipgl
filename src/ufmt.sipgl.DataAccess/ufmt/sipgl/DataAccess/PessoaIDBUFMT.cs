using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class PessoaIDBUFMT
{
	public long pessoaUID { get; set; }

	public string nome { get; set; }

	public string sexo { get; set; }

	public DateTime nascimentoData { get; set; }

	public string nomeMae { get; set; }

	public string nomePai { get; set; }

	public string cpf { get; set; }

	public string pisPasep { get; set; }

	public string ctps { get; set; }

	public string ctpsSerie { get; set; }

	public string ctpsUF { get; set; }

	public string rg { get; set; }

	public string rgOrgaoExpedidor { get; set; }

	public DateTime? rgDataExpedicao { get; set; }

	public string rgUF { get; set; }

	public byte? tipoEstadoCivilUID { get; set; }

	public string nacionalidade { get; set; }

	public string nascimentoPaisUID { get; set; }

	public string tituloEleitor { get; set; }

	public string tituloEleitorZona { get; set; }

	public string tituloEleitorSecao { get; set; }

	public string tituloEleitorDataEmissao { get; set; }

	public string tituloEleitorUF { get; set; }

	public string enderecoLogradouro { get; set; }

	public string enderecoNumero { get; set; }

	public string enderecoComplemento { get; set; }

	public string enderecoBairro { get; set; }

	public string enderecoMunicipio { get; set; }

	public int? enderecoMunicipioUID { get; set; }

	public string enderecoUF { get; set; }

	public string enderecoCEP { get; set; }

	public string telefonePrimario { get; set; }

	public string telefoneSecundario { get; set; }

	public string telefoneComercial { get; set; }

	public string mail { get; set; }

	public int? tipoTitulacaoUID { get; set; }

	public int? naturalidadeMunicipioUID { get; set; }

	public long? titulacaoUID { get; set; }

	public virtual Municipio Municipio { get; set; }

	public virtual Municipio Municipio1 { get; set; }

	public virtual ICollection<Discente> Discente { get; set; }

	public virtual UF UF { get; set; }

	public virtual UF UF1 { get; set; }

	public virtual UF UF2 { get; set; }

	public virtual UF UF3 { get; set; }

	public virtual ICollection<ProjetoBolsaEstagioLei_11788_2008> ProjetoBolsaEstagioLei_11788_2008 { get; set; }

	public virtual ICollection<ProjetoDespesas> ProjetoDespesas { get; set; }

	public virtual ICollection<ProjetoDiarias> ProjetoDiarias { get; set; }

	public virtual ICollection<ProjetoPassagens> ProjetoPassagens { get; set; }

	public virtual ICollection<ProjetoPessoalEncargos> ProjetoPessoalEncargos { get; set; }

	public virtual ICollection<ProjetoServicoTerceirosPessoaFisica> ProjetoServicoTerceirosPessoaFisica { get; set; }

	public virtual ICollection<ServidorIDBUFMT> Servidor { get; set; }

	public virtual TipoTitulacao TipoTitulacao { get; set; }

	public virtual ICollection<Usuario> Usuario { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public PessoaIDBUFMT()
	{
		Discente = new HashSet<Discente>();
		ProjetoBolsaEstagioLei_11788_2008 = new HashSet<ProjetoBolsaEstagioLei_11788_2008>();
		ProjetoDespesas = new HashSet<ProjetoDespesas>();
		ProjetoDiarias = new HashSet<ProjetoDiarias>();
		ProjetoPassagens = new HashSet<ProjetoPassagens>();
		ProjetoPessoalEncargos = new HashSet<ProjetoPessoalEncargos>();
		ProjetoServicoTerceirosPessoaFisica = new HashSet<ProjetoServicoTerceirosPessoaFisica>();
		Servidor = new HashSet<ServidorIDBUFMT>();
		Usuario = new HashSet<Usuario>();
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}
