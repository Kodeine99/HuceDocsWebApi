using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using HuceDocs.Services.EnumDefine;
using HuceDocs.Services.ViewModel;
using HuceDocs.Services.ViewModels.Category;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ViewModels.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuceDocs.Services.Services.DanhMuc
{
    public class DanhMucService
    {
        private UnitOfWork work;

        public DanhMucService()
        {
            work = UnitOfWork.GetDefaultInstance();
        }

        // Get Document Type
        public ApiResult<List<CategoryVM>> GetDocumentTypes()
        {
            var result = work.DocumentTypeRepository.NoTrackingEntities.Where(o => o.Status == (int)eStatus.active).Select(o => new CategoryVM(o)).ToList();
            return new ApiSuccess<List<CategoryVM>> { Result = result };
        }

        /// <summary>
        /// Get document type with filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ApiResult<PagedResult<DocumentType>> GetDocumentTypes(CategoryFilter filter)
        {
            var data = work.DocumentTypeRepository.NoTrackingEntities
                .Where(o => filter.NameOrCode == null || o.Name.Contains(filter.NameOrCode) || o.Code.Contains(filter.NameOrCode))
                .ToList();
            var result = data
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();
            var pagedResult = new PagedResult<DocumentType>()
            {
                TotalRecords = data.Count,
                PageIndex = filter.PageIndex,
                PageSize = filter.PageSize,
                Items = result
            };
            return new ApiSuccess<PagedResult<DocumentType>> { Result = pagedResult };
        }

        /// <summary>
        /// Get document type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResult<DocumentType> GetDocumentTypeById(int id)
        {
            var data = work.DocumentTypeRepository.ReadNoTracking(id);
            return new ApiResult<DocumentType> { Result = data };
        }

        /// <summary>
        /// Create Document type
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApiResult<int> DocumentTypeCreate(int adminid, DocumentType model)
        {
            //model.AdminId = adminid;
            model.UpdateDate = DateTime.Now;
            var id = work.DocumentTypeRepository.Create(model);
            return new ApiSuccess<int>() { Result = id};
        }

    }
}
