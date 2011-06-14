using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Hilvilla.Dominio;
using Hilvilla.Dominio.Model;
using Hilvilla.Dominio.Repositorios;
using Hilvilla.Models;

namespace Hilvilla.Controllers
{
    public class FacturarController : Controller
    {
        //
        // GET: /Facturar/

        public ActionResult Index()
        {
            IRepositorio<Cotizacion> repoCotizacion = new CotizacionRepositorio();
            var listaCot = repoCotizacion.GetAll();
            if (listaCot != null)
            {
                IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
                foreach (var cotizacion in listaCot)
                {
                    cotizacion.Cliente = repoCliente.GetById(cotizacion.Cliente.RifCedula);
                }
                return View(listaCot);
            }
            else
            {
                return View(new List<Cotizacion>());
            }

        }

        public ActionResult Report(int id)
        {
            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load("D:/Presupuesto2.rpt");
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = id;
            crParameterFieldDefinitions = rptDoc.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["myid"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            Stream stream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        //
        // GET: /Facturar/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Facturar/Create

        public ActionResult Create()
        {
            IRepositorio<Detalle> repoDetalle = new DetalleRepositorio();
            var items = repoDetalle.GetAll();
            ViewData["Tipo"] = items;
            IRepositorio<Marca> repoMarca = new MarcaRepositorio();
            var items2 = repoMarca.GetAll();
            var items3 = new List<String>();
            foreach (var marca in items2)
            {
                items3.Add(marca.Nombre);
            }
            ViewData["marcas"] = new SelectList(items3);
            items3 = new List<String>();
            items3.Add("Seleccione Marca");
            ViewData["motores"] = new SelectList(items3);
            items3.Add("Seleccione Motor");
            ViewData["tipos"] = new SelectList(items3);
            return View();
        }

        //
        // POST: /Facturar/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Motor myMotor = new Motor();
                IRepositorio<Detalle> repoDetalle = new DetalleRepositorio();
                IRepositorio<Motor> repoMotor = new MotorRepositorio();
                var items = repoDetalle.GetAll();
                String nameCliente = collection[0];
                int idMotor = Convert.ToInt32(collection[2]);
                Cliente miCliente = BuscarClientePorNombre(nameCliente);
                Motor miMotor = repoMotor.GetById(idMotor);
                IRepositorio<Cotizacion> repoCotizacion = new CotizacionRepositorio();
                Cotizacion miCotizacion = new Cotizacion();
                miCotizacion.Cliente = miCliente;
                miCotizacion.Motor = miMotor;
                miCotizacion.Fecha = DateTime.Now;
                miCotizacion.Tipo = "F";
                miCotizacion.Control = collection[4];
                int ultimoId = repoCotizacion.Save(miCotizacion);
                String idDetalle = "";
                String cantidad = "";
                IRepositorio<CotizacionDetalle> repoCotizacionDetalle = new CotizacionDetalleRepositorio();
                for (int i = 5; i < collection.Count - 1; i = i + 3)
                {
                    cantidad = collection[i];
                    idDetalle = collection.Keys[i + 1];
                    CotizacionDetalle myCotizacionDetalle = new CotizacionDetalle();
                    myCotizacionDetalle.IdCotizacion = ultimoId;
                    myCotizacionDetalle.IdDetalle = Convert.ToInt32(idDetalle);
                    myCotizacionDetalle.Cantidad = Convert.ToInt32(cantidad);
                    myCotizacionDetalle.Fecha = DateTime.Now;
                    myCotizacionDetalle.Cotizacion = repoCotizacion.GetById(ultimoId);
                    myCotizacionDetalle.Detalle = repoDetalle.GetById(Convert.ToInt32(idDetalle));
                    repoCotizacionDetalle.Save(myCotizacionDetalle);
                }

                return RedirectToAction("Report", new { id = ultimoId });
            }
            catch (Exception e)
            {
                return View(collection);
            }


        }

