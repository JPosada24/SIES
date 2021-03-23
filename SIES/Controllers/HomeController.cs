using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIES.Models;

namespace SIES.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarTodos()
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            return View(mu.RecuperarTodo());
        }


        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usu = new Usuario
            {
                Documento = long.Parse(collection["usu_documento"]),
                TipoDoc = collection["usu_tipoDoc"],
                Nombre = collection["usu_nombre"],
                Celular = long.Parse(collection["usu_celular"]),
                Email = collection["usu_email"],
                Genero = collection["usu_genero"],
                Aprendiz = collection["usu_aprendiz"],
                Egresado = collection["usu_egresado"],
                AreaFormacion = collection["usu_areaFormacion"],
                FechaEgresado = DateTime.Parse(collection["usu_fechaEgresado"]),
                Direccion = collection["usu_direccion"],
                Barrio = collection["usu_barrio"],
                Ciudad = collection["usu_ciudad"],
                Departamento = collection["usu_departamento"]
                //FechaRegistro = DateTime.Parse(collection["usu_fechaRegistro"].ToString())
            };

            mu.AgregarUsuario(usu);
            return RedirectToAction("ConsultarTodos");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
