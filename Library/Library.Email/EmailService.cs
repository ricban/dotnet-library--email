using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Email.Interfaces;
using MimeKit;

namespace Library.Email
{
    public class EmailService : IEmailService
    {
        private readonly IMailKitProvider mailKitProvider;

        public EmailService(IMailKitProvider provider)
        {
            mailKitProvider = provider;
        }

        public void Send(string mailTo, string subject, string message, bool isHtml = false)
        {
            SendEmail(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, null);
        }

        public void Send(string mailTo, string subject, string message, params string[] attachments)
        {
            SendEmail(mailTo, null, null, subject, message, Encoding.UTF8, false, attachments);
        }

        public void Send(string mailTo, string subject, string message, IEnumerable<string> attachments, bool isHtml = false)
        {
            SendEmail(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, attachments);
        }

        public void Send(string mailTo, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null)
        {
            SendEmail(mailTo, null, null, subject, message, encoding, isHtml, attachments);
        }

        public void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, bool isHtml = false)
        {
            SendEmail(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, null);
        }

        public void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, params string[] attachments)
        {
            SendEmail(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, false, attachments);
        }

        public void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, IEnumerable<string> attachments, bool isHtml = false)
        {
            SendEmail(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, attachments);
        }

        public void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null)
        {
            SendEmail(mailTo, mailCc, mailBcc, subject, message, encoding, isHtml, attachments);
        }

        public Task SendAsync(string mailTo, string subject, string message, bool isHtml = false)
        {
            return SendEmailAsync(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, null);
        }

        public Task SendAsync(string mailTo, string subject, string message, params string[] attachments)
        {
            return SendEmailAsync(mailTo, null, null, subject, message, Encoding.UTF8, false, attachments);
        }

        public Task SendAsync(string mailTo, string subject, string message, IEnumerable<string> attachments, bool isHtml = false)
        {
            return SendEmailAsync(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, attachments);
        }

        public Task SendAsync(string mailTo, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null)
        {
            return SendEmailAsync(mailTo, null, null, subject, message, Encoding.UTF8, isHtml, attachments);
        }

        public Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, bool isHtml = false)
        {
            return SendEmailAsync(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, null);
        }

        public Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, params string[] attachments)
        {
            return SendEmailAsync(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, false, attachments);
        }

        public Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, IEnumerable<string> attachments, bool isHtml = false)
        {
            return SendEmailAsync(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, attachments);
        }

        public Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null)
        {
            return SendEmailAsync(mailTo, mailCc, mailBcc, subject, message, Encoding.UTF8, isHtml, attachments);
        }

        private void SendEmail(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml, IEnumerable<string> attachments = null)
        {
            var mimeMessage = CreateMimeMessage(mailTo, mailCc, mailBcc, subject, message, encoding, isHtml, attachments);

            using var client = mailKitProvider.SmtpClient;

            client.Send(mimeMessage);
        }

        private async Task SendEmailAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml, IEnumerable<string> attachments = null)
        {
            var mimeMessage = CreateMimeMessage(mailTo, mailCc, mailBcc, subject, message, encoding, isHtml, attachments);

            using var client = mailKitProvider.SmtpClient;

            await client.SendAsync(mimeMessage).ConfigureAwait(false);
        }

        private MimeMessage CreateMimeMessage(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml, IEnumerable<string> attachments = null)
        {
            var builder = new BodyBuilder();

            if (isHtml)
            {
                builder.HtmlBody = message;
            }
            else
            {
                builder.TextBody = message;
            }

            if (attachments?.Count() > 0)
            {
                foreach (var attachment in attachments)
                {
                    builder.Attachments.Add(attachment);
                }
            }

            var mimeMessage = new MimeMessage
            {
                Subject = subject,
                Body = builder.ToMessageBody()
            };

            mimeMessage.From.Add(new MailboxAddress(mailKitProvider.Options.SenderName, mailKitProvider.Options.SenderEmail));

            if (!string.IsNullOrEmpty(mailTo))
            {
                foreach (var to in mailTo.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()))
                {
                    mimeMessage.To.Add(MailboxAddress.Parse(to));
                }
            }

            if (!string.IsNullOrEmpty(mailCc))
            {
                foreach (var cc in mailCc.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()))
                {
                    mimeMessage.Cc.Add(MailboxAddress.Parse(cc));
                }
            }

            if (!string.IsNullOrEmpty(mailBcc))
            {
                foreach (var bcc in mailBcc.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()))
                {
                    mimeMessage.Bcc.Add(MailboxAddress.Parse(bcc));
                }
            }

            return mimeMessage;
        }
    }
}