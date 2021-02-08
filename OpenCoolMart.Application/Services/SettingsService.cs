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
        public Configuraciones GetSettings()
        {
            return _settingsRepository.Get();
        }

        public void UpdateSettings(Configuraciones configurarcion)
        { 
            _settingsRepository.Update(configurarcion);
        }

        public async Task BackUp()
        {
            await _settingsRepository.BackUp();
        }
    }
}