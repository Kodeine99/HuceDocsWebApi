using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public  class GIAY_CAM_KET_TRA_NOConfiguration : IEntityTypeConfiguration<GIAY_CAM_KET_TRA_NO>
    {
       public void Configure(EntityTypeBuilder<GIAY_CAM_KET_TRA_NO> builder)
       {
            builder.ToTable("GIAY_CAM_KET_TRA_NO");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();


            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.MAU_SO).HasMaxLength(255);
            builder.Property(x => x.HO_TEN_SV).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH);
            builder.Property(x => x.GIOI_TINH).HasMaxLength(255);
            builder.Property(x => x.CMND).HasMaxLength(255);
            builder.Property(x => x.NOI_CAP).HasMaxLength(255);
            builder.Property(x => x.LOP).HasMaxLength(255);
            builder.Property(x => x.KHOA).HasMaxLength(255);
            builder.Property(x => x.SO_THE_HSSV).HasMaxLength(255);
            builder.Property(x => x.NIEN_KHOA).HasMaxLength(255);
            builder.Property(x => x.LOAI_HINH_DAO_TAO).HasMaxLength(255);
            builder.Property(x => x.MA_TRUONG).HasMaxLength(255);
            builder.Property(x => x.NGUOI_DUNG_TEN).HasMaxLength(255);
            builder.Property(x => x.DIA_CHI_NGUOI_DUNG_TEN).HasMaxLength(255);
            builder.Property(x => x.NGAN_HANG_VAY_VON).HasMaxLength(255);
            builder.Property(x => x.SO_TIEN_BANG_SO).HasMaxLength(255);
            builder.Property(x => x.SO_TIEN_BANG_CHU).HasMaxLength(255);
            builder.Property(x => x.NGAY_CAP_CMND);
            builder.Property(x => x.NGAY_NHAP_HOC);
            builder.Property(x => x.NGAY_RA_TRUONG);
            builder.Property(x => x.NGAY_KY);

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.GIAY_CAM_KET_TRA_NOs)
                .HasForeignKey(z => z.TICKET_ID);
       }
    }
}
