using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoDisciplina
{
	public long projetoDisciplinaUID { get; set; }

	public string nome { get; set; }

	public short cargaHoraria { get; set; }

	public string ementa { get; set; }

	public string bibliografia { get; set; }

	public long? projetoCursoUID { get; set; }

	public int? tipoDisciplina { get; set; }

	public virtual ICollection<ProjetoCorpoDocenteMaterialDidaticoEad> ProjetoCorpoDocenteMaterialDidaticoEad { get; set; }

	public virtual ICollection<ProjetoEncontroPresencial> ProjetoEncontroPresencial { get; set; }

	public virtual ICollection<ProjetoTurmaDisciplina> ProjetoTurmaDisciplina { get; set; }

	public virtual ICollection<ProjetoNota> ProjetoNota { get; set; }

	public virtual ProjetoCurso ProjetoCurso { get; set; }

	public ProjetoDisciplina()
	{
		ProjetoCorpoDocenteMaterialDidaticoEad = new HashSet<ProjetoCorpoDocenteMaterialDidaticoEad>();
		ProjetoEncontroPresencial = new HashSet<ProjetoEncontroPresencial>();
		ProjetoTurmaDisciplina = new HashSet<ProjetoTurmaDisciplina>();
		ProjetoNota = new HashSet<ProjetoNota>();
	}
}
