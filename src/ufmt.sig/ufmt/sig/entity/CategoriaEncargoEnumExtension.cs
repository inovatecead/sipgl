using ufmt.utils.extension;
using System.Text;

namespace ufmt.sig.entity;

public static class CategoriaEncargoEnumExtension
{
	public static string Descricao(this CategoriaEncargoEnum categoriaEncargoEnum)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if ((CategoriaEncargoEnum.ATIVIDADE_ADMINISTRATIVA & categoriaEncargoEnum) == CategoriaEncargoEnum.ATIVIDADE_ADMINISTRATIVA)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "ADMINISTRAÇÃO");
		}
		if ((CategoriaEncargoEnum.PESQUISA & categoriaEncargoEnum) == CategoriaEncargoEnum.PESQUISA)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "PESQUISA");
		}
		if ((CategoriaEncargoEnum.EXTENSAO & categoriaEncargoEnum) == CategoriaEncargoEnum.EXTENSAO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "EXTENSÃO");
		}
		if ((CategoriaEncargoEnum.ORIENTACAO & categoriaEncargoEnum) == CategoriaEncargoEnum.ORIENTACAO)
		{
			StringBuilderExtension.AppendCommaSeparatedString(stringBuilder, "ORIENTAÇÃO");
		}
		return stringBuilder.ToString();
	}
}
