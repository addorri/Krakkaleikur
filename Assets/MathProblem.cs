using System.Collections;

public class MathProblem {

	private int first, last, ans;
	private bool type;

	public MathProblem() {
		
	}

	public MathProblem(int first, int last, int ans, bool type) {
		this.first = first;
		this.last = last;
		this.ans = ans;
		this.type = type; //0 for subtraction, 1 for addition
	}
	
	public string ToString() {
		string op;
		if(this.type) op = " + ";
		else op = " - ";
		return this.first + op + this.last + " = " + this.ans;
	}

}