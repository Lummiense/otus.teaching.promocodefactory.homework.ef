using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class PreferenceDbConfiguration:IEntityTypeConfiguration<Preference>
    {
        public void Configure (EntityTypeBuilder<Preference> builder)
        {
            builder.HasData(FakeDataFactory.Preferences);
            builder.Property(n => n.Name).HasMaxLength(30);
            builder.HasMany(p => p.PromoCodes).WithOne(p => p.Preference).HasForeignKey(fk => fk.PreferenceId);
        }
    }
}
