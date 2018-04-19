﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viacinema.Models;

namespace viacinema.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
    }
}