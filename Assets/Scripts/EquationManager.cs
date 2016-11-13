using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquationManager : MonoBehaviour
{
	public GameManager gm;
	public NumberManager nm;
	public OperationButtonManager obm;

	public UILabel[] equationOperators;
	public UILabel[] equationNumbers;
	public List<float> equationValues = new List<float>();
	public List <string> relationalOperators = new List<string>();

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
		if (FindRelationalOperator ())
			CalculateEquation();
		else
		{
			ResetOperators();
			Debug.Log ("Equals sign needed!");
		}

	}

	private bool FindRelationalOperator()
	{
		foreach (UILabel uil in equationOperators)
		{
			foreach (string str in obm.listOfPossibleRelationalOperators)
			{
				if (uil.text == str)
					return true;
			}
		}
		return false;
	}

	private void CalculateEquation()
	{

		int n = 0;	//equationNumber counter
		int v = 0;  //equationValues counter

		//set the first equation to the first number
		equationValues.Add (0);
		equationValues [v] += float.Parse (equationNumbers [n].text);
		n++;

		//go through remaining equation, if equals are found, break off the equation and start a new one (in case there are two =s or more!)
		for (int i = 0; i < equationOperators.Length; i++)
		{
			if (FindRelationalOperator(i))
			{
				switch (equationOperators [i].text)
				{
				case "+":
					equationValues [v] += float.Parse (equationNumbers [n].text);
					break;

				case "-":
					equationValues [v] -= float.Parse (equationNumbers [n].text);
					break;

				case "×":
					equationValues [v] *= float.Parse (equationNumbers [n].text);
					break;

				case "÷":
					equationValues [v] /= float.Parse (equationNumbers [n].text);
					break;

				case "yª":
					equationValues [v] = Mathf.Pow(equationValues [v], float.Parse (equationNumbers [n].text));
					break;
				}
				n++;
			}
			else
			{
				relationalOperators.Add (equationOperators [i].text);
				equationValues.Add (0);
				v++;

				equationValues [v] += float.Parse (equationNumbers [n].text);
				n++;
			}

		}
		ComputeAnswers ();
	}

	private bool FindRelationalOperator(int i )
	{
		foreach (string str in obm.listOfPossibleRelationalOperators)
		{
			if (equationOperators [i].text == str)
				return false;
		}
		return true;
	}

	private void ComputeAnswers()
	{
		bool allEquationsTrue = true;
		float target = 0;

		target = equationValues [0];
		for (int i = 0; i < relationalOperators.Count; i++)
		{
			switch (relationalOperators[i])
			{
			case "=":
				Debug.Log ("= operator");
				if (!(target == equationValues [i + 1]))
					allEquationsTrue = false;
				break;

			case "<":
				Debug.Log ("< operator");
				if (!(target < equationValues [i + 1]))
					allEquationsTrue = false;
				break;

			case ">":
				Debug.Log ("> operator");
				if (!(target > equationValues [i + 1]))
					allEquationsTrue = false;
				break;

			case "≤":
				Debug.Log ("≤ operator");
				if (!(target <= equationValues [i + 1]))
					allEquationsTrue = false;
				break;

			case "≥":
				Debug.Log ("≥ operator");
				if (!(target >= equationValues [i + 1]))
					allEquationsTrue = false;
				break;
			}
		}

		if (allEquationsTrue)
			gm.UpdateStreak (true);
		else
			gm.UpdateStreak (false);

		PrepareNewEquation ();
	}

	public void PrepareNewEquation()
	{
		//need to calculate possible numbers that go here, then pass them down

		int[] possibleNumbers = {1, 2, 3, 4, 6, 8};

		nm.AddNewNumber (Random.Range (0, 4), possibleNumbers[Random.Range (0, possibleNumbers.Length)]);
	}

	public void ResetOperators()
	{
		foreach (UILabel uil in equationOperators)
			uil.text = "?";
		equationValues.Clear ();
		relationalOperators.Clear ();
	}
}
