using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public GameController gameController;

    public float speed = 1;
    public int timeThere = 5;

    float newPos;

    public Vector2 initialPos;
    [HideInInspector]
    public bool canBeHit;
    [HideInInspector]
    public bool isHit;
    bool timerHasStarted;

    [HideInInspector]
    public bool doneMovingUp;
    [HideInInspector]
    public bool doneAnim = true;

    bool beginMovingUp;
    [HideInInspector]
    public bool beginMovingDown;

    [Range(-100, 100)]
    public int givesScoreOf;

    int prevTime;
    bool setHitTime;
    int timeAfterHit;
    bool addedScore;

    void FixedUpdate()
    {
        /*if(isHit && doneMovingUp)
        {
            if (!doneMovingUp)
            {
                isHit = false;
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Damage");
                score++;
                canBeHit = false;
                beginMovingDown = false;
            }
        }*/
        if (!timerHasStarted && canBeHit)
        {
            prevTime = Mathf.FloorToInt(Time.time);
            timerHasStarted = true;
        }
        if (timerHasStarted && !doneMovingUp && !beginMovingUp)
        {
            MoveUp();
        }
        if (doneMovingUp && !beginMovingDown)
        {
            canBeHit = true;
        }
        if (doneMovingUp && Mathf.FloorToInt(Time.time) - prevTime >= timeThere && !beginMovingDown)
        {
            MoveDown();
        }
        if (beginMovingUp)
        {
            canBeHit = false;
            isHit = false;
            if (newPos == 0) newPos = transform.position.y + 1.52f;
            if (transform.position == new Vector3(transform.position.x, newPos))
            {
                doneMovingUp = true;
                beginMovingUp = false;
                newPos = 0;
                return;
            }
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, newPos, speed));
        }
        if (beginMovingDown)
        {
            if (newPos == 0) newPos = transform.position.y - 1.52f;
            if (transform.position == new Vector3(transform.position.x, newPos))
            {
                addedScore = false;
                timerHasStarted = false;
                timeAfterHit = 0;
                transform.position = initialPos;
                beginMovingDown = false;
                timerHasStarted = false;
                doneAnim = true;
                canBeHit = false;
                isHit = false;
                newPos = 0.0f;
                doneMovingUp = false;
                prevTime = 0;
                //GetComponent<Animator>().SetTrigger("End");
            }
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, newPos, speed));
        }
        if (isHit && !setHitTime)
        {
            timeAfterHit = Mathf.FloorToInt(Time.time);
            setHitTime = true;
        }
        if (isHit && canBeHit)
        {
            //GetComponent<Animator>().SetTrigger("Damage");
            if (!addedScore) gameController.score += givesScoreOf;
            addedScore = true;
            canBeHit = false;
            beginMovingUp = false;
            IEnumerator coroutine = Hit(Mathf.FloorToInt(Time.time) - Mathf.FloorToInt(timeAfterHit));
            StartCoroutine(coroutine);
        }
    }

    void Move(Vector2 where)
    {
        transform.position = where;
    }
    void MoveUp()
    {
        beginMovingUp = true;
    }
    void MoveDown()
    {
        beginMovingDown = true;
    }

    IEnumerator Hit(int whenHappened)
    {
        beginMovingDown = false;
        yield return new WaitUntil(() => whenHappened >= 1);
        beginMovingDown = true;
        isHit = false;
        newPos = 0;
    }

}
