<Query Kind="Program" />

void Main()
{

}

// You can define other methods, fields, classes and namespaces here
public class Solution
{
	private double radius;
	private double x_center;
	private double y_center;
	private Random random;

	public Solution(double radius, double x_center, double y_center)
	{
		this.radius = radius;
		this.x_center = x_center;
		this.y_center = y_center;
		this.random = new Random();
	}

	public double[] RandPoint()
	{
		double ang = random.NextDouble() * 2 * Math.PI;
		double hyp = Math.Sqrt(random.NextDouble()) * this.radius;
		double adj = Math.Cos(ang) * hyp;
		double opp = Math.Sin(ang) * hyp;
		return new double[] { this.x_center + adj, this.y_center + opp };
	}
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(radius, x_center, y_center);
 * double[] param_1 = obj.RandPoint();
 */