using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.OcrRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Services
{
    public interface IOCR_RequestService 
    {
       Task<ApiResult<bool>> CreateAsync(UpdateOCR_RequestVM request);

       ApiResult<bool> Update(UpdateOCR_RequestVM request);

       ApiResult<List<OCR_RequestVM>> GetAll(OCR_RequestFilter filter);
        
    }
}
