using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject groceryPrefab;
    [SerializeField] private GameObject grocerySpawnPos;
    
    void Start()
    {
        //DontDestroyOnLoad(this);
        if(GameObject.FindGameObjectWithTag("Player") == null)
            Instantiate(playerPrefab, spawnPos.transform.position, Quaternion.identity);
        else
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            playerObject.GetComponent<PlayerController>().enabled = true;
            playerObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (GameObject.FindGameObjectWithTag("Grocery") == null)
            Instantiate(groceryPrefab, grocerySpawnPos.transform.position, Quaternion.identity);
        else
        {
            GameObject groceryObject = GameObject.FindGameObjectWithTag("Grocery");
            groceryObject.GetComponent<MeshRenderer>().enabled = true;
            groceryObject.GetComponent<BoxCollider>().enabled = true;
        }


    }

    void Update()
    {
    }
}

public enum GameState
{
    FirstStart,
    Start,
    Gameplay,
    Pause,
    End
}
