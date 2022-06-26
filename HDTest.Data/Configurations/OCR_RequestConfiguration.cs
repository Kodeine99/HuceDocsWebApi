using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Data.Configurations
{
    public class OCR_RequestConfiguration : IEntityTypeConfiguration<OCR_Request>
    {
        public void Configure(EntityTypeBuilder<OCR_Request> builder)
        {
            builder.ToTable("OCR_Request");

            builder.HasKey(x => x.Ticket_Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Ticket_Id).IsRequired();
            builder.Property(x => x.JsonData);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DocumentId).IsRequired();
            builder.Property(x => x.CreateTime).IsRequired();

            builder.Property(x => x.CreateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Token);
            builder.Property(x => x.VerifyLink);
            builder.Property(x => x.IsSaved).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsDelete).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.OCR_Status_Code).HasDefaultValue(0).IsRequired();
        }
    }
}
