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
    public class ContactController : ApiController
    {
        // GET api/contact
        DataStore db = new DataStore();
        public IEnumerable<Contacto> Get()
        {
            db.Contactos.ToList();
            //return new string[] { "value1", "value2" };
            return db.Contactos.ToList().AsEnumerable();
        }

        // GET api/contact/5
        public Contacto Get(int id)
        {
            return db.Contactos.Find(id); 
        }

        // POST api/contact
        public void Post([FromBody] Contacto contact)
        {
            db.Contactos.Add(contact);
            db.SaveChanges();
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]Contacto contact)
        {
            var tempcontact = db.Contactos.Find(id);
            if (tempcontact != null)
            {
                db.Entry(tempcontact).CurrentValues.SetValues(contact);
                db.SaveChanges();
            }
        }

        // DELETE api/contact/5
        public String Delete(int id)
        {
            try
            {
                Contacto tempcontacto = db.Contactos.Find(id);
                db.Contactos.Remove(tempcontacto);
                db.SaveChanges();
                return "Registro Borrado";
            }
            catch
            {
                return "No fue posible borrar el registro";
            }
        }
    }
}
