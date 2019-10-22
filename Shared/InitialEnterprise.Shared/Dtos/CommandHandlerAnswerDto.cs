using FluentValidation.Results;

namespace InitialEnterprise.Shared.Dtos
{
    public class CommandHandlerAnswerDto<TAggregateRootDto>
    {
        public TAggregateRootDto AggregateRoot { get; set; }
        public ValidationResult ValidationResult { get; set; }       
    }
}