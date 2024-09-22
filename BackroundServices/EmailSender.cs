using System;
using System.Net;
using System.Net.Mail;

namespace SqlSearchQuery.BackroundServices;

public class EmailSender : IEmailSender
{

    public Task SendEmailAsync(string CompanyEmail, string CompanyName, string OfferEmail, string Title, string Message, string NameSurname)
    {
        var MainMail = "stajtestemial@outlook.com"; //Mail'i Göndericek E-mail adresi.
        var pw = "****"; //Mail adresinin şifresi.

        var client = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(MainMail, pw)
        };

        var uniqueSubject = $"Yeni Teklif - {Title} - {DateTime.Now:yyyy.MM.dd HH:mm}";



        // E-posta içeriğini HTML olarak oluştur
        var emailBody = $@"
    <html>
    <body>
        <h1>Teklif var!</h1>
        <h2>Merhaba {CompanyName} adlı şirketinize bir teklif var,</h2>

        <h3>{Title}</h3>

        <h4>{Message}</h4>

        <h3>Ad Soyad: {NameSurname}</h3>

        <h3>E-Mail: {OfferEmail}</h3>
    </body>
    </html>
    ";

        var mailMessage = new MailMessage
        {
            From = new MailAddress(MainMail),
            To = { CompanyEmail },
            Subject = uniqueSubject,
            Body = emailBody,
            IsBodyHtml = true
        };

        return client.SendMailAsync(mailMessage);

    }
}
