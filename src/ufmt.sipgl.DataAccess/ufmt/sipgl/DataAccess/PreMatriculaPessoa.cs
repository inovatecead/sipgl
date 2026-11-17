using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class PreMatriculaPessoa
{
	public long preMatriculaPessoaUID { get; set; }

	public string nome { get; set; }

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

	public string telefoneFixo { get; set; }

	public string telefoneMovel { get; set; }

	public string telefoneComercial { get; set; }

	public DateTime graduacaoDataColacaoGrau { get; set; }

	public bool diplomaGraduacaoExterior { get; set; }

	public string numeroRegistroApostilaRevalidacao { get; set; }

	public byte? tipoFaixaRendaFamiliarUID { get; set; }

	public byte? tipoCorRacaUID { get; set; }

	public DateTime dataHoraCadastro { get; set; }

	public DateTime dataHoraUltimaAtualizacao { get; set; }

	public string senha { get; set; }

	public string enderecoUFUID { get; set; }

	public string graduacaoUFUID { get; set; }

	public string naturalidadeUFUID { get; set; }

	public string chaveValidacaoCadastro { get; set; }

	public bool? emailConfirmado { get; set; }

	public string chaveRecuperacaoSenha { get; set; }

	public DateTime? dataValidadeChave { get; set; }

	public long? projetoTipoGraduacaoUID { get; set; }

	public string cursoGraduacao { get; set; }

	public string numeroRegistroDiploma { get; set; }

	public string passaporte { get; set; }

	public string tituloEleitoral { get; set; }

	public string zona { get; set; }

	public string tituloEleitoralUFUID { get; set; }

	public int? tituloEleitoralMunicipioUID { get; set; }

	public string profissao { get; set; }

	public string localTrabalho { get; set; }

	public string celularComercial { get; set; }

	public string emailComercial { get; set; }

	public int? graduacaoInstituicaoEnsinoUID { get; set; }

	public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }

	public virtual Municipio Municipio { get; set; }

	public virtual Municipio Municipio1 { get; set; }

	public virtual Pais Pais { get; set; }

	public virtual TipoCorRaca TipoCorRaca { get; set; }

	public virtual TipoEstadoCivil TipoEstadoCivil { get; set; }

	public virtual TipoFaixaRendaFamiliar TipoFaixaRendaFamiliar { get; set; }

	public virtual UF UF { get; set; }

	public virtual UF UF1 { get; set; }

	public virtual ICollection<PreMatriculaInscricao> PreMatriculaInscricao { get; set; }

	public virtual ICollection<ProjetoPreInscricao> ProjetoPreInscricao { get; set; }

	public virtual ProjetoTipoGraduacao ProjetoTipoGraduacao { get; set; }

	public PreMatriculaPessoa()
	{
		PreMatriculaInscricao = new HashSet<PreMatriculaInscricao>();
		ProjetoPreInscricao = new HashSet<ProjetoPreInscricao>();
	}
}
