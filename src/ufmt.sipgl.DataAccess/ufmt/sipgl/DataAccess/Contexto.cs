namespace ufmt.sipgl.DataAccess;

public static class Contexto
{
	private static EntidadesIdbufmt contexto;

	public static EntidadesIdbufmt GetContextInstance()
	{
		contexto = new EntidadesIdbufmt();
		return contexto;
	}
}
