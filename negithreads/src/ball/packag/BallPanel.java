package ball.packag;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.ImageIcon;
import javax.swing.JPanel;

public class BallPanel extends JPanel {
	ArrayList<Ball> myBalls;
	ArrayList<BallThread> myBallThreads;
	Image bg;
	public BallPanel() {
		RefreshThread myRefreshThread = new RefreshThread(this);
		//RefreshThread myRefreshThread = new RefreshThread(this);
		myRefreshThread.start();
		myBalls = new ArrayList<>();
		myBallThreads = new ArrayList<>();
		//setBackground(Color.CYAN);
		 bg = new ImageIcon("back.jpg").getImage();
		
	}
	
	@Override
	protected void paintComponent(Graphics g) {
		super.paintComponent(g);
		g.drawImage(bg, 0, 0, getWidth(), getHeight(), this);
		for(Ball myBall:myBalls)
		{
			myBall.drawBall(g);
		}
		
	}
	
	public void addBall(){
		Color newcolor=new Color(new Random().nextInt(255),new Random().nextInt(255), new Random(255).nextInt(255));
		Ball newBall = new Ball(new Random().nextInt(800), new Random().nextInt(700), 20, 4, 4, this,newcolor);
		BallThread newBallThread = new BallThread(newBall);
		newBallThread.start();
		myBalls.add(newBall);
		myBallThreads.add(newBallThread);
	}
	
	public void stop(){
		for(BallThread myBallThread:myBallThreads)
		myBallThread.interrupt();
		
		myBalls.clear();
		myBallThreads.clear();
	}
	
	
	
}
