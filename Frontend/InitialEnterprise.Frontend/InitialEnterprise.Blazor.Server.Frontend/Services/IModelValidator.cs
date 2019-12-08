using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public interface IModelValidator
    {
        event EventHandler<ValidationErrorEventArgs> OnValidationDone;
        bool Validate(object instance);
    }

    public class ValidationErrorEventArgs
    {
        public List<ValidationResult> Errors { get; set; }
        public object Instance { get; set; }
    }
}
