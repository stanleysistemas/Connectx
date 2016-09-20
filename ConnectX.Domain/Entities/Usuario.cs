using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            this.Dispositivo = new List<Dispositivos>();
            this.Localizacao = new List<UsuarioLocalizacao>();
        }
        public int IdUsuario { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SenhaKey { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Sexo { get; set; }
        public byte Foto { get; set; }
        public int DatadeNascimento { get; set; }
        public int Idade { get; set; }
        public virtual PerfilUsuario PerfilUsuario { get; set; }
        public virtual ICollection<Dispositivos> Dispositivo { get; set; }
        public virtual ICollection<UsuarioLocalizacao> Localizacao { get; set; }
    }
}
