using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Domain.Entities
{
    public partial class Dispositivos
    { 
        public int IdDispositivo { get; set; }
        public int IdUsuario { get; set; }
        public string IMEI { get; set; }
        public string NomeDispositivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
