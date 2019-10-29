using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim_OA.Data
{
    public class NewDbContext : DbContext
    {
        public NewDbContext() : base() { }
        public DbSet<Car> Cars { get; set; }
    }
}
