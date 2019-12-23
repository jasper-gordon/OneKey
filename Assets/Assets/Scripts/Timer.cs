using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float time;
    public float endTime;
    private float totaltime = 10f;
    private Text str;
    private float clock = 0.0f;
    private bool stop = false;
    public Text Ptext;
    private int count = 0;
    private bool lose = false;
    // Start is called before the first frame update
    void Start()
    {
        str = GetComponent<Text>();
        str.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            time -= Time.deltaTime;
            str.text = time.ToString("F2");
            if (time <= 0.0f)
            {
                
                string str = "You   Lose";
                Ptext.text = str;
                Ptext.transform.localPosition = new Vector3(0, 0, 0);
                Ptext.transform.localScale = new Vector3(2, 2, 0);
                Ptext.color = Color.red;


                lose = true;
                //theaudio.volume = 1;
                GameObject textobj = GameObject.Find("Text");
                GameObject[] keyarr = GameObject.FindGameObjectsWithTag("key");
                textobj.GetComponent<Timer>().stopper();
                foreach (GameObject i in keyarr)
                {
                    i.GetComponent<key_script>().boostIt(true, Color.black);
                }
                stop = true;

                Invoke("GoToIntro", endTime);

            }
        }
    }

    public void Reset()
    {
        if (totaltime != 2)
        {
            totaltime -= .5f;
            
        }
        time = totaltime;
        str.text = time.ToString();

    }
    public void stopper()
    {
        str.text = "0.00";
        stop = true;
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

}
