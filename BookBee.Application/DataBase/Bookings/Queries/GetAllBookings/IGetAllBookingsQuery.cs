namespace BookBee.Application.DataBase.Bookings.Queries.GetAllBookings
{
    public interface IGetAllBookingsQuery
    {
        Task<List<GetAllBookingsModel>> Execute();
    }
}
