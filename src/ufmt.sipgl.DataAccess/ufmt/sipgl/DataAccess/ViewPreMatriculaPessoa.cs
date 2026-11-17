using System;

namespace ufmt.sipgl.DataAccess;

public class ViewPreMatriculaPessoa
{
	public long preMatriculaPessoaUID { get; set; }

	public string nomeCandidato { get; set; }

	public string sexo { get; set; }

	public DateTime nascimentoData { get; set; }

	public string nomeMae { get; set; }

	public string nomePai { get; set; }

	public string cpf { get; set; }

	public string rgNumero { get; set; }

	public string rgUFUID { get; set; }

	public string rgOrgaoExpedidor { get; set; }

	public DateTime rgDataExpedicao { get; set; }

	public byte tipoEstadoCivilUID { get; set; }

	public string nacionalidade { get; set; }

	public string nascimentoPaisUID { get; set; }

	public int? naturalidadeMunicipioUID { get; set; }

	public string email { get; set; }

	public string enderecoLogradouro { get; set; }

	public string enderecoNumero { get; set; }

	public string enderecoComplemento { get; set; }

	public string enderecoBairro { get; set; }

	public string enderecoCEP { get; set; }

	public int enderecoMunicipioUID { get; set; }

	public string enderecoUFUID { get; set; }

	public string graduacaoUFUID { get; set; }

	public string naturalidadeUFUID { get; set; }

	public string telefoneFixo { get; set; }

	public string telefoneMovel { get; set; }

	public bool diplomaGraduacaoExterior { get; set; }

	public string numeroRegistroApostilaRevalidacao { get; set; }

	public int? graduacaoInstituicaoEnsinoUID { get; set; }

	public DateTime graduacaoDataColacaoGrau { get; set; }

	public byte? tipoFaixaRendaFamiliarUID { get; set; }

	public byte? tipoCorRacaUID { get; set; }

	public DateTime dataHoraCadastro { get; set; }

	public DateTime dataHoraUltimaAtualizacao { get; set; }

	public string cursoGraduacao { get; set; }

	public string numeroRegistroDiploma { get; set; }

	public string tituloEleitoral { get; set; }

	public string zona { get; set; }

	public string tituloEleitoralUFUID { get; set; }

	public int? tituloEleitoralMunicipioUID { get; set; }

	public string passaporte { get; set; }

	public string profissao { get; set; }

	public string localTrabalho { get; set; }

	public string telefoneComercial { get; set; }

	public string celularComercial { get; set; }

	public string emailComercial { get; set; }

	public string nomeTipoEstadoCivil { get; set; }

	public string nomeNascimentoPais { get; set; }

	public string naturalidadeNomeMunicipio { get; set; }

	public string graduacaoUfInstituicaoEnsino { get; set; }

	public string enderecoNomeMunicipio { get; set; }

	public string graduacaoInstituicaoEnsino { get; set; }

	public string senha { get; set; }

	public long? projetoTipoGraduacaoUID { get; set; }

	public string tipoGraduacao { get; set; }
}
