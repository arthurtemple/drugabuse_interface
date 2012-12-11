package cli;

import cli.interaction.Interactor;


public class CLI {

	/**
	 * @param args
	 * @throws Exception 
	 */
	public static void main(String[] args) throws Exception{
		Interactor interactor = new Interactor(System.in, System.out);
		interactor.interact();
	}

}
