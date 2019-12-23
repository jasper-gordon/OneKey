using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCall : MonoBehaviour
{
    private float introTime;
    public GameObject lightning;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BringTheLight", 3.8f);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    void BringTheLight()
    {
        Instantiate(lightning);
    }
}
