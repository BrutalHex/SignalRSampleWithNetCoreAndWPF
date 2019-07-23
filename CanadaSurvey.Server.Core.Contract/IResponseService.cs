using Microsoft.AspNetCore.SignalR;
using System;

namespace CanadaSurvey.Server.Core.Contract
{
    public interface IResponseService
    {
        string GetResponse(string receivedMessage, Hub hub);
    }
}
