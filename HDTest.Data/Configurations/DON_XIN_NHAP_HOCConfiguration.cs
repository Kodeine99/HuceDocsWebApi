using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class DON_XIN_NHAP_HOCConfiguration : IEntityTypeConfiguration<DON_XIN_NHAP_HOC>
    {
        public void Configure(EntityTypeBuilder<DON_XIN_NHAP_HOC> builder)
        {
            builder.ToTable("DON_XIN_NHAP_HOC");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();
            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.NGUOI_LAP_DON).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH).HasMaxLength(255);
            builder.Property(x => x.MSSV).HasMaxLength(255);
            builder.Property(x => x.KHOA).HasMaxLength(255);
            builder.Property(x => x.LOP).HasMaxLength(255);
            builder.Property(x => x.NHAP_HOC_TU_KY).HasMaxLength(255);
            builder.Property(x => x.SO_GIAY_PHEP).HasMaxLength(255);
            builder.Property(x => x.NGAY_NGHI_THEO_GIAY_PHEP).HasMaxLength(255);
            builder.Property(x => x.NGAY_KY).HasMaxLength(255);

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.DON_XIN_NHAP_HOCs)
                .HasForeignKey(z => z.TICKET_ID);
        }
    }
}
