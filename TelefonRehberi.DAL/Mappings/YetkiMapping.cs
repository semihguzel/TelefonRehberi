using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.DAL.Mappings
{
    public class YetkiMapping : EntityTypeConfiguration<Yetki>
    {
        public YetkiMapping()
        {
            HasKey(x => x.YetkiID);
            Property(x => x.YetkiAdi).HasMaxLength(50).IsRequired();
        }
    }
}
