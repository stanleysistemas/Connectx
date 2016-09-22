using ConnectX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Domain.Interfaces.Domain
{
    public interface IServicoDeUsuarioDomain
    {
        Usuario LogaUsuario(string email, string senha);
        Usuario RecuperaUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilUsuario);
        List<PerfilUsuario> RecuperaTodosPerfisAtivos();

        Usuario RecuperarUsuarioPorId(int id);

        void CadastraUsuario(Usuario usuario);
    }
}
