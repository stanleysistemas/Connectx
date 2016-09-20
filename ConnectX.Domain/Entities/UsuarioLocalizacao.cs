using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectX.Domain.Entities
{
    public partial class UsuarioLocalizacao
    {
        public int IdLocalizacao { get; set; }
        public int IdUsuario { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public float Precisao { get; set; }
        public DateTime DtGPS { get; set; }
        public string Provider { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
