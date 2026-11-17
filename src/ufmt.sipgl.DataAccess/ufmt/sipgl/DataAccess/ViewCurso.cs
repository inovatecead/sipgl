using System;

namespace ufmt.sipgl.DataAccess;

public class ViewCurso
{
	public long cursoUID { get; set; }

	public int codigoCurso { get; set; }

	public int campusUID { get; set; }

	public string nomeCampus { get; set; }

	public long unidadeUID { get; set; }

	public string nomeUnidadeConcatenado { get; set; }

	public long CNPqGrandeAreaConhecimentoUID { get; set; }

	public string nomeCNPqGrandeAreaConhecimento { get; set; }

	public long CNPqAreaConhecimentoUID { get; set; }

	public string nomeCNPqAreaConhecimento { get; set; }

	public long CNPqSubAreaConhecimentoUID { get; set; }

	public string nomeCNPqSubAreaConhecimento { get; set; }

	public string nomeCurso { get; set; }

	public byte tipoModalidadeUID { get; set; }

	public string nomeTipoModalidade { get; set; }

	public short cargaHoraria { get; set; }

	public short numeroResolucaoConsepe { get; set; }

	public DateTime dataResolucaoConsepe { get; set; }

	public string numeroPortariaPropg { get; set; }

	public DateTime dataPortariaPropg { get; set; }

	public byte tipoStatusCursoUID { get; set; }

	public string nomeTipoStatusCurso { get; set; }

	public string descricaoCancelamento { get; set; }

	public DateTime dataHoraUltimaAtualizacao { get; set; }

	public byte tipoStatusHomologacaoUID { get; set; }

	public string nomeTipoStatusHomologacao { get; set; }

	public DateTime? dataHoraHomologado { get; set; }

	public bool excluido { get; set; }

	public DateTime? dataHoraExcluido { get; set; }

	public string codigoAcesso { get; set; }

	public long estruturaCurricularUID { get; set; }

	public DateTime? dataInicioEstruturaCurricular { get; set; }

	public DateTime? dataFimEstruturaCurricular { get; set; }

	public DateTime? dataInicioInscricao { get; set; }

	public DateTime? dataFimInscricao { get; set; }

	public int? numeroEspecialidades { get; set; }

	public long? coordenadorServidorUID { get; set; }

	public string nomeCoordenador { get; set; }

	public string emailCoordenador { get; set; }

	public long? ViceCoordenadorServidorUID { get; set; }

	public string nomeViceCoordenador { get; set; }

	public string emailViceCoordenador { get; set; }

	public bool? possuiCorrecaoPendente { get; set; }

	public bool? possuiCorrecaoAdministrador { get; set; }

	public bool? possuiCorrecaoCoordenador { get; set; }
}
