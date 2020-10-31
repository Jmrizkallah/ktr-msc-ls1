using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ktr_msc_ls1_BCM.Models;

namespace ktr_msc_ls1_BCM.Controllers
{
    public class Profiles_LibraryController : Controller
    {
        private Entities db = new Entities();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Username"] != null)
                base.OnActionExecuting(filterContext);
            else
                filterContext.Result = new RedirectResult("~/UserLogin/Login");
            return;
        }
        // GET: Profiles_Library
        public async Task<ActionResult> Index()
        {
            var idToBeUsedForInsert = Convert.ToInt32(Session["Id"]);
            return View(await db.Profiles_Library.Where(x => x.Profile_ID == idToBeUsedForInsert).ToListAsync());
        }

        // GET: Profiles_Library/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profiles_Library profiles_Library = await db.Profiles_Library.FindAsync(id);
            if (profiles_Library == null)
            {
                return HttpNotFound();
            }
            return View(profiles_Library);
        }

        // GET: Profiles_Library/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles_Library/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Firstname,Lastname,Company,Email,Phonenumber,PL_Status")] Profiles_Library profiles_Library)
        {
            if (ModelState.IsValid)
            {
                profiles_Library.Profile_ID = (int)Session["Id"];
                profiles_Library.PL_Status = "Active";
                db.Profiles_Library.Add(profiles_Library);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(profiles_Library);
        }

        // GET: Profiles_Library/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profiles_Library profiles_Library = await db.Profiles_Library.FindAsync(id);
            if (profiles_Library == null)
            {
                return HttpNotFound();
            }
            return View(profiles_Library);
        }

        // POST: Profiles_Library/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Firstname,Lastname,Company,Email,Phonenumber,PL_Status")] Profiles_Library profiles_Library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profiles_Library).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profiles_Library);
        }

        // GET: Profiles_Library/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profiles_Library profiles_Library = await db.Profiles_Library.FindAsync(id);
            if (profiles_Library == null)
            {
                return HttpNotFound();
            }
            return View(profiles_Library);
        }

        // POST: Profiles_Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Profiles_Library profiles_Library = await db.Profiles_Library.FindAsync(id);
            db.Profiles_Library.Remove(profiles_Library);
            await db.SaveChangesAsync();
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
