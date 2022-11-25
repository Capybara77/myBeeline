using MailKit.Net.Smtp;
using MimeKit;

namespace web.Tools
{
    public static class Email
    {
        private static string _emailSender;
        private static string _password;

        static Email()
        {
            if (File.Exists("email"))
                _emailSender = File.ReadAllText("email");

            if (File.Exists("password"))
                _password = File.ReadAllText("password");
        }

        public static async Task<bool> SendEmailAsync(string emailGetter, string subject, string text)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта Mybeeline", _emailSender));
            emailMessage.To.Add(new MailboxAddress("Beeline", emailGetter));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = text
            };

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.yandex.ru", 25, false);
            await client.AuthenticateAsync(_emailSender, _password);
            await client.SendAsync(emailMessage);

            try
            {
                await client.DisconnectAsync(true);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }

}
