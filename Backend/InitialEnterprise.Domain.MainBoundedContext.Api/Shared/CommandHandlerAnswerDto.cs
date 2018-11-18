using FluentValidation.Results;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Shared
{
    public class CommandHandlerAnswerDto<TAggregateRootDto>
    {
        public TAggregateRootDto AggregateRoot { get; set; }
        public ValidationResult ValidationResult { get; set; }       
    }
}