namespace BookBee.Application.DataBase.User.Queries.GetUserByID
{
    public interface IGetUserByIdQuery
    {
        Task<GetUserByIdModel> Execute(int userId);
    }
}
