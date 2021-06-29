using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using BxlForm.DemoSecurity.Api.Models.Client.Services;
using GR = BxlForm.DemoSecurity.Api.Models.Global.Repositories;
using GS = BxlForm.DemoSecurity.Api.Models.Global.Services;
using Tools.Connections.Database;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BxlForm.DemoSecurity.Api.Infrastructure.Security;

namespace BxlForm.DemoSecurity.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("DemoSecurityDb")));
            services.AddSingleton<GR.IAuthRepository, GS.AuthService>();
            services.AddSingleton<GR.IContactRepository, GS.ContactService>();
            services.AddSingleton<GR.ICategoryRepository, GS.CategoryService>();
            services.AddSingleton<IContactRepository, ContactService>();
            services.AddSingleton<ICategoryRepository, CategoryService>();
            services.AddSingleton<IAuthRepository, AuthService>();
            services.AddSingleton<ITokenRepository, TokenService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BxlForm.DemoSecurity.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BxlForm.DemoSecurity.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
