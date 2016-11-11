using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquationManager : MonoBehaviour 
{
	public UILabel[] equationOperators;
	public UILabel[] equationNumbers;
	public List<int> equalsLocations = new List<int>();

	private void CalculateEquation()
	{
		
	}

	private void PrepareEquation()
	{
		FindEquals();
		if (equalsLocations.Count == 0) 
		{
			ResetOperators();
			Debug.Log ("Equals sign needed!");
		}
		else
		{
			foreach (int loc in equalsLocations)
				Debug.Log (loc);
		}
	}

	private void FindEquals()
	{
		for (int i = 0; i < equationOperators.Length; i++)
		{
			if (equationOperators [i].text == "=")
				equalsLocations.Add (i);
		}
	}

	public void ResetOperators()
	{
		foreach (UILabel uil in equationOperators)
			uil.text = "?";	
	}

	public void UpdateOperator(string str)
	{
		foreach (UILabel uil in equationOperators) 
		{
			if (uil.text == "?")
			{
				uil.text = str;	
				if (uil.gameObject == equationOperators [equationOperators.Length - 1].gameObject)
					PrepareEquation();
				break;
			}
		}

	}
}