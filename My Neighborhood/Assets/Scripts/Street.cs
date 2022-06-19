using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField]private List<Building> buildings;
    private float _ownRate;
    
    // Start is called before the first frame update
    void Start()
    {
        _ownRate = CalculateOwnRate();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateOwnRate();
    }

    private float CalculateOwnRate()
    {

        int owned = 0;

        foreach (Building building in buildings)
        {

            if (building.IsOwned)
                owned++;

        }

        float rate = owned / buildings.Count * 100;
        _ownRate = rate;
        return _ownRate;
    }
}
