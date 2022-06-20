using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class BANG_DIEM_TIENG_ANHConfiguration : IEntityTypeConfiguration<BANG_DIEM_TIENG_ANH>
    {
        public void Configure(EntityTypeBuilder<BANG_DIEM_TIENG_ANH> builder)
        {
            builder.ToTable("BANG_DIEM_TIENG_ANH");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();
            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);


            builder.Property(x => x.FULL_NAME).HasMaxLength(255);
            builder.Property(x => x.MAJOR).HasMaxLength(255);
            builder.Property(x => x.STUDENT_ID).HasMaxLength(255);
            builder.Property(x => x.S_CLASS).HasMaxLength(255);
            builder.Property(x => x.TRAINING_FORM).HasMaxLength(255);
            builder.Property(x => x.GPA_10SCALE).HasMaxLength(255);
            builder.Property(x => x.GPA_4SCALE).HasMaxLength(255);
            builder.Property(x => x.TOTAL_CREDITS).HasMaxLength(255);
            builder.Property(x => x.CLASSIFICATION).HasMaxLength(255);
            builder.Property(x => x.MARK_TABLE);

            builder.Property(x => x.DOB);

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.BANG_DIEM_TIENG_ANHs)
                .HasForeignKey(z => z.TICKET_ID);

        }
    }
}
