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
    public class SendMailsController : ApiController
    {
        DataStore db = new DataStore();
        // GET api/sendmails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value3" };
        }
        // POST api/sendmails
        public void Post([FromBody]EmailsHistorial email)
        {
            StrategyFile strategy = new StrategyFile();
            if (email.Formato == "Json")
            {
                strategy.setStrategy(new JsonStrategy(email));
            }
            else
            {
                strategy.setStrategy(new XmlStrategy(email));
            }
            strategy.createFile();
            db.EmailHistory.Add(email);
            db.SaveChanges();
        }
    }
}
