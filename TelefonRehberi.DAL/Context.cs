using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DAL.Mappings;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.DAL
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = "server = .; database = TelefonRehberi; uid = sa; pwd = 123";
        }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<CalisanDetay> CalisanDetaylari { get; set; }
        public DbSet<Yonetici> Yoneticiler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CalisanMapping());
            modelBuilder.Configurations.Add(new CalisanDetayMapping());
            modelBuilder.Configurations.Add(new YoneticiMapping());
            modelBuilder.Configurations.Add(new DepartmanMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
