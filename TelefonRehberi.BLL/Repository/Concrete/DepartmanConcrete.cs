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
    public class DepartmanConcrete : IDepartman
    {
        public IRepository<Departman> _departmanRepository;
        public IUnitOfWork _departmanUnitOfWork;
        private DbContext _dbContext;

        public DepartmanConcrete()
        {
            _dbContext = new Context();
            _departmanUnitOfWork = new EFUnitOfWork(_dbContext);
            _departmanRepository = _departmanUnitOfWork.GetRepository<Departman>();
        }
    }
}
