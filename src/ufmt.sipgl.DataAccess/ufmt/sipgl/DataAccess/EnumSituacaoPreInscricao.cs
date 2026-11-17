using System.ComponentModel;

namespace ufmt.sipgl.DataAccess;

public enum EnumSituacaoPreInscricao
{
	[Description("Pendente")]
	PENDENTE = 1,
	[Description("Aprovado")]
	APROVADO,
	[Description("Cancelado")]
	CANCELADO
}
