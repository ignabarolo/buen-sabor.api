
using MediatR;

namespace Application.Commons;

public interface IQuery<T, TR1> : IRequest<ResultModel<T, TR1>>
    where T : notnull
    where TR1 : notnull
{
}

public interface IRequestCustom<TRequest, TResponse1> : IQuery<TRequest, TResponse1>
    where TRequest : notnull
    where TResponse1 : notnull
{
}

public record ResultModel<TRequest, TResponse>(TRequest request, TResponse Result, bool IsError = false, string Error = default!)
    where TRequest : notnull
    where TResponse : notnull
{
    public static ResultModel<TRequest, TResponse> Transform(TRequest request, TResponse result, bool isError = false, string errors = default!)
    {
        return new(request, result, isError, errors ?? string.Empty);
    }
}
