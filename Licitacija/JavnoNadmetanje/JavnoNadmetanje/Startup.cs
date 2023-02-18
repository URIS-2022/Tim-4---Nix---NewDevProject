using JavnoNadmetanje.Auth;
using JavnoNadmetanje.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JavnoNadmetanje
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Console.WriteLine(" Using SQL DB");
            services.AddDbContext<JavnoNadmetanjeContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("JavnoNadmetanjeConnection")));


            //Console.WriteLine(" Using IN MEM DB");
            //services.AddDbContext<JavnoNadmetanjeContext>(opt => opt.UseInMemoryDatabase("InMem"));


            services.AddScoped<IJavnoNadmetanjeRepository, JavnoNadmetanjeRepository>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("JavnoNadmetanjeOpenApiSpecification", new OpenApiInfo()
                {
                    Title = "Javno Nadmetanje API",
                    Version = "1",
                    //Description = "Pomoæu ovog API-ja mogu da se vrše sve CRUD operacije u okviru agregata Javno Nadmetanje.",
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Sofija Dangubic",
                    //    Email = "sofijadangubic8@gmail.com",
                    //    Url = new Uri(Configuration["Links:FTN"])
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "FTN licence",
                    //    Url = new Uri(Configuration["Links:FTN"])
                    //},
                    //TermsOfService = new Uri(Configuration["Links:TermsOfService"])
                });

                var xmlComments = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";

                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                setupAction.IncludeXmlComments(xmlCommentsPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/JavnoNadmetanjeOpenApiSpecification/swagger.json", "Javno Nadmetanje API");
                });

            }
            else  // ukoliko se nalazimo u Production modu postavljamo defaulr poruku za greske koje su nastale na servisu
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>

                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Došlo je do neoèekivane greške. Molimo pokušajte kasnije.");
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.PrepPopulation(app);
        }
    }
}
