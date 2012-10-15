using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Simpl.Fundamental.Net;
using Simpl.Serialization;
using ecologylab.collections;
using Simpl.OODSS.Distributed.Server;

namespace WebSocketOODSSTutorial.Chat
{
    public class ChatServer
    {
        private static readonly int _idleTimeout = -1;
        private static readonly int _MTU = -1;

        public static void StartServer()
        {
            SimplTypesScope chatTranslation = ChatTranslations.Get();
            Scope<object> applicationScope = new Scope<object>();

            IPAddress[] locals = NetTools.GetAllIPAddressesForLocalhost();

            WebSocketOODSSServer chatServer = new WebSocketOODSSServer(chatTranslation, applicationScope, _idleTimeout,
                                                                       _MTU);

            chatServer.Start();
        }

    }
}
