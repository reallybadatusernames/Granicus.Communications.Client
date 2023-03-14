using System;
using System.Reflection;
using System.Threading.Tasks;

using Granicus.Infrastructure.Infrastructure;

namespace Granicus.Infrastructure.Utilities
{
    public class RequestDispatcher : IRequestDispatcher
    {
        public TResult Dispatch<TParameter, TResult>(TParameter request)
            where TParameter : IRequest
            where TResult : IResponse
        {
            if (!(request is IRequestHandler<TParameter, TResult>))
                throw new NotImplementedException("Request does not implement IRequestHandler");

            MethodInfo mi = typeof(IRequestHandler<TParameter, TResult>).GetMethod("ProcessRequest");
            return (TResult)Convert.ChangeType(mi.Invoke(request, new object[] { }), typeof(TResult));
        }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter request)
            where TParameter : IRequest
            where TResult : IResponse
        {
            MethodInfo mi = typeof(IRequestHandlerAsync<TParameter, TResult>).GetMethod("ProcessRequestAsync");
            var task = (Task<TResult>)mi.Invoke(request, new object[] { request });
            return await task;
        }
    }
}
