using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaSurvey.CommunicationComponent
{
    public interface IClient
    {
        Task<string> SendAsync(string message);
    }
}
