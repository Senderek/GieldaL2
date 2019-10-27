using GieldaL2.DB.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.DB
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
