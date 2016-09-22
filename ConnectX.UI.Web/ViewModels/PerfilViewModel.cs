using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConnectX.UI.Web.ViewModels
{
    public class PerfilViewModel
    {
        [Display(Name = "E-mail")]
        [MaxLength(30, ErrorMessage = "Máximo permitido para o Email são 30 caracteres.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}