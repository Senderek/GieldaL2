using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GieldaL2.DB
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new GieldaL2Context(serviceProvider.GetRequiredService<DbContextOptions<GieldaL2Context>>()))
            {
                
            }


        }
    }
}
