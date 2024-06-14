using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpenceTracker.Models
{
    public class ExpenceDbContext : DbContext
    {
        public ExpenceDbContext(DbContextOptions<ExpenceDbContext> options): base(options) 
        { 

        }
        public DbSet<Items> Items{ get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseType> ExpenseTypes { get; set; }
    }
}
