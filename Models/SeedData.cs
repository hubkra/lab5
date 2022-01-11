using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace lab5.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new aspNetlab5Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<aspNetlab5Context>>()))
            {
                // Look for any movies.
                if (context.aspNetlab5.Any())
                {
                    return;   // DB has been seeded
                }

                context.aspNetlab5.AddRange(
                    new aspNetlab5Item
                    {
                        Name = "Hubert",
                        Surname = "Kras",
                        EmployeeId = 40215,
                        EmployeeTask = "Zrobic Zadanie",
                        IsComplete = true
                    },

                    new aspNetlab5Item
                    {
                        Name = "Elwira",
                        Surname = "Maczek",
                        EmployeeId = 9021,
                        EmployeeTask = "Sprawdzić zadanie",
                        IsComplete = false
                    },

                    new aspNetlab5Item
                    {
                        Name = "Kacper",
                        Surname = "Ochlejus",
                        EmployeeId = 0921,
                        EmployeeTask = "Zrobic zakupy",
                        IsComplete = false
                    },

                    new aspNetlab5Item
                    {
                        Name = "Marek",
                        Surname = "Towarek",
                        EmployeeId = 3221,
                        EmployeeTask = "Zamowic rzeczy na magazyn",
                        IsComplete = true
                    }




                );
                context.SaveChanges();
            }
        }
    }
}
