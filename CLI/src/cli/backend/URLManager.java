package cli.backend;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.HashMap;

public class URLManager {

	private static URLManager INSTANCE;

	private HashMap<String, String> urlMap;

	private URLManager(){
		urlMap = new HashMap<String, String>();

		urlMap.put("emergency", "http://www.bt.cdc.gov/");
		urlMap.put("service", "http://drugabuse.herokuapp.com/info/show?request=");
		urlMap.put("web", "../../Web/index.html");

	}

	public static URLManager getInstance(){
		if(INSTANCE==null)
			INSTANCE = new URLManager();
		return INSTANCE;
	}

	public String getURL(String s, String request){
		try {
			return urlMap.get(s) + (request == null ? "" : URLEncoder.encode(request, "UTF-8"));
		} catch (UnsupportedEncodingException e) {
			return null;
		}
	}

}
