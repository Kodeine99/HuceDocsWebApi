using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class CCCDConfiguration : IEntityTypeConfiguration<CCCD>
    {
        public void Configure(EntityTypeBuilder<CCCD> builder)
        {
            builder.ToTable("CCCD");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();


            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.HO_TEN).HasMaxLength(255);
            builder.Property(x => x.SO_THE).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH);
            builder.Property(x => x.GIOI_TINH).HasMaxLength(255);
            builder.Property(x => x.QUOC_TICH).HasMaxLength(255);
            builder.Property(x => x.QUE_QUAN).HasMaxLength(255);
            builder.Property(x => x.DIA_CHI_THUONG_TRU).HasMaxLength(255);
            builder.Property(x => x.NGAY_CAP).HasMaxLength(255);
    

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.CCCDs)
                .HasForeignKey(z => z.TICKET_ID);
        }
    }
}
