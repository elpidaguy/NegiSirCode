package ball.packag;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
public class BallFrame extends JFrame {
	public BallFrame(String title){
		super(title);
		BallPanel myBallPanel = new BallPanel();
		BallThread obj=new BallThread();
		add(myBallPanel);
		
		JPanel controlPanel = new JPanel();
		JButton btnStart = new JButton("Start");
		JButton btnStop = new JButton("Stop");
		JButton increase = new JButton("+Speed");
		JButton decrease = new JButton("-Speed");
		btnStart.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				myBallPanel.addBall();
			}
		});
		
		btnStop.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				myBallPanel.stop();
				
			}
		});
		increase.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				//JOptionPane.showMessageDialog(null, "incr");
				int i=obj.getI();
				i-=10;
				obj.setI(i);
				
			}
		});
		decrease.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				int i=obj.getI();
				i+=10;
				obj.setI(i);
				
			}
		});
		controlPanel.add(btnStart);
		controlPanel.add(btnStop);
		controlPanel.add(increase);
		controlPanel.add(decrease);
		add(controlPanel,BorderLayout.SOUTH);
	}
}
