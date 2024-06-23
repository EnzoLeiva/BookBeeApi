using FluentValidation.Results;

namespace BookBee.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        private string errorMessage;

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }

        public IDictionary<string, string[]> ValidationErrors { get; private set; }
    }
}
