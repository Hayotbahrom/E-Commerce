namespace E_Commerce.Service.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; set; }

    public CustomException(int code,  string message) : base(message)
    {
        this.StatusCode = code;
    }
}
