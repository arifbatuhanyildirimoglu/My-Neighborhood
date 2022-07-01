using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField]private List<Building> buildings;
    private float _ownRate;
    private ProgressBar progressBar;
    public int OwnedBuildings{ set; get; }
    
    void Start()
    {
        _ownRate = CalculateOwnRate();
        OwnedBuildings = 0;
    }

    void Update()
    {
        CalculateOwnRate();
    }

    public float CalculateOwnRate()
    {

        ;

        foreach (Building building in buildings)
        {

            if (building.IsOwned)
                OwnedBuildings++;

        }

        float rate = _ownRate / buildings.Count * 100;
        _ownRate = rate;
        return _ownRate;
    }
}
