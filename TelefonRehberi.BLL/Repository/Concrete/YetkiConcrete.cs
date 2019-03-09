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
    public class YetkiConcrete : IYetki
    {
        public IRepository<Yetki> _yetkiRepository;
        public IUnitOfWork _yetkiUnitOfWork;
        private DbContext _dbContext;

        public YetkiConcrete()
        {
            _dbContext = new Context();
            _yetkiUnitOfWork = new EFUnitOfWork(_dbContext);
            _yetkiRepository = _yetkiUnitOfWork.GetRepository<Yetki>();
        }
    }
}
