using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Email.Interfaces
{
    public interface IEmailService
    {
        void Send(string mailTo, string subject, string message, bool isHtml = false);
        void Send(string mailTo, string subject, string message, params string[] attachments);
        void Send(string mailTo, string subject, string message, IEnumerable<string> attachments, bool isHtml = false);
        void Send(string mailTo, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null);
        void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, bool isHtml = false);
        void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, params string[] attachments);
        void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, IEnumerable<string> attachments, bool isHtml = false);
        void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null);
        Task SendAsync(string mailTo, string subject, string message, bool isHtml = false);
        Task SendAsync(string mailTo, string subject, string message, params string[] attachments);
        Task SendAsync(string mailTo, string subject, string message, IEnumerable<string> attachments, bool isHtml = false);
        Task SendAsync(string mailTo, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null);
        Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, bool isHtml = false);
        Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, params string[] attachments);
        Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, IEnumerable<string> attachments, bool isHtml = false);
        Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml = false, IEnumerable<string> attachments = null);
    }
}