using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpForce = 2f;
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb;
    public Animator  anim;
    public PlayableDirector director;
    private GameManager gameManager;


    
    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        
         if (horizontal == 1)
        {   
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Correr", true);
        }      
            else if (horizontal == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Correr", true);
        }else 
        {
            anim.SetBool("Correr", false);
        }

        if(Input.GetButtonDown("Jump") && GroundChecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }

        //GameManager.Instance.RestarVidas();

        Global.nivel = 1;   

    }

    void FixedUpdate() {

        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
            
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
        if(other.gameObject.tag == "Bomba")
        {
            Debug.Log("Te ha explotado una bomba");
            gameManager.BombaHit(other.gameObject);
            gameManager.RestarVidas(this.gameObject);

        }
        if(other.gameObject.tag == "DeadZone")
        {
            Debug.Log("Estas Muerto ninja pocho");
            gameManager.DeathCharacter(this.gameObject);
        }
        if(other.gameObject.tag == "Estrella")
        {
            Debug.Log("Una estrellita for you bro");
            gameManager.ColeccionaEstrella(other.gameObject, this.gameObject);
        }
        

    }


}
