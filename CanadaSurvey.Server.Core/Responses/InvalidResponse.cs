using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanadaSurvey.Server.Core.Responses
{
    public class InvalidResponse : BaseResponse
    {
        public InvalidResponse(string incomingMessage, Hub hub) : base(incomingMessage, hub)
        {

        }

        public override string GetReponse()
        {
            var client = GetCurrentClient();

            var awaiter = client.SendAsync("RaiseException", IncomingMessage).GetAwaiter();

            return string.Empty;
        }


    }
}
