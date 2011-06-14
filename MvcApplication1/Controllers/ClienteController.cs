using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Hilvilla.Dominio;
using Hilvilla.Dominio.Model;
using Hilvilla.Dominio.Repositorios;

namespace Hilvilla.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
            IList<Cliente> misClientes = repoCliente.GetAll();
            return View(misClientes);
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id)
        {
            
            IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
            Cliente micliente= repoCliente.GetById(id);
            if(micliente!=null)
            return View(micliente);
            else
            {
                return View();
            }
        }

        //
        // GET: /Cliente/Edit/5
        public ActionResult Edit(int id)
        {

            IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
            Cliente micliente = repoCliente.GetById(id);
            if (micliente != null)
                return View(micliente);
            else
            {
                return View();
            }
        }

        //
        // POST: /Cliente/Edit/

        [HttpPost]
        public ActionResult Edit(Cliente c)
        {
            try
            {
                IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
                repoCliente.Update(c);
                return RedirectToAction("Index");
            }catch(Exception e)
            {

            }
            return View(c);



        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            IEnumerable<string> items = new string[] { "Natural", "Juridico" };
            ViewData["Tipo"] = new SelectList(items);
            return View();
        } 

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(Cliente Persona)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    
                    IRepositorio<Cliente> repo = new ClienteRepositorio();
                    if (Persona.Tipo.Equals("Natural"))
                        Persona.Tipo = "V";
                    else
                        Persona.Tipo = "J";
                    repo.Save(Persona);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
                IEnumerable<string> items = new string[] { "Natural", "Juridico" };
                ViewData["Tipo"] = new SelectList(items);
                return View(Persona);

            }
        }
        
    
        //
        // GET: /Cliente/Delete/5
 
        public ActionResult Delete(int id)
        {
            try
            {
                IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
                repoCliente.Delete(repoCliente.GetById(id));
                return RedirectToAction("Index");
            }catch(Exception e)
            {

            }
            return RedirectToAction("Index");
          
        }


        public ActionResult Find(string q)
        {
            IRepositorio<Cliente> repoP = new ClienteRepositorio();
            IList<Cliente> Clientes = repoP.GetAll();
            IList<Cliente> posiblesAmigos = new List<Cliente>();

            foreach (var item in Clientes)
            {
                if (item.Nombre.Contains(q.ToUpper()) || item.Nombre.Contains(q.ToLower()))
                {
                    posiblesAmigos.Add(item);
                }
            }
            string[] ami = new string[posiblesAmigos.Count];
            int i = 0;
            foreach (var Cliente in posiblesAmigos)
            {
                ami[i] = Cliente.Nombre;
                i++;
            }

            return Content(string.Join("\n", ami)); ;
        }

        //
        // POST: /Cliente/
        [HttpPost]
        public ActionResult Index(HtmlForm form)
        {
            string nick = Request["persona"];

            int[] ids = buscarPorNombre(nick);
            IList<Cliente> milista = new List<Cliente>();
            IRepositorio<Cliente> repo = new ClienteRepositorio();
            if(ids!=null)
            foreach (var id in ids)
            {
                Cliente miPersona = repo.GetById(id);
                milista.Add(miPersona);
            }
           
            
            return View(milista);
        }

        public int[] buscarPorNombre(String nombre)
        {
            IRepositorio<Cliente> repoP = new ClienteRepositorio();
            IList<Cliente> Clientes = repoP.GetAll();
            IList<Cliente> posiblesAmigos = new List<Cliente>();

            foreach (var item in Clientes)
            {
                if (item.Nombre.Contains(nombre))
                {
                    posiblesAmigos.Add(item);
                }
            }
            int[] ids = new int[posiblesAmigos.Count];
            int i = 0;

            foreach (var posiblesAmigo in posiblesAmigos)
            {
                ids[i] = Convert.ToInt32(posiblesAmigo.RifCedula);
            }
            return ids;

        }

    }
}
