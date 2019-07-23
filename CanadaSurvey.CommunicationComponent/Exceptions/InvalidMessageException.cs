using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CanadaSurvey.CommunicationComponent.Exceptions
{
    public class InvalidMessageException: SystemException
    {
        public InvalidMessageException(string message):base($"invalid message received.this is the message : {message}")
        {
            

        }

    }
}
