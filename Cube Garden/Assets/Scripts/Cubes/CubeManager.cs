using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
	[SerializeField] private Transform cubePrefab;
	[SerializeField] private Transform eggPrefab;
	[SerializeField] private Color[] colors;
	[SerializeField] private Material[] materials;

	[SerializeField] private InputReader input;
	[SerializeField] private CubeCreateUI createMenu;
	[SerializeField] private CubeInspectUI inspectMenu;

	private Cube[] cubes = new Cube[8];

	private static CubeManager instance;
	public static CubeManager Instance { get {return instance; } private set{} }
	private void Awake()
	{
		if(instance != null && instance != this)
			Destroy(this);
		else
			instance = this;
	}

	private void Start()
	{
		input.CreateEvent += HandleCreate;
		input.InteractEvent += HandleInteract;
	}

	private void HandleCreate()
	{
		createMenu.Open();
	}

	private void HandleInteract()
	{
		inspectMenu.Open();
	}

	private Cube InstantiateCube()
	{
		float spawnRadius = 10f;
		Vector3 spawnPoint = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
		Transform cubeGO = Instantiate(cubePrefab, spawnPoint, Quaternion.identity, this.transform);
		Transform eggGO = Instantiate(eggPrefab, spawnPoint, Quaternion.identity, this.transform);

		Cube cube = cubeGO.GetComponent<Cube>();
		for(int i = 0; i < cubes.Length; i++)
		{
			if(cubes[i] == null)
			{
				cubes[i] = cube;
				cube.indices[0] = i;
			}
		}

		return cube;
	}

	public void CreateCube()
	{
		Cube cube = InstantiateCube();

		cube.indices[1] = 0;
		cube.indices[2] = Random.Range(0, 4);

		MeshRenderer cubeRenderer = cube.GetComponentInChildren<MeshRenderer>();
		cubeRenderer.material = materials[cube.indices[1]];
		cubeRenderer.material.color = colors[cube.indices[2]];
	}

	public void CreateCube(int[] indices, string name = "")
	{
		Cube cube = InstantiateCube();
		cube.nickname = name;

		cube.indices[1] = indices[0];
		cube.indices[2] = indices[1];

		MeshRenderer cubeRenderer = cube.GetComponentInChildren<MeshRenderer>();
		cubeRenderer.material = materials[indices[0]];
		cubeRenderer.material.color = colors[indices[1]];
	}
	public void CreateCube(Cube cube)
	{
		int[] indices = cube.indices;
		for (int i = 1; i < cube.indices.Length; i++)
		{
			indices[i - 1] = cube.indices[i];
		}
		CreateCube(indices, cube.ToString());
	}
	public void CreateCube(Cube parent1, Cube parent2) {}

	public void ReleaseCube(Cube cube)
	{
		cubes[cube.indices[0]] = null;
	}
}
