using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
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
            builder.HasKey(k => new { k.CustomerId, k.PreferenceId });
            builder.HasOne(k => k.Customer).WithMany(k => k.CustomerPreferences).HasForeignKey(k => k.CustomerId);
            builder.HasOne(k => k.Preference).WithMany(k => k.CustomerPreferences).HasForeignKey(k => k.PreferenceId);
        }
    }
}
