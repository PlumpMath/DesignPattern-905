using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class LogDAO : IProductDAO
    {
        private ILog log { get; set; }
        private IProductDAO dao { get; set;}
        public string Message
        {
            get { return this.Message; }
        }

        public LogDAO(IProductDAO dao, ILog log)
        {
            this.dao = dao;
            this.log = log;
        }

        public void Create(Product product)
        {
            this.dao.Create(product);
            this.log.Info("Create Log dao");
        }

    }
}
