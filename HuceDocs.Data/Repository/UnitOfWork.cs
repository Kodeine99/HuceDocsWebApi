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
        private IRepository<DocumentType> documentTypeRepository;
        private IRepository<OCR_Request> ocr_requestRepository;
        private IRepository<Verify> verifyRepository;

        public HuceDocsContext DbContext => dbContext;
        public IRepository<User> UserRepository => userRepository ?? (userRepository = new Repository<User>(DbContext));
        public IRepository<Role> RoleRepository => roleRepository ?? (roleRepository = new Repository<Role>(DbContext));
        public IRepository<Document> DocumentRepository => documentRepository ?? (documentRepository = new Repository<Document>(DbContext));
        public IRepository<DocumentType> DocumentTypeRepository => documentTypeRepository ?? (documentTypeRepository = new Repository<DocumentType>(DbContext));
        public IRepository<OCR_Request> OCR_RequestRepository => ocr_requestRepository ?? (ocr_requestRepository = new Repository<OCR_Request>(DbContext));
        public IRepository<Verify> VerifyRepository => verifyRepository ?? (verifyRepository = new Repository<Verify>(DbContext));
        

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