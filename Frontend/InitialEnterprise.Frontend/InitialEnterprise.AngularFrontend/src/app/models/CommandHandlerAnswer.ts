export	interface CommandHandlerAnswer {
  aggregateRoot: any;
  validationResult: ValidationResult;
}

export	interface ValidationResult {
  isValid: boolean;
  errors: ValidationFailure[];
}

// errors: { [key: string]: string } = {};
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
