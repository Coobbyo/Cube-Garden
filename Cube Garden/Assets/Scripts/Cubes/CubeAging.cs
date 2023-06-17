using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAging : MonoBehaviour
{
    [SerializeField] private AnimationCurve growthCurve;
    [SerializeField] private float secondsUntilGrowing;
    [SerializeField] private int secondsUntilAdult;
    [SerializeField] private int secondsUntilDead;
    private int startTick;

    private Cube cube;

    private void Start()
    {
        cube = GetComponent<Cube>();

        startTick = TimeTickSystem.GetTick();
        SetSize(secondsUntilGrowing);
    }

    private void Update()
    {
        if(GetAge() > secondsUntilGrowing &&
            GetAge() < secondsUntilAdult)
        {
            SetSize(GetAge());
        }

        if(GetAge() > secondsUntilDead)
            cube.Die();
    }

    private void SetSize(float age)
    {
        transform.localScale = Vector3.one * growthCurve.Evaluate(age / secondsUntilAdult);
    }

    //This is the number of ticks the cube has been alive
    public int GetTickAge()
    {
        return TimeTickSystem.GetTick() - startTick;
    }

    //This is the number of seconds the cube has been alive
    public float GetAge()
    {
        return (float)GetTickAge() * 0.2f;
    }
}
