using System;
using System.Collections.Generic;
using WebAPIRuleEngine.Validations;

namespace WebAPIRuleEngine.Exceptions
{
    public class ValidationException : Exception
    {
        public List<BusinessValidationError> BusinessValidationErrors { get; set; }

        public ValidationException(List<BusinessValidationError> errors) : base("Business Validation errors occured")
        {
            this.BusinessValidationErrors = errors;
        }
    }
}