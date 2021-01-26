using OpenCoolMart.Domain.Entities;

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ISettingsRepository
    {
        public void Create(Configurarciones config);
        public Configurarciones Get();
        public void Update(Configurarciones config);
    }
}