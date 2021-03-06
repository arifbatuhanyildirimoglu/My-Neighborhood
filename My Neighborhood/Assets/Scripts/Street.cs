using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField]private List<Building> buildings;
    private float _ownRate;
    
    void Start()
    {
        _ownRate = CalculateOwnRate();
    }

    void Update()
    {
        CalculateOwnRate();
    }

    public float CalculateOwnRate()
    {

        int owned = 0;

        foreach (Building building in buildings)
        {

            if (building.IsOwned)
                owned++;

        }
        Debug.Log(owned);

        float rate = owned / buildings.Count * 100;
        _ownRate = rate;
        return _ownRate;
    }

    public float OwnRate => _ownRate;
}
