using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Configuration
{
    public interface IResult
    {
        public string Message { get; }
        public bool IsSuccess { get; }
    }
    public interface IResult<T> : IResult 
    {
        public T Data { get; }
    }

    public class Result : IResult
    {
        private string _message;
        private bool _success;
        public string Message => _message;

        public bool IsSuccess => _success;
        private Result() 
        { }
        public static IResult Fail (string message)
        {   
            if (message == null)
                throw new ArgumentNullException ("message");
            return new Result () { _success = false, _message = message };

        }
        public static IResult Success() 
        {
            return new Result() { _success = true };
        }
    }

    public class Result<T> : IResult<T>
    {
        private T _result;
        private bool _success;
        private string _message;

        public T Data => _result;

        public string Message => _message;

        public bool IsSuccess => _success;

        public static IResult<T> Fail(string message)
        {
            return new Result<T> {  _success = false, _message = message };
        }
        public static IResult<T> Success(T data)
        {
            return new Result<T> { _result = data, _success = true };
        }


    }
}
