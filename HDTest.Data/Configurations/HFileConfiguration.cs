using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class HFileConfiguration : IEntityTypeConfiguration<HFile>
    {
        public void Configure(EntityTypeBuilder<HFile> builder)
        {
            builder.ToTable("HFile");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FileName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FilePath).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FileExtension).HasMaxLength(50);
            builder.Property(x => x.Status).HasDefaultValue(1);

            builder.HasOne(x => x.Document).WithMany(y => y.HFiles).HasForeignKey(f => f.DocumentId);
        }
    }
}
