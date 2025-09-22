using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	public void startGame()
	{
		Time.timeScale = 1f;
		StartCoroutine(DelayedGameStart());
	}

	private IEnumerator DelayedGameStart()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("SampleScene");
	}
	
	public void exitGame()
	{
		Application.Quit();
	}
}
