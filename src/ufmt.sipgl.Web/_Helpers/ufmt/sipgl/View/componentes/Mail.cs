using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using ufmt.sipgl.View.componentes.exception;

namespace ufmt.sipgl.View.componentes;

public class Mail
{
	public static void SendMail(string smtpHost, int? smtpPort, string smtpUserLogin, string smtpUserAddress, string smtpUserDisplayName, string smtpUserPassword, string receiverAddress, string receiverDisplayName, string subject, string content, bool html, string anexo)
	{
		if (string.IsNullOrEmpty(smtpHost))
		{
			throw new ArgumentNullException("smtpHost", "O endereço IP ou nome do servidor SMTP não foi informado.");
		}
		if (string.IsNullOrEmpty(smtpUserAddress))
		{
			throw new ArgumentNullException("smtpUserAddress", "O e-mail do usuário SMTP não foi informado.");
		}
		if (string.IsNullOrEmpty(smtpUserPassword))
		{
			throw new ArgumentNullException("smtpUserPassword", "A senha do usuário SMTP não foi informada.");
		}
		if (string.IsNullOrEmpty(receiverAddress))
		{
			throw new ArgumentNullException("receiverAddress", "O e-mail do destinatário não foi informado.");
		}
		if (string.IsNullOrEmpty(subject))
		{
			throw new ArgumentNullException("subject", "O assunto do e-mail não foi informado.");
		}
		if (string.IsNullOrEmpty(content))
		{
			throw new ArgumentNullException("content", "O conteúdo do e-mail não foi informado.");
		}
		MailMessage mailMessage = new MailMessage();
		if (!string.IsNullOrEmpty(smtpUserDisplayName))
		{
			mailMessage.From = new MailAddress(smtpUserAddress, smtpUserDisplayName);
		}
		else
		{
			mailMessage.From = new MailAddress(smtpUserAddress);
		}
		if (!string.IsNullOrEmpty(receiverDisplayName))
		{
			mailMessage.To.Add(new MailAddress(receiverAddress, receiverDisplayName));
		}
		else
		{
			mailMessage.To.Add(new MailAddress(receiverAddress));
		}
		mailMessage.IsBodyHtml = html;
		mailMessage.Body = content;
		mailMessage.Subject = subject;
		_ = HttpContext.Current.Request.PhysicalApplicationPath;
		SmtpClient smtpClient = new SmtpClient(smtpHost);
		if (smtpPort.HasValue)
		{
			smtpClient.Port = smtpPort.Value;
		}
		smtpClient.Credentials = new NetworkCredential(smtpUserLogin, smtpUserPassword);
		try
		{
			smtpClient.Send(mailMessage);
		}
		catch (SmtpFailedRecipientException ex)
		{
			SmtpStatusCode statusCode = ex.StatusCode;
			switch (statusCode)
			{
			case SmtpStatusCode.MailboxBusy:
				throw new EmailException(statusCode.ToString());
			case SmtpStatusCode.MailboxUnavailable:
				throw new EmailException(statusCode.ToString());
			case SmtpStatusCode.TransactionFailed:
				throw new EmailException(statusCode.ToString());
			}
		}
		catch (SmtpException)
		{
			throw new EmailException("SMTPFailed");
		}
		catch (Exception)
		{
			throw new EmailException("InternalError");
		}
	}

	public static bool EmailValido(string str)
	{
		if (!string.IsNullOrEmpty(str))
		{
			return new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*").IsMatch(str);
		}
		return false;
	}
}
