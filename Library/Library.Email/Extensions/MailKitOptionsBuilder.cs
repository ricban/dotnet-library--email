using System.Collections.Generic;
using Library.Email.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Library.Email.Extensions
{
    public class MailKitOptionsBuilder : IMailKitOptionsBuilder
    {
        /// <summary>
        /// Gets the service collection in which the interception based services are added.
        /// </summary>
        public IServiceCollection ServiceCollection { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/> service collection</param>
        public MailKitOptionsBuilder(IServiceCollection services)
        {
            ServiceCollection = services;
        }

        /// <summary>
        ///  Add email service to DI
        /// </summary>
        /// <param name="options"></param>
        /// <param name="lifetime"></param>
        public IMailKitOptionsBuilder UseMailKit(MailKitOptions options, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            ServiceCollection.TryAddSingleton<IMailKitProvider>(new MailKitProvider(options));
            ServiceCollection.TryAdd(new ServiceDescriptor(typeof(IEmailService), typeof(EmailService), lifetime));

            return this;
        }
    }
}