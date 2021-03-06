using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text healthDisplay;
    public GameObject losePanel;

    public float speed;
    private float input;
    Rigidbody2D rb;
    Animator anim;
    public AudioSource[] sounds;
    AudioSource sourceDamage;
    AudioSource sourceHeal;
    public int health;

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        sourceDamage = sounds[0];
        sourceHeal = sounds[1];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }

    private void Update(){

        if(input != 0){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        }

        if(input > 0){
            transform.eulerAngles = new Vector3(0,180,0);
        }else if(input < 0){
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isDashing == false){
            speed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if(dashTime <= 0 && isDashing == true){
            isDashing = false;
            speed -= extraSpeed;
        }else{
            dashTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount){
        sourceDamage.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();
        if(health <= 0){
            health = 0;
            healthDisplay.text = health.ToString();
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
    
    public void GiveHealth(int healAmount){
        if(health >= 10){
            health = 10;
            healthDisplay.text = health.ToString();
        }
        sourceHeal.Play();
        health += healAmount;
        healthDisplay.text = health.ToString();
    }
}
