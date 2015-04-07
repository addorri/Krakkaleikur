using System;
using UnityEngine;

public sealed class MathHandler {
	
	//max > 1
	public static MathProblem CreateAdditionProblem(int max) {
		int a, b, c;

		System.Random r = new System.Random();
		a = r.Next(1, max);
		b = r.Next(0, max - a + 1);
		c = a+b;
		return new MathProblem(a,b,c,true);
	}

	//max > 1
	public static string GenerateAdditionProblemString(int size, int max) {
		int a, b, c;
		string s = "";

		System.Random r = new System.Random(Environment.TickCount);

		for(int i = 0; i<size; i++) {
			a = r.Next(1, max);
			b = r.Next(0, max - a + 1);
			c = a+b;
			s += ""+a+b+c+"p";
		}
		Debug.Log(s);
		return s;
	}

	//max > 1
	public static MathProblem CreateSubtractionProblem(int max) {
		int a, b, c, big, small;

		System.Random r = new System.Random();
		a = r.Next(1, max+1);
		b = r.Next(0, max+1);
		big = Math.Max(a,b);
		small = Math.Min(a,b);
		a = big;
		b = small;
		c = big-small;
		return new MathProblem(a,b,c,false);
	}

}