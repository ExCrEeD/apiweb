using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApiMails.Models
{
    public class Correo
    {
        [Key]
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}