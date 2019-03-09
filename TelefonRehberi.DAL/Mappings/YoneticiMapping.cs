using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.DAL.Mappings
{
    public class YoneticiMapping : EntityTypeConfiguration<Yonetici>
    {
        public YoneticiMapping()
        {
            HasKey(x => x.YoneticiID);
            Property(x => x.KullaniciAdi).HasMaxLength(30).IsRequired();
            Property(x => x.Sifre).HasMaxLength(30).IsRequired();
            Property(x => x.AktifMi).IsRequired();
        }
    }
}
