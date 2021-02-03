using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenCoolMart.Application.Services;
using OpenCoolMart.Domain.ConstrainsMap;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Infraestructure.Data;
using OpenCoolMart.Infraestructure.Repositories;

namespace OpenCoolMart.Api
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
            services.AddCors();

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            // services.AddDbContext<OpenCoolMartContext>(options =>
            //         options.UseSqlServer(Configuration.GetConnectionString("Alejandro"))
            // );
            services.AddDbContext<OpenCoolMartContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Roger"))
            );
            //services.AddDbContext<OpenCoolMartContext>(options =>
            //  options.UseSqlServer(Configuration.GetConnectionString("Kennet"))
            //);
            services.Configure<RouteOptions>(route => 
            {
                route.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            });
            //services.AddMvc().AddFluentValidation(options =>
            //        options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("https://localhost:44368");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //   name: "default",
                //   pattern: "{controller=Home}/{action=Index}/{id:alphanumeric}");
            });
        }
    }
}
