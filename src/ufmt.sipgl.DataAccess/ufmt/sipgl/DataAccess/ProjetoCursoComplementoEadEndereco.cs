namespace ufmt.sipgl.DataAccess;

public class ProjetoCursoComplementoEadEndereco
{
	public long projetoCursoComplementoEadEnderecoUID { get; set; }

	public long projetoCursoComplementoEadUID { get; set; }

	public long enderecoUID { get; set; }

	public byte tipoEnderecoEadUID { get; set; }

	public virtual ProjetoCursoComplementoEad ProjetoCursoComplementoEad { get; set; }

	public virtual TipoEnderecoEad TipoEnderecoEad { get; set; }
}
