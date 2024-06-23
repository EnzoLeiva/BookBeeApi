using BookBee.Domain.Entities.Booking;
using BookBee.Domain.Entities.Customer;
using BookBee.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace BookBee.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<CustomerEntity> Customers { get; set; }
        DbSet<BookingEntity> Bookings { get; set; }
        Task<bool> SaveAsync();
    }
}
