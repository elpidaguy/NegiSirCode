package ball.packag;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.geom.AffineTransform;
import java.awt.image.BufferedImage;
import java.io.File;
import java.util.Random;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JPanel;

public class Ball {
	public Color cl;
	int xpos,ypos,dx=10,dy=10,z=10,q=10;
	JPanel p1;
	boolean b;
	Rectangle r;
 public BufferedImage image,image2,flipimg,flipimg2,image3;
	public Ball(int i, int j, int k, int l, int m, BallPanel ballPanel, Color newcolor) {
		this.xpos=i;
		this.ypos=j;
		System.out.println(xpos+" and "+ypos);
		this.p1=ballPanel;
		this.cl=newcolor;
		try {                
	          image = ImageIO.read(new File("11.png"));
	          flipimg = ImageIO.read(new File("1.png"));
	          image2 = ImageIO.read(new File("22.png"));
	          image3 = ImageIO.read(new File("33.png"));
	       //  flipimg2 = ImageIO.read(new File("2.png"));
	       } catch (Exception ex) {
	            // handle exception...
	       }
		 
	}
	

	public void drawBall(Graphics g) {
		
		//g.fillOval(xpos, ypos,10,10);
		if(b==false)
		{
		//g.drawImage(image, xpos, ypos, null);
		g.drawImage(image, xpos, ypos, z, q, null);
		g.drawImage(image2, xpos+150, ypos+130, z, q, null);
		g.drawImage(image3, xpos-150, ypos-130, z-10, q-10, null);
		//g.drawImage(image2, new Random().nextInt(400), new Random().nextInt(400), null);
		}
		else
		{
			g.drawImage(flipimg, xpos, ypos, z, q, null);
			//g.drawImage(flipimg, xpos, ypos, null);
			//g.drawImage(flipimg2, new Random().nextInt(400), new Random().nextInt(400), null);
		}
		//g.drawImage(image, xpos, ypos, 50, 50, true);
		//g.drawImage(img, xpos, ypos, 30, 30, true);
	}

	public void moveBall() {
		r=p1.getBounds();
		xpos+=dx;
		ypos+=dy;
		z+=1;
		q+=1;
		if(z>180 || q>180)
		{
			z=150;
			q=150;
		}
		if(xpos<=0 || xpos-10>=r.width)
		{
			if(xpos<=0)
			{
				b=true;
			}
			if(xpos>r.width)
			{
				b=false;
			}
			dx*=-1;
		}
		if(ypos<=0 || ypos-10>=r.height)
			dy*=-1;
	
	}
	/* private static BufferedImage createFlipped(BufferedImage image)
	    {
	        AffineTransform at = new AffineTransform();
	        at.concatenate(AffineTransform.getScaleInstance(1, -1));
	        at.concatenate(AffineTransform.getTranslateInstance(0, -image.getHeight()));
	        return createTransformed(image, at);
	    }
	 private static BufferedImage createTransformed(
		        BufferedImage image, AffineTransform at)
		    {
		        BufferedImage newImage = new BufferedImage(
		            image.getWidth(), image.getHeight(),
		            BufferedImage.TYPE_INT_ARGB);
		        Graphics2D g = newImage.createGraphics();
		        g.transform(at);
		        g.drawImage(image, 0, 0, null);
		        g.dispose();
		        return newImage;
		    }
*/

	
	
}
