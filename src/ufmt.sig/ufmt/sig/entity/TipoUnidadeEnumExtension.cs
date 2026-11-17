using ufmt.utils.extension;
using System.Text;

namespace ufmt.sig.entity;

public static class TipoUnidadeEnumExtension
{
	public static string Descricao(this TipoUnidadeEnum tipoUnidadeEnum)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if ((TipoUnidadeEnum.INSTITUTO_ENSINO & tipoUnidadeEnum) == TipoUnidadeEnum.INSTITUTO_ENSINO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "INSTITUTO DE ENSINO");
		}
		if ((TipoUnidadeEnum.DIRETORIA_INSTITUTO_ENSINO & tipoUnidadeEnum) == TipoUnidadeEnum.DIRETORIA_INSTITUTO_ENSINO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "DIRETORIA DO INSTITUTO DE ENSINO");
		}
		if ((TipoUnidadeEnum.DEPARTAMENTO_ENSINO & tipoUnidadeEnum) == TipoUnidadeEnum.DEPARTAMENTO_ENSINO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "DEPARTAMENTO DE ENSINO");
		}
		if ((TipoUnidadeEnum.COORDENACAO_ENSINO_GRADUACAO & tipoUnidadeEnum) == TipoUnidadeEnum.COORDENACAO_ENSINO_GRADUACAO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "COORDENAÇÃO DE ENSINO DE GRADUAÇÃO");
		}
		if ((TipoUnidadeEnum.COORDENACAO_ENSINO_POS_GRADUACAO & tipoUnidadeEnum) == TipoUnidadeEnum.COORDENACAO_ENSINO_POS_GRADUACAO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "COORDENAÇÃO DE ENSINO DE PÓS-GRADUAÇÃO");
		}
		if ((TipoUnidadeEnum.UNIDADE_LOTACIONAL_DOCENTE & tipoUnidadeEnum) == TipoUnidadeEnum.UNIDADE_LOTACIONAL_DOCENTE)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "UNIDADE DE LOTAÇÃO DE DOCENTES");
		}
		if ((TipoUnidadeEnum.DIRETORIA_ADJUNTA & tipoUnidadeEnum) == TipoUnidadeEnum.DIRETORIA_ADJUNTA)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "DIRETORIA ADJUNTA");
		}
		if ((TipoUnidadeEnum.SUPERVISÃO_ENSINO_GRADUAÇÃO & tipoUnidadeEnum) == TipoUnidadeEnum.SUPERVISÃO_ENSINO_GRADUAÇÃO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "SUPERVISÃO DE ENSINO DE GRADUAÇÃO");
		}
		if ((TipoUnidadeEnum.INFORMAL & tipoUnidadeEnum) == TipoUnidadeEnum.INFORMAL)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "ADJUNTA");
		}
		return stringBuilder.ToString();
	}

	public static TipoUnidadeEnum Identificador(string descricaoEnum)
	{
		if (descricaoEnum.Equals("INSTITUTO DE ENSINO"))
		{
			return TipoUnidadeEnum.INSTITUTO_ENSINO;
		}
		if (descricaoEnum.Equals("DEPARTAMENTO DE ENSINO"))
		{
			return TipoUnidadeEnum.DEPARTAMENTO_ENSINO;
		}
		if (descricaoEnum.Equals("COORDENAÇÃO DE ENSINO DE GRADUAÇÃO"))
		{
			return TipoUnidadeEnum.COORDENACAO_ENSINO_GRADUACAO;
		}
		if (descricaoEnum.Equals("COORDENAÇÃO DE ENSINO DE PÓS-GRADUAÇÃO"))
		{
			return TipoUnidadeEnum.COORDENACAO_ENSINO_POS_GRADUACAO;
		}
		if (descricaoEnum.Equals("UNIDADE DE LOTAÇÃO DE DOCENTES"))
		{
			return TipoUnidadeEnum.UNIDADE_LOTACIONAL_DOCENTE;
		}
		if (descricaoEnum.Equals("DIRETORIA ADJUNTA"))
		{
			return TipoUnidadeEnum.DIRETORIA_ADJUNTA;
		}
		if (descricaoEnum.Equals("DIRETORIA De INSTITUTO DE ENSINO"))
		{
			return TipoUnidadeEnum.DIRETORIA_INSTITUTO_ENSINO;
		}
		if (descricaoEnum.Equals("SUPERVISÃO DE ENSINO DE GRADUAÇÃO"))
		{
			return TipoUnidadeEnum.SUPERVISÃO_ENSINO_GRADUAÇÃO;
		}
		return TipoUnidadeEnum.INFORMAL;
	}

	public static bool Match(this TipoUnidadeEnum thisUnidadeEnum, TipoUnidadeEnum otherUnidadeEnum)
	{
		return (thisUnidadeEnum & otherUnidadeEnum) != 0;
	}
}
