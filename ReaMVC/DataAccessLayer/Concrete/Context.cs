using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{

    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-I0GI83O\\MSSQLSERVERSS;database=MyWeb;integrated security=true;");
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
