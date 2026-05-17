using MailKit.Net.Smtp;
using MimeKit;

public class EmailService : IEmailService
{
    public async Task Send(
        string to,
        string subject,
        string body)
    {
        var email = new MimeMessage();

        email.From.Add(
            MailboxAddress.Parse("SEU_EMAIL@gmail.com")
        );

        email.To.Add(
            MailboxAddress.Parse(to)
        );

        email.Subject = subject;

        email.Body =
            new TextPart("plain")
            {
                Text = body
            };

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(
            "smtp.gmail.com",
            587,
            false
        );

        await smtp.AuthenticateAsync(
            "SEU_EMAIL@gmail.com",
            "SUA_SENHA_APP"
        );

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}