using Sample.App.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Sample.App.Api.Installer;

namespace CodeSnippet.App.Api.Installer
{
    public class DBInstaller : IInstaller
    {
        public void InstallService(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
