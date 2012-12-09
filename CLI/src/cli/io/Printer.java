package cli.io;

import java.io.PrintStream;

public class Printer {

	private PrintStream out;
	private final static int numberOfLinesInTerminal = 15;
	
	public Printer(){
		this(System.out);
	}
	
	public Printer(PrintStream ps){
		super();
		this.out = ps;
	}

	public void print(String s) {
		out.println(s);
	}

	public void print() {
		print("");
	}
	
	public void clear(){
		//Conan the Barbarian way
		for(int i = 0 ; i < numberOfLinesInTerminal ; i++){
			out.println();
		}
	}

}
