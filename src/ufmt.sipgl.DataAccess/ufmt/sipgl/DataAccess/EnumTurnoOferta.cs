using System.ComponentModel;

namespace ufmt.sipgl.DataAccess;

public enum EnumTurnoOferta
{
	[Description("Integral")]
	Integral = 1,
	[Description("Diurno")]
	Diurno,
	[Description("Matutino")]
	Matutino,
	[Description("Vespertino")]
	Vespertino,
	[Description("Noturno")]
	Noturno,
	[Description("Ensino a Distância")]
	EAD
}
