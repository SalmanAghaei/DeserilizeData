using System.Net;
using System.Threading.Tasks;
using System.Transactions;

namespace Toolkit;

public class ServiceResult
{
    public ServiceResult()
    {

    }
    public ServiceResult(HttpStatusCode statusCode, bool isSuccess, string message)
    {
        HttpStatusCode = statusCode;
        IsSuccess = isSuccess;
        Message = message;
    }
    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";
}
public class ServiceResult<TData> : ServiceResult
{
    public ServiceResult(TData data)
    {
        Data = data;
    }

    public ServiceResult(HttpStatusCode statusCode, bool isSuccess, string message, TData data) : base(statusCode, isSuccess, message)
    {
        Data = data;
    }

    public TData Data { get; set; }
}
public static class ServiceResultHandler
{

    public static ServiceResult Ok() =>
        new ServiceResult();

    public static ServiceResult Fail(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "") =>
        new ServiceResult(statusCode, false, message);

    public static Task<ServiceResult> OkAsync() =>
        Task.FromResult(new ServiceResult());

    public static Task<ServiceResult> FailAsync(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "") =>
         Task.FromResult(new ServiceResult(statusCode, false, message));




    public static ServiceResult<TData> Ok<TData>(TData data) =>
        new ServiceResult<TData>(data);

    public static ServiceResult<TData> Fail<TData>(TData data, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "") =>
        new ServiceResult<TData>(statusCode, false, message, data);

    public static Task<ServiceResult<TData>> OkAsync<TData>(TData data) =>
        Task.FromResult(new ServiceResult<TData>(data));

    public static Task<ServiceResult<TData>> FailAsync<TData>(TData data, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "") =>
         Task.FromResult(new ServiceResult<TData>(statusCode, false, message, data));
}
