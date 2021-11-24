using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{

    public GameObject enemy;
    public Transform TopAttack;
    public Transform BottomAttack;

    Rigidbody2D myRB;


    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody2D>();

        InvokeRepeating("LaunchProjectileTop", 1.0f, 2.9f);
        InvokeRepeating("LaunchProjectileLow", 1.0f, 2.3f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectileTop()
    {

        Instantiate(enemy, TopAttack.position, Quaternion.Euler(new Vector3(0, 0, 0)));

    }

    void LaunchProjectileLow()
    {

        Instantiate(enemy, BottomAttack.position, Quaternion.Euler(new Vector3(0, 0, 0)));

    }


}
