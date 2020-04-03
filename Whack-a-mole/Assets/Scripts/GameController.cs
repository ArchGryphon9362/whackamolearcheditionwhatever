using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public bool isGameActive;
    [HideInInspector]
    public bool gameDone;
    public int score;
    
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    void Start()
    {
        isGameActive = true;
        gameDone = false;
    }

}
