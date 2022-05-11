using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> robbers;
    private static Queue<GameObject> policecars;

    static GWorld()
    {
        world = new WorldStates();
        robbers = new Queue<GameObject>();
        policecars = new Queue<GameObject>();
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Police Car");
        foreach (GameObject c in cubes)
        {
            policecars.Enqueue(c);
        }

        if (cubes.Length > 0)
        {
            world.ModifyState("FreePoliceCar", cubes.Length);
        }

        Time.timeScale = 5.0f;
    }

    private GWorld()
    {

    }

    public void AddRobber(GameObject r)
    {
        robbers.Enqueue(r);
    }

    public GameObject RemoveRobber()
    {
        if (robbers.Count == 0) return null;
        return robbers.Dequeue();
    }

    public void AddPoliceCar(GameObject p)
    {
        policecars.Enqueue(p);
    }

    public GameObject RemovePoliceCar()
    {
        if (policecars.Count == 0) return null;
        return policecars.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
