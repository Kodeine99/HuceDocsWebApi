﻿using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class GIAY_XAC_NHAN_VAY_VONConfiguration : IEntityTypeConfiguration<GIAY_XAC_NHAN_VAY_VON>
    {
        public void Configure(EntityTypeBuilder<GIAY_XAC_NHAN_VAY_VON> builder)
        {
            builder.ToTable("GIAY_XAC_NHAN_VAY_VON");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TICKET_ID).IsRequired();
            builder.Property(x => x.USER_CREATE).IsRequired();
            builder.Property(x => x.CREATE_DATE).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UPDATE_DATE).IsRequired();


            builder.Property(x => x.STATUS).IsRequired().HasDefaultValue(1);

            builder.Property(x => x.HO_TEN).HasMaxLength(255);
            builder.Property(x => x.NGAY_SINH).HasMaxLength(255);
            builder.Property(x => x.GIOI_TINH);
            builder.Property(x => x.CMND).HasMaxLength(255);
            builder.Property(x => x.NGAY_CAP_CMND).HasMaxLength(255);
            builder.Property(x => x.NOI_CAP).HasMaxLength(255);
            builder.Property(x => x.MA_TRUONG).HasMaxLength(255);
            builder.Property(x => x.TEN_TRUONG).HasMaxLength(255);
            builder.Property(x => x.NGANH_HOC).HasMaxLength(255);
            builder.Property(x => x.HE_DT).HasMaxLength(255);
            builder.Property(x => x.SO_KHOA).HasMaxLength(255);
            builder.Property(x => x.LOP).HasMaxLength(255);
            builder.Property(x => x.MSSV).HasMaxLength(255);
            builder.Property(x => x.KHOA).HasMaxLength(255);
            builder.Property(x => x.NGAY_NHAP_HOC).HasMaxLength(255);
            builder.Property(x => x.NGAY_RA_TRUONG).HasMaxLength(255);
            builder.Property(x => x.HOC_PHI_MOI_THANG).HasMaxLength(255);
            builder.Property(x => x.STK);
            builder.Property(x => x.TAI_NH);
            builder.Property(x => x.CM_THUOC_DIEN);
            builder.Property(x => x.CM_THUOC_DOI_TUONG);

            builder.HasOne(x => x.OCR_Request).WithMany(y => y.GIAY_XAC_NHAN_VAY_VONs)
                .HasForeignKey(z => z.TICKET_ID);
        }
    }
}
