using ConnectX.Domain.Entities;
using ConnectX.Domain.Interfaces.Domain;
using ConnectX.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectX.Domain.Services
{
    public class ServicoDeUsuarioDomain : ServicoDeDominioBase, IServicoDeUsuarioDomain
    {
        private readonly IRepositorioDeUsuarios _repositorioUsuario;
        private readonly IRepositorioDePerfilDeUsuario _repositorioPerfil;
       

        public ServicoDeUsuarioDomain(IRepositorioDeUsuarios repositorioUsuario, IRepositorioDePerfilDeUsuario repositorioPerfil)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioPerfil = repositorioPerfil;
           
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuarioRetorno = _repositorioUsuario.LogaUsuario(email, senha);
            return usuarioRetorno;
        }

        public Usuario RecuperaUsuarioPorEmail(string email)
        {
            var usuarioRetorno = _repositorioUsuario.RecuperarUsuarioPorEmail(email);
            return usuarioRetorno;
        }

        public List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilUsuario)
        {
            var usuariosDoPerfil = _repositorioPerfil.RetornaUsuariosDoPerfil(idPerfilUsuario);
            return usuariosDoPerfil;
        }

        public List<PerfilUsuario> RecuperaTodosPerfisAtivos()
        {
            return _repositorioPerfil.RecuperarTodos().Where(x => x.FlAtivo && !x.FlAdminMaster).ToList();
        }

        public void CadastraUsuario(Usuario usuario)
        {
            try
            {
                IniciarTransação();
                _repositorioUsuario.CadastraUsuario(usuario);
                PersistirTransação();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }            
        }

        public Usuario RecuperarUsuarioPorId(int id)
        {
            var usuarioRetorno = _repositorioUsuario.RecuperarUsuarioPorId(id);
            return usuarioRetorno;
        }
    }
}
