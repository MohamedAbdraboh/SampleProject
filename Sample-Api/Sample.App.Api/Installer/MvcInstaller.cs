using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sample.App.Api.Installer
{
    public class MvcInstaller : IInstaller
    {
        public void InstallService(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddControllers()
                    .AddOData(options => options.Select()).AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddRazorPages();
            services.AddSwaggerGen(g =>
            {
                g.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "V1" });

                //var security = new Dictionary<string, IEnumerable<string>>
                //{
                //    { "Bearer", new string[0] }
                //};

                //g.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //{

                //    Description = "JWT Authorization header using bearer scheme",
                //    Name = "Authorization",
                //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                //});
            });

            string allowedOrgins = Configuration.GetValue<string>("AllowedHosts");
            services.AddCors(options =>
            {
                options.AddPolicy(name: allowedOrgins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
                                  });
            });
        }
    }
}