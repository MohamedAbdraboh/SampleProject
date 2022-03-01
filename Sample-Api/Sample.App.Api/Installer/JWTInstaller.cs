using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.App.Api.Installer
{
    public class JWTInstaller : IInstaller
    {
        public void InstallService(IConfiguration Configuration, IServiceCollection services)
        {
        }
    }
}
