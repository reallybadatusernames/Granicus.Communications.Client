using System.Threading.Tasks;

namespace Granicus.Infrastructure.Infrastructure
{
    public interface IRequestHandler<in TParameter, out TResult> where TResult : IResponse where TParameter : IRequest
    {
        TResult ProcessRequest();
    }

    public interface IRequestHandlerAsync<TParameter, TResult> where TResult : IResponse where TParameter : IRequest
    {
        Task<TResult> ProcessRequestAsync();
    }
}
