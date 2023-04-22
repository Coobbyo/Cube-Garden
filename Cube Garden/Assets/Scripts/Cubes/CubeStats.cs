using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStats : Damageable
{
	private void Start()
	{
		//Friendliness.baseValue = Random.Range(0, 5);
		//Loyalty.baseValue = Random.Range(-10, 10);
		//Aggression.baseValue = Random.Range(0, 2);
		//Idleness.baseValue = Random.Range(-5, 5);

		MaxHealth.baseValue = 10;
		CurrentHealth = MaxHealth.GetValue();
		Damage.baseValue = 1;//Aggression.baseValue;
		Armor.baseValue = 0;
	}
}
