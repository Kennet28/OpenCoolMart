using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using OpenCoolMart.Infraestructure.Repositories;

namespace OpenCoolMart.Application.Services
{
    public class SettingsService:ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }
        public void CreateSettings(Configurarciones configurarcion)
        {
            _settingsRepository.Create(configurarcion);
        }

        public Configurarciones GetSettings()
        {
            return _settingsRepository.Get();
        }

        public void UpdateSettings(Configurarciones configurarcion)
        { 
            _settingsRepository.Update(configurarcion);
        }
    }
}