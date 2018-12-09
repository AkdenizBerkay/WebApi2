using BusinessLayer;
using Entities;
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
    public class LoginController : ApiController
    {
        //public class UserNorth{
        //    public string name { get; set; }
        //    public string surname { get; set; }
        //}

        [HttpGet]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage Get([FromUri] string name, [FromUri] string surname)
        {
            var Perso = ValidationControl.IsPersonel(name, surname);
            if (Perso!=null)
            {
                //UserNorth u = new UserNorth();
                //u.name = Perso.Adi;
                //u.surname = Perso.SoyAdi;
                var jsonstr = Newtonsoft.Json.JsonConvert.SerializeObject(Perso);
                string token = FTH.Extension.Encrypter.Encrypt(jsonstr, "159357");
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Giriş yapılan bilgilere sahip personel bulunmamaktadır.");
            }
        }

        [HttpGet]
        [EnableCors("*","*","*")]
        public HttpResponseMessage GetList()
        {
            Manager<Musteriler> man = new Manager<Musteriler>();
            var list = man.GetAll().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}
