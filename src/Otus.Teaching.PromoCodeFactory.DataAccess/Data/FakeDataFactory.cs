﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Data
{
    public static class FakeDataFactory
    {

        public static IEnumerable<Employee> Employees => new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                Email = "owner@somemail.ru",
                FirstName = "Иван",
                LastName = "Сергеев",
                RoleId = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                AppliedPromocodesCount = 5
            },
            new Employee()
            {
                Id = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                Email = "andreev@somemail.ru",
                FirstName = "Петр",
                LastName = "Андреев",
                RoleId = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                AppliedPromocodesCount = 10
            },
        };

        public static IEnumerable<Role> Roles => new List<Role>()
        {
            new Role()
            {
                Id = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                Name = "Admin",
                Description = "Администратор",
            },
            new Role()
            {
                Id = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                Name = "PartnerManager",
                Description = "Партнерский менеджер"
            }
        };

        public static IEnumerable<Preference> Preferences => new List<Preference>()
        {
            new Preference()
            {
                Id = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                Name = "Театр",
            },
            new Preference()
            {
                Id = Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                Name = "Семья",
            },
            new Preference()
            {
                Id = Guid.Parse("76324c47-68d2-472d-abb8-33cfa8cc0c84"),
                Name = "Дети",
            }
        };

        public static List<Customer> Customers
        {
            get
            {
                
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99d"),
                        Email = "ivan_sergeev@mail.ru",
                        FirstName = "Иван",
                        LastName = "Петров",

                        /*CustomerPreferences= new List<CustomerPreference>()
                        {
                                new CustomerPreference()
                                {
                                    CustomerId=customerId,
                                    PreferenceId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c")
                                },
                                new CustomerPreference()
                                {
                                    CustomerId=customerId,
                                    PreferenceId=Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd")
                                }
                        }*/
                    },

                     new Customer()
                    {
                        Id = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef97e"),
                        Email = "ivanov@mail.ru",
                        FirstName = "Иван",
                        LastName = "Иванов",
                        /*
                        CustomerPreferences = new List<CustomerPreference>
                        {
                                new CustomerPreference()
                                {
                                        CustomerId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef97e"),
                                        PreferenceId=Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd")
                                },
                                new CustomerPreference()
                                {
                                        CustomerId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef97e"),
                                        PreferenceId=Guid.Parse("76324c47-68d2-472d-abb8-33cfa8cc0c84")
                                }
                        }*/
                    }
                };

                return customers;
            }
        }
        public static List<CustomerPreference> CustomerPreferences
        {
            get
            {
                var customerPereference = new List<CustomerPreference>()
                {
                    new CustomerPreference()
                    {
                        CustomerId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99d"),
                        PreferenceId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c")
                    },
                    new CustomerPreference()
                    {
                        CustomerId=Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef97e"),
                        PreferenceId=Guid.Parse("c4bda62e-fc74-4256-a956-4760b3858cbd")
                    },

                };
                return customerPereference;

            }
        }
        public static List<PromoCode> PromoCodes
        {
            get
            {
                var promoCodes = new List<PromoCode>()
                {
                    new PromoCode()
                    {
                        Id = Guid.Parse("2fc304b2-61ec-4c2c-9fc0-80eda981c1f3"),
                        Code = "Promo",
                        ServiceInfo = "Some info",
                        BeginDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(5),
                        PartnetManagerId = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                        CustomerId = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99d"),
                        PreferenceId = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c")

                    }
                };
                return promoCodes;
            }
        }
    }
}
 