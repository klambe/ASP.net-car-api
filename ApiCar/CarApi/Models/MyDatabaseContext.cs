using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarApi.Models
{
    public class MyDatabaseContext : DbContext
    {
        
    
        public MyDatabaseContext() : base("name=MyDbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDatabaseContext>());
        }

        public System.Data.Entity.DbSet<CarApi.Models.Car> Cars { get; set; }
    }
}
