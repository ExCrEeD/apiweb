using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMails.Models;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace WebApiMails.Controllers
{
    public class XmlStrategy: InterfaceStrategyFile
    {
        private EmailsHistorial mail;
        public XmlStrategy(EmailsHistorial mail)
        {
            this.mail = mail;
        }
        public void writeFile()
        {
            mail.RutaArchivo += ".xml";
            using (StreamWriter mylogs = new StreamWriter(mail.RutaArchivo, true))
            {
                XmlSerializer serializador = new XmlSerializer(typeof(EmailsHistorial));
                StringBuilder sb = new StringBuilder();
                TextWriter tw = new StringWriter(sb);
                serializador.Serialize(tw, mail);
                tw.Close();
                string xml = sb.ToString();
                mylogs.WriteLine(xml);
            }     

        }
    }
}