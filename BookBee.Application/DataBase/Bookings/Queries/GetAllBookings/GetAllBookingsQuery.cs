using Microsoft.EntityFrameworkCore;

namespace BookBee.Application.DataBase.Bookings.Queries.GetAllBookings
{
    internal class GetAllBookingsQuery : IGetAllBookingsQuery
    {
        private readonly IDataBaseService _databaseService;
        public GetAllBookingsQuery(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from booking in _databaseService.Bookings
                                join customer in _databaseService.Customers
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingsModel
                                {
                                    BookingId = booking.BookingId,
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber
                                }).ToListAsync();

            return result;
        }
    }
}
