using CanadaSurvey.Server.Core.Contract;
using CanadaSurvey.Server.Core.Responses;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanadaSurvey.Server.Core
{
    public class ResponseService : IResponseService
    {
        public ResponseService()
        {

           
         
        }

        private void InitstrategyList(Hub hub,string incommingMessage)
        {
            ResponseCollection.Add("Hello", new HiResponse(incommingMessage,hub));//one second delay
            ResponseCollection.Add("Bye", new ByeResponse(incommingMessage, hub));//close connection
            ResponseCollection.Add("Ping",new PingResponse(incommingMessage, hub));
            //other should raise exception in client
        }

        Dictionary<string, BaseResponse> ResponseCollection = new Dictionary<string, BaseResponse>();

        public string GetResponse(string receivedMessage, Hub hub)
        {
            InitstrategyList(hub, receivedMessage);
           

            if (ResponseCollection.ContainsKey(receivedMessage))
            {
                var call = ResponseCollection[receivedMessage];
                return call.GetReponse();
            }
           else
            {

                var exceptionResponse = new InvalidResponse(receivedMessage, hub);
               return exceptionResponse.GetReponse();
            }


        }

       // public delegate string GenerateResponse(string incomingMessage, Hub hub);


       
        

      


        
      

    }





}
