using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models.ViewModel
{
    public class 客戶銀行資訊VM
    {
        public List<客戶銀行資訊> 客戶銀行資訊s { get; set; }

        #region search parameter

        public string 銀行名稱 { get; set; }
        public int? 銀行代碼 { get; set; }
        public int? 分行代碼 { get; set; }
        public string 帳戶名稱 { get; set; }
        public string 帳戶號碼 { get; set; }

        #endregion
    }
}