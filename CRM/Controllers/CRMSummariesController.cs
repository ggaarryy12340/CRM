using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Models;

namespace CRM.Controllers
{
    public class CRMSummariesController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: CRMSummaries
        public ActionResult Index()
        {
            return View(db.CRMSummary.ToList());
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
