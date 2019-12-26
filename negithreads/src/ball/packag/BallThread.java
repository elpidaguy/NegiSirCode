package ball.packag;

import java.util.Random;

public class BallThread extends Thread {
	Ball ref;
	public int i=40;
	public BallThread(Ball ref) {
		super();
		this.ref = ref;
	}
	public BallThread() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public void run() {
		try {
			while(true){
			ref.moveBall();
			Thread.sleep(i);
			}
		} catch (Exception e) {
			//e.printStackTrace();
			System.out.println("Fish Die");
		}
	}

	public int getI() {
		return i;
	}

	public void setI(int i) {
		this.i = i;
	}
	
}
