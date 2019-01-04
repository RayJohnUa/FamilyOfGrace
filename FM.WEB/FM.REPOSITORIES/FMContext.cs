﻿using FM.DATA;
using Microsoft.EntityFrameworkCore;

namespace FM.REPOSITORIES
{
    public class FMContext : DbContext
    {
        public FMContext(DbContextOptions<FMContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}