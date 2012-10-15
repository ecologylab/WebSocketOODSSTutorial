package ecologylab.chatTutorial;

import android.app.Activity;
import android.view.View;
import android.widget.ScrollView;
import android.widget.TextView;
import ecologylab.collections.Scope;
import ecologylab.oodss.distributed.client.WebSocketOODSSClient;
import ecologylab.oodss.distributed.client.WebSocketOODSSConnectionCallbacks;
import ecologylab.serialization.SimplTypesScope;

public class ChatClient implements ChatUpdateListener, WebSocketOODSSConnectionCallbacks
{
	public static String serverAddress = "192.168.137.1";
	public static int portNumber = 2018;
	private WebSocketOODSSClient client;
	private Activity activity;
	private SimplTypesScope chatTranslation;
	private Scope scope;
	
	public ChatClient(Activity activity)
	{
		chatTranslation = ChatTranslations.get();
		scope  = new Scope();
		scope.put(ChatUpdateListener.CHAT_UPDATE_LISTENER, this);
		client = new WebSocketOODSSClient(serverAddress, portNumber, chatTranslation, scope, this);
		this.activity = activity;
		//startConnection();
	}

	//@Override
	public void recievedUpdate(ChatUpdate response)
	{	
		final TextView display = (TextView) activity.findViewById(R.id.display);
	  final String id = response.getId();
	  final String message = response.getMessage();
	  display.post(new Runnable(){

			//@Override
			public void run()
			{
				display.append(id + "->" + message + "\n\n");
			}
	  	
	  });
	  
		final ScrollView scroll = (ScrollView) activity.findViewById(R.id.scrollView1);
		
		scroll.post(new Runnable(){

			public void run() {
				// TODO Auto-generated method stub
				scroll.fullScroll(View.FOCUS_DOWN);
			}
			
		});

	}
	
	public void sendMessage(String message)
	{
		final ChatRequest chatRequest = new ChatRequest(message);
		new Thread(new Runnable() {public void run() { client.sendMessage(chatRequest); }}).start();
	}

	public void webSocketConnected() {
		// allow sending chat request at this point. 
	}
	
//	public void startConnection()
//	{
//		client.connect();
//	}
}
