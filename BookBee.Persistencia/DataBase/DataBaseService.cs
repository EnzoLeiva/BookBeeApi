using BookBee.Application.DataBase;
using BookBee.Domain.Entities.Booking;
using BookBee.Domain.Entities.Customer;
using BookBee.Domain.Entities.User;
using BookBee.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookBee.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }

    }
}
