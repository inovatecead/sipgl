using ufmt.utils.extension;
using System.Text;

namespace ufmt.sig.entity;

public static class ModalidadeCursoEnumExtension
{
	public static string Descricao(this ModalidadeCursoEnum modalidadeCursoEnum)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if ((ModalidadeCursoEnum.LICENCIATURA_PLENA & modalidadeCursoEnum) == ModalidadeCursoEnum.LICENCIATURA_PLENA)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "LICENCIATURA PLENA");
		}
		if ((ModalidadeCursoEnum.BACHARELADO & modalidadeCursoEnum) == ModalidadeCursoEnum.BACHARELADO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "BACHARELADO");
		}
		if ((ModalidadeCursoEnum.ESPECIFICO_REFERENTE_PROFISSAO & modalidadeCursoEnum) == ModalidadeCursoEnum.ESPECIFICO_REFERENTE_PROFISSAO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "ESPECÍFICO REFERENTE À PROFISSÃO");
		}
		if ((ModalidadeCursoEnum.ESPECIALIZACAO & modalidadeCursoEnum) == ModalidadeCursoEnum.ESPECIALIZACAO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "ESPECIALIZAÇÃO");
		}
		if ((ModalidadeCursoEnum.MESTRADO & modalidadeCursoEnum) == ModalidadeCursoEnum.MESTRADO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "MESTRADO");
		}
		if ((ModalidadeCursoEnum.DOUTORADO & modalidadeCursoEnum) == ModalidadeCursoEnum.DOUTORADO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "DOUTORADO");
		}
		if ((ModalidadeCursoEnum.DOUTORADO & modalidadeCursoEnum) == ModalidadeCursoEnum.MESTRADO_PROFISSIONAL)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "MESTRADO PROFISSIONAL");
		}
		return stringBuilder.ToString();
	}
}
