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
    public class CalisanDetayConcrete : ICalisanDetay
    {
        public IRepository<CalisanDetay> _calisanDetayRepository;
        public IUnitOfWork _calisanDetayUnitOfWork;
        private DbContext _dbContext;

        public CalisanDetayConcrete()
        {
            _dbContext = new Context();
            _calisanDetayUnitOfWork = new EFUnitOfWork(_dbContext);
            _calisanDetayRepository = _calisanDetayUnitOfWork.GetRepository<CalisanDetay>();
        }

    }
}
