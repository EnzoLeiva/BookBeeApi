namespace BookBee.Application.External.Password
{
    public interface IPasswordService
    {
        bool Check(string hash, string password);
        string Hash(string password);

    }
}
