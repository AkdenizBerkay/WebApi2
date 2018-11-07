using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class WebApplicationController : Controller
    {
        // GET: WebApplication
        public ActionResult Liste()
        {
            List<Musteriler> list = new List<Musteriler>();
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61886/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "yourusername", "yourpwd"))));
            HttpResponseMessage response;
            response = client.GetAsync("api/ManagerWebApi").Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<Musteriler>>().Result;
            }
            return View(list);
        }

        // GET: WebApplication/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: WebApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebApplication/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebApplication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WebApplication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebApplication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WebApplication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
