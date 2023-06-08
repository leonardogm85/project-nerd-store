using FluentValidation.Results;

namespace NerdStore.Core.Domain
{
    public interface IValidatable
    {
        ValidationResult GetValidationResult();
    }
}
