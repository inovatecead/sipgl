using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoComplementoEad
{
	public long projetoCursoComplementoEadUID { get; set; }

	public long projetoCursoUID { get; set; }

	public string descricaoMaterialDidaticoTextualMultimidia { get; set; }

	public string descricaoAmbienteVirtualAprendizagem { get; set; }

	public DateTime dataInicioInscricao { get; set; }

	public DateTime dataFimInscricao { get; set; }

	public DateTime dataInicioSelecao { get; set; }

	public DateTime dataFimSelecao { get; set; }

	public DateTime dataInicioMatricula { get; set; }

	public DateTime dataFimMatricula { get; set; }

	public DateTime dataPrevisaoInicioAulas { get; set; }

	public string criteriosSelecao { get; set; }

	public string criteriosComprovacaoCarenciaFinanceira { get; set; }

	public string descricaoSelecaoCandidatos { get; set; }

	public string procedimentoRecursoAdm { get; set; }

	public string procedimentoDivulgacaoResultadoFinal { get; set; }

	public string orientacoesProcedimentoMatricula { get; set; }

	public string procedimentoRealizacaoSegundaChamada { get; set; }

	public virtual ICollection<ProjetoCursoComplementoEadEndereco> ProjetoCursoComplementoEadEndereco { get; set; }

	public virtual ICollection<ProjetoCursoComplementoEadVagas> ProjetoCursoComplementoEadVagas { get; set; }

	public virtual ICollection<ProjetoCorpoDocenteMaterialDidaticoEad> ProjetoCorpoDocenteMaterialDidaticoEad { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }

	public ProjetoCursoComplementoEad()
	{
		ProjetoCursoComplementoEadEndereco = new HashSet<ProjetoCursoComplementoEadEndereco>();
		ProjetoCursoComplementoEadVagas = new HashSet<ProjetoCursoComplementoEadVagas>();
		ProjetoCorpoDocenteMaterialDidaticoEad = new HashSet<ProjetoCorpoDocenteMaterialDidaticoEad>();
	}
}
