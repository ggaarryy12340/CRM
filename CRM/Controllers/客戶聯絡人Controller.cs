using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using ClosedXML.Excel;
using System.IO;
using CRM.ActionFilter;
using System.Data.Entity.Validation;
using PagedList;

namespace CRM.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private int PageSize = 2;
        客戶聯絡人Repository Repo = RepositoryHelper.Get客戶聯絡人Repository();

        // GET: 客戶聯絡人
        [TitleSelector]
        public ActionResult Index(int page = 1)
        {
            int CurrentPage = page < 1 ? 1 : page;

            var 客戶聯絡人PagedList = Repo.All().Include(客 => 客.客戶資料).OrderBy(x => x.Id).ToPagedList(CurrentPage, PageSize);

            return View(客戶聯絡人PagedList);
        }

        [HttpPost]
        [TitleSelector]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string 職稱, int page = 1)
        {
            int CurrentPage = page < 1 ? 1 : page;

            if (ModelState.IsValid)
            {
                var 客戶聯絡人s = Repo.SearchByTitle(職稱).OrderBy(x => x.Id).ToPagedList(CurrentPage, PageSize);
                return View(客戶聯絡人s);
            }
 
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
        
        public ActionResult Get客戶資料Partial(int 客戶聯絡人ID)
        {
            客戶資料 客戶資料 = Repo.Find(客戶聯絡人ID).客戶資料;
            return PartialView("_Partial客戶資料", 客戶資料);
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
        [HandleError(View = "ValidationErrorPage", ExceptionType = typeof(DbEntityValidationException))]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public FileResult Export()
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("客戶聯絡人");
                List<客戶聯絡人> 客戶銀行資訊s = Repo.All().ToList();
                var rowIndex = 2;

                ws.Cell("A1").Value = "客戶名稱";
                ws.Cell("B1").Value = "職稱";
                ws.Cell("C1").Value = "姓名";
                ws.Cell("D1").Value = "Email";
                ws.Cell("E1").Value = "手機";
                ws.Cell("F1").Value = "電話";
                ws.Cell("G1").Value = "已刪除";

                foreach (var item in 客戶銀行資訊s)
                {
                    ws.Cell("A" + rowIndex).Value = item.客戶資料.客戶名稱;
                    ws.Cell("B" + rowIndex).Value = item.職稱;
                    ws.Cell("C" + rowIndex).Value = item.姓名;
                    ws.Cell("D" + rowIndex).Value = item.Email;
                    ws.Cell("E" + rowIndex).Value = item.手機;
                    ws.Cell("F" + rowIndex).Value = item.電話;
                    ws.Cell("G" + rowIndex).Value = item.IsDeleted;

                    rowIndex++;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "客戶聯絡人.xlsx");
                }
            }

        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Repo.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
