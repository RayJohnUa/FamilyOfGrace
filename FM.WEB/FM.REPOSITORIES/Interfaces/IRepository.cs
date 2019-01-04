﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM.DATA;
using Microsoft.EntityFrameworkCore;

namespace FM.REPOSITORIES.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}