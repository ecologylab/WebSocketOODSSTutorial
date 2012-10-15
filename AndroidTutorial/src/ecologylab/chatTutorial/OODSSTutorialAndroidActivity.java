package ecologylab.chatTutorial;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.ScrollView;
import android.widget.TextView;

public class OODSSTutorialAndroidActivity extends Activity {
    /** Called when the activity is first created. */
	private static ChatClient chatClient;  
	
	
	@Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        if (chatClient == null)
        {	
        	chatClient = new ChatClient(this);
        }	
    }
    
	@Override
    public void onResume()
    {
    	super.onResume();
    }
	  
	public void onSendButtonClicked(View v)
	{
		EditText input = (EditText) findViewById(R.id.inputText);
		TextView display = (TextView) findViewById(R.id.display);
		String message = input.getText().toString();
		chatClient.sendMessage(message);
		display.append("me -> " + message + "\n\n");
		input.clearComposingText();
		input.setText("");
		ScrollView scroll = (ScrollView) findViewById(R.id.scrollView1);
		scroll.fullScroll(View.FOCUS_DOWN);
	}
    
}