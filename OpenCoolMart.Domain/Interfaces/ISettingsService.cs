using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ISettingsService
    {
        Configuraciones GetSettings();
        void UpdateSettings(Configuraciones configurarcion);
<<<<<<< HEAD
=======
        public Task BackUp();
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
    }
}