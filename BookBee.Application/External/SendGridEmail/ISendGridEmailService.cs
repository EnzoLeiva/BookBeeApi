using BookBee.Domain.Models.SendGridEmailRequestModel;

namespace BookBee.Application.External.SendGridEmail
{
    public interface ISendGridEmailService
    {
        Task<bool> Execute(SendGridEmailRequestModel model);
    }
}
