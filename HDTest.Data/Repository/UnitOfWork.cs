using HuceDocs.Data.DbContext;
using HuceDocs.Data.Models;
using HuceDocs.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly HuceDocsContext dbContext;
        //private IRepository<AppConfig> appConfigRepository;
        private IRepository<User> userRepository;
        private IRepository<Role> roleRepository;
        private IRepository<Document> documentRepository;
        private IRepository<HFile> hFileRepository;
        private IRepository<DocumentType> documentTypeRepository;
        private IRepository<OCR_Request> ocr_requestRepository;
        private IRepository<Verify> verifyRepository;
        //private IRepository<Notification> notificationRepository;
        private IRepository<OutputResults> outputResultsRepository;
        private IRepository<GIAY_XAC_NHAN_TOEIC> GIAY_XAC_NHAN_TOEICRepository;
        private IRepository<GIAY_CAM_KET_TRA_NO> GIAY_CAM_KET_TRA_NORepository;
        private IRepository<BANG_DIEM_TIENG_ANH> BANG_DIEM_TIENG_ANHRepository;
        private IRepository<GIAY_XAC_NHAN_VAY_VON> GIAY_XAC_NHAN_VAY_VONRepository;
        private IRepository<BANG_DIEM> BANG_DIEMRepository;
        private IRepository<CCCD> CCCDRepository;


        public HuceDocsContext DbContext => dbContext;
        //public IRepository<Notification> NotificationRepository => notificationRepository ?? (notificationRepository = new Repository<Notification>(DbContext));
        public IRepository<User> UserRepository => userRepository ?? (userRepository = new Repository<User>(DbContext));
        public IRepository<Role> RoleRepository => roleRepository ?? (roleRepository = new Repository<Role>(DbContext));
        public IRepository<Document> DocumentRepository => documentRepository ?? (documentRepository = new Repository<Document>(DbContext));
        public IRepository<DocumentType> DocumentTypeRepository => documentTypeRepository ?? (documentTypeRepository = new Repository<DocumentType>(DbContext));
        public IRepository<HFile> HFileRepository => hFileRepository ?? (hFileRepository = new Repository<HFile>(DbContext));

        public IRepository<OCR_Request> OCR_RequestRepository => ocr_requestRepository ?? (ocr_requestRepository = new Repository<OCR_Request>(DbContext));
        public IRepository<Verify> VerifyRepository => verifyRepository ?? (verifyRepository = new Repository<Verify>(DbContext));
        public IRepository<OutputResults> OutputResultsRepository => outputResultsRepository ?? (outputResultsRepository = new Repository<OutputResults>(DbContext));
        public IRepository<GIAY_XAC_NHAN_TOEIC> GGIAY_XAC_NHAN_TOEICRepository => GIAY_XAC_NHAN_TOEICRepository ?? (GIAY_XAC_NHAN_TOEICRepository = new Repository<GIAY_XAC_NHAN_TOEIC>(DbContext));
        public IRepository<GIAY_CAM_KET_TRA_NO> GGIAY_CAM_KET_TRA_NORepository => GIAY_CAM_KET_TRA_NORepository ?? (GIAY_CAM_KET_TRA_NORepository = new Repository<GIAY_CAM_KET_TRA_NO>(DbContext));
        public IRepository<BANG_DIEM_TIENG_ANH> BBANG_DIEM_TIENG_ANHRepository => BANG_DIEM_TIENG_ANHRepository ?? (BANG_DIEM_TIENG_ANHRepository = new Repository<BANG_DIEM_TIENG_ANH>(DbContext));
        public IRepository<GIAY_XAC_NHAN_VAY_VON> GGIAY_XAC_NHAN_VAY_VONRepository => GIAY_XAC_NHAN_VAY_VONRepository ?? (GIAY_XAC_NHAN_VAY_VONRepository = new Repository<GIAY_XAC_NHAN_VAY_VON>(DbContext));
        public IRepository<BANG_DIEM> BBANG_DIEMRepository => BANG_DIEMRepository ?? (BANG_DIEMRepository = new Repository<BANG_DIEM>(DbContext));
        public IRepository<CCCD> CCCCDRepository => CCCDRepository ?? (CCCDRepository = new Repository<CCCD>(DbContext));


        public UnitOfWork()
        {
            dbContext = (new HuceDocsContextFactory()).CreateDbContext(null);
        }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public static UnitOfWork GetDefaultInstance()
        {
            return new UnitOfWork();
        }

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    DbContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}