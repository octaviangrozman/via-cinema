using Microsoft.EntityFrameworkCore;
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
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Screening> Screenings { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
    }
}
