namespace Repository.Core.Types;

public class InValidEntityException : Exception
{
    public IEnumerable<string> ValidationErrors { get; }

    public InValidEntityException(IEnumerable<string> validationErrors)
    {
        ValidationErrors = validationErrors;
    }
}