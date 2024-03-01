using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFragment : MonoBehaviour
{
    [SerializeField]
    Vector3 moveDirection;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    int overTimeRarity;
    bool overTimeRaritySet = false;
    public int OverTimeRarity
    {
        get { return overTimeRarity; }
        set { if (overTimeRaritySet)
                return;
            overTimeRarity = value;
            overTimeRaritySet = true;
        }
    }

    public bool inPool = true;

    private void Update()
    {
        if (inPool)
            return;
        Move();
    }

    void Move()
    {
        transform.position += moveSpeed * moveDirection * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        EndOfWay endOfWay = other.gameObject.GetComponent<EndOfWay>();
        if (endOfWay == null)
            return;

        MapFragmentPool.instance.ReturnPooledFragment(this);
    }
} 
