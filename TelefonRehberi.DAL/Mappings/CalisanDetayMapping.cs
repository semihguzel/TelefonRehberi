using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.DAL.Mappings
{
    public class CalisanDetayMapping : EntityTypeConfiguration<CalisanDetay>
    {
        public CalisanDetayMapping()
        {
            ToTable("CalisanDetaylari");
            HasKey(x => x.CalisanID);
            Property(x => x.Cinsiyet).IsRequired();
            Property(x => x.Adres).HasMaxLength(500);

            HasRequired(x => x.Departman).WithMany(x => x.CalisanDetaylari).HasForeignKey(x => x.DepartmanID);

            HasRequired(x => x.Yetki).WithMany(x => x.CalisanDetaylari).HasForeignKey(x => x.YetkiID);

        }
    }
}
