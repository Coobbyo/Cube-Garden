using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeCreateUI : MonoBehaviour
{
	[SerializeField] private TMP_InputField nameField;
	[SerializeField] private TMP_InputField matField;
	[SerializeField] private TMP_InputField colorField;

	private void Awake()
	{
		//Close();
	}

	public void CreateCube()
	{
		bool canClose = true;
		canClose = int.TryParse(matField.text, out int material);
		canClose = int.TryParse(colorField.text, out int color);
		int[] indices = new int[2] { material, color };
		if(canClose)
		{
			CubeManager.Instance.CreateCube(indices, nameField.text);
			Close();
		}
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
