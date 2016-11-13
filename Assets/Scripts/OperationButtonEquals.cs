using UnityEngine;
using System.Collections;

public class OperationButtonEquals : MonoBehaviour 
{
	public OperationButtonManager obm;
	public UILabel otl;
	private bool press = false, clearSent = false;
	private float timePressed = 0;

	void OnPress(bool p)
	{
		press = p;	
		if (!p) 
		{
			if (timePressed < .5)
				obm.OperatorPressed (otl.GetComponentInChildren<UILabel> ().text);
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

			//this is all temporary, remove this later
			if (timePressed > 3)
				Application.LoadLevel (0);
		}
	}
}
