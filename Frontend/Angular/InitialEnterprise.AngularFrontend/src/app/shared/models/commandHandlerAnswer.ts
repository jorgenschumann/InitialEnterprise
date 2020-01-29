export	interface CommandHandlerAnswer<TAggregate> {
  aggregateRoot: TAggregate;
  validationResult: ValidationResult;
}

export	interface ValidationResult {
  isValid: boolean;
  errors: ValidationFailure[];
}

export interface ValidationFailure {
  propertyName: string;
  errorMessage: string;
  severity: Severity;
}

enum Severity {
  error,
  warning ,
  info
}
