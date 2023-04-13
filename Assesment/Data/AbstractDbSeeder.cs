using Assesment.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Assesment.Data
{
    public class AbstractDbSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AbstractDbContext>();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new Users()
                    {
                        Name = "Admin",
                        Email = "admin@mailer.com",
                        Contact = "555-3529-8291",
                        DateCreated = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
