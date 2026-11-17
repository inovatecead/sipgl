using System;

namespace ufmt.utils.mail;

// NÃO RECUPERADO: esta classe pertencia ao assembly externo "ufmt.utils",
// ausente de todos os backups disponíveis. A assinatura abaixo foi inferida
// apenas pelo único ponto de chamada conhecido (AutenticacaoBO.SendMail), mas
// a implementação real (conexão SMTP, autenticação, tratamento de erro,
// logging) é desconhecida e NÃO foi reconstituída — não invente esse
// comportamento sem confirmar com quem tiver acesso ao assembly original ou
// a um backup que o contenha.
public static class Mail
{
    public static void SendMail(
        string smtpHost,
        int? smtpPort,
        string fromEmail,
        string fromDisplayName,
        string password,
        string toEmail,
        string toDisplayName,
        string subject,
        string body,
        bool isBodyHtml)
    {
        throw new NotImplementedException(
            "ufmt.utils.mail.Mail.SendMail não foi recuperado: o assembly original ufmt.utils não está " +
            "disponível em nenhum backup. Implemente de acordo com o mecanismo de envio de e-mail real " +
            "usado pela UFMT antes de usar em produção.");
    }
}
