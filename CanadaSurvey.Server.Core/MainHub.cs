using CanadaSurvey.Server.Core.Contract;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CanadaSurvey.Server.Core
{
    public class MainHub : Hub
    {
        private readonly IResponseService _responseService;

        public MainHub(IResponseService responseService)
        {
            _responseService = responseService;
        }


        public async Task<string> SendMessage(  string message)
        {



           return await Task.Run(  ()=> { return _responseService.GetResponse(message, this); });
        }
    }
}
