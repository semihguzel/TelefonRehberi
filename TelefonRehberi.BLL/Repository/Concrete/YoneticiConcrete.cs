using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.BLL.Repository.Abstract;
using TelefonRehberi.DAL;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.BLL.Repository.Concrete
{
    public class YoneticiConcrete : IYonetici
    {
        public IRepository<Yonetici> _yoneticiRepository;
        public IUnitOfWork _yoneticiUnitOfWork;
        private DbContext _dbContext;

        public YoneticiConcrete()
        {
            _dbContext = new Context();
            _yoneticiUnitOfWork = new EFUnitOfWork(_dbContext);
            _yoneticiRepository = _yoneticiUnitOfWork.GetRepository<Yonetici>();
        }

        public bool Login(string username, string password)
        {
           var user = _yoneticiRepository.GetEntity().FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == password);
            if (user == null)
                return false;
            else
                return true;
        }
    }
}
