using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text score;
    void Start()
    {
        Cursor.visible = true;
        if (GameController.instance != null)
        {
            score.text = GameController.instance.score.ToString();
        }
    }

    public void GoStart()
    {
        SceneManager.LoadScene(0);
    }
}
