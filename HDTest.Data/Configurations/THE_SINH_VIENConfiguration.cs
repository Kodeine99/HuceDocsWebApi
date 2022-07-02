using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class THE_SINH_VIENConfiguration : IEntityTypeConfiguration<THE_SINH_VIEN>
    {
        public void Configure(EntityTypeBuilder<THE_SINH_VIEN> builder)
        {
            builder.ToTable("THE_SINH_VIEN");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();


            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.HO_TEN).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH).HasMaxLength(25);
            builder.Property(x => x.MSSV).HasMaxLength(10);
            builder.Property(x => x.LOP).HasMaxLength(10);
            builder.Property(x => x.KHOA).HasMaxLength(255);
            builder.Property(x => x.HKTT).HasMaxLength(255);
            builder.Property(x => x.EMAIL).HasMaxLength(255);
            builder.Property(x => x.KHOA_HOC).HasMaxLength(255);

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.THE_SINH_VIENs)
                .HasForeignKey(z => z.TICKET_ID);
        }
    }
}
