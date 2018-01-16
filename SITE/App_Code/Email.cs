using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Configuration;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{

    public static void enviarEmail(String Destinatario, String Nome, String Assunto, String Conteudo)
    {
        try
        {
            string remetenteEmail = "etepti@gmail.com";

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
            client.Send(mail);
        }
        catch
        { }
    }

    public static void sendNewCad(String Destinatario, String NomeCadastro, String Usuario, String Senha)
    {
        enviarEmail(Destinatario, "Yönetim", "Yönetim - Conta Criada com Sucesso",
            "<img src='https://pbs.twimg.com/media/CQK6VlQWIAEaeW4.png' /><hr />" +
            "<h1>A Yönetim agradece por seu cadastro.</h1><br /><h2>Boas Compras!</h2><br /><br />" +
            "<b>" + NomeCadastro +
                                            "</b><hr /><br /><b><h3>Seus dados para login são:</h3></b> " +
                                            "<br /><b>Login:</b> " + Usuario +
                                            "<br /><b>Senha:</b> " + Senha +
                                            "<br /><hr /><br />Atenciosamente, Yönetim.");
    }
    
    public static void enviarEsqueciSenha(String destinatario, String nome, string url)
    {
        enviarEmail(destinatario, "DownloadBanker", "DownloadBanker - Recuperar sua senha",
            "<h1 style='text-align: center;'><img src='http://i63.tinypic.com/2hqcyok.png'"
            +"alt='Logo'/></h1><hr /><h1 style='text-align: left;'>"
            +"Prezado "+nome+",</h1><p>Uma solicita&ccedil;&atilde;o para recuperar a sua senha"
            +" foi enviada, <a href='"+url+"novaSenhaEsqueci.aspx'><b>clique aqui</b></a>"
            +" para redefinir a sua senha.</p><p>Caso voc&ecirc; n&atilde;o senha feito essa solicita&ccedil;&atilde;o, "
            +"ignore esta mensagem.</p><p>&nbsp;</p><p>Atenciosamente, DownloadBanker</p><p>&nbsp;</p>"); 
    }

    public static void sendNewCadFunc(String Destinatario, String NomeCadastro, String Usuario, String Senha)
    {
        enviarEmail(Destinatario, "Yönetim", "Yönetim - Conta Criada com Sucesso",
            "<img src='https://pbs.twimg.com/media/CQK6VlQWIAEaeW4.png' /><hr />" +
            "<h1>Seja Bem vindo a empresa.</h1><br /><br />" +
            "<b>" + NomeCadastro +
                                            "</b><hr /><br /><b><h3>Seus dados para login como funcionário são:<h3></b> " +
                                            "<br /><b>Usuário:</b> " + Usuario +
                                            "<br /><b>Senha:</b> " + Senha +
                                            "<br /><hr /><br />Atenciosamente, Yönetim.");
    }

    public static void sendTellUs(String Destinatario, String Nome, String Contato, String Conteudo)
    {
        enviarEmail("suporte.yonetim@gmail.com", "Yönetim", "Yönetim - Fale Conosco",
            "<img src='https://pbs.twimg.com/media/CQK6VlQWIAEaeW4.png' /><hr />" +
            "<h1>Fale Conosco</h1><br /><br />" +
            "<b>Nome: </b>" + Nome + ", " +
            "<b>Telefone: </b>" + Contato +
            "<br /><br />Entrou em contato dizendo:<hr /><br />" +
                                            Conteudo);

        enviarEmail(Destinatario, "Yönetim", "Yönetim - Fale Conosco",
            "<img src='https://pbs.twimg.com/media/CQK6VlQWIAEaeW4.png' /><hr />" +
            "<h1>A Yönetim agradece por entrar em contato conosco.</h1><br />" +
            "<h3>Srª." + Nome + ".</h3>" +
                                            "<br /><hr /><br />Atenciosamente, Yönetim.");
    }

    public static void sendTellUsFunc(String Destinatario, String NomeFunc, String Nome, String Contato, String Email, String Conteudo)
    {
        enviarEmail(Destinatario, "Yönetim", "Yönetim - Fale Conosco",
            "<img src='https://pbs.twimg.com/media/CQK6VlQWIAEaeW4.png' /><hr />" +
            "<h1>Fale Conosco</h1><br /><br />" +
            "<h3>Srª." + NomeFunc + ".</h3>" +
            "<hr />" +
            "Entraram em contato pelo site da Yönetim." +
            "Se você puder resolver o problema do usuário, a empresa agradece!" +
            "<br /><hr /><br />Dados do Usuário:<br /><br />" +
            "<b>Nome: </b>" + Nome + ", <br />" +
            "<b>Telefone: </b>" + Contato + "<br />" +
            "<b>E-Mail: </b>" + Email + "<br />" +
            "<br /><br />Entrou em contato dizendo:<hr /><br />" +
                                            Conteudo);
    }

    public static void shop(String Destinatario, String Nome, String valor, String Endereco)
    {
        enviarEmail(Destinatario, "Yönetim", "Yönetim - Compra Efetuada",
            "<img src='https://pbs.twimg.com/media/CQK6VlQWIAEaeW4.png' /><hr />" +
            "<h1>A Yönetim agradece por sua Compra.</h1><br />" +
            "<h3>Srª." + Nome + ".</h3>" +
            "<p><b>Valor da Compra:</b> " + valor + "</p><br />" +
            "<p>Que está destinada ao endereço: " + Endereco +
            "<br /><hr /><br />Atenciosamente, Yönetim.");

    }
}