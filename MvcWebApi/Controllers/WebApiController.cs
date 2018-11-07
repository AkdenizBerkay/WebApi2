using MyEverNote.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebApi.Controllers
{
    public class WebApiController<T> : ApiController where T : class
    {
        Manager<T> man = new Manager<T>();

        // GET: api/WebApi
        public IQueryable<T> GetAll()
        {
            return man.GetAll();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return man.GetAll(predicate);
        }
        // GET: api/WebApi/5
        public T GetById(int id)
        {
            return man.GetById(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return man.Get(predicate);
        }

        // POST: api/WebApi
        public void Post(T entity)
        {
            man.Add(entity);
        }

        // PUT: api/WebApi/5
        public void Put(int id, [FromBody]string value)
        {
        }
        public void Update(T entity)
        {
            cef.Update(entity);
        }

        // DELETE: api/WebApi/5
        public void Delete(int id)
        {
        }
    }
}
