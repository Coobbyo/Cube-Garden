using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInspectUI : MonoBehaviour
{
	private void Awake()
	{
		//Close();
	}
	
	public void Open()
	{
		gameObject.SetActive(true);
	}

	public void Close()
	{
		gameObject.SetActive(false);
	}
}
