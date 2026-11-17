using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using ufmt.sipgl.DataAccess;
using ufmt.sipgl.DataAccess.Enums;
using ufmt.sipgl.View.componentes.exception;

namespace ufmt.sipgl.View.componentes;

public class Email
{
	public ResultadoOperacao EnviarConfirmacaoEmail(string receiverAddress, string receiverDisplayName, string cpf, string chave)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			string text = WebConfigurationManager.AppSettings["linkConfirmacaoEmail"].ToString();
			text = text + "?&cpf=" + cpf + "&chave=" + chave;
			string assunto = "UFMT - Pós-Graduação - Confirmação de E-mail";
			string contentConfirmarEmail = GetContentConfirmarEmail(receiverDisplayName, text);
			ConfigurarEmail(receiverAddress, receiverDisplayName, assunto, contentConfirmarEmail);
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Cadastro efetuado com sucesso. Uma mensagem de confirmação foi enviada para o seu e-mail.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Cadastro efetuado com sucesso, porém houve um erro ao enviar email. Entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public ResultadoOperacao EnviarRecuperacaoSenha(string receiverAddress, string receiverDisplayName, string cpf, string chave)
	{
		ResultadoOperacao resultadoOperacao = new ResultadoOperacao();
		try
		{
			string text = WebConfigurationManager.AppSettings["linkRecuperacaoSenha"].ToString();
			text = text + "?&cpf=" + cpf + "&chave=" + chave;
			string assunto = "UFMT - Pós-Graduação - Recuperação de Senha";
			string contentRecuperarSenha = GetContentRecuperarSenha(receiverDisplayName, text);
			ConfigurarEmail(receiverAddress, receiverDisplayName, assunto, contentRecuperarSenha);
			resultadoOperacao.Erro = false;
			resultadoOperacao.TextMessage = "Enviamos para seu email um link para recuperação de senha.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Success;
		}
		catch (Exception)
		{
			resultadoOperacao.Erro = true;
			resultadoOperacao.TextMessage = "Erro ao enviar email. Tente novamente. Se o erro persistir entre em contato com o administrador do sistema.";
			resultadoOperacao.TypeMessageEnum = TypeMessageEnum.Error;
		}
		return resultadoOperacao;
	}

