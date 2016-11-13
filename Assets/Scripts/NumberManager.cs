using UnityEngine;
using System.Collections;

public class NumberManager : MonoBehaviour 
{
	public NumberActor[] numbers;

	public void AddNewNumber(int target, int num)
	{
		numbers [target].PrepNumberSwap (num);
		numbers [target].GetComponent<UIPlayTween> ().Play (true);
	}
}
