using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
	[SerializeField] private Transform cubePrefab;
	[SerializeField] private Transform eggPrefab;
	[SerializeField] private Color[] colors;
	[SerializeField] private Material[] materials;
	[SerializeField] private Texture[] textures;

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

	private void InstantiateEgg(MeshRenderer cubeRenderer, Vector3 spawnPoint)
	{
		Transform eggGO = Instantiate(eggPrefab, spawnPoint, Quaternion.identity, this.transform);
		MeshRenderer eggRenderer = eggGO.GetComponentInChildren<MeshRenderer>();
		eggRenderer.material = cubeRenderer.material;
		eggRenderer.material.color = cubeRenderer.material.color;
		eggRenderer.material.mainTexture = cubeRenderer.material.mainTexture;
	}

	public void CreateCube()
	{
		int[] indices = new int[Cube.NUM_IDICIES];

		indices[1] = Random.Range(0, materials.Length);
		indices[2] = Random.Range(0, colors.Length);
		indices[3] = 3; //indices[3] = Random.Range(0, textures.Length);

		CreateCube(indices);
	}

	public void CreateCube(int[] indices, string name = "")
	{
		Cube cube = InstantiateCube();
		cube.nickname = name;

		if(indices.Length != Cube.NUM_IDICIES) Debug.LogError("Wrong indices inputed");

		for(int i = 0; i < Cube.NUM_IDICIES; i++)
		{
			cube.indices[i] = indices[i];
		}

		MeshRenderer cubeRenderer = cube.GetComponentInChildren<MeshRenderer>();
		cubeRenderer.material = materials[indices[1]];
		cubeRenderer.material.color = colors[indices[2]];
		cubeRenderer.material.mainTexture = textures[indices[3]];

		InstantiateEgg(cubeRenderer, cube.transform.position);
	}
	public void CreateCube(Cube cube)
	{
		int[] indices = cube.indices;
		
		//indices[0];

		CreateCube(indices, cube.ToString());
	}
	public void CreateCube(Cube parent1, Cube parent2) {}

	public void ReleaseCube(Cube cube)
	{
		cubes[cube.indices[0]] = null;
	}
}
