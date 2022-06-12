using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class GIAY_XAC_NHAN_TOEICConfiguration : IEntityTypeConfiguration<GIAY_XAC_NHAN_TOEIC>
    {
        public void Configure(EntityTypeBuilder<GIAY_XAC_NHAN_TOEIC> builder)
        {
            builder.ToTable("GIAY_XAC_NHAN_TOEIC");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();


            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.HO_TEN).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH);
            builder.Property(x => x.MSSV).HasMaxLength(255);
            builder.Property(x => x.LOP).HasMaxLength(255);
            builder.Property(x => x.NGANH_HOC).HasMaxLength(255);
            builder.Property(x => x.HE_DAO_TAO).HasMaxLength(255);
            builder.Property(x => x.KHOA).HasMaxLength(255);
            builder.Property(x => x.LOP).HasMaxLength(255);
            builder.Property(x => x.NDXN).HasMaxLength(255);
            builder.Property(x => x.DIEM_THI).HasMaxLength(255);
            builder.Property(x => x.DOT_THI).HasMaxLength(255);
            builder.Property(x => x.NGAY_XAC_NHAN);

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.GIAY_XAC_NHAN_TOEICs)
                .HasForeignKey(z => z.TICKET_ID);
        }
    }
}
