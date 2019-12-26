package ball.packag;

import javax.swing.JPanel;

public class RefreshThread extends Thread {
	JPanel myPanel;
	Ball ref;

	public RefreshThread(JPanel myPanel, Ball ref) {
		super();
		this.myPanel = myPanel;
		this.ref = ref;
	}

	public RefreshThread(JPanel myPanel) {
		super();
		this.myPanel = myPanel;
	}
	
	@Override
	public void run() {
		try {
			while(true){
				//ref.moveBall();
			myPanel.repaint();
			
			Thread.sleep(16);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
