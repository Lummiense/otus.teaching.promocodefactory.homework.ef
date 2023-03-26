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
    public class EmployeeDbConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(FakeDataFactory.Employees);
            builder.HasOne(r => r.Role).WithMany(e => e.Employees).HasForeignKey(fk => fk.RoleId);
            builder.HasMany(p => p.PromoCodes).WithOne(e => e.PartnerManager).HasForeignKey(fk => fk.PartnetManagerId);
            builder.Property(fn => fn.FirstName).HasMaxLength(30);
            builder.Property(ln => ln.LastName).HasMaxLength(40);
            builder.Property(e => e.Email).HasMaxLength(50);
        }
    }
}
