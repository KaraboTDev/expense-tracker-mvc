using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceDbContext : DbContext
    {
        //The constructor receives Options that tell it, "Hey, we are using SQL Server today!"
        //or "We are using SQLite!" This ensures the robot brings the right tools for the job.
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
        {
            
        }
        //i use this to create an expenses table in my database
        public DbSet<Expense> Expenses { get; set; }
    }
}
