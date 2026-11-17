using System;

namespace ufmt.sipgl.DataAccess;

public class ViewRelatorioGeralCursos
{
	public string Campus { get; set; }

	public string Nome_do_Curso { get; set; }

	public int Código_do_Curso { get; set; }

	public short Número_da_Resolução_CONSEPE { get; set; }

	public string Data_da_Resolução_CONSEPE { get; set; }

	public DateTime? Data_de_Início { get; set; }

	public DateTime? Data_de_Fim { get; set; }
}
