<<<<<<< HEAD
﻿using OpenCoolMart.Domain.Entities;
=======
﻿using System.Threading.Tasks;
using OpenCoolMart.Domain.Entities;
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3

namespace OpenCoolMart.Domain.Interfaces
{
    public interface ISettingsRepository
    {
        public Configuraciones Get();
        public void Update(Configuraciones config);
<<<<<<< HEAD
=======
        public Task BackUp();
>>>>>>> a3a3ce209b3e29b1e3e25d655ef2dbd98679b5b3
    }
}