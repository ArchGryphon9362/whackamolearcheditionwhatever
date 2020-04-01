using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public bool isGameActive;
    [HideInInspector]
    public bool gameDone;
    public int score;

    void Start()
    {
        isGameActive = true;
        gameDone = false;
    }

}
