using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public EquationManager em;
	public NotificationManager nm;

	public void UpdateStreak(bool onFire)
	{
		nm.UpdateStreak (onFire);
	}
}
