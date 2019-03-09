using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.DAL.Mappings
{
    public class DepartmanMapping : EntityTypeConfiguration<Departman>
    {
        public DepartmanMapping()
        {
            HasKey(x => x.DepartmanID);
            Property(x => x.DepartmanAdi).HasMaxLength(100).IsRequired();
            Property(x => x.Aciklama).HasMaxLength(500);

        }
    }
}
