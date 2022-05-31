using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.EnumDefine
{
    public static class ConstantDefine
    {
        public static List<string> InputExtension()
        {
            var result = new List<string>();
            result.Add(".doc");
            result.Add(".pdf");
            result.Add(".docx");
            return result;
        }
    }
}
