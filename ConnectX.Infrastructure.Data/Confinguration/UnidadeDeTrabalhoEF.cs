using Microsoft.Practices.ServiceLocation;
using ConnectX.Domain.Interfaces.Infrastructure;
using ConnectX.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Infrastructure.Data.Confinguration
{
    public class UnidadeDeTrabalhoEF : IUnidadeDeTrabalho
    {
        private ContextoBanco _contexto;

        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorio>()
                              as GerenciadorDeRepositorio;

            _contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }

    }
}
