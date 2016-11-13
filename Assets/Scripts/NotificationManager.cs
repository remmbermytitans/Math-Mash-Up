using UnityEngine;
using System.Collections;

public class NotificationManager : MonoBehaviour 
{
	public UILabel notificationStreakText, statusPointText;
	private int score, streak = 0, fontSize;

	public void UpdateStreak(bool onFire)
	{
		Streak (onFire);
		score += streak;
		statusPointText.text = score.ToString () + " pts";

		if (onFire)
			notificationStreakText.text = "+" + streak.ToString ();
		else
			notificationStreakText.text = streak.ToString ();

		notificationStreakText.fontSize = fontSize;
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
			fontSize = Mathf.Clamp (streak + 5, 8, 30);  
		}
		else 
		{
			if (streak < 0)
				streak -= 1;
			else
				streak = -1;
			fontSize = Mathf.Clamp ((streak - 5) * -1, 8, 30);  
		}
	}
}
