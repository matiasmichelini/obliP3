using Dominio.EntidadesNegocio;
using Repositorios;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfServicio;
using System.Data.Entity;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CargaDeDatos()
        {
           
            ServicioUsuarios miservicio = new ServicioUsuarios();

            List<DtoSolicitante> solicitantes = miservicio.AgregarSolicitantes();

            List<Solicitante> misSolicitantes = MapeoDtoSolicitanteAsolicitante(solicitantes);


            //agrego admin
            RepoUsuarios miRepoUsuarios = new RepoUsuarios();

            Admin admin = new Admin
            {
                Ci = "admin",
                Password = "admin",
                TipoUsuario = "A"
            };

            miRepoUsuarios.Add(admin);


            RepoUsuarios miRepoUsuario = new RepoUsuarios();

            foreach (Solicitante s in misSolicitantes)
            {
                if (miRepoUsuario.FindById(s.Ci) == null)
                {
                    miRepoUsuario.Add(s);
                    ViewBag.mensaje = "Los usuarios se agregaron correctamente";
                }
                else
                {
                    ViewBag.mensaje = "Los usuarios ya existen.";
                }
            }



            RepoProyectos miRepoProy = new RepoProyectos();


            List<DtoPersonal> personales = miservicio.AgregarPersonales();

            List<Personal> misPersonales = MapeoDtoPersonalAPersonal(personales);

            RepoProyectosAnalizados miRepoAnalizados = new RepoProyectosAnalizados();
            List<ProyectoAnalizado> misAnalizados = new List<ProyectoAnalizado>();

            foreach (Personal p in misPersonales)
            {

               
                if (miRepoProy.FindById(p.Id) == null)
                {
                    miRepoProy.Add(p);

                    
                   
                    ProyectoAnalizado miAnalizado = new ProyectoAnalizado {
                        Id = p.Id,
                        Fecha = DateTime.Now,
                        MontoTotal = 0,
                        CuotaTotal = 0,
                        TasaInteres = p.CantCuotas,
                        Puntaje = new Random().Next(6,10),
                        Estado = "Abierto",
                        AdminCi = admin.Ci,
                        Admin = admin,
                        ProyectoId = p.Id,
                        Proyecto = p
                    };

                    miAnalizado.CuotaTotal = p.MontoSolicitado * miAnalizado.TasaInteres / 100;
                    miAnalizado.MontoTotal = miAnalizado.CuotaTotal * p.CantCuotas;

                    miRepoAnalizados.Add(miAnalizado);

                    ViewBag.mensaje2 = "Los Proyectos Personales se agregaron correctamente.";
                }
                else
                {
                    ViewBag.mensaje2 = "Los Proyectos Personales no se agregaron.";
                }
            }

            List<DtoCooperativo> cooperativos = miservicio.AgregarCooperativos();

            List<Cooperativo> misCooperativos = MapeoDtoCooperativoACooperativo(cooperativos);

            foreach (Cooperativo c in misCooperativos)
            {
                if (miRepoProy.FindById(c.Id) == null)
                {
                    miRepoProy.Add(c);

                    ProyectoAnalizado miAnalizado = new ProyectoAnalizado
                    {
                        Id = c.Id,
                        Fecha = DateTime.Now,
                        MontoTotal = 0,
                        CuotaTotal = 0,
                        TasaInteres = c.CantCuotas,
                        Puntaje = new Random().Next(6, 10),
                        Estado = "Abierto",
                        AdminCi = admin.Ci,
                        Admin = admin,
                        ProyectoId =c.Id,
                        Proyecto=c

                    };

                    miAnalizado.CuotaTotal = c.MontoSolicitado * miAnalizado.TasaInteres / 100;
                    miAnalizado.MontoTotal = miAnalizado.CuotaTotal * c.CantCuotas;

                    miRepoAnalizados.Add(miAnalizado);

                    ViewBag.mensaje3 = "Los Proyectos Cooperativos se agregaron correctamente.";
                }
                else
                {
                    ViewBag.mensaje3 = "Los Proyectos Cooperativos no se agregaron.";
                }
            }

            return View("Index");
        }

        private List<Cooperativo> MapeoDtoCooperativoACooperativo(List<DtoCooperativo> cooperativos)
        {
            List<Cooperativo> misCooperativos = new List<Cooperativo>();


            foreach (DtoCooperativo c in cooperativos)
            {
                Cooperativo miCoop = new Cooperativo
                {
                    Id = c.Id,
                    Titulo = c.Titulo,
                    Descripcion = c.Descripcion,
                    MontoSolicitado = c.MontoSolicitado,
                    CantCuotas = c.CantCuotas,
                    Imagen = c.Imagen,
                    Fecha = c.Fecha,
                    SolicitanteCi = c.SolicitanteCi,
                    Integrantes = c.Integrantes
                };

                misCooperativos.Add(miCoop);

            }

            return misCooperativos;
        }

        private List<Personal> MapeoDtoPersonalAPersonal(List<DtoPersonal> personales)
        {
            List<Personal> misPersonales = new List<Personal>();


            foreach (DtoPersonal p in personales)
            {
                Personal miP = new Personal
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descripcion = p.Descripcion,
                    MontoSolicitado = p.MontoSolicitado,
                    CantCuotas = p.CantCuotas,
                    Imagen = p.Imagen,
                    Fecha = p.Fecha,
                    SolicitanteCi = p.SolicitanteCi,
                    ExpProy = p.ExpProy
                    
                };

                misPersonales.Add(miP);
            }
            return misPersonales;
        }

        private List<Solicitante> MapeoDtoSolicitanteAsolicitante(List<DtoSolicitante> solicitantes)
        {
            List<Solicitante> misSolicitantes = new List<Solicitante>();
            

            foreach (DtoSolicitante s in solicitantes)
            {
                Solicitante miSol = new Solicitante
                {
                    Ci = s.Ci,
                    Password = s.Password,
                    TipoUsuario = s.TipoUsuario,
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    FechaNac = s.FechaNac,
                    Celular = s.Celular
                };

                misSolicitantes.Add(miSol);

            }

            return misSolicitantes;
        }


        [HttpGet]
        public ActionResult Login()
        {
            //string model=null;

            return View();
        }

        [HttpPost]
        public ActionResult Login( Inversor model)
        {
            try
            {
                using (var db = new ObliContext())
                {
                    RepoUsuarios miRepo = new RepoUsuarios();
                    Usuario unUsuario = miRepo.FindById(model.Ci);

                    if (unUsuario != null)
                    {
                        if (unUsuario.Ci==model.Ci && unUsuario.Password==model.Password)
                        { 
                            if (unUsuario.TipoUsuario == "A")
                            {
                                Session["A"] = "A";
                            }
                            if (unUsuario.TipoUsuario == "I")
                            {
                                Session["I"] = "I";
                            }

                            return RedirectToAction("ListarProyectos", "Home");
                        }
                    }
                }


            }
            catch
            {
                return View();
            }

            return View();
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {


            if (Session["A"] != null)
            {
                Session.Remove("A");
                return RedirectToAction("Login");
            }
            if (Session["I"] != null)
            {
                Session.Remove("I");
                return RedirectToAction("Login");
            }
            return View();
        }

       

        public ActionResult ListarProyectos()
        {

            using(ObliContext db = new ObliContext())
            {

                //arreglar este listado

                List<Proyecto> misProy = new List<Proyecto>();
                foreach(Proyecto p in db.Proyectos)
                {
                    misProy.Add(p);
                }
                return View(misProy);

            }

            
        }
        
    }
}