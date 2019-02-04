using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApiMails.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Correo { get; set; }
        public String Estado { get; set; }
    }
}