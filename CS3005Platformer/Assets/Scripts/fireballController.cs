using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballController : MonoBehaviour
{

    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Awake()
    {

        myRB = GetComponent<Rigidbody2D>();
        myRB.velocity = new Vector2(-10f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
