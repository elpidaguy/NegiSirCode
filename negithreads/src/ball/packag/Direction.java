package ball.packag;

import java.util.Random;

public class Direction {
	int dirX,dirY;	
	public Direction(int dirX, int dirY) {
		super();
		this.dirX = dirX;
		this.dirY = dirY;
	}
	public void setDirection(int x,int y){
		this.dirX = x;
		this.dirY = y;
	}
	public int getDirX() {
		return dirX;
	}
	
	public int getDirY() {
		return dirY;
	}

	public void toggleX() {
		this.dirX*=-1;
	}

	public void toggleY() {
		this.dirY*=-1;
	}
	
	public static Direction getRandomDirection(Random r){
		switch(	r.nextInt(4)){
		 case 0:
			 return new Direction(-1,-1);
		 case 1:
			 return new Direction(-1,1);
		 case 2:
			 return new Direction(1,-1);
		 default:
			 return new Direction(1,1);
		 }
	}
}
