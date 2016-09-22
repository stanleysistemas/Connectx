using ConnectX.Domain.Entities;
using ConnectX.Domain.Interfaces.Repositories;
using ConnectX.Infrastructure.Data.Security;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ConnectX.Infrastructure.Data.Repositories
{
    public class RepositorioDeUsuarios : RepositorioBase<Usuario>, IRepositorioDeUsuarios
    {
        public Usuario CadastraUsuario(Usuario user)
        {
            user.Senha = Crypto.EncryptStringAES(user.Senha, user.SenhaKey);
            return _contexto.Usuarios.Add(user);
        }

        public Usuario RecuperarUsuarioPorId(int id)
        {
            var usuario = _contexto.Usuarios.Where(u => u.IdUsuario == id).FirstOrDefault();
            return usuario;
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            if (usuario == null)
                return null;

            string passDecrypt = Crypto.DecryptStringAES(usuario.Senha, usuario.SenhaKey);

            if (passDecrypt == senha)
                return usuario;
                else return null;
        }

        public List<Dispositivos> RecuperaDispositivosDoUsuario(int idUsuario)
        {
            var dispositivo = _contexto.Dispositivos.Where(x => x.IdUsuario == idUsuario).ToList();
            return dispositivo;
        }

        public List<UsuarioLocalizacao> RecuperaLocalizacaoDoUsuario(int idUsuario, DateTime DiaGps)
        {
            var localiza = _contexto.UsuarioLocalizacao.Where(l => l.IdUsuario == idUsuario && l.DtGPS == DiaGps).ToList();
            return localiza;
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            return usuario;


        }

        
    }
}
