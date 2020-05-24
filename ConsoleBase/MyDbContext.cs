using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBase
{
    public class MyDbContext1 : DbContext
    {
        public MyDbContext1() : base("DbConnectionString")
        {
        }

        public DbSet<Table_1> Table_1s { get; set; }

        public DbSet<test1> test1s { get; set; }
    }
}
