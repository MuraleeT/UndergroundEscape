﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHit : MonoBehaviour
{

    public float weaponDamage;

    projectileController myPC;

    // Start is called before the first frame update
    void Awake()
    {

        myPC = GetComponentInParent<projectileController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

            myPC.removeForce();
            Destroy(gameObject);

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {

            myPC.removeForce();
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {

                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);

            }

        }

    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

            myPC.removeForce();
            Destroy(gameObject);

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {

            myPC.removeForce();
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {

                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);

            }

        }

    }


}