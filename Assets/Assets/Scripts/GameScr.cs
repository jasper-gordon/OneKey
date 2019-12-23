using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScr : MonoBehaviour
{
    public bool Player1 = true;
    private Dictionary<string, KeyCode> LinkDict = new Dictionary<string, KeyCode>();
    private Dictionary<string, Vector2> DistanceDict = new Dictionary<string, Vector2>();
    private string deathKey;
    private string namekey;
    private AudioSource theaudio;
    private Color backgr = new Color(125, 125, 0);
    private bool lose = false;
    private PhysicsMaterial2D bouncyboy;
    public Text Ptext;
    public float endTime;


    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.backgroundColor = backgr;
        theaudio = GetComponent<AudioSource>();
        string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        deathKey = st[Random.Range(0, st.Length)].ToString();

       
        LoadDict();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !lose)
        {
            
            foreach(KeyValuePair<string, KeyCode> pair in LinkDict)
            {
                if (Input.GetKeyDown(pair.Value))
                {

                   
                    
                    namekey = pair.Key + "-Key_0";

                    GameObject textobj = GameObject.Find("Text");
                    GameObject obj = GameObject.Find(namekey);


                    if (deathKey == pair.Key)
                    {
                        if (!Player1)
                        {
                            Ptext.text = "Player   1   Wins!";
                        }
                        else {
                            Ptext.text = "Player   2   Wins!";
                        }
                        Ptext.transform.localPosition = new Vector3(0, 0, 0);
                        Ptext.transform.localScale = new Vector3(3, 3, 0);
                        Ptext.color = Color.red;
                        //Return to main
                        Invoke("GoToIntro", endTime);


                        lose = true;
                        theaudio.volume = 1;
                        obj.tag = "deathkey";
                        obj.GetComponent<key_script>().changelayer();
                        GameObject[] keyarr = GameObject.FindGameObjectsWithTag("key");
                        textobj.GetComponent<TimerPVP>().stopper();
                        foreach (GameObject i in keyarr)
                        {
                            i.GetComponent<key_script>().boostIt(true, Color.red);
                        }
                        

                    }

                    else if (!obj.GetComponent<key_script>().ispressed)
                    {
                        if (Player1)
                        {
                            Ptext.text = "Player 2";
                            Player1 = false;
                        }
                        else
                        {
                            Ptext.text = "Player 1";
                            Player1 = true;
                        }
                        textobj.GetComponent<TimerPVP>().Reset();
                        
                        Vector2 dist1 = DistanceDict[deathKey];
                        Vector2 dist2 = DistanceDict[pair.Key];
                        float dist = Vector2.Distance(dist1, dist2);
                        dist = dist / 8.1f;
                        //dist = Mathf.Round(dist);
                        Debug.Log(dist);
                        //Camera.main.backgroundColor = new Color(1 - dist, 0, dist);
                        
                        obj.GetComponent<key_script>().boostIt(false, new Color(1 - dist, 0, dist));
                        theaudio.volume += .025f;
                        theaudio.pitch += .01f;
                    }
                    
                }
            }
        }
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    void LoadDict()
    {
        DistanceDict.Add("Q", new Vector2(0, 1));
        DistanceDict.Add("A", new Vector2(0, 2));
        DistanceDict.Add("Z", new Vector2(0, 3));
        DistanceDict.Add("W", new Vector2(1, 1));
        DistanceDict.Add("S", new Vector2(1, 2));
        DistanceDict.Add("X", new Vector2(1, 3));
        DistanceDict.Add("E", new Vector2(2, 1));
        DistanceDict.Add("D", new Vector2(2, 2));
        DistanceDict.Add("C", new Vector2(2, 3));
        DistanceDict.Add("R", new Vector2(3, 1));
        DistanceDict.Add("F", new Vector2(3, 2));
        DistanceDict.Add("V", new Vector2(3, 3));
        DistanceDict.Add("T", new Vector2(4, 1));
        DistanceDict.Add("G", new Vector2(4, 2));
        DistanceDict.Add("B", new Vector2(4, 3));
        DistanceDict.Add("Y", new Vector2(5, 1));
        DistanceDict.Add("H", new Vector2(5, 2));
        DistanceDict.Add("N", new Vector2(5, 3));
        DistanceDict.Add("U", new Vector2(6, 1));
        DistanceDict.Add("J", new Vector2(6, 2));
        DistanceDict.Add("M", new Vector2(6, 3));
        DistanceDict.Add("I", new Vector2(7, 1));
        DistanceDict.Add("K", new Vector2(7, 2));
        DistanceDict.Add("O", new Vector2(8, 1));
        DistanceDict.Add("L", new Vector2(8, 2));
        DistanceDict.Add("P", new Vector2(9, 1));
        DistanceDict.Add("1", new Vector2(0, 0));
        DistanceDict.Add("2", new Vector2(1, 0));
        DistanceDict.Add("3", new Vector2(2, 0));
        DistanceDict.Add("4", new Vector2(3, 0));
        DistanceDict.Add("5", new Vector2(4, 0));
        DistanceDict.Add("6", new Vector2(5, 0));
        DistanceDict.Add("7", new Vector2(6, 0));
        DistanceDict.Add("8", new Vector2(7, 0));
        DistanceDict.Add("9", new Vector2(8, 0));
        DistanceDict.Add("Space", new Vector2(4, 4));
        DistanceDict.Add("Shift", new Vector2(0, 3));
        DistanceDict.Add("Ctrl", new Vector2(0, 4));
        DistanceDict.Add("Alt", new Vector2(2, 4));

        LinkDict.Add("Shift", KeyCode.LeftShift);
        LinkDict.Add("Ctrl", KeyCode.LeftControl);
        LinkDict.Add("Alt", KeyCode.LeftAlt);
        LinkDict.Add("Space", KeyCode.Space);
        LinkDict.Add("Q", KeyCode.Q);
        LinkDict.Add("A", KeyCode.A);
        LinkDict.Add("Z", KeyCode.Z);
        LinkDict.Add("W", KeyCode.W);
        LinkDict.Add("S", KeyCode.S);
        LinkDict.Add("X", KeyCode.X);
        LinkDict.Add("E", KeyCode.E);
        LinkDict.Add("D", KeyCode.D);
        LinkDict.Add("C", KeyCode.C);
        LinkDict.Add("R", KeyCode.R);
        LinkDict.Add("F", KeyCode.F);
        LinkDict.Add("V", KeyCode.V);
        LinkDict.Add("T", KeyCode.T);
        LinkDict.Add("G", KeyCode.G);
        LinkDict.Add("B", KeyCode.B);
        LinkDict.Add("Y", KeyCode.Y);
        LinkDict.Add("H", KeyCode.H);
        LinkDict.Add("N", KeyCode.N);
        LinkDict.Add("U", KeyCode.U);
        LinkDict.Add("J", KeyCode.J);
        LinkDict.Add("M", KeyCode.M);
        LinkDict.Add("I", KeyCode.I);
        LinkDict.Add("K", KeyCode.K);
        LinkDict.Add("O", KeyCode.O);
        LinkDict.Add("L", KeyCode.L);
        LinkDict.Add("P", KeyCode.P);
        LinkDict.Add("1", KeyCode.Alpha1);
        LinkDict.Add("2", KeyCode.Alpha2);
        LinkDict.Add("3", KeyCode.Alpha3);
        LinkDict.Add("4", KeyCode.Alpha4);
        LinkDict.Add("5", KeyCode.Alpha5);
        LinkDict.Add("6", KeyCode.Alpha6);
        LinkDict.Add("7", KeyCode.Alpha7);
        LinkDict.Add("8", KeyCode.Alpha8);
        LinkDict.Add("9", KeyCode.Alpha9);

    }
}
