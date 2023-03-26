using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class PromoCodeDbConfiguration:IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder) 
        {
            builder.HasOne(c => c.Customer).WithMany(p => p.PromoCodes).HasForeignKey(fk => fk.CustomerId);
            builder.Property(c => c.Code).HasMaxLength(15);
            builder.Property(si => si.ServiceInfo).HasMaxLength(50);
        }
        
    }

}
