using UnityEngine;

public abstract class CubeBaseState
{
	protected CubeStateManager manager;
	protected CubeStats stats;
	public int stateID;

	abstract public void EnterState();
	abstract public void LeaveState();
	abstract public void UpdateState();
	abstract public Vector3 GetTarget();
	abstract public void OnDrawGizmosSelected();
}
