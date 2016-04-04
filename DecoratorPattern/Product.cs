using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Product
    {
        public string Message { get; set; }

        public Product()
        {

        }

        public Product(IProductDAO productDao)
        {
            ProductDAO = productDao;
        }

        public IProductDAO ProductDAO { get; set; }

        public void Create(Product produc)
        {
            ProductDAO.Create(produc);
            //this.Message = ProductDAO;
            Console.WriteLine("呼叫Product Create 建立產品");
        }
    }
}
