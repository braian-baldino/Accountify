using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Reflection;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //DBSETS
        public DbSet<AnualBalance> AnualBalances { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleSpending> VehicleSpendings { get; set; }

        //The following code will run the Data/Config custom configuration classes for the model.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
