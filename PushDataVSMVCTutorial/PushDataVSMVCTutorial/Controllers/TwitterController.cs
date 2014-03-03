using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSDAPILibrary;


namespace PushDataVSMVCTutorial.Controllers
{
    public class TwitterController : Controller
    {
        //
        // GET: /Twitter/
        
        public ActionResult Index()
        {
            return HttpResponses.Ok();
        }

        //
        // GET: /Twitter/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Twitter/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Twitter/Create

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

        //
        // GET: /Twitter/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Twitter/Edit/5

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

        //
        // GET: /Twitter/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Twitter/Delete/5

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
