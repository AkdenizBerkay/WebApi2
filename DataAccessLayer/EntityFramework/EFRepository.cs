﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private NorthwindEntities dbcontext;
        private DbSet<T> dbset;
        private static object LockObject = new object();

        public EFRepository()
        {
            dbcontext = RepositoryBase.CreateContext();
            dbcontext.Configuration.ProxyCreationEnabled = false;
            dbset = dbcontext.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = dbset.Find(id);
            if (entity != null)
            {
                dbset.Remove(entity);
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return dbset;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate);
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public void Update(T entity)
        {
            dbcontext.SaveChanges();
        }
    }
}
