using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class RoleDbConfiguration:IEntityTypeConfiguration<Role>
    {
        public void Configure (EntityTypeBuilder<Role> builder)
        {
            builder.HasData(FakeDataFactory.Roles);
            builder.Property(n => n.Name).HasMaxLength(30);
            builder.Property(d => d.Description).HasMaxLength(100);
        }
    }
}
