using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Category;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ViewModels.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services
{
    public interface IDanhMucService
    {
        ApiResult<DocumentType> GetDocumentTypeById(int id);
        ApiResult<List<CategoryVM>> GetDocumentTypes();
        //ApiResult<List<OutputExtension>> GetOutputExtensions(int type);
        ApiResult<PagedResult<DocumentType>> GetDocumentTypes(CategoryFilter filter);
        ApiResult<int> DocumentTypeCreate(int adminid, DocumentType model);
        //ApiResult<int> DocumentTypeUpdate(int adminid, DocumentType model);
    }
}
