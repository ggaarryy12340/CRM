using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.ActionFilter
{
    public class 客戶資料DropDownListAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var Repo客戶分類 = RepositoryHelper.Get客戶分類Repository();

            var 客戶分類DropDownList =  Repo客戶分類.All().ToList();
            客戶分類DropDownList.Add(new 客戶分類 { Id = 0, 分類名稱 = "" });
            filterContext.Controller.ViewBag.客戶分類Id = new SelectList(客戶分類DropDownList.OrderBy(x => x.Id), "Id","分類名稱");

            filterContext.Controller.ViewBag.排序 = new List<SelectListItem>
                                {
                                                    new SelectListItem() {Text = "", Value=""},
                                                    new SelectListItem() {Text = "客戶名稱", Value="客戶名稱"},
                                                    new SelectListItem() {Text = "客戶分類Id", Value="客戶分類Id"},
                                                    new SelectListItem() {Text = "統一編號", Value="統一編號"},
                                                    new SelectListItem() {Text = "電話", Value="電話"},
                                                    new SelectListItem() {Text = "Email", Value="Email"}
                                };
            filterContext.Controller.ViewBag.升降 = new List<SelectListItem>
                                {
                                                    new SelectListItem() {Text = "", Value=""},
                                                    new SelectListItem() {Text = "升冪", Value="升冪"},
                                                    new SelectListItem() {Text = "降冪", Value="降冪"}
                                };
            base.OnResultExecuting(filterContext);

        }
    }
}