using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CubeStateManager : MonoBehaviour
{
	public Cube cube;

	public GameObject[] stateEffects;

	private CubeBaseState currentState;
	public CubeRoamState RoamState;
	//public CubePlayState PlayState;
	//public CubeBreedState BreedState;
	//public CubeHungeredState HungeredState;


	private void Awake()
	{
		cube = GetComponent<Cube>();

		RoamState = new CubeRoamState(this);
		//PlayState = new CubePlayState(this);
		//BreedState = new CubeBreedState(this);
		//HungeredState = new CubeHungeredState(this);
	}

	private void Start()
	{
		currentState = RoamState;
		currentState.EnterState();
	}

	private void Update()
	{
		currentState.UpdateState();
	}

	private void OnDestroy()
	{
		//Debug.Log("State Manager Destroied");
		currentState.LeaveState();
		currentState = null;
	}

	public void SwitchState(CubeBaseState state)
	{
		currentState.LeaveState();
		state.EnterState();
		currentState = state;
	}

	public Vector3 GetTarget()
	{
		return currentState.GetTarget();
	}

	public bool IsState(CubeBaseState state)
	{
		if(currentState == null)
		{
			return false;
		}
		return state.stateID == currentState.stateID;
	}

	private void OnDrawGizmosSelected()
	{
		currentState.OnDrawGizmosSelected();
	}
}
