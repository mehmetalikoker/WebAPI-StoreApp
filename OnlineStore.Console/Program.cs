using OnlineStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new OnlineStoreContext();

            var productList = context.Products.ToList();
        }
    }
}
