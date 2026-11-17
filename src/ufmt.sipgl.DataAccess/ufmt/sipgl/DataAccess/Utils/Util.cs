using System.Linq;

namespace ufmt.sipgl.DataAccess.Utils;

public class Util
{
	public bool ValidarCPF(string cpf)
	{
		if (string.IsNullOrWhiteSpace(cpf))
		{
			return false;
		}
		char[] array = cpf.ToArray();
		if (array.Length != 11)
		{
			return false;
		}
		char[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (!char.IsDigit(array2[i]))
			{
				return false;
			}
		}
		if (array[0] == array[1] && array[1] == array[2] && array[2] == array[3] && array[3] == array[4] && array[4] == array[5] && array[5] == array[6] && array[6] == array[7] && array[7] == array[8] && array[8] == array[9] && array[9] == array[10])
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length - 2; j++)
		{
			int num3 = 10 - j;
			num += int.Parse(array[j].ToString()) * num3;
		}
		num2 = num * 10 % 11;
		if (num2 == 10)
		{
			num2 = 0;
		}
		if (num2 != int.Parse(array[9].ToString()))
		{
			return false;
		}
		num = 0;
		num2 = 0;
		for (int k = 0; k < array.Length - 1; k++)
		{
			int num3 = 11 - k;
			num += int.Parse(array[k].ToString()) * num3;
		}
		num2 = num * 10 % 11;
		if (num2 == 10)
		{
			num2 = 0;
		}
		if (num2 != int.Parse(array[10].ToString()))
		{
			return false;
		}
		return true;
	}

	public bool ValidarRG(string rg)
	{
		if (string.IsNullOrWhiteSpace(rg))
		{
			return false;
		}
		return true;
	}
}
