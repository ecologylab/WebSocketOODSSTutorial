using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSocketOODSSTutorial.Chat
{
    interface ChatUpdateListener
    {
        void ReceivedUpdate(ChatUpdate response);
    }
}
