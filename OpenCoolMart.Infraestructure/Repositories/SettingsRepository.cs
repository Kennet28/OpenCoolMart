using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using IConfiguration = AutoMapper.Configuration.IConfiguration;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public class SettingsRepository:ISettingsRepository
    {
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
    }
}