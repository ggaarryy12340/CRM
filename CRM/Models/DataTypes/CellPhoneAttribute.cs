using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CRM.Models.DataTypes
{
    public class CellPhoneAttribute : DataTypeAttribute
    {
        public CellPhoneAttribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            Regex rgx = new Regex(@"\d{4}-\d{6}");

            string str = (string)value;

            if (!rgx.IsMatch(str))
            {
                return false;
            }

            return true;
        }
    }
}