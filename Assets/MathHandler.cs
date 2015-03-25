using System;

public sealed class MathHandler {
	

	public static MathProblem CreateAdditionProblem(int max) {
		int a, b, c;

		Random r = new Random();
		a = r.Next(0, max);
		b = r.Next(0, max - a + 1);
		c = a+b;
		MathProblem p = new MathProblem(a,b,c,true);
		return p;

	}

	public static MathProblem CreateSubtractionProblem(int max) {
		int a, b, c, big, small;

		Random r = new Random();
		a = r.Next(1, max+1);
		b = r.Next(0, max+1);
		big = Math.Max(a,b);
		small = Math.Min(a,b);
		a = big;
		b = small;
		c = big-small;
		MathProblem p = new MathProblem(a,b,c,false);
		return p;
	}
}