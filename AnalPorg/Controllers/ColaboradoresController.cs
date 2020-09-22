using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnalPorg.Models;
using PagedList;
using System.IO;

namespace AnalPorg.Controllers
{
    public class ColaboradoresController : Controller
    {
        private ColaboradoresContext db = new ColaboradoresContext();

        // GET: Colaboradores
        public ActionResult Index(int? pagina)
        {
            int paginaTamanho = 6;
            int paginaNumero = (pagina ?? 1);

            return View(db.Colaborador.ToList().ToPagedList(paginaNumero, paginaTamanho));
        }

        // GET: Colaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaborador.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Matricula")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                var Verificador = db.Colaborador.Where(c => c.Nome == colaboradores.Nome && c.Matricula == colaboradores.Matricula).ToList();

                if (Verificador.Count <= 0)
                {
                    db.Colaborador.Add(colaboradores);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.msg = "O Colaborador já se encontra cadastrado em nossa base de dados!!";
                    return View();
                }
                return RedirectToAction("Index");
            }

            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaborador.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Matricula")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                var Verificador = db.Colaborador.Where(c => c.Nome == colaboradores.Nome && c.Matricula == colaboradores.Matricula).ToList();

                if (Verificador.Count <= 0)
                {
                    db.Entry(colaboradores).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.msg = "O Colaborador já se encontra cadastrado em nossa base de dados!!";
                    return View();
                }                
                return RedirectToAction("Index");
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaborador.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaboradores colaboradores = db.Colaborador.Find(id);
            db.Colaborador.Remove(colaboradores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
