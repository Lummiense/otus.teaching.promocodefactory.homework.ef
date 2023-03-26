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
    public class CustomerDbConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) 
        {
            builder.HasData(FakeDataFactory.Customers);
            builder.Property(fn => fn.FirstName).HasMaxLength(30);
            builder.Property(ln => ln.LastName).HasMaxLength(40);
            builder.Property(e => e.Email).HasMaxLength(50);
        }
    }
}
