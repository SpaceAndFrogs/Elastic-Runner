using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFragmentPool : MonoBehaviour
{
    MapFragment mapFragment;
    List<MapFragment> pooledFragments = new List<MapFragment>();

    void Initialize()
    {

    }

    MapFragment GetPooledFragment()
    {
        return null;
    }

    void ReturnPooledFragment()
    {

    }
}
