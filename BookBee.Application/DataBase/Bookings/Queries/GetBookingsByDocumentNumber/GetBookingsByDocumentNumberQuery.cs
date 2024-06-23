using Microsoft.EntityFrameworkCore;

namespace BookBee.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery : IGetBookingsByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetBookingsByDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in _dataBaseService.Bookings
                                join customer in _dataBaseService.Customers
                                on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == documentNumber
                                select new GetBookingsByDocumentNumberModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type
                                }).ToListAsync();

            return result;
        }
    }
}
