using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HuceDocs.Services.Common
{
    public static class DocumentHelper
    {
        public static int GetPageOfDocument(string filePath, string extension)
        {
            try
            {
                if (extension == null || !extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    return 1;
                }
                using (var file = new FileStream(filePath, FileMode.Open))
                {
                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
                        var pdf = new Aspose.Pdf.Document(stream);
                        return pdf.Pages.Count;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
        public static int GetPageOfDocument(IFormFile ifile, string extension)
        {
            try
            {
                if (extension == null || !extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    return 1;
                }
                using (var stream = new MemoryStream())
                {
                    ifile.CopyTo(stream);
                    var pdf = new Aspose.Pdf.Document(stream);
                    return pdf.Pages.Count;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
