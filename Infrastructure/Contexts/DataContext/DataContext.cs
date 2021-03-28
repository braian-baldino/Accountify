using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Reflection;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //DBSETS

        //The following code will run the Data/Config custom configuration classes for the model.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
