using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.OODSS.Messages;
using Simpl.Serialization.Attributes;
using ecologylab.collections;

namespace WebSocketOODSSTutorial.Chat
{
    class ChatUpdate : UpdateMessage
    {
        [SimplScalar] private string message;

        [SimplScalar] private string id;

        public ChatUpdate()
        {
        }

        public ChatUpdate(string message, string id)
        {
            this.message = message;
            this.id = id;
        }

        public override void ProcessUpdate(Scope<object> applicationObjectScope)
        {
            //get lisener from applicationobjacetscope
            var listener = (ChatUpdateListener) applicationObjectScope.Get(ChatConstants.ChatUpdateLisener);
            //call the listener's receive update
            if (listener != null)
            {
                listener.ReceivedUpdate(this);
            }
            else
            {
                Console.WriteLine("Listener not set in application scope. Can't display message from\n"+ id + ": " + message);
            }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
