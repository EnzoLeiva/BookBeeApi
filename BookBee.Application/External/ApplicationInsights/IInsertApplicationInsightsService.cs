using BookBee.Domain.Models.ApplicationInsights;

namespace BookBee.Application.External.ApplicationInsights
{
    public interface IInsertApplicationInsightsService
    {
        bool Execute(InsertApplicationInsightsModel metric);
    }
}
