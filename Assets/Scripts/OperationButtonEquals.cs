using UnityEngine;
using System.Collections;

public class OperationButtonEquals : MonoBehaviour 
{
	public OperationButtonManager obm;
	private bool press = false, clearSent = false;
	private float timePressed = 0;

	void OnPress(bool p)
	{
		press = p;	
		if (!p) 
		{
			if (timePressed < .5)
				obm.OperatorPressed (GetComponentInChildren<UILabel> ().text);
			else
				clearSent = false;
			timePressed = 0;

		}
	}

	void Update()
	{
		if (press) 
		{
			timePressed += Time.deltaTime;
			if (timePressed > .5 && !clearSent) 
			{
				obm.ResetOperators();
				clearSent = true;
			}
		}
	}

}
