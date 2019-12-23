using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
	public float timeLeft;
    public Color targetColor;
    private Text myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            myText.color = targetColor;
            
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.3f;

        }
        else
        {
            myText.color = Color.Lerp(myText.color, targetColor, Time.deltaTime);
            timeLeft -= Time.deltaTime;
        }
    }
}
