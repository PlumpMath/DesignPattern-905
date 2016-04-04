using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var productDAO = new ProductDAO();
            var log = new Log();
            var logDAO = new LogDAO(productDAO,log);

            var result = new Product(logDAO);

            result.Create(new Product());

            Console.ReadKey();

            Product a = new Product();
            Console.ReadKey();

        }
    }
}
