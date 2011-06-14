using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hilvilla.Dominio;
using Hilvilla.Dominio.Model;
using Hilvilla.Dominio.Repositorios;

namespace Hilvilla.Controllers
{
    public class MotorController : Controller
    {
        //
        // GET: /Motor/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Motor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Motor/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Motor/Create

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
        // GET: /Motor/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Motor/Edit/5

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
        // GET: /Motor/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Motor/Delete/5

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

        public ActionResult Find(string q)
        {
            IRepositorio<Motor> repoP = new MotorRepositorio();
            IList<Motor> Motores = repoP.GetAll();
            IList<Motor> posiblesMotores = new List<Motor>();

            foreach (var item in Motores)
            {
                if (item.Nombre.Contains(q.ToUpper()) || item.Nombre.Contains(q.ToLower()))
                {
                    posiblesMotores.Add(item);
                }
            }
            string[] mot = new string[posiblesMotores.Count];
            int i = 0;
            foreach (var motors in posiblesMotores)
            {
                mot[i] = motors.Nombre+ " "+ motors.Anio.Value.Year;
                i++;
            }

            return Content(string.Join("\n", mot)); ;
        }
    }
}
