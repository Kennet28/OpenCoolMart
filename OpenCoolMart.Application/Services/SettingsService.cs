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
<<<<<<< HEAD
=======

        public async Task BackUp()
        {
            await _settingsRepository.BackUp();
        }
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
    }
}