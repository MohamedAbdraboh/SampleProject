using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Sample.App.Api.Installer
{
    public static class InstallExtension
    {
        public static void InstallServicesInAssmbly(this IServiceCollection services, IConfiguration Configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(i => { i.InstallService(Configuration, services); });
        }
    }
}
