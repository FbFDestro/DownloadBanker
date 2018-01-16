using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net.Configuration;

namespace DownloadBanker
{
    public class Email
    {
        public static void sendEmail(String Destinatario, String Nome, String Assunto, String Conteudo)
        {

            try
            {
                string remetenteEmail = "etepti@gmail.com"; //O e-mail do remetente

                MailMessage mail = new MailMessage();

                mail.To.Add(Destinatario);

                mail.From = new MailAddress(remetenteEmail, Nome, System.Text.Encoding.UTF8);

                mail.Subject = Assunto;

                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                mail.Body = Conteudo;

                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.IsBodyHtml = true;

                mail.Priority = MailPriority.High; //Prioridade do E-Mail

                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:

                client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "senhaetepti");



                client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio

                client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail

                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer


            client.Send(mail); }
            catch
            { }
        }

        public static void sendNewCad(String Destinatario, String NomeCadastro, String Usuario, String Senha)
        {
            sendEmail(Destinatario, "DownloadBanker", "DownloadBanker - Conta Criada com Sucesso",
                "<img src='http://imageshack.com/a/img924/541/XHn3yY.png' /><hr />" +
                "O DownloadBanker agradece por seu cadastro.<br />Boas Compras!<br /><br />" +
                "<b>" + NomeCadastro +
                                                "</b><hr /><br /><b>Seus dados para login são:</b> " +
                                                "<br /><b>Login:</b> " + Usuario +
                                                "<br /><b>Senha:</b> " + Senha +
                                                "<br /><hr /><br />Atenciosamente, DownloadBanker.");
        }

        public static void sendForgotPass(String Destinatario, String nome, String login, String senha)
        {
            sendEmail(Destinatario, "DownloadBanker", "DownloadBanker - Esqueceu a Senha",
               "<img src='http://imageshack.com/a/img924/541/XHn3yY.png' /><hr />" +
                "Prezado usuario <i>" + nome +
                "</i><br /><br />Login: <b>" + login +
                "</b><br />Senha: <b>" + senha + "</b><br /><br /><br />Atenciosamente, DownloadBanker.");
        }

        public static void sendNewCadFunc(String Destinatario, String NomeCadastro, String Usuario, String Senha)
        {
            sendEmail(Destinatario, "DownloadBanker", "DownloadBanker - Conta Criada com Sucesso",
                "<img src='http://imageshack.com/a/img924/541/XHn3yY.png' /><hr />" +
                "Seja bem vindo a empresa.<br /><br />" +
                "<b>" + NomeCadastro +
                                                "</b><hr /><br /><b>Seus dados para login são:</b> " +
                                                "<br /><b>Usuário:</b> " + Usuario +
                                                "<br /><b>Senha:</b> " + Senha +
                                                "<br /><hr /><br />Atenciosamente, DownloadBanker.");
        }
    }
}
