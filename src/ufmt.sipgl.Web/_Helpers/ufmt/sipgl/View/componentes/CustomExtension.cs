using System;
using System.ComponentModel;

namespace ufmt.sipgl.View.componentes;

public static class CustomExtension
{
	public static string FormatarCPF(this string cpf)
	{
		if (cpf.Length != 11)
		{
			return cpf;
		}
		cpf = cpf.Insert(9, "-");
		cpf = cpf.Insert(6, ".");
		cpf = cpf.Insert(3, ".");
		return cpf;
	}

	public static string RemoverMascaraCPF(this string cpf)
	{
		cpf = cpf.Replace(".", "");
		cpf = cpf.Replace("-", "");
		return cpf;
	}

	public static string ObterDescricao(this Enum e)
	{
		Type type = e.GetType();
		DescriptionAttribute[] array = new DescriptionAttribute[0];
		if (Enum.IsDefined(type, e))
		{
			array = (DescriptionAttribute[])type.GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
		}
		if (array.Length == 0)
		{
			return e.ToString();
		}
		return array[0].Description.ToUpper() ?? "Nulo";
	}

	public static string FormatarShortDate(this DateTime data)
	{
		return data.ToShortDateString();
	}
}
