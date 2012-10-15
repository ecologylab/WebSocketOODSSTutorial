using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.Fundamental.Generic;
using Simpl.OODSS.Distributed.Common;
using Simpl.OODSS.Messages;
using Simpl.OODSS.Distributed.Server.ClientSessionManager;
using Simpl.Serialization.Attributes;
using ecologylab.collections;

namespace WebSocketOODSSTutorial.Chat
{
    class ChatRequest:RequestMessage
    {
        [SimplScalar] private string message;

        public ChatRequest()
        {
        }

        public ChatRequest(string message)
        {
            this.message = message;
        }

        public override ResponseMessage PerformService(Scope<object> clientSessionScope)
        {
            var sessionManagerMap =
                (DictionaryList<object, WebSocketClientSessionManager>)
                clientSessionScope.Get(SessionObjects.SessionsMap);

            string sessionId = (string) clientSessionScope.Get(SessionObjects.SessionId);

            ChatUpdate messageUpdate = new ChatUpdate(message, sessionId);

            foreach (WebSocketClientSessionManager otherClient in sessionManagerMap.Values)
            {
                Console.WriteLine(otherClient.SessionId + "Checking to make sure not " + sessionId);
                if (!otherClient.SessionId.Equals(sessionId))
                {
                    otherClient.SendUpdateToClient(messageUpdate, otherClient.SessionId);
                }
            }

            return OkResponse.ReusableInstance;
        }
    }
}
