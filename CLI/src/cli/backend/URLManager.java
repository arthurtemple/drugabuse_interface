package cli.backend;

import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.HashMap;

public class URLManager {

	private static URLManager INSTANCE;

	private HashMap<String, String> urlMap;

	private URLManager(){
		urlMap = new HashMap<String, String>();

		urlMap.put("emergency", "http://www.bt.cdc.gov/");
		urlMap.put("service", "http://drugabuse.herokuapp.com/info/show?request=");
		urlMap.put("web", "PUT HERE URL OF WEB INTERFACE");

	}

	public static URLManager getInstance(){
		if(INSTANCE==null)
			INSTANCE = new URLManager();
		return INSTANCE;
	}

	public URL getURL(String s, String request){
		try {
			return new URL(urlMap.get(s) + (request == null ? "" : URLEncoder.encode(request, "UTF-8")));
		} catch (MalformedURLException | UnsupportedEncodingException e) {
			return null;
		}
	}

}
