using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using ConnectX.Domain.Interfaces.Domain;
using ConnectX.Domain.Interfaces.Infrastructure;
using ConnectX.Domain.Interfaces.Repositories;
using ConnectX.Domain.Services;
using ConnectX.Infrastructure.Data.Confinguration;
using ConnectX.Infrastructure.Data.Repositories;
using SimpleInjector;

namespace ConnectX.Infrastructure.IoC
{
    public class Bindings
    {
        /// <summary>
        /// Install-Package SimpleInjector
        /// Install-Package CommonServiceLocator -Version 1.3.0
        /// Install-Package CommonServiceLocator.SimpleInjectorAdapter
        /// </summary>
        public static void Start(Container container)
        {
            //Infrastrutura
            container.Register<IGerenciadorDeRepositorio, GerenciadorDeRepositorio>();
            container.Register<IUnidadeDeTrabalho, UnidadeDeTrabalhoEF>();
            container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeUsuarios), typeof(RepositorioDeUsuarios), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDePerfilDeUsuario), typeof(RepositorioDePerfilDeUsuario), Lifestyle.Scoped);

            //Dominio
            container.Register(typeof(IServicoDeUsuarioDomain), typeof(ServicoDeUsuarioDomain), Lifestyle.Scoped);

            //Aplicacao
            //todo

            //Service Locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
