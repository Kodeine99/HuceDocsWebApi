using HuceDocs.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Configurations
{
    public class DocOutputExtensionsConfiguration : IEntityTypeConfiguration<DocOutputExtensions>
    {
        public void Configure(EntityTypeBuilder<DocOutputExtensions> builder)
        {
            builder.HasKey(x => new { x.DocumentId, x.OutputExtensionId });

            builder.HasOne(x => x.Document).WithMany(y => y.OutputExtensions).HasForeignKey(x => x.DocumentId);
            //builder.HasOne(x => x.OutputExtension).WithMany(y => y.Documents).HasForeignKey(x => x.OutputExtensionId);
        }
    }
}
