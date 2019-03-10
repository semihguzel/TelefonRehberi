namespace TelefonRehberi.DAL.Migrations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TelefonRehberi.DATA.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TelefonRehberi.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TelefonRehberi.DAL.Context context)
        {
            if (context.Yoneticiler.FirstOrDefault(x => x.KullaniciAdi == "admin") == null)
            {
                context.Yoneticiler.Add(new Yonetici() { KullaniciAdi = "admin", Sifre = "123", AktifMi = true });
                context.SaveChanges();
            }
            if (context.Yetkiler.ToList().Count == 0)
            {
                context.Yetkiler.AddRange(new List<Yetki>() { new Yetki() { YetkiAdi = "Müdür" }, new Yetki() { YetkiAdi = "Uzman" }, new Yetki() { YetkiAdi = "Stajyer" } } );
                context.SaveChanges();
            }
        }
    }
}
