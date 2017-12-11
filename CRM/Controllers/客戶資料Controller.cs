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
    public class 客戶資料Controller : Controller
    {
        //private CRMEntities db = new CRMEntities();
        客戶資料Repository Repo = RepositoryHelper.Get客戶資料Repository();

        // GET: 客戶資料
        public ActionResult Index()
        {
            var vm = new 客戶資料VM()
            {
                客戶資料s = Repo.All().ToList()
            };

            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int 客戶分類Id)
        {
            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();

            if (ModelState.IsValid)
            {
                var vm = new 客戶資料VM()
                {
                    客戶資料s = Repo.SearchByType(客戶分類Id)
                };

                return View(vm);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchFilter(客戶資料VM vm)
        {
            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();

            if (ModelState.IsValid)
            {
                vm.客戶資料s = Repo.SearchByVM(vm);
            }

            return View("Index", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public FileResult Export(客戶資料VM vm)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("客戶資料");
                List<客戶資料> 客戶資料s = Repo.SearchByVM(vm);
                var rowIndex = 2;

                ws.Cell("A1").Value = "客戶名稱";
                ws.Cell("B1").Value = "客戶分類";
                ws.Cell("C1").Value = "統一編號";
                ws.Cell("D1").Value = "電話";
                ws.Cell("E1").Value = "傳真";
                ws.Cell("F1").Value = "地址";
                ws.Cell("G1").Value = "Email";
                ws.Cell("H1").Value = "已刪除";

                foreach (var item in 客戶資料s)
                {
                    ws.Cell("A" + rowIndex).Value = item.客戶名稱;
                    ws.Cell("B" + rowIndex).Value = item.客戶分類;
                    ws.Cell("C" + rowIndex).Value = item.統一編號;
                    ws.Cell("D" + rowIndex).Value = item.電話;
                    ws.Cell("E" + rowIndex).Value = item.傳真;
                    ws.Cell("F" + rowIndex).Value = item.地址;
                    ws.Cell("G" + rowIndex).Value = item.Email;
                    ws.Cell("H" + rowIndex).Value = item.IsDeleted;

                    rowIndex++;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "客戶資料.xlsx");
                }
            }

        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = Repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,IsDeleted,客戶分類Id")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(客戶資料);
                Repo.UnitOfWork.Commit();
                TempData["Msg"] = "新增成功";
                return RedirectToAction("Index");
            }

            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = Repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,IsDeleted,客戶分類Id")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var item = Repo.Find(客戶資料.Id);
                item.Id = 客戶資料.Id;
                item.Email = 客戶資料.Email;
                item.傳真 = 客戶資料.傳真;
                item.地址 = 客戶資料.地址;
                item.客戶名稱 = 客戶資料.客戶名稱;
                item.統一編號 = 客戶資料.統一編號;
                item.電話 = 客戶資料.電話;
                item.客戶分類Id = 客戶資料.客戶分類Id;
                Repo.UnitOfWork.Commit();
                TempData["Msg"] = "修改成功";

                ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = Repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = Repo.Find(id);

            客戶資料.IsDeleted = true;
            客戶資料.客戶聯絡人.ToList().ForEach(c => c.IsDeleted = true);
            客戶資料.客戶銀行資訊.ToList().ForEach(c => c.IsDeleted = true);

            Repo.UnitOfWork.Commit();

            ViewBag.CustomerTypeList = Repo.GetCostomerTypeList();
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
