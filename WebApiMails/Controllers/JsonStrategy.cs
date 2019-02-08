using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMails.Models;
using System.Web.Script.Serialization;
using System.IO;

namespace WebApiMails.Controllers
{
    public class JsonStrategy : InterfaceStrategyFile
    {
        private EmailsHistorial mail;
        public JsonStrategy(EmailsHistorial mail)
        {
            this.mail = mail;
        }

        public void writeFile()
        {
            mail.RutaArchivo += ".json";
            using (StreamWriter mylogs = new StreamWriter(mail.RutaArchivo, true)) 
            {
                string json = new JavaScriptSerializer().Serialize(mail);
                mylogs.WriteLine(json);
            }           
        }
    }
}