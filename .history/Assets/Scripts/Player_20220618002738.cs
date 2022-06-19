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

    public int health;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount){

        health -= damageAmount;
        healthDisplay.text = health.ToString();
        if(health <= 0){
            health = 0;
            healthDisplay.text = health.ToString();
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
