using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;
    float currentHealth;
    PlayerController controlMovement;

    public AudioClip playerHurt;
    AudioSource playerAS;

    public Slider healthSlider;
    public Text gameOverScreen;

    public restartGame theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<PlayerController>();

        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        playerAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {

        if (damage <= 0) return;
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();


        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {

            makeDead();

        }

    }

    public void makeDead()
    {

        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.restartTheGame();

    }


}
