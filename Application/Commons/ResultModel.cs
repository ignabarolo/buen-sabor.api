
namespace Application.Commons;

internal interface HttpResultModel<T1, T2>
{
    public T1 Request { get; set;}
    public T2 Response { get; set;}
}
