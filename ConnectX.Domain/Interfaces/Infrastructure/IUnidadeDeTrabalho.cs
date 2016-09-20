using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Domain.Interfaces.Infrastructure
{
    public interface IUnidadeDeTrabalho
    {
        void Iniciar();
        void Persistir();
    }
}
