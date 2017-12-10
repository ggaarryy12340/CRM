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
    public class 客戶聯絡人Controller : Controller
    {
        //private CRMEntities db = new CRMEntities();
        客戶聯絡人Repository Repo = RepositoryHelper.Get客戶聯絡人Repository();

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            ViewBag.TitleSelector = new SelectList(Repo.Get職稱List());
            var 客戶聯絡人 = Repo.All().Include(客 => 客.客戶資料);
            return View(客戶聯絡人.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string 職稱)
        {
            if (ModelState.IsValid)
            {
                var 客戶聯絡人s = Repo.SearchByTitle(職稱);

                ViewBag.TitleSelector = new SelectList(Repo.Get職稱List());
                return View(客戶聯絡人s);
            }

            ViewBag.TitleSelector = new SelectList(Repo.Get職稱List());
            return View();
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = Repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,IsDeleted")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(客戶聯絡人);
                Repo.UnitOfWork.Commit();
                TempData["Msg"] = "新增成功";
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = Repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,IsDeleted")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                客戶聯絡人 item = Repo.Find(客戶聯絡人.Id);

                item.Id = 客戶聯絡人.Id;
                item.姓名 = 客戶聯絡人.姓名;
                item.客戶Id = 客戶聯絡人.客戶Id;
                item.手機 = 客戶聯絡人.手機;
                item.職稱 = 客戶聯絡人.職稱;
                item.電話 = 客戶聯絡人.電話;
                item.Email = 客戶聯絡人.Email;

                Repo.UnitOfWork.Commit();
                TempData["Msg"] = "修改成功";
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = Repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = Repo.Find(id);
            客戶聯絡人.IsDeleted = true;
            Repo.UnitOfWork.Commit();
            TempData["Msg"] = "刪除成功";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
