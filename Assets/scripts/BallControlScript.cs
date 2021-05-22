using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControlScript : MonoBehaviour {
	static bool isDead;
	static bool youWin;

	[SerializeField]
	GameObject winText, lostText;

	AccelerometerMovement movement;

	float timer = 1.5f;

	void Start () {
		movement = GetComponent<AccelerometerMovement>();
		Debug.Log("movement = " + movement);
		winText.gameObject.SetActive(false);
		lostText.gameObject.SetActive(false);

		youWin = false;
		isDead = false;

		movement.SetMoveAllowed(true);
	}
	
	void Update () {
		lostText.gameObject.SetActive(isDead);
		winText.gameObject.SetActive(youWin);

		if (isDead || youWin)
		{
			movement.SetMoveAllowed(false);
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
            {
				RestartScene();
            }
		}

	}

	public static void setIsDeadTrue()
	{
		isDead = true;
	}

	public static void setYouWinToTrue()
	{
		youWin = true;
	}

	void RestartScene()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
