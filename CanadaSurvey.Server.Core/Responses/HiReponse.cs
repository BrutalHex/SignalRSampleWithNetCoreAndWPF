using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CanadaSurvey.Server.Core.Responses
{
    public class HiResponse: BaseResponse
    {
        public HiResponse(string incomingMessage, Hub hub):base(incomingMessage, hub)
        {

        }

        public override string GetReponse()
        {
            string result = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                return "Hi";
            }).Result;

            var client = GetCurrentClient();
            client.SendAsync("ReceiveMessage", result);

            return result;
        }

        
    }
}
