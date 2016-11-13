using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquationManager : MonoBehaviour 
{
	public GameManager gm;
	public NumberManager nm;

	public UILabel[] equationOperators;
	public UILabel[] equationNumbers;
	public List<float> equationValues = new List<float>();

	public void UpdateOperator(string str)
	{
		foreach (UILabel uil in equationOperators) 
		{
			if (uil.text == "?")
			{
				uil.text = str;	
				if (uil.gameObject == equationOperators [equationOperators.Length - 1].gameObject)
					CheckEquation();
				break;
			}
		}

	}

	private void CheckEquation()
	{
		if (FindEquals ())
			CalculateEquation();
		else 
		{
			ResetOperators();
			Debug.Log ("Equals sign needed!");
		}

	}

	private bool FindEquals()
	{
		foreach (UILabel uil in equationOperators)
		{
			if (uil.text == "=")
				return true;
		}
		return false;
	}

	private void CalculateEquation()
	{
		//equationNumber counter
		int n = 0; 														
		int v = 0;														

		//set the first equation to the first number
		equationValues.Add (0);
		equationValues [v] += float.Parse (equationNumbers [n].text);
		n++;

		//go through remaining equation, if equals are found, break off the equation and start a new one (in case there are two =s or more!)
		for (int i = 0; i < equationOperators.Length; i++) 
		{
			if (equationOperators [i].text != "=") 
			{						
				switch (equationOperators [i].text) 
				{
				case "+":
					equationValues [v] += float.Parse (equationNumbers [n].text);
					break;

				case "-":
					equationValues [v] -= float.Parse (equationNumbers [n].text);
					break;

				case "x":
					equationValues [v] *= float.Parse (equationNumbers [n].text);
					break;

				case "÷":
					equationValues [v] /= float.Parse (equationNumbers [n].text);
					break;
				}
				n++;
			}
			else 
			{
				equationValues.Add (0);
				v++;

				equationValues [v] += float.Parse (equationNumbers [n].text);
				n++; 
			}

		}
		ComputeAnswers ();
	}

	private void ComputeAnswers()
	{
		bool allEquationsEqual = true;
		float target = 0;

		target = equationValues [0];
		foreach (float f in equationValues) 
		{
			if (f != target)
				allEquationsEqual = false;
		}

		if (allEquationsEqual) 
			gm.UpdateStreak (true);
		else
			gm.UpdateStreak (false);

		PrepareNewEquation ();
	}

	public void PrepareNewEquation()
	{
		//need to calculate possible numbers that go here, then pass them down

		int[] possibleNumbers = { 2, 4, 8 };

		nm.AddNewNumber (Random.Range (0, 4), possibleNumbers[Random.Range (0, 3)]);
	}

	public void ResetOperators()
	{
		foreach (UILabel uil in equationOperators)
			uil.text = "?";	
		equationValues.Clear ();
	}
}