using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullController : MonoBehaviour
{

    public float speed;
    public float leftBound;
    public float rightBound;

    Rigidbody2D myRB;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody2D>();
        myRB.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);


    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > rightBound)
        {

            myRB.velocity = new Vector2(0.0f, 0.0f);
            myRB.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-0.6f, 0.6f, 1f);

        }

        if (transform.position.x < leftBound)
        {

            myRB.velocity = new Vector2(0.0f, 0.0f);
            myRB.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(0.6f, 0.6f, 1f);

        }



    }
}
