using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth: MonoBehaviour
{
	[SerializeField] private AnimationCurve growthCurve;

	public float GetSize(float age, float endAge)
	{
		return growthCurve.Evaluate(age / endAge);
	}
}
