using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMails.Controllers
{
    public class StrategyFile
    {
        private InterfaceStrategyFile iStrategy;

        public void setStrategy(InterfaceStrategyFile iStrategy)
        {
            this.iStrategy = iStrategy;
        }

        public void createFile()
        {
            iStrategy.writeFile();
        }
    }
}