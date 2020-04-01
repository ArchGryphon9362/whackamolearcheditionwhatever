using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public GameObject ratEasy;
    public GameObject ratNormal;
    public GameObject ratHard;

    float prevTime;

    enum ratTypes
    {
        NONE = -1, EASY = 0, NORMAL = 1, HARD = 2
    }

    ratTypes ratType = ratTypes.NONE;

    Animator easyAnim;
    Animator normalAnim;
    Animator hardAnim;

    Rat easyRC;
    Rat normalRC;
    Rat hardRC;

    Vector2 randomHole;

    bool timerHasStarted = true;
    bool canStart = false;
    bool foundThings = false;
    [HideInInspector]
    public bool ratsBegan;

    public GameController gc;

    void Start()
    {
        easyAnim = ratEasy.GetComponent<Animator>();
        normalAnim = ratNormal.GetComponent<Animator>();
        hardAnim = ratHard.GetComponent<Animator>();

        easyRC = ratEasy.GetComponent<Rat>();
        normalRC = ratNormal.GetComponent<Rat>();
        hardRC = ratHard.GetComponent<Rat>();
    }

    void Update()
    {
        if (gc.isGameActive)
        {
            if (!timerHasStarted && (Mathf.Floor(Time.time) - prevTime) >= 4)
            {
                prevTime = Mathf.Floor(Time.time);
                timerHasStarted = true;
            }

            if ((Mathf.Floor(Time.time) - prevTime) == 4)
            {
                canStart = true;
                timerHasStarted = false;
            }

            StartCoroutine(PickRandomHole());
            StartCoroutine(PickRandomRat());

            if (randomHole != new Vector2(0.0f, 0.0f) && ratType != ratTypes.NONE)
            {
                foundThings = true;
            }

            if (foundThings && easyRC.doneAnim && normalRC.doneAnim && hardRC.doneAnim)
            {
                ratsBegan = true;
                switch (ratType)
                {
                    case ratTypes.EASY:
                        ratEasy.transform.position = randomHole;
                        easyRC.canBeHit = true;
                        easyRC.doneAnim = false;
                        break;
                    case ratTypes.NORMAL:
                        ratNormal.transform.position = randomHole;
                        normalRC.canBeHit = true;
                        normalRC.doneAnim = false;
                        break;
                    case ratTypes.HARD:
                        ratHard.transform.position = randomHole;
                        hardRC.canBeHit = true;
                        hardRC.doneAnim = false;
                        break;
                    default:
                        Debug.LogError("Something bad but unknown happened!?");
                        break;
                }
                foundThings = false;
                canStart = false;
            }
        }

    }

    IEnumerator PickRandomHole()
    {
        yield return new WaitUntil(() => canStart);
        switch (Random.Range(1, 6))
        {
            case 1:
                randomHole = new Vector2(-3.6f, -0.21f);
                break;
            case 2:
                randomHole = new Vector2(0.0f, -0.21f);
                break;
            case 3:
                randomHole = new Vector2(3.6f, -0.21f);
                break;
            case 4:
                randomHole = new Vector2(-1.825f, -1.98f);
                break;
            case 5:
                randomHole = new Vector2(1.825f, -1.98f);
                break;
            case 6:
                randomHole = new Vector2(0.0f, -3.8f);
                break;
            default:
                Debug.LogError("How!?... Reached a random number that was undefined!?");
                randomHole = new Vector2(0.0f, 0.0f);
                break;
        }
    }

    IEnumerator PickRandomRat()
    {
        yield return new WaitUntil(() => canStart);

        switch(Random.Range(0, 10))
        {
            case 0:
                ratType = ratTypes.EASY;
                break;
            case 1:
                ratType = ratTypes.EASY;
                break;
            case 2:
                ratType = ratTypes.EASY;
                break;
            case 3:
                ratType = ratTypes.EASY;
                break;
            case 4:
                ratType = ratTypes.EASY;
                break;
            case 5:
                ratType = ratTypes.EASY;
                break;
            case 6:
                ratType = ratTypes.NORMAL;
                break;
            case 7:
                ratType = ratTypes.NORMAL;
                break;
            case 8:
                ratType = ratTypes.NORMAL;
                break;
            case 9:
                ratType = ratTypes.HARD;
                break;
            case 10:
                ratType = ratTypes.HARD;
                break;

            default:
                ratType = ratTypes.NONE;
                break;
        }
    }

}
