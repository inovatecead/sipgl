namespace ufmt.sipgl.DataAccess;

public class EspecialidadeDisciplina
{
	public long especialidadeDisciplinaUID { get; set; }

	public long especialidadeUID { get; set; }

	public long disciplinaUID { get; set; }

	public virtual Disciplina Disciplina { get; set; }

	public virtual Especialidade Especialidade { get; set; }
}
