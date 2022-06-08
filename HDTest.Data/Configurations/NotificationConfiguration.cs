using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FileName).HasMaxLength(2000);
            builder.Property(x => x.DocumentType).HasMaxLength(2000);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status);
            //builder.Property(x => x.Type);
            builder.Property(x => x.Seen).HasDefaultValue(false);

            builder.HasOne(x => x.User).WithMany(y => y.Notifications).HasForeignKey(f => f.UserId);
        }
    }
}
