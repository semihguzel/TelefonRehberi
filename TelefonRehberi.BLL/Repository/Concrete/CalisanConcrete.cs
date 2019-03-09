﻿using System;
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
        public IUnitOfWork __calisanUnitOfWork;
        private DbContext _dbContext;

        public CalisanConcrete()
        {
            _dbContext = new Context();
            __calisanUnitOfWork = new EFUnitOfWork(_dbContext);
            _calisanRepository = __calisanUnitOfWork.GetRepository<Calisan>();
        }
    }
}