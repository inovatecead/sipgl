using System.ComponentModel;

namespace ufmt.sipgl.DataAccess;

public enum EnumTipoRemuneracao
{
	[Description("Bolsa Lei 8958/94")]
	Bolsa_Lei_8958_94 = 1,
	[Description("Bolsa SisUAB")]
	Bolsa_SisUAB,
	[Description("Outros")]
	Outros
}
