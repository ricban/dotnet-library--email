using Microsoft.Extensions.DependencyInjection;

namespace Library.Email.Interfaces
{
    public interface IMailKitOptionsBuilder
    {
        /// <summary>
        /// Service collection
        /// </summary>
        IServiceCollection ServiceCollection { get; }

        /// <summary>
        /// Add MailKit to the IServiceCollection
        /// </summary>
        /// <param name="options">redis options</param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        IMailKitOptionsBuilder UseMailKit(MailKitOptions options, ServiceLifetime lifetime = ServiceLifetime.Scoped);
    }
}