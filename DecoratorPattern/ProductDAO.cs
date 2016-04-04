using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class ProductDAO : IProductDAO
    {
        public string Messages { get; set; }

        public void Create(Product product)
        {
            Console.WriteLine("呼叫ProductDAO Create 建立產品");
            this.Messages = "建立成功";
        }

        public void Update(Product product)
        {
            Console.WriteLine("更新產品");
            this.Messages = "更新成功";
        }

    }
}