        [HttpGet]
        public ActionResult tipoMotor(int val)
        {

            IRepositorio<Detalle> repoDetalle = new DetalleRepositorio();
            IRepositorio<Tipo> repoTipo = new TipoRepositorio();
            Tipo t = repoTipo.GetById(val);
            var items = repoDetalle.GetAll();
            var detalles = new List<Detalle>();
            foreach (var detalle in items)
            {
                if (detalle.Tipo == t.Nombre || detalle.Tipo == "G")
                    detalles.Add(detalle);
            }
            String html = "";
            html += "<table border=1> <tr> <th> <label style=\" width:500\">Descripcion</label></th> <th> Precio</th><th>Cantidad</th><th>Check</th><th>Total</th></tr>";
            foreach (var detalle in detalles)
            {
                html += "<tr><td><label>" + detalle.Descripcion + "</label><td> <label>" + detalle.Costo + "</label></td>";
                html += "<td onMouseOver= \"mouse1(document.presupuesto.text" + detalle.IdDetalle + ")\" onMouseOut= \"mouse2(document.presupuesto.text" + detalle.IdDetalle + ")\">";
                html += "<input type=\"text\" name=\"text" + detalle.IdDetalle + "\" style =\" width:50px ;  disabled ='disabled' \" /></td><td>";
                html += "<input  type=\"checkbox\" id=\"ch" + detalle.IdDetalle + "\" name=\"" +
                        detalle.IdDetalle + "\" value=\"ch" + detalle.IdDetalle + "\" onclick =\"producto(" +
                        detalle.Costo + "," + "document.presupuesto.text" + detalle.IdDetalle +
                        ".value, document.presupuesto.label" + detalle.IdDetalle + ", document.presupuesto.ch" +
                        detalle.IdDetalle + ", document.presupuesto.text" + detalle.IdDetalle + ")\" />";
                html += "</td><td>";
                html += "<input type=text name=\"label" + detalle.IdDetalle +
                        "\" style =\" width:50px ;  disabled = 'disabled' \" /></td></tr>";
            }
            html += "</table>";
            List<JsonSelectObject> citiesList = new List<JsonSelectObject>();
            JsonSelectObject myJsonSelectObject = new JsonSelectObject();
            myJsonSelectObject.Text = "";
            myJsonSelectObject.Value = html;
            myJsonSelectObject.When = val.ToString();
            citiesList.Add(myJsonSelectObject);
            return Json(citiesList, JsonRequestBehavior.AllowGet);

        }

        public Cliente BuscarClientePorNombre(String name)
        {
            IRepositorio<Cliente> repoCliente = new ClienteRepositorio();
            IList<Cliente> misClientes = repoCliente.GetAll();
            foreach (var miCliente in misClientes)
            {
                if (miCliente.Nombre.Equals(name))
                    return miCliente;
            }
            return null;
        }

        public Motor BuscarMotorPorNombre(String name)
        {
            IRepositorio<Motor> repoMotor = new MotorRepositorio();
            IList<Motor> misMotores = repoMotor.GetAll();
            foreach (var miMotor in misMotores)
            {

                if (miMotor.Nombre.Equals(name))
                    return miMotor;
            }
            return null;
        }


        //
        // GET: /Facturar/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Facturar/Edit/5

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
        // GET: /Facturar/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Facturar/Delete/5

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

        [HttpGet]
        public ActionResult GetMotores()
        {

            IRepositorio<Motor> repoMotor = new MotorRepositorio();
            IList<Motor> query2 = repoMotor.GetAll();
            IRepositorio<Marca> repoMarca = new MarcaRepositorio();
            IList<Marca> query = repoMarca.GetAll();
            List<JsonSelectObject> citiesList = new List<JsonSelectObject>();

            foreach (var marca in query)
            {
                foreach (var motor in query2)
                {
                    if (marca.IdMarca == motor.Marca.IdMarca)
                        citiesList.Add(new JsonSelectObject
                        {
                            When = marca.Nombre,
                            Value = motor.IdMotor.ToString(),
                            Text = motor.Nombre
                        });
                }

            }
            return Json(citiesList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTipos()
        {

            IRepositorio<Motor> repoMotor = new MotorRepositorio();
            IList<Motor> query2 = repoMotor.GetAll();
            IRepositorio<Tipo> repoTipo = new TipoRepositorio();
            IList<Tipo> query = repoTipo.GetAll();
            List<JsonSelectObject> citiesList = new List<JsonSelectObject>();

            foreach (var tipo in query)
            {
                foreach (var motor in query2)
                {
                    if (tipo.IdTipo == motor.Tipo.IdTipo)
                        citiesList.Add(new JsonSelectObject
                        {
                            When = motor.IdMotor.ToString(),
                            Value = tipo.IdTipo.ToString(),
                            Text = tipo.Nombre
                        });
                }

            }
            return Json(citiesList, JsonRequestBehavior.AllowGet);
        }
    }
}
