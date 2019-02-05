using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiMails.Contexto;
using WebApiMails.Models;

namespace WebApiMails.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CorreoController : ApiController
    {
        DataStore db = new DataStore();
        // GET api/correo
        public IEnumerable<Correo> Get()
        {
            db.Contactos.ToList();
           
            return db.Correos.ToList().AsEnumerable();
        }

        // GET api/correo/5
        public Correo Get(int id)
        {
            return db.Correos.Find(id); 
        }

        // POST api/correo
        public void Post([FromBody]Correo mail)
        {
            db.Correos.Add(mail);
            db.SaveChanges();
        }

        // PUT api/correo/5
        public void Put(int id, [FromBody]string value)
        {
            var tempcontact = db.Contactos.Find(id);
            if (tempcontact != null)
            {
                db.Entry(tempcontact).CurrentValues.SetValues(contact);
                db.SaveChanges();
            }
        }

        // DELETE api/correo/5
        public void Delete(int id)
        {
        }
    }
}
