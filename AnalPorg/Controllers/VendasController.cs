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
    public class VendasController : Controller
    {
        private VendasContext db = new VendasContext();
        private ColaboradoresContext db_colab = new ColaboradoresContext();

        // GET: Vendas
        public ActionResult Index(int? pagina)
        {
            int paginaTamanho = 6;
            int paginaNumero = (pagina ?? 1);

            return View(db.Venda.ToList().ToPagedList(paginaNumero, paginaTamanho));           
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendas vendas = db.Venda.Find(id);
            if (vendas == null)
            {
                return HttpNotFound();
            }
            return View(vendas);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.Colaboradores = (from c in db_colab.Colaborador
                               select c.Nome).Distinct();

            return View();
        }

        // POST: Vendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Salesman,SalesOrderNumber,TotalValue,ItensCount")] Vendas vendas)
        {
            if (ModelState.IsValid)
            {
                var Verificador = db.Venda.Where(v => v.SalesOrderNumber == vendas.SalesOrderNumber && v.Salesman == vendas.Salesman).ToList();

                if (Verificador.Count <= 0)
                {
                    db.Venda.Add(vendas);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.msg = "Esta Venda já se encontra cadastrado em nossa base de dados!!";
                    ViewBag.Colaboradores = (from c in db_colab.Colaborador
                                             select c.Nome).Distinct();
                    return View();
                }
                
                return RedirectToAction("Index");
            }

            return View(vendas);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendas vendas = db.Venda.Find(id);
            if (vendas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Colaboradores = (from c in db_colab.Colaborador
                                     select c.Nome).Distinct();
            return View(vendas);
        }

        // POST: Vendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Salesman,SalesOrderNumber,TotalValue,ItensCount")] Vendas vendas)
        {
            ViewBag.Colaboradores = (from c in db_colab.Colaborador
                                     select c.Nome).Distinct();

            if (ModelState.IsValid)
            {
                var Verificador = db.Venda.Where(v => v.SalesOrderNumber == vendas.SalesOrderNumber && v.Salesman == vendas.Salesman).ToList();

                if (Verificador.Count <= 0)
                {
                    db.Entry(vendas).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.msg = "Esta Venda já se encontra cadastrado em nossa base de dados!!";                   
                    return View();
                }
                
                return RedirectToAction("Index");
            }
            return View(vendas);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendas vendas = db.Venda.Find(id);
            if (vendas == null)
            {
                return HttpNotFound();
            }
            return View(vendas);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendas vendas = db.Venda.Find(id);
            db.Venda.Remove(vendas);
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
