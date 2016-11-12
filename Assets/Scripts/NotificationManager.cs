using UnityEngine;
using System.Collections;

public class NotificationManager : MonoBehaviour 
{
	public GameObject notificationStreakText;
	private int score, streak = 0;

	public void UpdateStreak(bool onFire)
	{
		Streak (onFire);
		score += streak;
		if (onFire)
			notificationStreakText.GetComponent<UILabel> ().text = "+" + streak.ToString ();
		else
			notificationStreakText.GetComponent<UILabel> ().text = streak.ToString ();

		notificationStreakText.GetComponent<UIPlayTween> ().Play (true);
	}

	private void Streak(bool onFire)
	{
		if (onFire) 
		{
			if (streak > 0)
				streak += 1;
			else
				streak = 1;
		}
		else 
		{
			if (streak < 0)
				streak -= 1;
			else
				streak = -1;
		}
	}
}
