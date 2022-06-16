using HuceDocs.Services.ViewModel;
using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HuceDocs.Services.ViewModels.Document;
using Microsoft.AspNetCore.Http;
using HuceDocs.Services.ViewModels.Common;
using HuceDocs.Services.ModelFilter;

namespace HuceDocs.Services
{
    public interface IDocumentService
    {
        /// <summary>
        /// Tạo mới từ document model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //ApiResult<int> Create(Document model);

        /// <summary>
        /// Tạo mới bóc tách từ request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResult<DocumentResultModel>> CreateExtraction(ExtractionRequest request);
        
        /// <summary>
        /// Tạo mới bóc tách từ request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
       //Task<ApiResult<DocumentResultModel>> CreateRecognition(RecognitionRequest request);

        /// <summary>Update với Document Model </summary>
        //ApiResult<bool> Update(Document model);
        /// <summary>
        /// Xóa file gốc tải lên
        /// </summary>
        /// <param name="selectedIds">danh sánh id của các document cần xóa</param>
        /// <returns></returns>
        //ApiResult<string> Delete(int userid, List<int> id);

        /// <summary>
        /// thực thi số hóa/bóc tách
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResult<bool>> ExecuteAsync(int id, int userid, string ExtractType);
        /// <summary>
        /// Thực hiện lại
        /// </summary>
        Task<ApiResult<bool>> ReworkAsync(int id, int userid);

        /// <summary>
        /// lấy danh sách file kết quả
        /// </summary>
        /// <param name="id">document id</param>
        /// <param name="userid">user id</param>
        /// <returns></returns>
        //ApiResult<List<OutputResults>> GetOutputs(int id, int userid);
        /// <summary>Update trang thái </summary>
        //ApiResult<bool> UpdateStatus(int id, int status);
        /// <summary>Check trang thái </summary>
        //ApiResult<int> CheckStatus(int id, int userid);
        /// <summary>
        /// Tìm kiếm tài liệu
        /// </summary>
        ApiResult<PagedResult<DocumentVM>> GetDocuments(DocumentFilter filter);
        /// <summary>
        /// Lấy danh sánh tài liệu theo user
        /// </summary>
        ApiResult<List<Document>> GetDocuments(int userid);
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="id">id tài liệu</param>
        /// <returns></returns>
        ApiResult<Document> GetById(int id);
        /// <summary>
        /// Lấy theo id và user
        /// </summary>
        /// <param name="id">id tài liệu</param>
        /// <param name="userid">id user</param>
        /// <returns></returns>
        ApiResult<Document> GetById(int id, int userid);
        /// <summary>
        /// Lấy theo id và user
        /// </summary>
        /// <param name="id">id tài liệu</param>
        /// <param name="userid">id user</param>
        /// <returns></returns>
        ApiResult<DocumentVM> GetViewModelById(int id, int userid);
        /// <summary>
        /// Hoàn thành tài liệu
        /// </summary>
        /// <param name="id">id tài liệu</param>
        /// <param name="files">Danh sách file</param>
        /// <param name="pageCount">Số trang đã làm</param>
        /// <param name="fieldCount">Số trường đã làm (bóc tách)</param>
        /// <param name="isOK">trạng thái: true = thành công; false = không thành công</param>
        /// <param name="description">Mô tả lỗi trong trường hợp không thành công</param>
        /// <returns></returns>
        Task<ApiResult<bool>> CompletedAsync(int id, IFormFileCollection file, int pageCount, int? fieldCount, bool isCaptured, string description);


        Task<ApiResult<bool>> UpdateVerifyAsync(int id, string url);
        /// <summary>
        /// Lấy kết quả theo dạng json - bóc tách
        /// </summary>
        /// <param name="id">Document id</param>
        /// <param name="userid">User id</param>
        /// <returns></returns>
        //ApiResult<FileVM> GetResultAsJson(string source, Document document);
    }
}
