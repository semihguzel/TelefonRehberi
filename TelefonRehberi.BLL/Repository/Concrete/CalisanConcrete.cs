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
    public class CalisanConcrete : ICalisan
    {
        public IRepository<Calisan> _calisanRepository;
        public IUnitOfWork _calisanUnitOfWork;
        private DbContext _dbContext;

        public CalisanConcrete()
        {
            _dbContext = new Context();
            _calisanUnitOfWork = new EFUnitOfWork(_dbContext);
            _calisanRepository = _calisanUnitOfWork.GetRepository<Calisan>();
        }

        public bool DoesEmployeeHaveSubordinate(Calisan calisan)
        {
            var employeeSubordinateCount = _calisanRepository.GetEntity().Where(x => x.UstCalisanID == calisan.CalisanID).Count();
            if (employeeSubordinateCount >= 1)
                return true;
            else
                return false;
        }
    }
}
