using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simpl.OODSS.Messages;
using Simpl.Serialization;

namespace WebSocketOODSSTutorial.Chat
{
    class ChatTranslations
    {
        public const string TranslationSpaceName = "ChatTranslations";

        public static SimplTypesScope Get()
        {
            return SimplTypesScope.Get(TranslationSpaceName, DefaultServicesTranslations.Get(), typeof (ChatRequest),
                                       typeof (ChatUpdate));
        }
    }
}
