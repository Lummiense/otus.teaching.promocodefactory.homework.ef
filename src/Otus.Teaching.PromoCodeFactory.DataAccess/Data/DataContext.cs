using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Data
{
    
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

           /* Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        //public DbSet<CustomerPreference> CustomerPreferences { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeDbConfiguration());
           /* modelBuilder.Entity<Employee>().HasData(FakeDataFactory.Employees);
            modelBuilder.Entity<Employee>().HasOne(r => r.Role).WithMany(e => e.Employees).HasForeignKey(fk=>fk.RoleId);
            modelBuilder.Entity<Employee>().HasMany(p => p.PromoCodes).WithOne(e => e.PartnerManager).HasForeignKey(fk => fk.PartnetManagerId);
            modelBuilder.Entity<Employee>().Property(fn => fn.FirstName).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(ln => ln.LastName).HasMaxLength(40);
            modelBuilder.Entity<Employee>().Property(e => e.Email).HasMaxLength(50);*/

            modelBuilder.ApplyConfiguration(new RoleDbConfiguration());
            /*modelBuilder.Entity<Role>().HasData(FakeDataFactory.Roles);
            modelBuilder.Entity<Role>().Property(n => n.Name).HasMaxLength(30);
            modelBuilder.Entity<Role>().Property(d => d.Description).HasMaxLength(100);*/

            modelBuilder.ApplyConfiguration(new PreferenceDbConfiguration());
            /*modelBuilder.Entity<Preference>().HasData(FakeDataFactory.Preferences);
            modelBuilder.Entity<Preference>().Property(n => n.Name).HasMaxLength(30);
            modelBuilder.Entity<Preference>().HasMany(p => p.PromoCodes).WithOne(p => p.Preference).HasForeignKey(fk => fk.PreferenceId);*/

            modelBuilder.ApplyConfiguration(new CustomerDbConfiguration());
            /*modelBuilder.Entity<Customer>().HasData(FakeDataFactory.Customers);
            modelBuilder.Entity<Customer>().Property(fn => fn.FirstName).HasMaxLength(30);
            modelBuilder.Entity<Customer>().Property(ln => ln.LastName).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(e => e.Email).HasMaxLength(50);*/

            modelBuilder.ApplyConfiguration(new CustomerPreferenceDbConfiguration());
            /*modelBuilder.Entity<CustomerPreference>().HasKey(k=>new {k.CustomerId,k.PreferenceId});
            modelBuilder.Entity<CustomerPreference>().HasOne(c => c.Customer).WithMany(cp => cp.CustomerPreferences).HasForeignKey(fk => fk.CustomerId);
            modelBuilder.Entity<CustomerPreference>().HasOne(p => p.Preference).WithMany(cp => cp.CustomerPreferences).HasForeignKey(fk => fk.PreferenceId);*/

            modelBuilder.ApplyConfiguration(new PromoCodeDbConfiguration());
            /*modelBuilder.Entity<PromoCode>().HasOne(c => c.Customer).WithMany(p => p.PromoCodes).HasForeignKey(fk => fk.CustomerId);
            modelBuilder.Entity<PromoCode>().Property(c => c.Code).HasMaxLength(15);
            modelBuilder.Entity<PromoCode>().Property(si => si.ServiceInfo).HasMaxLength(50);*/



        }
    }
   


}
