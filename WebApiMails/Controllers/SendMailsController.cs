using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiMails.Contexto;
using WebApiMails.Models;

namespace WebApiMails.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SendMailsController : ApiController
    {
        DataStore db = new DataStore();
        // GET api/sendmails
        public IEnumerable<EmailsHistorial> Getall()
        {
            return db.EmailHistory.ToList().AsEnumerable();
        }
        // GET api/sendmails/GetFile/int
        public HttpResponseMessage GetFile(int id)
        {
            var email = db.EmailHistory.Find(id);
            string fileName = "mail." + email.Formato;
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream file = new FileStream(email.RutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);
                    HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                    httpResponseMessage.Content = new ByteArrayContent(bytes.ToArray());
                    httpResponseMessage.Content.Headers.Add("x-filename", fileName);
                    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    return httpResponseMessage;
                }
            }
        }
        // GET api/sendmails
        public IEnumerable<EmailsHistorial> GetReportFilter([FromUri]EmailsHistorial email)
        {
            IEnumerable<EmailsHistorial> query = db.EmailHistory.ToList();
            if (!String.IsNullOrEmpty(email.De))
                query = query.Where(a => a.De == email.De);
            if (!String.IsNullOrEmpty(email.Para))
                query = query.Where(a => a.Para == email.Para);
            if (!String.IsNullOrEmpty(email.Cc))
                query = query.Where(a => a.Cc == email.Cc);
            if (!String.IsNullOrEmpty(email.Bcc))
                query = query.Where(a => a.Cc == email.Bcc);
            if (!String.IsNullOrEmpty(email.Bcc))
                query = query.Where(a => a.Cc == email.Bcc);
            if (!String.IsNullOrEmpty(email.Formato))
                query = query.Where(a => a.Formato == email.Formato);
            if (email.Fecha.Year >1)
                query = query.Where(a => a.Fecha.ToShortDateString() == email.Fecha.ToShortDateString());

            return query;
        }

        // POST api/sendmails
        public void Post([FromBody]EmailsHistorial email)
        {
            
            db.EmailHistory.Add(email);
            db.SaveChanges();
            //var countOfRows = db.EmailHistory.Count();
            //email = db.EmailHistory.OrderBy(c => 1 == 1).Skip(countOfRows - 1).FirstOrDefault();
            email.RutaArchivo = @"C:\EmailFiles\" + email.Id.ToString();
            StrategyFile strategy = new StrategyFile();
            if (email.Formato == "json")
            {
                strategy.setStrategy(new JsonStrategy(email));
            }
            else
            {
                strategy.setStrategy(new XmlStrategy(email));
            }
            strategy.createFile();
            db.Entry(email).CurrentValues.SetValues(email);
            db.SaveChanges();
        }
    }
}
