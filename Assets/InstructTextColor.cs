using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructTextColor : MonoBehaviour
{

    private Text myText;
    //Two colors instruction text swithces between
    public Color color1;
    public Color color2;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        
        Debug.Log("Color1 is " + color1);
    }

    // Update is called once per frame
    void Update()
    {
        var pingPong = Mathf.PingPong(Time.time, 1);
        var color = Color.Lerp(Color.black, Color.yellow, pingPong);
        myText.color = color;
    }
}
