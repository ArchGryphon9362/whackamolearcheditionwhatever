using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public Animator anim;

    public void End()
    {
        anim.SetTrigger("End");
        StartCoroutine("GoNext");
    }

    IEnumerator GoNext()
    {
        yield return new WaitForSeconds(0.6f);
        DontDestroyOnLoad(GameController.instance);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
