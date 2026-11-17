using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ufmt.sipgl.DataAccess;

public class EnumService
{
	public static string EnumDescription(Enum e)
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

	public static IList EnumList(Type t)
	{
		ArrayList arrayList = new ArrayList();
		if (t != null)
		{
			foreach (Enum value in Enum.GetValues(t))
			{
				arrayList.Add(new KeyValuePair<int, string>(Convert.ToInt32(value), EnumDescription(value)));
			}
		}
		return arrayList;
	}
}
