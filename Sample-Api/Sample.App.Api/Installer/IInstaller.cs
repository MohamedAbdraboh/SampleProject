using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.App.Api.Installer
{
    public interface IInstaller
    {
        void InstallService(IConfiguration Configuration, IServiceCollection services);
    }
}
