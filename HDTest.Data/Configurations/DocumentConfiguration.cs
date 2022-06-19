using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.IsDelete).HasDefaultValue(false);

            

            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(0).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000);

            //builder.Property(x => x.DocumentTypeId);
            //builder.Property(x => x.FileName).HasMaxLength(2000);
            //builder.Property(x => x.FilePath).HasMaxLength(2000);
            //builder.Property(x => x.FileLength);
            //builder.Property(x => x.FileExtension).HasMaxLength(200);
            //builder.Property(x => x.TotalOfPages).HasDefaultValue(0);
            //builder.Property(x => x.TotalOfFields).HasDefaultValue(0);

            //builder.HasOne(x => x.User).WithMany(y => y.Services).HasForeignKey(f => f.UserId);
            //builder.HasOne(x => x.DocumentType).WithMany(y => y.Services).HasForeignKey(f => f.DocumentTypeId);
            
            builder.HasOne(x => x.Verify).WithOne(y => y.Document).HasForeignKey<Verify>(f => f.DocumentId);
            builder.HasOne(x => x.OCR_Request).WithOne(y => y.Document).HasForeignKey<OCR_Request>(f => f.DocumentId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
