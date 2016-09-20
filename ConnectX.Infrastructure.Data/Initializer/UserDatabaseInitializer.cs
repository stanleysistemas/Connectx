using ConnectX.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ConnectX.Infrastructure.Data.Initializer
{
    public class UserDatabaseInitializer
    {
        public static List<ModulosAcesso> GetModulosAcesso()
        {
            var modulos = new List<ModulosAcesso>
            {
                new ModulosAcesso
                {
                    IdModulo = 1,
                    FlAtivo = true,
                    NomeMenuAcesso = "Administração",
                    NomeModulo = "Admin",
                    UrlMenu = "#",
                    DataCadastro = DateTime.Now

                },
                new ModulosAcesso
                {
                    IdModulo = 2,
                    FlAtivo = true,
                    NomeMenuAcesso = "Cadastro",
                    NomeModulo = "Cadastro",
                    UrlMenu = "#",
                    DataCadastro = DateTime.Now,
                    IdModuloPai = 1
                },
                new ModulosAcesso
                {
                    IdModulo = 3,
                    FlAtivo = true,
                    NomeMenuAcesso = "Perfil de Usuário",
                    NomeModulo = "Perfil de Usuário",
                    UrlMenu = "#",
                    DataCadastro = DateTime.Now,
                    IdModuloPai = 2
                }
            };

            return modulos;
        }
        public static List<PerfilUsuario> GetPerfisUsuarios()
        {
            var perfisUsuario = new List<PerfilUsuario>
            {
                new PerfilUsuario
                {
                    IdPerfilUsuario = 1,
                    DataCadastro = DateTime.Now,
                    FlAdminMaster =true,
                    FlAtivo = true,
                    NomePerfil = "Administrador Master",
                    ModulosAcesso = GetModulosAcesso()
                },
                new PerfilUsuario
                {
                    IdPerfilUsuario = 2,
                    DataCadastro = DateTime.Now,
                    FlAdminMaster = false,
                    FlAtivo = true,
                    NomePerfil = "Usuário"
                    
                }

            };
            return perfisUsuario;
        }

        public static List<Usuario> GetUsuario()
        {
            var usuario = new List<Usuario>
            {
                new Usuario
               {

                  IdUsuario = 0,
                  Nome = "Admin",
                  DataCadastro = DateTime.Now,
                  Email = "suporte@stanleysistemas.xyz",
                  IdPerfilUsuario = 1,
                  Senha = "win2000adm"
                  // SenhaKey =

            
               }

            };

            return usuario;
        }
    }
}
