using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.api.Data;
using CadastroUsuario.api.Data.Repository;
using CadastroUsuario.api.Domain.Model;
using CadastroUsuario.api.Domain.Repositories;
using CadastroUsuario.api.Domain.Services;
using CadastroUsuario.api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace CadastroUsuario.api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .WithHeaders(HeaderNames.AccessControlAllowHeaders, "Content-Type")
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));

            services.AddDbContext<UsuarioContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("CadastroUsuario"));
            });

            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddTransient<IRepository<Usuario>, RepositorioEF<Usuario>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("ApiCorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
