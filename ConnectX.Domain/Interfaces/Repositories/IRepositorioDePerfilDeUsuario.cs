using ConnectX.Domain.Entities;
using System.Collections.Generic;

namespace ConnectX.Domain.Interfaces.Repositories
{
    public interface IRepositorioDePerfilDeUsuario : IRepositorioBase<PerfilUsuario>
    {
        List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario);
    }
}
