using Dominio.EntidadesNegocio;
using MVC.Models;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class InversorRegistroController : Controller
    {

        RepoUsuarios miRepo = new RepoUsuarios();

        // GET: InversorRegistro
        public ActionResult Index()
        {
            return View();
        }

        // GET: InversorRegistro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InversorRegistro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InversorRegistro/Create
        [HttpPost]
        public ActionResult Create(InversorModel unInversor)
        {
            unInversor.TipoUsuario = "I";
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //validacion precaria de mayoria de edad +21
                    if (unInversor.FechaNac.Year < DateTime.Now.Year - 21)
                    {
                        Inversor inversor = PasarModelAInversor(unInversor);
                        if (miRepo.Add(inversor))
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(unInversor);
            }
            catch
            {
                return View();
            }
        }

        private Inversor PasarModelAInversor(InversorModel unInversor)
        {
            if (unInversor != null)
            {
                return new Inversor
                {
                    Ci=unInversor.Ci,
                    Password = unInversor.Password,
                    TipoUsuario = "I",
                    Nombre = unInversor.Nombre,
                    Apellido = unInversor.Apellido,
                    FechaNac = unInversor.FechaNac,
                    Celular = unInversor.Celular,
                    PrestamoMaximo = unInversor.PrestamoMaximo,
                    Descripcion = unInversor.Descripcion
                };
            }
            return null;
        }

        // GET: InversorRegistro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InversorRegistro/Edit/5
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

        // GET: InversorRegistro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InversorRegistro/Delete/5
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
