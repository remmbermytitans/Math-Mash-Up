using UnityEngine;
using System.Collections;

public class OperationButton : MonoBehaviour 
{
	public OperationButtonManager obm;

	void OnClick()
	{
		obm.OperatorPressed(GetComponentInChildren<UILabel>().text);
	}
}
