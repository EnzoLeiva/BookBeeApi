﻿using Microsoft.EntityFrameworkCore;

namespace BookBee.Application.DataBase.Bookings.Queries.GetBookingsByType
{
    public class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetBookingsByTypeQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<List<GetBookingsByTypeModel>> Execute(string type)
        {
            var result = await (from booking in _dataBaseService.Bookings
                                join customer in _dataBaseService.Customers
                                on booking.CustomerId equals customer.CustomerId
                                where booking.Type == type

                                select new GetBookingsByTypeModel
                                {
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
