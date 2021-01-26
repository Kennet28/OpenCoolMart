using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;

namespace OpenCoolMart.Infraestructure.Repositories
{
    public class SettingsRepository:ISettingsRepository
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\json\test.json");
        public void Create(Configurarciones config)
        {
            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText(path,json);
        }
        public Configurarciones Get()
        {
            var jsonStream = File.OpenText(path);
            var json = jsonStream.ReadToEnd();
            var configuracion = JsonConvert.DeserializeObject<Configurarciones>(json);
            jsonStream.Close();
            return configuracion;
        }
        public void Update(Configurarciones config)
        {
            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText(path,json);
        }
    }
}