using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanadaSurvey.Server.Core.Responses
{
    public class ByeResponse : BaseResponse
    {
        public ByeResponse(string incomingMessage, Hub hub) : base(incomingMessage, hub)
        {

        }

        public override string GetReponse()
        {
            var client = GetCurrentClient();

            var awaiter = client.SendAsync("ReceiveMessage", "Bye").GetAwaiter();

            //Context.Connection.GetHttpContext().Abort();
            awaiter.OnCompleted(() =>
            {
                client.SendAsync("Disconnect");
                
            });

            return "Bye";
        }


    }
}
