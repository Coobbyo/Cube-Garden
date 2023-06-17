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
		int[] indices = new int[Cube.NUM_IDICIES];
		if(canClose = int.TryParse(matField.text, out int material))
			indices[1] = material;
		if(canClose = int.TryParse(colorField.text, out int color))
			indices[2] = color;

		if(canClose)
		{
			CubeManager.Instance.CreateCube(indices, nameField.text);
			Close();
		}

		if(matField.text == "" || colorField.text == "")
		{
			CubeManager.Instance.CreateCube();
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
