using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFragmentPool : MonoBehaviour
{
    [SerializeField]
    List<ListOfMapFragments> mapFragmentPrefabs = new List<ListOfMapFragments>();
    [SerializeField]
    List<ListOfMapFragments> pooledFragments = new List<ListOfMapFragments>();
    [SerializeField]
    int rarityStep;
    const int amountOfStartFragments = 10;
    [Serializable]
    class ListOfMapFragments
    {
        [SerializeField]
        public List<MapFragment> fragments = new List<MapFragment>();
        [HideInInspector]
        public int timeRarity;
        public ListOfMapFragments(int timeRarity)
        {
            fragments = new List<MapFragment>();
            this.timeRarity = timeRarity;
        }
    }
    public static MapFragmentPool instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        Initialize();
    }
    void Initialize()
    {
        int rarity = rarityStep;
        for(int i = 0; i < mapFragmentPrefabs.Count; i ++)
        {
            ListOfMapFragments listOfMapFragments = new ListOfMapFragments(rarity);

            for (int j = 0; j<amountOfStartFragments; j ++)
            {
                int indexOfPrefab = UnityEngine.Random.Range(0, mapFragmentPrefabs[i].fragments.Count);
                MapFragment mapFragment = Instantiate(mapFragmentPrefabs[i].fragments[indexOfPrefab],transform.position,transform.rotation);
                mapFragment.OverTimeRarity = rarity;
                listOfMapFragments.fragments.Add(mapFragment);
            }

            pooledFragments.Add(listOfMapFragments);
            rarity += rarityStep;
        }
    }

    public MapFragment GetPooledFragment(int rarity)
    {
        int rarityIndex = UnityEngine.Random.Range(0,rarity);
        
        for(int i = pooledFragments.Count - 1; i >= 0; i--)
        {
            if(rarityIndex >= pooledFragments[i].timeRarity)
            {
                int index = UnityEngine.Random.Range(0, pooledFragments[i].fragments.Count);
                pooledFragments[i].fragments.RemoveAt(index);
                return pooledFragments[i].fragments[index];
            }
        }
        return null;
    }

    public void ReturnPooledFragment(MapFragment mapFragment)
    {
        for(int i = 0; i <  pooledFragments.Count; i++)
        {
            if(mapFragment.OverTimeRarity == pooledFragments[i].timeRarity)
            {
                mapFragment.transform.position = transform.position;
                mapFragment.inPool = true;
                pooledFragments[i].fragments.Add(mapFragment);
            }
        }
    }
}
