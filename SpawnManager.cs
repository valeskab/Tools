using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balloonPrefabs;
    public float startDelay = 0.5f;
    public float spawnInterval = 1.5f;

    //public int balloonIndex;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBalloon", startDelay, spawnInterval);
    }

    void SpawnRandomBalloon()
    {
        // Get a random position on the x-axis
        Vector3 spawnPos = new Vector3(Random.Range(-5,5),10,0);
        // Pick a random ballon from the balloon array
        int balloonIndex = Random.Range(0,balloonPrefabs.Length);
        // Spawn random ballon at spawn position
        Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
    }
}
