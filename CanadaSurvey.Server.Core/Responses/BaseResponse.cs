using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanadaSurvey.Server.Core.Responses
{
    public  abstract class BaseResponse
    {
        public BaseResponse(string incomingMessage, Hub hub)
        {
            Hub = hub;
            IncomingMessage = incomingMessage;
        }


        public Hub Hub { get; }
        public string IncomingMessage { get; }

        public abstract string GetReponse();


        protected IClientProxy GetCurrentClient()
        {
            return Hub.Clients.Client(Hub.Context.ConnectionId);
        }
    }
}
