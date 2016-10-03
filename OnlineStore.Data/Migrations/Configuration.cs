using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Migrations
{
    internal class Configuration : DbMigrationsConfiguration<OnlineStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
