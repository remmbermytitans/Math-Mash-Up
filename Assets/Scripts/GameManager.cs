using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public EquationManager em;
	public NotificationManager nm;

	//probably not needed!
	public void UpdateStreak(bool onFire)
	{
		nm.UpdateStreak (onFire);
	}
}
