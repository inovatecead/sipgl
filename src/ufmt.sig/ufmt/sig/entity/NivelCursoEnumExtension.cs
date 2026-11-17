using System;

namespace ufmt.sig.entity;

public static class NivelCursoEnumExtension
{
	public static string Descricao(this NivelCursoEnum nivelCursoEnum)
	{
		if (NivelCursoEnum.GRADUACAO.Equals(nivelCursoEnum))
		{
			return "GRADUAÇÃO";
		}
		if (NivelCursoEnum.POS_GRADUACAO.Equals(nivelCursoEnum))
		{
			return "PÓS-GRADUAÇÃO";
		}
		throw new NotSupportedException("Nível de curso desconhecido.");
	}
}