	public void ConfigurarEmail(string receiverAddress, string receiverDisplayName, string assunto, string content)
	{
		string host = WebConfigurationManager.AppSettings["smtpHost"].ToString();
		int port = int.Parse(WebConfigurationManager.AppSettings["smtpPort"].ToString());
		string userName = WebConfigurationManager.AppSettings["smtpUserLogin"].ToString();
		string password = WebConfigurationManager.AppSettings["smtpUserPassword"].ToString();
		string address = WebConfigurationManager.AppSettings["smtpUserAddress"].ToString();
		string text = WebConfigurationManager.AppSettings["smtpUserDisplayName"].ToString();
		MailMessage mailMessage = new MailMessage();
		if (!string.IsNullOrEmpty(text))
		{
			mailMessage.From = new MailAddress(address, text);
		}
		else
		{
			mailMessage.From = new MailAddress(address);
		}
		if (!string.IsNullOrEmpty(receiverDisplayName))
		{
			mailMessage.To.Add(new MailAddress(receiverAddress, receiverDisplayName));
		}
		else
		{
			mailMessage.To.Add(new MailAddress(receiverAddress));
		}
		mailMessage.IsBodyHtml = true;
		mailMessage.Body = content;
		mailMessage.Subject = assunto;
		SmtpClient smtpClient = new SmtpClient(host);
		smtpClient.Port = port;
		smtpClient.Credentials = new NetworkCredential(userName, password);
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

	public string GetContentConfirmarEmail(string receiverDisplayName, string linkConfirmacaoEmail)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<!DOCTYPE html>");
		stringBuilder.Append("<html style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("<head>");
		stringBuilder.Append("<meta name='viewport' content='width=device-width' />");
		stringBuilder.Append("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />");
		stringBuilder.Append("<title> SIPGL - Confirmação de E-mail </title>");
		stringBuilder.Append("<style> img {");
		stringBuilder.Append("max-width: 100%;");
		stringBuilder.Append("}");
		stringBuilder.Append("body {-webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100 % !important; height: 100 %; line-height: 1.6;");
		stringBuilder.Append("}");
		stringBuilder.Append("");
		stringBuilder.Append("@media only screen and(max-width: 640px) {");
		stringBuilder.Append("    h1 { font-weight: 600 !important; margin: 20px 0 5px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append("    h2 { font-weight: 600 !important; margin: 20px 0 5px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append("    h3 { font-weight: 600 !important; margin: 20px 0 5px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append("    h4 { font-weight: 600 !important; margin: 20px 0 5px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append("    h1 { font-size: 22px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append("    h2 { font-size: 18px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append("    h3 { font-size: 16px !important;");
		stringBuilder.Append("    }");
		stringBuilder.Append(".container { width: 100 % !important;");
		stringBuilder.Append("              }");
		stringBuilder.Append(".content { padding: 10px !important;");
		stringBuilder.Append("              }");
		stringBuilder.Append(".content-wrapper { padding: 10px !important;");
		stringBuilder.Append("              }");
		stringBuilder.Append(".invoice { width: 100 % !important;");
		stringBuilder.Append("              }");
		stringBuilder.Append("          }");
		stringBuilder.Append("</style >");
		stringBuilder.Append("</head>");
		stringBuilder.Append("<body style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; -webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6; margin: 0; padding: 0;'>");
		stringBuilder.Append("<table class='body-wrap' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; width: 100%; margin: 0; padding: 0;'>");
		stringBuilder.Append("<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("\t\t<td class='container' width='600' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto; padding: 0;' valign='top'>");
		stringBuilder.Append("\t\t\t<div class='content' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;'>");
		stringBuilder.Append("\t\t\t\t<table class='main' width='100%' cellpadding='0' cellspacing='0' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; border-radius: 3px; margin: 0; padding: 0; border: 1px solid #e9e9e9;' bgcolor='#fff'>");
		stringBuilder.Append("\t\t\t\t\t<tr style='padding: .75rem 1.25rem; margin-bottom: 0; background-color: #00000008; border-bottom: 1px solid' >");
		stringBuilder.Append("                        <td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding:20px;text-align: center; font-weight: bold;'>");
		stringBuilder.Append("                            Sistema de Gerencialmento de Pós-Graduação");
		stringBuilder.Append("                        </td>      ");
		stringBuilder.Append("                    </tr>");
		stringBuilder.Append("                    <tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("                        <td class='content-wrap' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 20px;' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t<table width='100%' cellpadding='0' cellspacing='0' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("                                <tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("                                    <td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;' valign='top'>");
		stringBuilder.Append("                                        Olá,");
		if (!string.IsNullOrWhiteSpace(receiverDisplayName))
		{
			stringBuilder.Append(" " + receiverDisplayName.ToUpper() + ".");
		}
		stringBuilder.Append("                                    </td>");
		stringBuilder.Append("                                </tr>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("                                    <td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t\tEsta verificação é necessária para finalizar seu cadastro.");
		stringBuilder.Append("                                    </td>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("                                    <td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t\tPor favor, confirme seu endereço de e-mail clicando no link abaixo.");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("                                    <td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px; text-align: center;'  valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t\t<a href='");
		stringBuilder.Append(linkConfirmacaoEmail);
		stringBuilder.Append("' class='btn-primary' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; color: #FFF; text-decoration: none; background-color: #348eda; line-height: 2; font-weight: bold; text-align: center; cursor: pointer; display: inline-block; border-radius: 5px; margin: 0; padding: 0; border-color: #348eda; border-style: solid; border-width: 10px 20px;'>Confirmar endereço de e-mail</a>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</tr>");
		stringBuilder.Append("                            </table>");
		stringBuilder.Append("                        </td>");
		stringBuilder.Append("                    </tr>");
		stringBuilder.Append("                </table>");
		stringBuilder.Append("                <div class='footer' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; width: 100%; clear: both; color: #888; margin: 0; padding: 20px;'>");
		stringBuilder.Append("\t\t\t\t\t<table width='100%' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("                            <td class='aligncenter content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 12px; margin: 0; padding: 0 0 20px;' align='center' valign='top'><a href='http://ufmt.br/' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 12px; color: #888; text-decoration: underline; margin: 0; padding: 0;'>Universidade Federal do Mato Grosso</a>.</td>");
		stringBuilder.Append("\t\t\t\t\t\t</tr>");
		stringBuilder.Append("                        <tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;' >");
		stringBuilder.Append("                            <td class='aligncenter content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 12px; margin: 0; padding: 0 0 20px;' align='center' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<span>Copyright © 2018 - Secretaria de Tecnologia Educacional - UFMT");
		stringBuilder.Append("                                     <br />");
		stringBuilder.Append("                                     Avenida Fernando Corrêa, Nº 2367 - Boa Esperança, Cuiabá-MT 78060-900");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t <br />");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t Fone: (65) 3615-6242");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t <br />");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t Contato:&nbsp<a href='mailto: apoio@ufmt.br'>apoio@ufmt.br</a>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</span>");
		stringBuilder.Append("\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t</table>");
		stringBuilder.Append("\t\t\t\t</div>");
		stringBuilder.Append("            </div>");
		stringBuilder.Append("\t\t</td>");
		stringBuilder.Append("\t</tr>");
		stringBuilder.Append("</table>");
		stringBuilder.Append("</body>");
		stringBuilder.Append("</html>");
		return stringBuilder.ToString();
	}

	public string GetContentRecuperarSenha(string receiverDisplayName, string linkRecuperacaoSenha)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<!DOCTYPE html>");
		stringBuilder.Append("<html xmlns='http://www.w3.org/1999/xhtml' xmlns='http://www.w3.org/1999/xhtml' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("<head>");
		stringBuilder.Append("<meta name='viewport' content='width=device-width' />");
		stringBuilder.Append("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />");
		stringBuilder.Append("<title>Recuperação de senha</title>");
		stringBuilder.Append("<style>");
		stringBuilder.Append("img {max-width: 100%;}");
		stringBuilder.Append("body {-webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6;}");
		stringBuilder.Append("@media only screen and (max-width: 640px) {");
		stringBuilder.Append("  h1 {font-weight: 600 !important; margin: 20px 0 5px !important;}");
		stringBuilder.Append("  h2 {font-weight: 600 !important; margin: 20px 0 5px !important;}");
		stringBuilder.Append("  h3 {font-weight: 600 !important; margin: 20px 0 5px !important;}");
		stringBuilder.Append("  h4 {font-weight: 600 !important; margin: 20px 0 5px !important;}");
		stringBuilder.Append("  h1 {font-size: 22px !important;}");
		stringBuilder.Append("  h2 {font-size: 18px !important;}");
		stringBuilder.Append("  h3 {font-size: 16px !important;}");
		stringBuilder.Append("  .container {width: 100% !important;}");
		stringBuilder.Append("  .content {    padding: 10px !important;}");
		stringBuilder.Append("  .content-wrapper {padding: 10px !important;}");
		stringBuilder.Append("  .invoice {width: 100% !important;}");
		stringBuilder.Append("}");
		stringBuilder.Append("</style>");
		stringBuilder.Append("</head>");
		stringBuilder.Append("<body style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 19px; -webkit-font-smoothing: antialiased; -webkit-text-size-adjust: none; width: 100% !important; height: 100%; line-height: 1.6; margin: 0; padding: 0;'>");
		stringBuilder.Append("<table class='body-wrap' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; width: 100%; margin: 0; padding: 0;'>");
		stringBuilder.Append("  <tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t<td class='container' width='600' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto; padding: 0;' valign='top'>");
		stringBuilder.Append("\t\t\t<div class='content' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;'>");
		stringBuilder.Append("\t\t\t\t<table class='main' width='100%' cellpadding='0' cellspacing='0' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; border-radius: 3px; margin: 0; padding: 0; border: 1px solid #e9e9e9;' bgcolor='#fff'>");
		stringBuilder.Append("\t\t\t\t\t<tr style='padding: .75rem 1.25rem; margin-bottom: 0; background-color: #00000008; border-bottom: 1px solid'>");
		stringBuilder.Append("\t\t\t          \t<td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding:20px;text-align: center; font-weight: bold;'>");
		stringBuilder.Append("\t\t\t            \tSistema de Gerencialmento de Pós-Graduação");
		stringBuilder.Append("\t\t\t            </td>      ");
		stringBuilder.Append("\t\t            </tr>");
		stringBuilder.Append("          \t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("            \t\t\t<td class='content-wrap' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 20px;' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t<table width='100%' cellpadding='0' cellspacing='0' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("                \t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("                  \t\t\t\t\t<td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;' valign='top'>");
		stringBuilder.Append("                    \t\t\t\t\tOlá,");
		if (!string.IsNullOrWhiteSpace(receiverDisplayName))
		{
			stringBuilder.Append(" " + receiverDisplayName.ToUpper() + ".");
		}
		stringBuilder.Append("                  \t\t\t\t\t</td>");
		stringBuilder.Append("                \t\t\t\t</tr>");
		stringBuilder.Append("                \t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t<td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px;' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t\tVocê solicitou recuperção de senha para a sua conta do Sistema de Pós-Graduação da Universidade Federal de Mato Grosso, e pode fazer isto clicando no link abaixo.");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t<td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0 0 20px; text-align: center;'  valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t\t<a href='");
		stringBuilder.Append(linkRecuperacaoSenha + "'");
		stringBuilder.Append("class='btn-primary' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; color: #FFF; text-decoration: none; background-color: #348eda; line-height: 2; font-weight: bold; text-align: center; cursor: pointer; display: inline-block; border-radius: 5px; margin: 0; padding: 0; border-color: #348eda; border-style: solid; border-width: 10px 20px;'>Recuperar Senha</a>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t<td class='content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; margin: 0; padding: 0 0 20px; text-align: center;'  valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t\t<span style='font-size: 11px;'>Se você não solicitou recuperção de senha, por favor ignore este e-mail. Sua senha não será alterada até que você acesse o link acima e crie uma nova.</span>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t\t\t</table>");
		stringBuilder.Append("\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t</table>");
		stringBuilder.Append("\t\t\t\t<div class='footer' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; width: 100%; clear: both; color: #888; margin: 0; padding: 20px;'>");
		stringBuilder.Append("\t\t\t\t\t<table width='100%' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t\t<td class='aligncenter content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 12px; margin: 0; padding: 0 0 20px;' align='center' valign='top'><a href='http://ufmt.br/' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 12px; color: #888; text-decoration: underline; margin: 0; padding: 0;'>Universidade Federal do Mato Grosso</a>.</td>");
		stringBuilder.Append("\t\t\t\t\t\t</tr>");
		stringBuilder.Append("            \t\t\t<tr style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 14px; margin: 0; padding: 0;'>");
		stringBuilder.Append("\t\t\t\t\t\t\t<td class='aligncenter content-block' style='font-family: Helvetica Neue, Helvetica, Helvetica, Arial; box-sizing: border-box; font-size: 12px; margin: 0; padding: 0 0 20px;' align='center' valign='top'>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t<span>Copyright © 2020 - Secretaria de Tecnologia da Informação - STI - UFMT");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t <br />");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t Avenida Fernando Corrêa, Nº 2367 - Boa Esperança, Cuiabá-MT 78060-900");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t <br />");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t Fone: (65) 3615-6283");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t <br />");
		stringBuilder.Append("\t\t\t\t\t\t\t\t\t Contato:&nbsp<a href='mailto: apoio@ufmt.br'>apoio@ufmt.br</a>");
		stringBuilder.Append("\t\t\t\t\t\t\t\t</span>");
		stringBuilder.Append("\t\t\t\t\t\t\t</td>");
		stringBuilder.Append("\t\t\t\t\t\t</tr>");
		stringBuilder.Append("\t\t\t\t\t</table>");
		stringBuilder.Append("\t\t\t\t</div></div>");
		stringBuilder.Append("\t\t</td>");
		stringBuilder.Append("\t</tr>");
		stringBuilder.Append("</table>");
		stringBuilder.Append("</body>");
		stringBuilder.Append("</html>");
		return stringBuilder.ToString();
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
