 using Sample.App.BLL.Services.Entities.V1;
using Sample.App.BLL.Services.Contract.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.App.Api.Installer.V1
{
    public class EntitiesServicesInstaller : IInstaller
    {
        public void InstallService(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ISubStatusRepository, SubStatusRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}