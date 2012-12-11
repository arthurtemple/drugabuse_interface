package cli.interaction;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

import cli.io.Printer;

public class Browser {

	private static Browser INSTANCE;
	private static Printer PRINTER;
	private final String TEMP_DIR = "TEMP";

	private Browser(){
		new File(TEMP_DIR).mkdirs();
	}
	
	public static void setPrinter(Printer p){
		PRINTER = p;
	}

	public static Browser getInstance(){
		if(INSTANCE==null)
			INSTANCE = new Browser();
		return INSTANCE;
	}

	public void open(String url){
		if(!java.awt.Desktop.isDesktopSupported()) {
			PRINTER.print("Your computer needs at least Java 6 to open a browser.\nPlease try to do it yourself by opening your everyday browser and typing following line into the URL bar:\n"+url.toString());
		}
		try {
			java.awt.Desktop.getDesktop().browse(URI.create(url));
		} catch (IOException e) {
		}
	}

	public void openFile(String fileName){
		if(!java.awt.Desktop.isDesktopSupported()) {
			PRINTER.print("Your computer needs at least Java 6 to open a file.\nPlease try to do it yourself by opening following file:\n"+fileName);
		}
		try {
			java.awt.Desktop.getDesktop().open(new File(fileName));
		} catch (IOException e) {
		}
	}

	public String download(URL url) {
		try
		{
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setRequestMethod("GET");
			conn.setAllowUserInteraction(false);
			conn.setDoInput(true);
			conn.setDoOutput(true);
			conn.connect();
			InputStream is = conn.getInputStream();

			String fileName = TEMP_DIR+"/"+conn.getHeaderField("Content-Disposition").split("=")[1].replaceAll("\"", "");
			File f = new File(fileName);
			f.createNewFile();
			FileOutputStream writer = new FileOutputStream(f);
			byte[] buffer = new byte[153600];
			int bytesRead = 0;

			while ((bytesRead = is.read(buffer)) > 0)
			{  
				writer.write(buffer, 0, bytesRead);
				buffer = new byte[153600];
			}

			writer.close();
			is.close();
			return fileName;
		}
		catch (Exception e)
		{
		}
		return null;
	}

}
