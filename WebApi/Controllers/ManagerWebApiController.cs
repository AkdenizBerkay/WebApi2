using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Filters;

namespace WebApi.Controllers
{
    //[CustomTokenAuthorize]
    [MyAuthorization]
    public class ManagerWebApiController : ApiController
    {
        //Manager<T> man = new Manager<T>();

        // GET: api/ManagerWebApi
        //[RequiredSSL]
        [HttpGet]
        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {
            Manager<Entities.Musteriler> man = new Manager<Entities.Musteriler>();
            var list = man.GetAll().ToList();
            return Ok(list);
        }

        // GET: api/ManagerWebApi/5
        //public IHttpActionResult Get(int id)
        //{
        //    var obj = man.GetById(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(obj);
        //}

        //// POST: api/ManagerWebApi
        //public IHttpActionResult Post(T obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        man.Add(obj);
        //        return Created("DefaultApi", obj);
        //    }

        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //// PUT: api/ManagerWebApi/5
        //public IHttpActionResult Put(int id, T obj)
        //{
        //    T oldobj = man.GetById(id);

        //    if (oldobj == null)
        //    {
        //        return NotFound();
        //    }
        //    else if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    else
        //    {
        //        man.Update(obj);
        //        return Ok(obj);
        //    }
        //}

        //// DELETE: api/ManagerWebApi/5
        //public IHttpActionResult Delete(int id)
        //{
        //    T delobj = man.GetById(id);

        //    if (delobj == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        man.Delete(delobj);
        //        return Ok(delobj);
        //    }
        //}
    }
}
