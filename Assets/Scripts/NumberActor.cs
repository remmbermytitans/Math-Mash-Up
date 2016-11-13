using UnityEngine;
using System.Collections;

public class NumberActor : MonoBehaviour 
{
	public int myNumber;

	void Start()
	{
		myNumber = int.Parse(GetComponent<UILabel> ().text);
	}

	public void PrepNumberSwap(int num)
	{
		myNumber = num;
	}

	public void NumberSwap()
	{
		GetComponent<UILabel> ().text = myNumber.ToString ();
		GetComponents<UIPlayTween> () [1].Play (true);
	}
}
