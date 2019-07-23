using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanadaSurvey.CommunicationComponent
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string  Message { get; set; }
    }
}
