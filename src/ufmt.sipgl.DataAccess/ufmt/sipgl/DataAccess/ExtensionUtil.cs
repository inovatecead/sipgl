using System.Globalization;
using System.Text;

namespace ufmt.sipgl.DataAccess;

public static class ExtensionUtil
{
	public static string SemCaracteresEspeciais(this string s)
	{
		string text = s.Normalize(NormalizationForm.FormD);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in text)
		{
			if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
