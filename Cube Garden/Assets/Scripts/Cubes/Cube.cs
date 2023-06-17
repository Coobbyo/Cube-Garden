using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
	public const int NUM_IDICIES = 4;

    public CubeStateManager stateManager;
    public int[] indices = new int[NUM_IDICIES];
	//0 is cube number
	//1 is material
	//2 is color
	//3 is texture

    public string nickname;
    public float interactRange { get; private set; }
    public Transform target { get; private set; }
    public Transform HatSlot;

    private string id
	{
		get { return indices[0].ToString(); }
	}

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
		//Debug.Log(indices.Length);
		interactRange = 1f;
		stats.OnHealthReachedZero += Die;
	}

    public void SetTarget(Transform t)
	{
		target = t;
	}

    public void Die()
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
		return nickname == "" ? "Cube " + id : nickname;
	}
}
