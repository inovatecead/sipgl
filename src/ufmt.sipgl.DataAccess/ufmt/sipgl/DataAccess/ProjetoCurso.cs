using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCurso
{
	public long projetoCursoUID { get; set; }

	public int codigoProjetoCurso { get; set; }

	public byte tipoModalidadeUID { get; set; }

	public string nomeCurso { get; set; }

	public long CNPqAreaConhecimentoUID { get; set; }

	public long proponenteUnidadeUID { get; set; }

	public string telefone { get; set; }

	public string fax { get; set; }

	public string email { get; set; }

	public string siteCurso { get; set; }

	public long coordenadorServidorUID { get; set; }

	public int? titulacaoCoordenadorUID { get; set; }

	public int? regimeTrabalhoCoordenadorUID { get; set; }

	public string telefoneResidencialCoordenador { get; set; }

	public string telefoneCelularCoordenador { get; set; }

	public string emailCoordenador { get; set; }

	public long? viceCoordenadorServidorUID { get; set; }

	public int? titulacaoViceCoordenadorUID { get; set; }

	public int? regimeTrabalhoViceCoordenadorUID { get; set; }

	public string telefoneResidencialViceCoordenador { get; set; }

	public string telefoneCelularViceCoordenador { get; set; }

	public string emailViceCoordenador { get; set; }

	public DateTime? realizacaoDataInicio { get; set; }

	public DateTime? realizacaoDataTermino { get; set; }

	public int? cargaHorariaTotal { get; set; }

	public int? turnoOfertaUID { get; set; }

	public int? periodicidadeUID { get; set; }

	public int? cargaHorariaDiario { get; set; }

	public int? cargaHorariaModular { get; set; }

	public string nomeCursoModular { get; set; }

	public string publicoAlvo { get; set; }

	public string descricaoInstalacoes { get; set; }

	public string descricaoEquipamentos { get; set; }

	public string descricaoMaterialBibliografico { get; set; }

	public string justificativaCurso { get; set; }

	public string objetivosCurso { get; set; }

	public byte[] minutaEdital { get; set; }

	public string formasAvaliacao { get; set; }

	public string caracteristicasMonografiaTcc { get; set; }

	public int? notaMinimaAprovacao { get; set; }

	public int? frequenciaMinimaAprovacao { get; set; }

	public byte[] financiamentoCurso { get; set; }

	public byte[] termoConvenio { get; set; }

	public byte? tipoFinanciamentoUID { get; set; }

	public byte? tipoGestaoFinanceiraUID { get; set; }

	public byte[] planoAplicacaoSuperavit { get; set; }

	public int? quantidadeEgresso { get; set; }

	public int? quantidadeVagas { get; set; }

	public DateTime? dataDocumentoRealizacaoCurso { get; set; }

	public byte[] documentoRealizacaoCurso { get; set; }

	public bool? VinculoCursoGraduacao { get; set; }

	public int? sigaCodCurso { get; set; }

	public string CEP { get; set; }

	public int? municipioEnderecoUID { get; set; }

	public string identificacaoEndereco { get; set; }

	public int? numeroEndereco { get; set; }

	public string complementoBairro { get; set; }

	public string bairroEndereco { get; set; }

	public string informacoesReferenciaEndereco { get; set; }

	public bool? finalizado { get; set; }

	public long? CNPqSubAreaConhecimentoUID { get; set; }

	public string descricaoAva { get; set; }

	public long? secretarioUID { get; set; }

	public string celularSecretario { get; set; }

	public string emailSecretario { get; set; }

	public long? usuarioCriacaoUID { get; set; }

	public DateTime? dataCriacao { get; set; }

	public string codigoEMEC { get; set; }

	public virtual CNPqAreaConhecimento CNPqAreaConhecimento { get; set; }

	public virtual CNPqSubAreaConhecimento CNPqSubAreaConhecimento { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }

	public virtual ServidorIDBUFMT Servidor1 { get; set; }

	public virtual TipoModalidade TipoModalidade { get; set; }

	public virtual Usuario Usuario { get; set; }

	public virtual ICollection<EnderecoPoloApoioPresencialEAD> EnderecoPoloApoioPresencialEAD { get; set; }

	public virtual ICollection<PreMatriculaInscricao> PreMatriculaInscricao { get; set; }

	public virtual ICollection<ProjetoBolsaEstagioLei_11788_2008> ProjetoBolsaEstagioLei_11788_2008 { get; set; }

	public virtual ICollection<ProjetoBolsaoLei_8958_94> ProjetoBolsaoLei_8958_94 { get; set; }

	public virtual ICollection<ProjetoColegiadoCurso> ProjetoColegiadoCurso { get; set; }

	public virtual TipoFinanciamento TipoFinanciamento { get; set; }

	public virtual TipoGestaoFinanceira TipoGestaoFinanceira { get; set; }

	public virtual ICollection<ProjetoCursoComplementoEad> ProjetoCursoComplementoEad { get; set; }

	public virtual ICollection<ProjetoCursoComplementoPresencial> ProjetoCursoComplementoPresencial { get; set; }

	public virtual ICollection<ProjetoDespesas> ProjetoDespesas { get; set; }

	public virtual ICollection<ProjetoDiarias> ProjetoDiarias { get; set; }

	public virtual ICollection<ProjetoDisciplina> ProjetoDisciplina { get; set; }

	public virtual ICollection<ProjetoEquipamento> ProjetoEquipamento { get; set; }

	public virtual ICollection<ProjetoInstalacao> ProjetoInstalacao { get; set; }

	public virtual ICollection<ProjetoMaterialConsumo> ProjetoMaterialConsumo { get; set; }

	public virtual ICollection<ProjetoMaterialPermanente> ProjetoMaterialPermanente { get; set; }

	public virtual ICollection<ProjetoObras> ProjetoObras { get; set; }

	public virtual ICollection<ProjetoPassagens> ProjetoPassagens { get; set; }

	public virtual ICollection<ProjetoPessoalEncargos> ProjetoPessoalEncargos { get; set; }

	public virtual ICollection<ProjetoPrevisaoReceitas> ProjetoPrevisaoReceitas { get; set; }

	public virtual ICollection<ProjetoServicoTerceirosPessoaFisica> ProjetoServicoTerceirosPessoaFisica { get; set; }

	public virtual ICollection<ProjetoServicoTerceirosPessoJuridica> ProjetoServicoTerceirosPessoJuridica { get; set; }

	public virtual ICollection<ProjetoTurma> ProjetoTurma { get; set; }

	public ProjetoCurso()
	{
		EnderecoPoloApoioPresencialEAD = new HashSet<EnderecoPoloApoioPresencialEAD>();
		PreMatriculaInscricao = new HashSet<PreMatriculaInscricao>();
		ProjetoBolsaEstagioLei_11788_2008 = new HashSet<ProjetoBolsaEstagioLei_11788_2008>();
		ProjetoBolsaoLei_8958_94 = new HashSet<ProjetoBolsaoLei_8958_94>();
		ProjetoColegiadoCurso = new HashSet<ProjetoColegiadoCurso>();
		ProjetoCursoComplementoEad = new HashSet<ProjetoCursoComplementoEad>();
		ProjetoCursoComplementoPresencial = new HashSet<ProjetoCursoComplementoPresencial>();
		ProjetoDespesas = new HashSet<ProjetoDespesas>();
		ProjetoDiarias = new HashSet<ProjetoDiarias>();
		ProjetoDisciplina = new HashSet<ProjetoDisciplina>();
		ProjetoEquipamento = new HashSet<ProjetoEquipamento>();
		ProjetoInstalacao = new HashSet<ProjetoInstalacao>();
		ProjetoMaterialConsumo = new HashSet<ProjetoMaterialConsumo>();
		ProjetoMaterialPermanente = new HashSet<ProjetoMaterialPermanente>();
		ProjetoObras = new HashSet<ProjetoObras>();
		ProjetoPassagens = new HashSet<ProjetoPassagens>();
		ProjetoPessoalEncargos = new HashSet<ProjetoPessoalEncargos>();
		ProjetoPrevisaoReceitas = new HashSet<ProjetoPrevisaoReceitas>();
		ProjetoServicoTerceirosPessoaFisica = new HashSet<ProjetoServicoTerceirosPessoaFisica>();
		ProjetoServicoTerceirosPessoJuridica = new HashSet<ProjetoServicoTerceirosPessoJuridica>();
		ProjetoTurma = new HashSet<ProjetoTurma>();
	}
}
