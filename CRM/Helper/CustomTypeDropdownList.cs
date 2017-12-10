using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CRM.Helper
{

    public static class CustomTypeDropdownList
    {
        public static MvcHtmlString CreateCustomerTypeDropdownList(string name, List<客戶分類> options)
        {
            var dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", name);
            dropdown.Attributes.Add("class", "form-control");

            StringBuilder option = new StringBuilder();
            if (option != null)
            {
                foreach (var item in options)
                {
                    option = option.Append("<option value='" + item.Id + "'>" + item.分類名稱 + "</option>");
                }
            }
            dropdown.InnerHtml = option.ToString();
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
    }

}