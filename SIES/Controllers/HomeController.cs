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
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usu = mu.RecuperarDocumento(id);
            return View(usu);
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
            Usuario usr = new Usuario
            {
                Documento = int.Parse(collection["usu_documento"].ToString()),
                TipoDoc = collection["usu_tipoDoc"],
                Nombre = collection["usu_nombre"],
                Celular = int.Parse(collection["usu_celular"].ToString()),
                Email = collection["usu_email"],
                Genero = collection["usu_genero"],
                Aprendiz = collection["usu_aprendiz"],
                Egresado = collection["usu_egresado"],
                AreaFormacion = collection["usu_areaFormacion"],
                FechaEgresado = DateTime.Parse(collection["usu_fechaEgresado"]),
                Direccion = collection["usu_direccion"],
                Barrio = collection["usu_barrio"],
                Ciudad = collection["usu_ciudad"],
                Departamento = collection["usu_departamento"],
                FechaRegistro = DateTime.Parse(collection["usu_fechaRegistro"]),
            };

            mu.AgregarUsuario(usr);
            return RedirectToAction("ConsultarTodos");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usu = mu.RecuperarDocumento(id);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = new Usuario
            {
                Id = id,
                Documento = int.Parse(collection["usu_documento"].ToString()),
                TipoDoc = collection["tipodocumento"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Celular = int.Parse(collection["celular"].ToString()),
                Email = collection["email"].ToString(),
                Genero = collection["genero"].ToString(),
                Aprendiz = collection["aprendiz"].ToString(),
                Egresado = collection["egresado"].ToString(),
                AreaFormacion = collection["areaformacion"].ToString(),
                FechaEgresado = DateTime.Parse(collection["fechaegresado"].ToString()),
                Direccion = collection["direccion"].ToString(),
                Barrio = collection["barrio"].ToString(),
                Ciudad = collection["ciudad"].ToString(),
                Departamento = collection["departamento"].ToString(),
                FechaRegistro = DateTime.Parse(collection["fecharegistro"].ToString())
            };
            ma.Modificar(usu);
            return RedirectToAction("ConsultarTodos");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            Usuario usu = mu.RecuperarDocumento(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoUsuario mu = new MantenimientoUsuario();
            mu.Eliminar(id);
            return RedirectToAction("ConsultarTodos");
        }
    }
}
