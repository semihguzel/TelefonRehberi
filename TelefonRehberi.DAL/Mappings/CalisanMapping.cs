using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.DAL.Mappings
{
    public class CalisanMapping : EntityTypeConfiguration<Calisan>
    {
        public CalisanMapping()
        {
            ToTable("Calisanlar");

            HasKey(x => x.CalisanID);
            Property(x => x.CalisanAdi).HasMaxLength(75).IsRequired();
            Property(x => x.CalisanSoyadi).HasMaxLength(75).IsRequired();
            Property(x => x.Telefon).HasColumnType("nchar").HasMaxLength(13).IsRequired();
            Property(x => x.UstCalisanID).IsOptional();

            HasRequired(x => x.CalisanDetay).WithRequiredPrincipal(x => x.Calisan);

        }
    }
}
