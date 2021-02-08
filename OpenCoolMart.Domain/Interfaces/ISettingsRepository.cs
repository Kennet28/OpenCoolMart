using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ISettingsRepository
    {
        public Configuraciones Get();
        public void Update(Configuraciones config);
        public Task BackUp();
    }
}