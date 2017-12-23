using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.Models.ViewModel;
using ClosedXML.Excel;
using System.IO;

namespace CRM.Controllers
{
    public class 客戶銀行資訊Controller : Controller
    {
        客戶銀行資訊Repository Repo = RepositoryHelper.Get客戶銀行資訊Repository();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            var vm = new 客戶銀行資訊VM()
            {
                客戶銀行資訊s = Repo.All().Include(客 => 客.客戶資料).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(客戶銀行資訊VM vm)
        {
            if (ModelState.IsValid)
            {
                vm.客戶銀行資訊s = Repo.SearchByVM(vm);
            }

            return View(vm);
        }

       

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = Repo.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼,IsDeleted")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(客戶銀行資訊);
                Repo.UnitOfWork.Commit();
                TempData["Msg"] = "新增成功";
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = Repo.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼,IsDeleted")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                var item = Repo.Find(客戶銀行資訊.Id);
                item.銀行名稱 = 客戶銀行資訊.銀行名稱;
                item.銀行代碼 = 客戶銀行資訊.銀行代碼;
                item.帳戶號碼 = 客戶銀行資訊.帳戶號碼;
                item.帳戶名稱 = 客戶銀行資訊.帳戶名稱;
                item.客戶Id = 客戶銀行資訊.客戶Id;
                item.分行代碼 = 客戶銀行資訊.分行代碼;

                Repo.UnitOfWork.Commit();
                TempData["Msg"] = "修改成功";
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(Repo.Get客戶資料List(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = Repo.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = Repo.Find(id);
            客戶銀行資訊.IsDeleted = true;
            Repo.UnitOfWork.Commit();
            TempData["Msg"] = "刪除成功";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public FileResult Export(客戶銀行資訊VM vm)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("客戶銀行資訊");
                List<客戶銀行資訊> 客戶銀行資訊s = Repo.SearchByVM(vm);
                var rowIndex = 2;

                ws.Cell("A1").Value = "客戶Id";
                ws.Cell("B1").Value = "銀行名稱";
                ws.Cell("C1").Value = "銀行代碼";
                ws.Cell("D1").Value = "分行代碼";
                ws.Cell("E1").Value = "帳戶名稱";
                ws.Cell("F1").Value = "帳戶號碼";
                ws.Cell("G1").Value = "已刪除";

                foreach (var item in 客戶銀行資訊s)
                {
                    ws.Cell("A" + rowIndex).Value = item.客戶資料.客戶名稱;
                    ws.Cell("B" + rowIndex).Value = item.銀行名稱;
                    ws.Cell("C" + rowIndex).Value = item.銀行代碼;
                    ws.Cell("D" + rowIndex).Value = item.分行代碼;
                    ws.Cell("E" + rowIndex).Value = item.帳戶名稱;
                    ws.Cell("F" + rowIndex).Value = item.帳戶號碼;
                    ws.Cell("G" + rowIndex).Value = item.IsDeleted;

                    rowIndex++;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "客戶銀行資訊.xlsx");
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
