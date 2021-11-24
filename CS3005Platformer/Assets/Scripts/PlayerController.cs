using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //speed of player
    public float speed = 10;

    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Animator myAnim;
    Rigidbody2D myRB;

    bool facingRight;

    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

    public GameObject levelDoor;


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }
    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        //pauses or plays game when player hits p
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }

        if (Input.GetAxisRaw("Fire1") > 0) fireArrow();

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        //get player input and set speed
        float movementSpeedX = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        myAnim.SetFloat("speed", Mathf.Abs(movementSpeedX));

        transform.Translate(movementSpeedX, 0, 0);

        if (movementSpeedX > 0 && !facingRight)
        {
            flip();
        }
        else if (movementSpeedX < 0 && facingRight)
        {
            flip();
        }

    }

    void flip()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;

    }

    void fireArrow()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler (new Vector3 (0,0,0)));
            }else if(!facingRight){
                Instantiate(bullet, gunTip.position, Quaternion.Euler (new Vector3 (0,0,180f)));
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "NextLevel")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }



    }


}