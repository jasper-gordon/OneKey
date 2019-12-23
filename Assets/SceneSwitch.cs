using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public string newScene;


    public void GoToInstruct()
    {
        SceneManager.LoadScene("Instructions");
    }


    public void GoTo1Player()
    {
        SceneManager.LoadScene("1Player");
    }

    public void GoTo2Player()
    {
        SceneManager.LoadScene("2Player");
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }
}




