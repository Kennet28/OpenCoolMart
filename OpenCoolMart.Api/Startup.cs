using System;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OpenCoolMart.Application.Services;
using OpenCoolMart.Domain.ConstrainsMap;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Infraestructure.Data;
using OpenCoolMart.Infraestructure.Repositories;
using Wkhtmltopdf.NetCore;

namespace OpenCoolMart.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            // services.AddDbContext<OpenCoolMartContext>(options =>
            //           options.UseSqlServer(Configuration.GetConnectionString("Alejandro")));
            //services.AddDbContext<OpenCoolMartContext>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("Roger"))
            //);
            services.AddDbContext<OpenCoolMartContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Kennet")));
            // services.AddDbContext<OpenCoolMartContext>(options =>
            //                     options.UseSqlServer(Configuration.GetConnectionString("Hosting")));
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("settings.json",optional: true, reloadOnChange: true).Build();
            // services.AddDbContext<OpenCoolMartContext>(options =>
            //     options.UseSqlServer(config["BDConexion"]));
            services.Configure<RouteOptions>(route =>
            {
                route.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            });
            services.AddMvc().AddFluentValidation(options =>options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //var appSettingsSection = Configuration.GetSection("AppSettings")
            // configure jwt authentication
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.UTF8.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    x => x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    });
            // x.RequireHttpsMetadata = false;
            //x.SaveToken = true;


            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<IVentaService, VentaService>();
            services.AddTransient<ICajaService, CajaService>();
            services.AddTransient<IFacturasService, FacturasService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddTransient<ICompraService, CompraService>();
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IAlmacenarImagen, AlmacenarImagen>();
            services.AddTransient<IGraficaRepository,GraficaRespository> ();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("*");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // app.UseAuthentication(); es necesario
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}