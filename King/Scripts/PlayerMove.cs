using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float horizontalSpeed = 7f;
    [SerializeField] float jumpSpeed = 50f;

    private float horizontalMove;

    private bool lookRight = true;
    public  bool attack;

    Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource Attack;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        music.Play();
    }



    void Update() 
    {

        ChangeDirection(horizontalMove);
    }

   public void FixedUpdate()
    {  
        //Cogemos el axis para la direccion del personaje  
        horizontalMove = Input.GetAxis("Horizontal");

        //Mover al personaje  

       if(GroundCheck.checkCollision)
        {
            rb.velocity = new Vector2(horizontalSpeed * horizontalMove, 0f);
            
            if(horizontalMove > 0.1 || horizontalMove < -0.1)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
            
            

        //Salto 

        if (Input.GetKey(KeyCode.Space) && GroundCheck.checkCollision)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            anim.SetBool("Jump", true);
            jump.Play();
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        //Ataque 
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Attack", true);
            attack = true;
            Attack.Play();
        }
        else 
        {
            anim.SetBool("Attack", false);
            attack = false;
        }
    }




    public void ChangeDirection(float h)
    {
        if ((h > 0 && !lookRight) || h < 0 && lookRight)
        {
            lookRight = !lookRight;
            Vector3 giro = transform.localScale;
            giro.x = giro.x * -1;
            transform.localScale = giro;
        }
    }


}
