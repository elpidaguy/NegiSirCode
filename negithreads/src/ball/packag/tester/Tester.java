package ball.packag.tester;

import javax.swing.JFrame;

import ball.packag.BallFrame;

public class Tester {

	public static void main(String[] args) {
		BallFrame myFrame = new BallFrame("Aquarium Developed By Negirox");
		myFrame.setSize(1100,700);
		myFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		myFrame.setVisible(true);
	}

}
