package ecologylab.chatTutorial;

public interface ChatUpdateListener
{
	public final static String CHAT_UPDATE_LISTENER = "CHAT_UPDATE_LISTENER";
	
	void recievedUpdate(ChatUpdate response);
}