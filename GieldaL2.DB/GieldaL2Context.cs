using GieldaL2.INFRASTRUCTURE.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE
{
    public class GieldaL2Context : IdentityDbContext
    {
        public GieldaL2Context(DbContextOptions<GieldaL2Context> options) : base(options)
        {
        }

        public static GieldaL2Context Create(DbContextOptions<GieldaL2Context> options)
        {
            return new GieldaL2Context(options);
        }
    }
}
