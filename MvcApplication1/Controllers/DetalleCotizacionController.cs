using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hilvilla.Controllers
{
    public class DetalleCotizacionController : Controller
    {
        //
        // GET: /DetalleCotizacion/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /DetalleCotizacion/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DetalleCotizacion/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DetalleCotizacion/Create

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
        // GET: /DetalleCotizacion/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /DetalleCotizacion/Edit/5

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
        // GET: /DetalleCotizacion/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DetalleCotizacion/Delete/5

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
