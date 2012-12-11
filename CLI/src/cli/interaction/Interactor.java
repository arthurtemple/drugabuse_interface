package cli.interaction;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.MalformedURLException;
import java.net.URL;

import cli.backend.URLManager;
import cli.io.Printer;

public class Interactor {

	private enum InteractionState{
		MENU,
		EXIT,
		REQUEST
	}

	private InteractionState state;
	private Printer o;
	private BufferedReader i;
	private String lastDownloadName;

	public Interactor(InputStream in, PrintStream out){
		super();
		this.state = InteractionState.MENU;
		this.o = new Printer(out);
		this.i = new BufferedReader(new InputStreamReader(in));
		this.lastDownloadName = "";
	}

	public void interact() throws IOException{
		while(true){
			o.clear();
			choices();
			act(i.readLine());
			if(this.state == InteractionState.EXIT)
				return;
		}
	}

	private void act(String valueRead) {
		int item;
		try{
			item = Integer.parseInt(valueRead);
		} catch(NumberFormatException e){
			o.print("You must type a number and "+valueRead+" is not a number. Please try to type a correct number.");
			return;
		}
		switch(state){
		case MENU:
			actMenu(item);
			break;
		case REQUEST:
			actRequest(item);
			break;
		case EXIT:
			break;
		}
	}

	private void actMenu(int item) {
		switch(item){
		case 1:
			o.print("Please write your request as you feel it. There is no special keyword, however it is important to specify which drug is causing you trouble.");
			String request = "";
			try {
				request = i.readLine();
			} catch (IOException e) {
				o.print("A problem occured while computing your request. Would you please retry?");
				return;
			}
			try {
				this.lastDownloadName = Browser.getInstance().download(new URL(URLManager.getInstance().getURL("service", request)));
			} catch (MalformedURLException e) {
			}
			if(this.lastDownloadName != null)
				this.state = InteractionState.REQUEST;
			break;
		case 2:
			o.print("Please wait while your browser is opening...");
			Browser.getInstance().open(URLManager.getInstance().getURL("web",null));
			sleep(3000);
			break;
		case 3:
			o.print("Please wait while your browser is opening...");
			Browser.getInstance().open(URLManager.getInstance().getURL("emergency",null));
			sleep(3000);
			break;
		case 4:
			this.state = InteractionState.EXIT;
			break;
		default:
			o.print("You chose an incorrect option. Please choose a number between 1 and 4.");
			break;
		}
	}

	private void actRequest(int item) {
		switch(item){
		case 1:
			o.print("Please wait while the downloaded file is opening...");
			Browser.getInstance().openFile(this.lastDownloadName);
			sleep(6000);
			break;
		case 2:
			this.state = InteractionState.MENU;
			break;
		case 3:
			this.state = InteractionState.EXIT;
			break;
		default:
			o.print("You chose an incorrect option. Please choose a number between 1 and 3.");
			break;
		}
	}
	
	private void sleep(long milliseconds){
		try {
			Thread.sleep(milliseconds);
		} catch (InterruptedException e) {
		}
	}

	private void choices() {
		switch(state){
		case MENU:
			o.print("\t\tAnonymous substance abuse counseling e-service");
			o.print("\t\t\tCommand-line interface");
			o.print();
			o.print("\tWhat do you want to do?");
			o.print("[1] Write a written request to Anonymous substance abuse e-service");
			o.print("[2] Open browser to Anonymous substance abuse e-service website");
			o.print("[3] Open browser to Centers of Disease Control and Prevention");
			o.print("[4] Exit");
			o.print();
			o.print("\tPress a number key between 1 and 4");
			break;
		case REQUEST:
			o.print();
			o.print("\tA file concerning your problems has been successfully downloaded to "+this.lastDownloadName);
			o.print("[1] Open file with PDF reader");
			o.print("[2] Go back to menu");
			o.print("[3] Exit");
			o.print();
			o.print("\tPress a number key between 1 and 3");
			break;
		case EXIT:
			o.print();
			o.print("Goodbye! And good luck!");
			break;
		}

	}

}
