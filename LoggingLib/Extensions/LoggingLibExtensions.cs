using LoggingLib.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LoggingLib.Extensions
{
    public static class LoggingLibExtensions
    {
        public static void AddLoggingLib(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILog<>), typeof(Log<>));
        }
    }
}
