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
            builder.ApplyConfiguration(new HFileConfiguration());
            builder.ApplyConfiguration(new DocOutputExtensionsConfiguration());
            builder.ApplyConfiguration(new OCR_RequestConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new GIAY_XAC_NHAN_TOEICConfiguration());
            builder.ApplyConfiguration(new GIAY_CAM_KET_TRA_NOConfiguration());
            builder.ApplyConfiguration(new BANG_DIEM_TIENG_ANHConfiguration());
            builder.ApplyConfiguration(new GIAY_XAC_NHAN_VAY_VONConfiguration());
            builder.ApplyConfiguration(new BANG_DIEMConfiguration());
            builder.ApplyConfiguration(new CCCDConfiguration());
            builder.ApplyConfiguration(new THE_SINH_VIENConfiguration());
            builder.ApplyConfiguration(new VerifyConfiguration());
            
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