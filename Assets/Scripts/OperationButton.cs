using UnityEngine;
using System.Collections;

public class OperationButton : MonoBehaviour 
{
	public OperationButtonManager obm;
	public UILabel otl;

	void OnClick()
	{
		obm.OperatorPressed(otl.GetComponentInChildren<UILabel>().text);
	}
}
