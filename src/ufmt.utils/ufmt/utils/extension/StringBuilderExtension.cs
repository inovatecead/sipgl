using System.Text;

namespace ufmt.utils.extension;

// RECONSTRUÍDO (não recuperado do binário original): esta classe pertencia ao
// assembly externo "ufmt.utils", que não estava presente em nenhum backup
// disponível. A implementação abaixo foi inferida a partir dos pontos de uso
// (CategoriaEncargoEnumExtension, ModalidadeCursoEnumExtension,
// TipoUnidadeEnumExtension): um helper trivial de concatenação com separador
// ", ". Revise antes de considerar definitivo.
public static class StringBuilderExtension
{
    public static StringBuilder AppendCommaSeparatedString(this StringBuilder stringBuilder, string value)
    {
        if (stringBuilder.Length > 0)
            stringBuilder.Append(", ");

        stringBuilder.Append(value);
        return stringBuilder;
    }
}
