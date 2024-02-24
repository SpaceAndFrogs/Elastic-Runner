using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    MapFragmentPool fragmentPool;
    float spawnRate;
    float fragmentSpawnPosition;
    float spawnTime;

    void StartGeneration()
    {

    }

    void stopGeneration()
    {

    }

    IEnumerator GenerateMapFragment()
    {
        yield return new WaitForSeconds(spawnRate);
    }
}
