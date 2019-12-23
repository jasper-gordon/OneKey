using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextPulse2 : MonoBehaviour
{
    private Text myText;
    public int minSize;
    public int maxSize;
    public int pongSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int newSize = (int)(Mathf.PingPong(Time.time * pongSpeed, maxSize - minSize));
        myText.fontSize = newSize + minSize;
        print(myText.fontSize);
    }
}

