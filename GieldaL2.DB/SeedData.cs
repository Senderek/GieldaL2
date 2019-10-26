using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GieldaL2.INFRASTRUCTURE
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GieldaL2Context(serviceProvider.GetRequiredService<DbContextOptions<GieldaL2Context>>()))
            {
                SeedDatabase(context);
            }
        }
        public static void SeedDatabase(GieldaL2Context context)
        {
            //coś tam seeduje
            context.SaveChanges();
        }
    }
}
