using _1.DATA.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Dbcontext
{
    public class SVDbcontext:DbContext
    {
        public SVDbcontext()
        {

        }

        public SVDbcontext(DbContextOptions options) : base(options)
        {
        }
       public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OJ4UDNH\SQLEXPRESS;Initial Catalog=Tes;Persist Security Info=True;User ID=Nbton03;Password=123"));
        }
    }
}
