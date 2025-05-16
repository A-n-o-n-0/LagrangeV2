using System.Text.Json.Serialization;
using Lagrange.Core;
using Lagrange.Milky.Implementation.Apis.Results;

namespace Lagrange.Milky.Implementation.Apis.System;

[Api("get_login_info")]
public class GetLoginInfoHandler(BotContext bot) : IEmptyParamApiHandler
{
    public ValueTask<IApiResult> HandleAsync(CancellationToken token)
    {
        if (bot.BotInfo == null) return ValueTask.FromResult<IApiResult>(new ApiFailedResult
        {
            Retcode = -1,
            Message = "bot info is null",
        });

        return ValueTask.FromResult<IApiResult>(new ApiOkResult<GetLoginInfoResult>
        {
            Data = new GetLoginInfoResult
            {
                Uin = bot.BotUin,
                Nickname = bot.BotInfo.Name,
            },
        });
    }
}

public class GetLoginInfoResult
{
    [JsonPropertyName("uin")]
    public required long Uin { get; init; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; init; }

}