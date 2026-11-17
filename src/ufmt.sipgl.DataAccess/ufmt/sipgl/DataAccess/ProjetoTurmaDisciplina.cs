using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoTurmaDisciplina
{
	public long projetoTurmaDisciplinaUID { get; set; }

	public long projetoTurmaUID { get; set; }

	public long projetoDisciplinaUID { get; set; }

	public long projetoCorpoDocenteUID { get; set; }

	public int? cargaHorariaSemanal { get; set; }

	public long? projetoCorpoDocenteSecundarioUID { get; set; }

	public int? possuiRemuneracaoDocentePrincipal { get; set; }

	public int? possuiRemuneracaoDocenteSecundario { get; set; }

	public int? tipoRemuneracaoDocentePrincipal { get; set; }

	public int? tipoRemuneracaoDocenteSecundario { get; set; }

	public string descricaoOutrosTiposRemuneracaoPrincipal { get; set; }

	public string descricaoOutrosTiposRemuneracaoSecundario { get; set; }

	public DateTime? dataInicio { get; set; }

	public DateTime? dataTermino { get; set; }

	public virtual ICollection<ProjetoHistorico> ProjetoHistorico { get; set; }

	public virtual ICollection<ProjetoHorario> ProjetoHorario { get; set; }

	public virtual ProjetoDisciplina ProjetoDisciplina { get; set; }

	public virtual ProjetoCorpoDocente ProjetoCorpoDocente { get; set; }

	public virtual ProjetoCorpoDocente ProjetoCorpoDocente1 { get; set; }

	public virtual ProjetoTurma ProjetoTurma { get; set; }

	public ProjetoTurmaDisciplina()
	{
		ProjetoHistorico = new HashSet<ProjetoHistorico>();
		ProjetoHorario = new HashSet<ProjetoHorario>();
	}
}
