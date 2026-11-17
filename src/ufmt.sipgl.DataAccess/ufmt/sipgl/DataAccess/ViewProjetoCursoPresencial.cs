using System;

namespace ufmt.sipgl.DataAccess;

public class ViewProjetoCursoPresencial
{
	public long projetoCursoUID { get; set; }

	public int codigoProjetoCurso { get; set; }

	public string Nome_do_Curso { get; set; }

	public long Área_do_Conhecimento { get; set; }

	public long Unidade_Proponente { get; set; }

	public string Logradouro { get; set; }

	public string Nº { get; set; }

	public string Complemento { get; set; }

	public string Caixa_Postal { get; set; }

	public string Bairro { get; set; }

	public string CEP { get; set; }

	public short? UF { get; set; }

	public int? Município { get; set; }

	public string Telefone { get; set; }

	public string Fax { get; set; }

	public string Email { get; set; }

	public string Site_do_Curso { get; set; }

	public string Coord__Nome { get; set; }

	public string Coord__CPF { get; set; }

	public string Coord__Titulação { get; set; }

	public string Coord__Unidade_de_Lotação { get; set; }

	public string Coord__Telefone_Residencial { get; set; }

	public string Coord__Telefone_Celular { get; set; }

	public string Coord__Regime_de_Trabalho { get; set; }

	public string Coord__E_mail { get; set; }

	public string Vice_Coord__Nome { get; set; }

	public string Vice_Coord__CPF { get; set; }

	public string Vice_Coord__Titulação { get; set; }

	public string Vice_Coord__Unidade_de_Lotação { get; set; }

	public string Vice_Coord__Telefone_Residencial { get; set; }

	public string Vice_Coord__Telefone_Celular { get; set; }

	public string Vice_Coord__Regime_de_Trabalho { get; set; }

	public string Vice_Coord__E_mail { get; set; }

	public DateTime Início_Curso { get; set; }

	public DateTime Término_Curso { get; set; }

	public int Carga_Hor__Total { get; set; }

	public string Turno_de_Oferta { get; set; }

	public string Periodicidade { get; set; }

	public string Tipo_Vaga { get; set; }

	public short? Número_de_Vagas { get; set; }

	public string Público_alvo { get; set; }

	public string Instalações { get; set; }

	public string Equipamentos { get; set; }

	public string Material_Bibliográfico { get; set; }

	public string Justificativa { get; set; }

	public string Objetivos { get; set; }

	public byte[] Minuta_Edital { get; set; }
}
