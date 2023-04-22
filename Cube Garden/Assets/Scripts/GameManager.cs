using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private bool doPause;
	[SerializeField] private InputReader input;
	[SerializeField] private GameObject pauseMenu;

	private void Start()
	{
		TimeTickSystem.Create();
		//TimeTickSystem.OnTick += ShowTick;
		//TimeTickSystem.OnTick_5 += ShowMegaTick;

		input.PauseEvent += HandlePause;
		input.ResumeEvent += HandleResume;
	}

	private void HandlePause()
	{
		if(doPause)
			Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	private void HandleResume()
	{
		if(doPause)
			Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	private void ShowTick(int tick)
	{
		//tick = TimeTickSystem.GetTick();
		Debug.Log("tick: " + tick);
	}

	private void ShowMegaTick(int tick)
	{
		Debug.Log("MEGA TICK");
	}
}
