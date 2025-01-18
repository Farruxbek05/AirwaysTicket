using Airways.Core.Common;

namespace Airways.Application.Models;


// ApiResult class representing success or failure.
public class ApiResult
{
    protected internal ApiResult(bool isSuccess, string? successMessage, Error? error)
    {
        // Check for valid success and error combination
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException("Success result cannot have an error.");

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException("Failure result must have an error.");

        IsSuccess = isSuccess;
        SuccessMessage = successMessage;
        Error = error ?? Error.None;  // Ensure error is never null
    }

    public bool IsSuccess { get; private set; }
    public string? SuccessMessage { get; private set; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; private set; }

    // Create a successful result with no message
    public static ApiResult Success() => new ApiResult(true, string.Empty, null);

    // Create a successful result
    public static ApiResult Success(string successMessage = null) => new ApiResult(true, successMessage, null);

    // Create a failure result with no message
    public static ApiResult Failure() => new ApiResult(false, string.Empty, Error.None);

    // Create a failure result with an error
    public static ApiResult Failure(Error error) => new ApiResult(false, string.Empty, error);

    // Create a failure result with an error
    public static ApiResult Failure(Error error, string failureMessage) => new ApiResult(false, failureMessage, error);

}

// ApiResult<TValue> class for handling success or failure with a value
public class ApiResult<TValue> : ApiResult
{
    private TValue? _value;

    protected internal ApiResult(TValue? value, string? successMessage, bool isSuccess, Error? error)
        : base(isSuccess, successMessage, error)
    {
        _value = value;
    }

    // The value of a successful result
    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    // Sort method for collections
    public void Sort(Func<TValue, TValue, int> comparator)
    {
        if (_value is IEnumerable<TValue> collection)
        {
            var sortedCollection = collection.OrderBy(item => item, new ComparisonComparer(comparator));
            _value = (TValue)(object)sortedCollection.ToList(); // Using List for sorting
        }
        else
        {
            throw new InvalidOperationException("Value must be a collection to sort.");
        }
    }

    // Create a successful result with a value
    public static ApiResult<TValue> Success(TValue value, string? successMessage = null)
        => new ApiResult<TValue>(value, successMessage, true, Error.None);

    // Create a failure result with an error
    public static ApiResult<TValue> Failure(Error error, string? failureMessage = null)
        => new ApiResult<TValue>(default, failureMessage, false, error);

    // Create a ApiResult<TValue> from a nullable value
    public static ApiResult<TValue> Create(TValue? value)
        => value != null ? Success(value) : Failure(Error.NullValue);

    // Implicit conversion operator to allow direct conversion from TValue to ApiResult<TValue>
    public static implicit operator ApiResult<TValue>(TValue? value) => Create(value);

    // Helper class for comparison
    private class ComparisonComparer : IComparer<TValue>
    {
        private readonly Func<TValue, TValue, int> _comparator;

        public ComparisonComparer(Func<TValue, TValue, int> comparator)
        {
            _comparator = comparator;
        }

        public int Compare(TValue x, TValue y) => _comparator(x, y);
    }
}


