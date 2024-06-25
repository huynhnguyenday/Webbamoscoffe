using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webbamoscoffe.Models.Common
{
    public class Filter
    {
        private static readonly string[] VietNamChar = new string[]
    {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
        
    };

        public static string LocDau(string str)
        {
            // Kiểm tra nếu str là null hoặc rỗng
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            // Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    // Kiểm tra nếu ký tự trong VietNamChar[i] hoặc VietNamChar[0] là null hoặc rỗng
                    if (VietNamChar[i][j] == '\0' || VietNamChar[0][i - 1] == '\0')
                    {
                        continue;
                    }

                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
            }
            str = str.Replace(" ", "-");
            return str;
        }
    }
}