using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    
    void Start()
    {
        //TODO: Eğer cihazda veri saklanmışsa first start değildir, değilse first starttır   
        

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
