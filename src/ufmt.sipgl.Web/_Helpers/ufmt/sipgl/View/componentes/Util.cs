using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace ufmt.sipgl.View.componentes;

public class Util
{
	public static string enviaEmailAutomatico(string indentificacaoCurso, string descricaoAlteracao, string[] receiverAddresses, string assunto)
	{
		string text = string.Empty;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<hr />");
		stringBuilder.Append("<b>");
		stringBuilder.Append(indentificacaoCurso);
		stringBuilder.Append("</b>");
		stringBuilder.Append("<hr />");
		stringBuilder.Append("<br />");
		stringBuilder.Append(descricaoAlteracao);
		stringBuilder.Append("<br />");
		stringBuilder.Append("<hr />");
		stringBuilder.Append("Atenção: Esta é uma mensagem automática, não é necessário respondê-la. Você recebeu esta mensagem por estar cadastrado em nosso sistema SIPGL.");
		stringBuilder.Append("<hr />");
		foreach (string text2 in receiverAddresses)
		{
			try
			{
				Mail.SendMail(WebConfigurationManager.AppSettings["smtpHost"].ToString(), int.Parse(WebConfigurationManager.AppSettings["smtpPort"].ToString()), WebConfigurationManager.AppSettings["smtpUserLogin"].ToString(), WebConfigurationManager.AppSettings["smtpUserAddress"].ToString(), WebConfigurationManager.AppSettings["smtpUserDisplayName"].ToString(), WebConfigurationManager.AppSettings["smtpUserPassword"].ToString(), text2, text2, assunto, stringBuilder.ToString(), html: true, null);
			}
			catch
			{
				text = text + "Não foi possível enviar a mensagem para " + text2 + ".  Clique em OK para continuar...";
			}
		}
		return text;
	}

	public static string getMD5Hash(string input)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString().ToLower();
	}
}
