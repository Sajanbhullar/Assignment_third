using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Website.Data;
using System;
using System.Linq;

namespace Website.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PersonalContext>>()))
            {
                // Look for any movies.
                if (context.Websiteinfo.Any())
                {
                    return;   // DB has been seeded
                }

                context.Websiteinfo.AddRange(
                    new Websiteinfo
                    {
                        ID=0,
                        FirstName="SajanPreet",
                        LastName="Singh",
                        Age=23,
                        Gender="male",
                        Hobbies="Sport"
                        

                    }

            
                );
                context.SaveChanges();
            }
        }
    }
}