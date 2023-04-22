using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Cube cube;

    private UnityEngine.AI.NavMeshAgent agent;
	private float stopDistance;
	private float followDistance;

    private TickTimer moveDelay;

    private void Awake()
	{
		cube = GetComponent<Cube>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    private void Start()
	{
		moveDelay = new TickTimer(MoveTowardsTarget);
		stopDistance = cube.interactRange * 0.9f;
	}

    private void MoveTowardsTarget()
	{
		Vector3 target = transform.position;
		if(cube.target == null)
			target = cube.stateManager.GetTarget();
		else
			target = cube.target.position;

		if(Vector3.Distance(transform.position, target) >= stopDistance)
			agent.SetDestination(target);

		moveDelay.Restart(Random.Range(2, 10));
	}

    public Vector3 FindNewDestination(float moveRange)
	{
		Vector3 newTarget = transform.position;
		
		newTarget += new Vector3(Random.Range(-moveRange, moveRange), 0f, Random.Range(-moveRange, moveRange));

		return newTarget;
	}

	private void OnDestroy()
	{
		moveDelay.Stop();
	}
}
