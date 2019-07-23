using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanadaSurvey.Server.Core.Responses
{
    public class PingResponse : BaseResponse
    {
        public PingResponse(string incomingMessage, Hub hub) : base(incomingMessage, hub)
        {

        }

        public override string GetReponse()
        {
            var client = GetCurrentClient();
            var result = "Pong";
            client.SendAsync("ReceiveMessage", result);

            return result;
        }

    }
}
