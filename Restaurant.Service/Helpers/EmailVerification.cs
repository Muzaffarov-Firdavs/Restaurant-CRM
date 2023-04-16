using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Restaurant.Service.DTOs.Users;
using Restaurant.Service.Exceptions;
using StackExchange.Redis;

namespace Restaurant.Service.Helpers
{
    public class EmailVerification
    {
        private readonly IConfiguration configuration;

        public EmailVerification(IConfiguration configuration)
        {
            this.configuration = configuration.GetSection("Email");
        }

        public async Task<string> SendAsync(UserForResultDto user)
        {
            try
            {
                Random random = new Random();
                int verificationCode = random.Next(123456, 999999);

                ConnectionMultiplexer redisConnect = ConnectionMultiplexer.Connect("localhost");
                IDatabase db = redisConnect.GetDatabase();
                db.StringSet("code", verificationCode.ToString());
                var result = db.StringGet("code");

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(this.configuration["EmailAddress"]));
                email.To.Add(MailboxAddress.Parse(user.Email));
                email.Subject = "Email verification for Admin!";
                email.Body = new TextPart(TextFormat.Html) { Text = result.ToString() };

                var sendMessage = new SmtpClient();
                await sendMessage.ConnectAsync(this.configuration["Host"], 587, SecureSocketOptions.StartTls);
                await sendMessage.AuthenticateAsync(this.configuration["EmailAddress"], this.configuration["Password"]);
                await sendMessage.SendAsync(email);
                await sendMessage.DisconnectAsync(true);

                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new CustomException(400, ex.Message);
            }
        }
    }
}
