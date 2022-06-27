using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject spawnPos;
    
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
        
        //Debug.Log("sa");

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
