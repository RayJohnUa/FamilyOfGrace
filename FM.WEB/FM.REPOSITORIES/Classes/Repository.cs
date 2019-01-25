using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FM.REPOSITORIES.Classes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly FMContext _context;
        protected DbSet<T> _entities;
        string errorMessage = string.Empty;

        public Repository(FMContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public T Get(long id)
        {
            return _entities.SingleOrDefault(s => s.Id == id && !s.IsDelete);
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.IsDelete = true;
            _context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
