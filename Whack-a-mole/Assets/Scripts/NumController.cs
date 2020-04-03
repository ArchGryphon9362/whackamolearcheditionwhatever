using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumController : MonoBehaviour
{

    public GameObject timeLeft;
    public GameObject timeRight;

    Animator animLeft;
    Animator animRight;
    EndScene endScene;

    public RatController rc;
    public GameController gc;

    bool gameDone;

    public float howMuchTime = 30;
    int time;
    float timeWhenGameShouldEndSoThatICanCheckWhatTimeItIsToSetTheTimerToThatTimeInsertWowMemeHere;
    bool timeWhenSet;

    void Start()
    {
        howMuchTime = Mathf.Clamp(howMuchTime, 10, 99);

        timeLeft = GameObject.Find("Num0");
        timeRight = GameObject.Find("Num1");

        animLeft = timeLeft.GetComponent<Animator>();
        animRight = timeRight.GetComponent<Animator>();
        endScene = GameObject.Find("EndScene").GetComponent<EndScene>();

        animLeft.Play("Num" + Mathf.FloorToInt(howMuchTime / 10));
        animRight.Play("Num" + (howMuchTime - (Mathf.FloorToInt(howMuchTime / 10) * 10)));
    }
    
    void Update()
    {
        if (rc.ratsBegan && !timeWhenSet)
        {
            timeWhenGameShouldEndSoThatICanCheckWhatTimeItIsToSetTheTimerToThatTimeInsertWowMemeHere = Mathf.Floor(Time.time) + howMuchTime;
            timeWhenSet = true;
        }
        if (timeWhenGameShouldEndSoThatICanCheckWhatTimeItIsToSetTheTimerToThatTimeInsertWowMemeHere != 0 && !gameDone)
        {
            time = (int)timeWhenGameShouldEndSoThatICanCheckWhatTimeItIsToSetTheTimerToThatTimeInsertWowMemeHere - Mathf.FloorToInt(Time.time);
            animLeft.Play("Num" + Mathf.FloorToInt(time / 10));
            animRight.Play("Num" + (time - (Mathf.FloorToInt(time / 10) * 10)));

            if (time == 0)
            {
                gc.isGameActive = false;
                gc.gameDone = true;
                gameDone = true;
                animLeft.StopPlayback();
                animRight.StopPlayback();
                endScene.End();
            }
        }
    }
}
