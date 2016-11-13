using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OperationButtonManager : MonoBehaviour 
{
	public EquationManager em;
	public List<string> listOfPossibleOperators;
	public List<string> listOfPossibleRelationalOperators;
	//public List<string> listOfChosenOperators;
	public UILabel[] operationButtonIconList; //can this be the object instead?

	void Awake()
	{
		SetOperators ();
	}

	void SetOperators()
	{
		for (int i = 0; i < 4; i++)
			operationButtonIconList[i].text = PickOperatorAtRandom();
		
		operationButtonIconList[operationButtonIconList.Length-1].text = PickRelationalOperatorAtRandom();
	}

	string PickOperatorAtRandom()
	{
		int randNum = Random.Range(0, listOfPossibleOperators.Count); //CHANGE THIS FOR GODS SAKE
		string randStr = listOfPossibleOperators [randNum];
		listOfPossibleOperators.RemoveAt (randNum);
		return randStr;
	}

	string PickRelationalOperatorAtRandom()
	{
		int randNum = Random.Range(0, listOfPossibleRelationalOperators.Count);
		string randStr = listOfPossibleRelationalOperators [randNum];
		return randStr;
	}

	public void OperatorPressed(string str)
	{
		//could put a 'catch' here that prevent the user from accidentally double tapping? this is just a catch for now
		em.UpdateOperator(str);
	}

	public void ResetOperators()
	{
		em.ResetOperators();
	}
}