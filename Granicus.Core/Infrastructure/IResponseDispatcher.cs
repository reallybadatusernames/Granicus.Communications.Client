using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granicus.Core.Infrastructure
{
    public interface IRequestDispatcher
    {
        TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IRequest
            where TResult : IResponse;
    }
}
