using Microsoft.EntityFrameworkCore;

namespace BankingWebApp.Models
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options)
    : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
