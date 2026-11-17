using System.ComponentModel;

namespace ufmt.sipgl.DataAccess;

public enum EnumRegimeTrabalho
{
	[Description("20 HORAS SEMANAIS")]
	_20_HORAS_SEMANAIS = 1,
	[Description("24 HORAS SEMANAIS")]
	_24_HORAS_SEMANAIS,
	[Description("25 HORAS SEMANAIS")]
	_25_HORAS_SEMANAIS,
	[Description("30 HORAS SEMANAIS")]
	_30_HORAS_SEMANAIS,
	[Description("40 HORAS SEMANAIS")]
	_40_HORAS_SEMANAIS,
	[Description("DEDICAÇÃO EXCLUSIVA")]
	DEDICACAO_EXCLUSIVA,
	[Description("NÃO IDENTIFICADA")]
	NAO_IDENTIFICADA
}
