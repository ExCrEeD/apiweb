using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiMails.Models
{
    public class EmailsHistorial
    {
        [Key]
        public int Id { get; set; }
        public String De { get; set; }
        public String Para { get; set; }
        public String Asunto { get; set; }
        public String Cc { get; set; }
        public String Bcc { get; set; }
        public String Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public String Formato { get; set; }
        public String Estado { get; set; }
    }
}