
using CanadaSurvey.CommunicationComponent.Exceptions;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CanadaSurvey.CommunicationComponent
{
    public class Communicator: IClient
    {
       private readonly HubConnection connection;
        public  Communicator(string url)
        {

          

            connection = new HubConnectionBuilder().WithUrl(url).Build();


            connection.On<string>("RaiseException", str =>
            {
                var ex= new InvalidMessageException(str);
                AddIncomingServerResponse(ex.Message);
               // TODO:  the bubbling does not work correctly, for demo its enough
                throw ex;
            });


            connection.On<string>("ReceiveMessage", str =>
            {
                AddIncomingServerResponse(str);
            });

            connection.On("Disconnect", async () =>
            {
               
               await Disconnect();
            });



        }

        public delegate void MessageReceived(object sender , MessageReceivedEventArgs e);
        public event MessageReceived OnMessageReceived;


       


        private void AddIncomingServerResponse(string message)
        {


             

            OnMessageReceived(this,new MessageReceivedEventArgs
            {
                Message=message

            });

         
        }


       
        public async void CloseChannel()
        {
            await Disconnect();
            await connection.DisposeAsync();
        }

       public async Task Disconnect()
        {
            AddIncomingServerResponse("Server Disconnected");
            await connection.StopAsync();
        }

 

        public async Task<string> SendAsync(string message)
        {
            if (connection.State == HubConnectionState.Disconnected)
            {
                await connection.StartAsync();
            }

           var res=await connection.InvokeAsync<string>("SendMessage", message);

            return res;




        }
    }


}
