using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Cors;
using primeira_api_aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace primeira_api_aspnet
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
            string postgreConnection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<AppDbContext>(options => 
                                                        options.UseNpgsql(
                                                            postgreConnection
                                                        )
                                                   );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api_net_core_cad_pessoa", Version = "v1" });
            });

        // Protocolo para habilitar troca de recursos entre origens diferentes (CORS)
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .AllowAnyOrigin()
                //.WithOrigins("https://localhost:5001")
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.AllowCredentials()
            );
        });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "primeira_api_aspnet v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            // Adicionando protocolo criado liberando acesso a qualquer origem
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
