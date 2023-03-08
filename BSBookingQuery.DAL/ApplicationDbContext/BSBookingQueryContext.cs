using BSBookingQuery.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace BSBookingQuery.DAL.ApplicationDbContext
{
    public class BSBookingQueryContext
        : DbContext
    {
        public BSBookingQueryContext(DbContextOptions options) : base(options) { }
        public DbSet<Hotel> Hotel
        {
            get;
            set;
        }
        public DbSet<Rating> Rating
        {
            get;
            set;
        }
        public DbSet<Location> Location
        {
            get;
            set;
        }

        public DbSet<Comment> Comment { get; set; }
    }
}
