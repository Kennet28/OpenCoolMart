using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ISettingsService
    {
        void CreateSettings(Configurarciones configurarcion);
        Configurarciones GetSettings();
        void UpdateSettings(Configurarciones configurarcion);
    }
}