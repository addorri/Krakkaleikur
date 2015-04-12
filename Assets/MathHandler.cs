using System;
using System.Collections.Generic;
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

	public static string GenerateSubtractionProblemString(int size, int max) {
		int a, b, c, big, small;
		string s = "";

		System.Random r = new System.Random(Environment.TickCount);

		for(int i = 0; i<size; i++) {
			a = r.Next(1, max+1);
			b = r.Next(0, max+1);
			big = Math.Max(a,b);
			small = Math.Min(a,b);
			a = big;
			b = small;
			c = big-small;
			s += ""+a+b+c+"m";
		}
		Debug.Log(s);
		return s;
	}

	public static int[] NotThisNumber(int num) {
		return NotThisNumber(num, 9, 8);
	}

	public static int[] NotThisNumber(int num, int max, int sizeOfReturnArray) {
		Debug.Log("params: num,max,sizeofreturn" + num + "," + max +"," + sizeOfReturnArray);
		if(sizeOfReturnArray<1) return null; //error, throw exception here
		if(num>max) return null; //error, throw new exception here
		List<int> allNumbersFromZeroToMax = new List<int>();
		for(int i = 0; i<=max; i++) {
			allNumbersFromZeroToMax.Add(i);
			Debug.Log(i + " added to list, list size: " + allNumbersFromZeroToMax.Count);
		}
		allNumbersFromZeroToMax.Remove(num);
		Debug.Log(num + " removed from list, list size: " + allNumbersFromZeroToMax.Count);
		int[] returnArray = new int[sizeOfReturnArray+1];
		Debug.Log("returnArray created, size: " + returnArray.Length);
		System.Random r = new System.Random(Environment.TickCount);
		for(int i = 0; i<=sizeOfReturnArray; i++) {
			int index = r.Next(0,max-i);
			Debug.Log("index of number to be removed: " + index + ", value at index: " + allNumbersFromZeroToMax[index]);
			returnArray[i] = allNumbersFromZeroToMax[index];
			Debug.Log(returnArray[i] + " added to return array at index " + i);
			allNumbersFromZeroToMax.RemoveAt(index);
			Debug.Log("number at index " + index + " removed from allnumberslist, current size: " + allNumbersFromZeroToMax.Count);
		}
		Debug.Log("return array ready!");
		string s = "";
		for(int i = 0; i<returnArray.Length; i++) {
			s += returnArray[i] + " " ; 
		}
		Debug.Log(s);
		return returnArray;

	}

}