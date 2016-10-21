using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Common.Contracts.ResponseMessages
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rank { get; set; }
    }
}
