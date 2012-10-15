package ecologylab.chatTutorial;

import java.util.HashMap;

import ecologylab.collections.Scope;
import ecologylab.oodss.distributed.common.SessionObjects;
import ecologylab.oodss.distributed.server.clientsessionmanager.SessionHandle;
import ecologylab.oodss.messages.OkResponse;
import ecologylab.oodss.messages.RequestMessage;
import ecologylab.oodss.messages.ResponseMessage;
import ecologylab.serialization.annotations.simpl_scalar;

public class ChatRequest extends RequestMessage
{
	/**
	 * The message being posted.
	 */
	@simpl_scalar
	String									message;

	/**
	 * Constructor used on server. Fields populated automatically by
	 * ecologylab.serialization
	 */
	public ChatRequest()
	{
	}

	/**
	 * Constructor used on client.
	 * 
	 * @param newEcho
	 *           a String that will be passed to the server to broadcast
	 * */
	public ChatRequest(String message)
	{
		this.message = message;
	}

	/**
	 * Called automatically by LSDCS on server
	 */
	@Override
	public ResponseMessage performService(Scope cSScope)
	{
		//implemented in ChatRequest on C# server side;
		/*
		 * Send back a response confirming that we got the request 
		 */
		return OkResponse.reusableInstance;
	}

	public boolean isDisposable()
	{
		return true;
	}
}