package ecologylab.chatTutorial;

import ecologylab.collections.Scope;
import ecologylab.oodss.distributed.server.clientsessionmanager.SessionHandle;
import ecologylab.oodss.messages.UpdateMessage;
import ecologylab.serialization.annotations.simpl_scalar;

public class ChatUpdate extends UpdateMessage
{
	@simpl_scalar
	private String	message;

	@simpl_scalar
	private String id;
	/**
	 * Constructor used on client. Fields populated automatically by
	 * ecologylab.serialization
	 */
	public ChatUpdate()
	{
	}

	/**
	 * Constructor used on server
	 * 
	 * @param message
	 *           the chat message
	 * 
	 * @param handle
	 *           handle of originating client
	 */
	public ChatUpdate(String message, String id)
	{
		this.message = message;
		this.id = id;
	}

	/**
	 * Called automatically by OODSS on client
	 */
	@Override
	public void processUpdate(Scope appObjScope)
	{
		/* get the chat listener */
		ChatUpdateListener listener = (ChatUpdateListener) appObjScope
				.get(ChatUpdateListener.CHAT_UPDATE_LISTENER);

		/* report incoming update */
		if (listener != null)
		{
			listener.recievedUpdate(this);
		}
		else
		{
			warning("Listener not set in application scope. Can't display message from\n"
				+ message);
		}
	}

	public String getMessage()
	{
		return message;
	}

	public String getId()
	{
		return id;
	}

}
