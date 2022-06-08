using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class VerifyConfiguration : IEntityTypeConfiguration<Verify>
    {
        public void Configure(EntityTypeBuilder<Verify> builder)
        {
            builder.ToTable("Verify");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DocumentId);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Active);
        }
    }
}
