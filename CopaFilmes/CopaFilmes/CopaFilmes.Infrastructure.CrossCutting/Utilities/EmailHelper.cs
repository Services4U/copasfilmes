using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;

namespace CopaFilmes.Infrastructure.CrossCutting.Utilities
{
    public class EmailHelper
    {
        private readonly IOptions<KeysConfig> ChaveConfiguracao;

        public EmailHelper(IOptions<KeysConfig> chaveConfiguracao)
        {
            ChaveConfiguracao = chaveConfiguracao;
        }

        public bool EnviarMensagem(string emailPara, string para, string assunto, string mensagem)
        {
            try {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(ChaveConfiguracao.Value.EmailFrom, ChaveConfiguracao.Value.From);
                mail.To.Add(new MailAddress(emailPara, para));
                mail.Subject = assunto;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = mensagem;

                SmtpClient smtp = new SmtpClient(ChaveConfiguracao.Value.SmtpServer, Convert.ToInt32(ChaveConfiguracao.Value.SmtpPort));

                EncryptionHelper encryptionHelper = new EncryptionHelper(ChaveConfiguracao);

                smtp.Credentials = new NetworkCredential(ChaveConfiguracao.Value.SmtpUser, encryptionHelper.Descriptografar(ChaveConfiguracao.Value.SmtpPassword));
                smtp.Send(mail);

                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public bool EnviarMensagem(string emailPara, string para, string assunto, string mensagem, string nomeArquivo)
        {
            try {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(ChaveConfiguracao.Value.EmailFrom, ChaveConfiguracao.Value.From);
                mail.To.Add(new MailAddress(emailPara, para));
                mail.Subject = assunto;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = mensagem;
                mail.Attachments.Add(new Attachment(nomeArquivo));

                SmtpClient smtp = new SmtpClient(ChaveConfiguracao.Value.SmtpServer, Convert.ToInt32(ChaveConfiguracao.Value.SmtpPort));

                EncryptionHelper encryptionHelper = new EncryptionHelper(ChaveConfiguracao);

                smtp.Credentials = new NetworkCredential(ChaveConfiguracao.Value.SmtpUser, encryptionHelper.Descriptografar(ChaveConfiguracao.Value.SmtpPassword));
                smtp.Send(mail);

                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
