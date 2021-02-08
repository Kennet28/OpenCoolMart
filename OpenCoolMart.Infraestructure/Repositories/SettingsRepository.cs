using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Infraestructure.Data;
using IConfiguration = AutoMapper.Configuration.IConfiguration;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public class SettingsRepository:ISettingsRepository
    {
        private readonly OpenCoolMartContext _context;

        public SettingsRepository(OpenCoolMartContext context)
        {
            _context = context;
        }
        public Configuraciones Get()
        {
            // var config = new ConfigurationBuilder()
            //     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //     .AddJsonFile("appsettings.json").Build();
            // var section = config.GetSection(nameof(Configuraciones));
            // var clientConfig = section.Get<Configuraciones>();
            var jsonStream = File.OpenText(Path.Combine(AppContext.BaseDirectory, "appsettings.json"));
            var json = jsonStream.ReadToEnd();
            var configuracion = JsonConvert.DeserializeObject<Configuraciones>(json);
            jsonStream.Close();
            return configuracion;
        }
        public void Update(Configuraciones config)
        {
            var updateConfig =  new Configuraciones()
            {
                Ip = config.Ip,
                Ncaja = config.Ncaja,
                BDConexion = config.BDConexion,
                RutaRespaldo = config.RutaRespaldo
            };
            var result = JsonConvert.SerializeObject(updateConfig);
            File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json"),result);
        }

        public async Task BackUp()
        { 
            var dir = Get().RutaRespaldo+"\\OpenCoolMart-"+DateTime.Now.ToShortDateString().Replace(' ','-').Replace('/','-').Replace(':','-')+".bak";
           var dataBase = _context.Database;
           const string query = @"BACKUP DATABASE [OpenCoolMart] TO  DISK = @dir WITH NOFORMAT, NOINIT,  NAME = N'OpenCoolMart-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
           await dataBase.ExecuteSqlRawAsync(query, new []
           {
               new SqlParameter("@dir",dir)
           });
           
        }
    }
}