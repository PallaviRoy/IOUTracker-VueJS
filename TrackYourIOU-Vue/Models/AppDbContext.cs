using Microsoft.EntityFrameworkCore;
using TrackYourIOU.Models;

namespace TrackYourIOU.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<TrackYourIOU.Models.Loan> Loan { get; set; }
    }
}