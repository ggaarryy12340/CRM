using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models.ViewModel
{
    public class 客戶資料VM
    {
        public List<客戶資料> 客戶資料s { get; set; }

        #region search parameter

        public string 客戶名稱 { get; set; }
        public int? 客戶分類Id { get; set; }
        public string 統一編號 { get; set; }
        public string 電話 { get; set; }
        public string Email { get; set; }
        public string 排序 { get; set; }
        public string 升降 { get; set; }

        #endregion
    }
}