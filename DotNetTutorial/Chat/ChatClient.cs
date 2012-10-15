using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.OODSS.Distributed.Client;
using Simpl.Serialization;
using ecologylab.collections;

namespace WebSocketOODSSTutorial.Chat
{
    //public delegate void ReceivedUpdateEventHandler(object sender, EventArgs e);

    class ChatClient:ChatUpdateListener
    {
        public static string ServerAddress = "localhost";

        public static int PortNumber = 2018;

        private WebSocketOODSSClient _client;
        private SimplTypesScope chatTranslation;
        private Scope<object> clientScope;

        public event EventHandler Updated;

        public ChatClient()
        {
            chatTranslation = ChatTranslations.Get();
            clientScope = new Scope<object>();
            clientScope.Add(ChatConstants.ChatUpdateLisener, this);
            _client = new WebSocketOODSSClient(ServerAddress, PortNumber, chatTranslation, clientScope);
        }

        public void ReceivedUpdate(ChatUpdate response)
        {
            Console.WriteLine(response.Id + "->" + response.Message);
            Console.WriteLine();
            OnUpdated(new UpdateEventArgs(response.Id, response.Message));
            //_mainWindow.UpdateReceivedMessage(response.Id, response.Message);
        }

        protected void OnUpdated(UpdateEventArgs e)
        {
            if (Updated != null)
                Updated(this, e);
        }

        public void SendMessage(string message)
        {
            ChatRequest chatRequest = new ChatRequest(message);
            _client.RequestAsync(chatRequest);
            Console.WriteLine("---------me------->" + message);
            Console.WriteLine();
        }

        public void StartConnection()
        {
            _client.Start();
            _client.ConnectAsync();
        }
    }

    public class UpdateEventArgs : EventArgs
    {
        public readonly string Id;
        public readonly string Message;
        public UpdateEventArgs(string id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
