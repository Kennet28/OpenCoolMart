using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ISettingsService
    {
        Configuraciones GetSettings();
        void UpdateSettings(Configuraciones configurarcion);
    }
}