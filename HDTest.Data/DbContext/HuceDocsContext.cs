using HuceDocs.Data.Configurations;
using HuceDocs.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.DbContext
{
    public sealed class HuceDocsContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        //contructor
        public HuceDocsContext(DbContextOptions<HuceDocsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // load config
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DocumentConfiguration());
            builder.ApplyConfiguration(new DocumentTypeConfiguration());
            builder.ApplyConfiguration(new DocOutputExtensionsConfiguration());
            builder.ApplyConfiguration(new OCR_RequestConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new GIAY_XAC_NHAN_TOEICConfiguration());
            
            // add identity
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserToken>().ToTable("UserToken");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
            //
            base.OnModelCreating(builder);
        }
    }
}