using Microsoft.EntityFrameworkCore;
using NET.Veterinary.CA.Domain.AggregateRoots;

namespace NET.Veterinary.CA.Infrastructure.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Appointment> Appointments { get; set; } 
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var assembly = typeof(ApplicationContext).Assembly;

           modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}