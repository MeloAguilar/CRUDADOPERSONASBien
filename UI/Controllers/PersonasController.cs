using BL.GestionBL;
using BL.ListasBL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace UI.Controllers
{
    public class PersonasController : Controller
    {
        GestionPersonasBL gestora = new GestionPersonasBL();



        // GET: PersonasController
        public ActionResult Index()
        {
            ViewBag.Dpts = ListadoDepartamentosBL.getListadoDepartamentos();
            IEnumerable<clsPersona> personas = ListadoPersonasBL.getListadoPersonas();
            return View(personas);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            ViewBag.Dpts = ListadoDepartamentosBL.getListadoDepartamentos();
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Nombre, string Apellidos, string Telefono, string Direccion, DateTime FechaNacimiento,byte[] Imagen, short idDepartamento)
        {
            ViewBag.Dpts = ListadoDepartamentosBL.getListadoDepartamentos();
            try
            {
                
                gestora.InsertPersona(Nombre, Apellidos, Telefono, Direccion, FechaNacimiento, Imagen, idDepartamento);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            clsPersona persona = ListadoPersonasBL.getPersonaDeLaLista(id);
            return View(persona);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string nombre, string apellidos, string telefono, string direccion, DateTime fechaNacimiento, IFormFile imagen, int idDepartamento)
        {   clsPersona persona = new clsPersona();
            try
            {

                using (var ms = new MemoryStream())
                {
                    imagen.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    persona.Imagen = Convert.FromBase64String(s);
                    // act on the Base64 data
                }


                persona.Id = id;
                persona.Nombre = nombre;
                persona.Apellidos = apellidos;
                persona.Telefono = telefono;
                persona.Direccion = direccion;
                persona.IdDepartamento = idDepartamento;
                persona.FechaNacimiento = fechaNacimiento;

                bool fin = false;
                List<clsDepartamento> departamentos = ListadoDepartamentosBL.getListadoDepartamentos();
                for (int i = 0; i < departamentos.Count && !fin; i++)
                {
                    if (departamentos.ElementAt(i).Id == idDepartamento )
                    {
                        persona.Departamento = departamentos.ElementAt(i);
                        fin = true;
                    }
                }



                gestora.EditarPersona(persona);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

            // GET: PersonasController/Delete/5
            public ActionResult Delete(int id)
        {
            clsPersona persona = new clsPersona();
            bool fin = false;
            for (int i = 0; i < ListadoPersonasBL.getListadoPersonas().Count; i++)
            {
                if (ListadoPersonasBL.getListadoPersonas().ElementAt(i).Id == id)
                {
                    persona = ListadoPersonasBL.getListadoPersonas().ElementAt(i);
                    fin = true;
                }
            }
            return View(persona);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                gestora.DeletePersona(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
