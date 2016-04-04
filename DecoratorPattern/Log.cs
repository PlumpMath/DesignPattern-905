using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Log : ILog
    {
        public void Info(string info)
        {
            Console.WriteLine("=====LOG START=====");
            Console.WriteLine(info);
            Console.WriteLine("=====LOG END=====");
        } 
    }
}
