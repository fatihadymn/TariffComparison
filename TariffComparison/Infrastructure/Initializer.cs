using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TariffComparison.Data;
using TariffComparison.Items.Entities;
using TariffComparison.Items.Models.Enum;

namespace TariffComparison.Infrastructure
{
    public class Initializer
    {
        public static void InitializeDatabase(IApplicationBuilder application)
        {
            var serviceScope = application.ApplicationServices.CreateScope();

            var provider = serviceScope.ServiceProvider;

            var db = provider.GetService<ApplicationContext>();

            db.Database.Migrate();
        }

        public static void InitializeDatas(IApplicationBuilder application)
        {
            var serviceScope = application.ApplicationServices.CreateScope();

            var provider = serviceScope.ServiceProvider;

            var db = provider.GetService<ApplicationContext>();

            var tariffs = new List<Tariff>()
            {
                new Tariff()
                {
                    Id = Guid.NewGuid(),
                    Name = TariffName.Basic,
                    BaseCost = 5,
                    ExtraCost = 0.22m,
                    BaseLimit = null,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsActive = true,
                },

                new Tariff()
                {
                    Id = Guid.NewGuid(),
                    Name = TariffName.Packaged,
                    BaseCost = 800,
                    ExtraCost = 0.3m,
                    BaseLimit = 4000,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsActive = true,
                }
            };

            db.Tariffs.AddRange(tariffs);

            db.SaveChanges();
        }
    }
}
