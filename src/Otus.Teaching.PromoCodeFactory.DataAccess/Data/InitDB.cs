using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Data
{
    public static class InitDB
    {
        public static async void Init(DataContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            await dbContext.AddRangeAsync(FakeDataFactory.Employees);
            await dbContext.AddRangeAsync(FakeDataFactory.Roles);
            await dbContext.AddRangeAsync(FakeDataFactory.Customers);
            await dbContext.AddRangeAsync(FakeDataFactory.Preferences);
            await dbContext.AddRangeAsync(FakeDataFactory.CustomerPreferences);
            await dbContext.AddRangeAsync(FakeDataFactory.PromoCodes);

            //await dbContext.SaveChangesAsync();
        }
    }
}
