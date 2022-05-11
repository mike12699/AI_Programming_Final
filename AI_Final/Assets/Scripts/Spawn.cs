using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject robberPrefab;
    public int numRobbers;

    void Start()
    {
        Invoke("SpawnRobber", 5.0f);
    }

    void SpawnRobber()
    {
        Instantiate(robberPrefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnRobber", Random.Range(2.0f, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
