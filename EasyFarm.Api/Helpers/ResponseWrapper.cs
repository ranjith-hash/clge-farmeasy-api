namespace EasyFarm.Api.Helpers;

public class ResponseWrapper<T>
{
    public ResponseWrapper() { }
    public ResponseWrapper(T data, string message = null)
    {
        Message = message;
        ApiData = data;

    }

    public ResponseWrapper(int statusCode, string message, bool sucess, T data)
    {
        StatusCode = statusCode;
        Message = message;
        Sucess = sucess;

        ApiData = data;
    }

    public ResponseWrapper(string message)
    {
        Message = message;
    }

    public ResponseWrapper(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public ResponseWrapper(bool sucess)
    {
        Sucess = sucess; 
    }
        
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public bool Sucess { get; set; }
    public T ApiData { get; set; }
}