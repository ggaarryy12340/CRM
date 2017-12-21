using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.ActionFilter
{
    public class TitleSelectorAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var Repo = RepositoryHelper.Get客戶聯絡人Repository();
            filterContext.Controller.ViewBag.TitleSelector = new SelectList(Repo.Get職稱List());
            base.OnResultExecuting(filterContext);

        }
    }
}