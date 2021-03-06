﻿using System;
using System.Collections.Generic;
using System.Text;
using br.procon.si.api.fornecedor.infra;

namespace br.procon.si.api.fornecedor.domain
{
    public class BaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;    
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void SaveChanges()
        {
            _uow.SaveChanges();
        }
    }
}
