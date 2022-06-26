using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class BANG_DIEMConfiguration : IEntityTypeConfiguration<BANG_DIEM>
    {
        public void Configure(EntityTypeBuilder<BANG_DIEM> builder)
        {
            builder.ToTable("BANG_DIEM");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();


            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.HO_TEN).HasMaxLength(255);
            builder.Property(x => x.MSSV).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH);
            builder.Property(x => x.LOP).HasMaxLength(255);
            builder.Property(x => x.NGANH).HasMaxLength(255);
            builder.Property(x => x.HE_DAO_TAO).HasMaxLength(255);
            builder.Property(x => x.THANG_DIEM_10).HasMaxLength(255);
            builder.Property(x => x.THANG_DIEM_4).HasMaxLength(255);
            builder.Property(x => x.TONG_SO_TIN_CHI).HasMaxLength(255);
            builder.Property(x => x.MARK_TABLE);


            builder.HasOne(x => x.OCR_Request).WithMany(y => y.BANG_DIEMs)
                .HasForeignKey(z => z.TICKET_ID);
        }
    }
}
