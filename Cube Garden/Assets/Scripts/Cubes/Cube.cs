using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public CubeStateManager stateManager;
    public int[] indices = new int[3];

    public string nickname;
    public float interactRange { get; private set; }
    public Transform target { get; private set; }
    public Transform HatSlot;

    private string id;

	[HideInInspector] public CubeMovement movement;
	[HideInInspector] public CubeStats stats;

    private void Awake()
	{
		stateManager = GetComponent<CubeStateManager>();

		movement = GetComponent<CubeMovement>();
		stats = GetComponent<CubeStats>();
	}

    private void Start()
	{
        id = indices[0].ToString();
		interactRange = 1f;
		stats.OnHealthReachedZero += Die;
	}

    public void SetTarget(Transform t)
	{
		target = t;
	}

    private void Die()
	{
		//Debug.Log("Fly you fools!");
        CubeManager.Instance.ReleaseCube(this);
		Destroy(gameObject);
	}

    private void OnDrawGizmosSelected()
	{
		//Gizmos.color = Color.white;
		//Gizmos.DrawWireSphere(transform.position, interactRange);
	}

    override public string ToString()
	{
        if(nickname == "")
		    return "Cube " + id;
        else
            return nickname;
	}
}
