using ConnectX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeUsuarios : IRepositorioBase<Usuario>
    {
        Usuario RecuperarUsuarioPorEmail(string email);
        Usuario RecuperarUsuarioPorId(int id);
        Usuario LogaUsuario(string email, string senha);
        Usuario CadastraUsuario(Usuario user);
    }
}
