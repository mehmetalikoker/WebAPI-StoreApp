using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class User : EntityBase<int>
    {
        public User()
        {
            AllowedCategories = new List<Category>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }

        // bu kullanıcı hangi kategorileri görmeye yetkili
        public virtual ICollection<Category> AllowedCategories { get; set; }
    }
}
