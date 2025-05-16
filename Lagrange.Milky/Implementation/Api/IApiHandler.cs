using Lagrange.Milky.Implementation.Api.Params;
using Lagrange.Milky.Implementation.Api.Results;

namespace Lagrange.Milky.Implementation.Api;

public interface IApiHandler
{
    Type ParamType { get; }

    ValueTask<IApiResult> HandleAsync(object param, CancellationToken token);
}

public interface IApiHandler<T> : IApiHandler
{
    Type IApiHandler.ParamType => typeof(T);

    ValueTask<IApiResult> IApiHandler.HandleAsync(object param, CancellationToken token) => HandleAsync((T)param, token);

    ValueTask<IApiResult> HandleAsync(T param, CancellationToken token);
}

public interface IEmptyParamApiHandler : IApiHandler<EmptyParam>
{
    ValueTask<IApiResult> IApiHandler<EmptyParam>.HandleAsync(EmptyParam param, CancellationToken token) => HandleAsync(token);

    ValueTask<IApiResult> HandleAsync(CancellationToken token);
}