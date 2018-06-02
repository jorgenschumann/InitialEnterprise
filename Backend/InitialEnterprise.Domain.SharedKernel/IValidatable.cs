using System;
using System.Collections.Generic;
using System.Text;

namespace InitialEnterprise.Domain.SharedKernel
{
    public interface IValidatable
    {
        Object Validate();

        Boolean IsValid { get; }
    }
}
