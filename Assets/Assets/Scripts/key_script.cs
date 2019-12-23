using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_script : MonoBehaviour
{
	private Rigidbody2D myRb2D;
	private SpriteRenderer mSprite;
    public bool ispressed = false;
    private PhysicsMaterial2D bouncyboy;
    public ParticleSystem explosion;
    

	// Start is called before the first frame update
	void Start()
	{
		myRb2D = GetComponent<Rigidbody2D>();
		mSprite = GetComponent<SpriteRenderer>();
        bouncyboy = GetComponent<PhysicsMaterial2D>();
    }

    public void boostIt(bool ending, Color col) {
        myRb2D.gravityScale = 1;
        
        if (ending)
        {
            
            myRb2D.gravityScale = 0;

        }
        int randInt = Random.Range(-1, 3);
        if (randInt == 0)
        {
            randInt = -1;
        }
        if(randInt == 2)
        {
            randInt = 1;
        }

        int randInt2 = Random.Range(-1, 3);
        if (randInt2 == 0)
        {
            randInt2 = -1;
        }
        if (randInt2 == 2)
        {
            randInt2 = 1;
        }

        Vector2 randomVector = new Vector2(Random.value +.3f, Random.value+.3f);
        randomVector *= 250;
        randomVector.x *= randInt;
        randomVector.y *= randInt2;
        myRb2D.AddForce(randomVector);
        ispressed = true;
        gameObject.layer = 9;
        ParticleSystem exp = explosion;
        exp.startColor = col;
        Instantiate(exp, transform.position, Quaternion.identity);
        
        
        
    }
    public void changelayer()
    {
        gameObject.layer = 9;
        //myRb2D.isKinematic = true;
        gameObject.transform.localScale = new Vector3(5,5,1);

    }

	// Update is called once per frame
	void Update()
	{

	}
}
