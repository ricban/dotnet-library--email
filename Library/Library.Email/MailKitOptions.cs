namespace Library.Email
{
    public class MailKitOptions
    {
        /// <summary>
        /// SMTP Server address
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// SMTP Server Port, default is 25
        /// </summary>
        public int Port { get; set; } = 25;

        /// <summary>
        /// Send user name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Send user email
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Send user account, may be equal to senderemail
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Send user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Enable security
        /// </summary>
        public bool Security { get; set; }
    }
}