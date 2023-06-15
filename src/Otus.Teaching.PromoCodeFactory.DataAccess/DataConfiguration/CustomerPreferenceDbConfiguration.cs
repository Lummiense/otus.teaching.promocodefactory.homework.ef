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
    public class CustomerPreferenceDbConfiguration: IEntityTypeConfiguration<CustomerPreference>
    {
        public void Configure(EntityTypeBuilder<CustomerPreference> builder)
        {
            builder.HasData(FakeDataFactory.CustomerPreferences);
            builder.HasKey(k => new { k.CustomerId, k.PreferenceId });
            builder.HasOne(c => c.Customer).WithMany(cp => cp.CustomerPreferences).HasForeignKey(fk => fk.CustomerId);
            builder.HasOne(p => p.Preference).WithMany(cp => cp.CustomerPreferences).HasForeignKey(fk => fk.PreferenceId);
            
        }
    }
}
