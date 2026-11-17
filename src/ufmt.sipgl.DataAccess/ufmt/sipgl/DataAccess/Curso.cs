using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Curso
{
	public long cursoUID { get; set; }

	public int codigoCurso { get; set; }

	public long unidadeUID { get; set; }

	public long CNPqSubAreaConhecimentoUID { get; set; }

	public string nome { get; set; }

	public byte tipoModalidadeUID { get; set; }

	public short cargaHoraria { get; set; }

	public short numeroResolucaoConsepe { get; set; }

	public DateTime dataResolucaoConsepe { get; set; }

	public string numeroPortariaPropg { get; set; }

	public DateTime dataPortariaPropg { get; set; }

	public byte tipoStatusCursoUID { get; set; }

	public string descricaoCancelamento { get; set; }

	public DateTime? dataHoraCancelado { get; set; }

	public DateTime dataHoraCadastro { get; set; }

	public DateTime dataHoraUltimaAtualizacao { get; set; }

	public byte tipoStatusHomologacaoUID { get; set; }

	public DateTime? dataHoraHomologado { get; set; }

	public bool excluido { get; set; }

	public DateTime? dataHoraExcluido { get; set; }

	public string codigoAcesso { get; set; }

	public virtual ICollection<Coordenador> Coordenador { get; set; }

	public virtual ICollection<CorrecaoCurso> CorrecaoCurso { get; set; }

	public virtual TipoStatusCurso TipoStatusCurso { get; set; }

	public virtual TipoStatusHomologacao TipoStatusHomologacao { get; set; }

	public virtual ICollection<EnderecoFuncionamentoCurso> EnderecoFuncionamentoCurso { get; set; }

	public virtual ICollection<EstruturaCurricular> EstruturaCurricular { get; set; }

	public virtual TipoModalidade TipoModalidade { get; set; }

	public virtual CNPqSubAreaConhecimento CNPqSubAreaConhecimento { get; set; }

	public Curso()
	{
		Coordenador = new HashSet<Coordenador>();
		CorrecaoCurso = new HashSet<CorrecaoCurso>();
		EnderecoFuncionamentoCurso = new HashSet<EnderecoFuncionamentoCurso>();
		EstruturaCurricular = new HashSet<EstruturaCurricular>();
	}
}
