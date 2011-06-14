using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hilvilla.Dominio.Model;
using Hilvilla.Dominio.Repositorios;

namespace Hilvilla.Controllers
{
    public class MarcaController : Controller
    {
        //
        // GET: /Marca/

        public ActionResult Index()
        {
            var repoMarca = new MarcaRepositorio();
            IList<Marca> misMarcas = repoMarca.GetAll();
            return View(misMarcas);
        }

        //
        // GET: /Marca/Details/5

        public ActionResult Details(int id)
        {
            var repoMarca = new MarcaRepositorio();
            Marca miMarca = repoMarca.GetById(id);
            return View(miMarca);
        }

        //
        // GET: /Marca/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Marca/Create

        [HttpPost]
        public ActionResult Create(Marca m)
        {
            try
            {
                var repoMarca = new MarcaRepositorio();
                repoMarca.Save(m);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Marca/Edit/5
 
        public ActionResult Edit(int id)
        {
            var repoMarca = new MarcaRepositorio();
            Marca m =repoMarca.GetById(id);
            return View(m);
        }

        //
        // POST: /Marca/Edit/5

        [HttpPost]
        public ActionResult Edit(Marca m)
        {
            try
            {
                var repoMarca = new MarcaRepositorio();
                repoMarca.Update(m);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Marca/Delete/5
 
        public ActionResult Delete(int id)
        {
            var repoMarca = new MarcaRepositorio();
            Marca m = repoMarca.GetById(id);
            return View(m);
        }

        //
        // POST: /Marca/Delete/5

        [HttpPost]
        public ActionResult Delete(Marca m)
        {
            try
            {
                var repoMarca = new MarcaRepositorio();
                repoMarca.Delete(m);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
