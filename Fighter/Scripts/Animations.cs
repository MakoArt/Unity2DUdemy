using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Move move;
 

    //BLOQUEO
    private bool _blocking=false;
    public  bool Blocking
    {
        get { return _blocking; }
        set { _blocking = value; }
    }
    //PATADA BAJA
    private bool _lowKickPlayer = false;
    public bool LowKickPlayer
    {
        get { return _lowKickPlayer; }
        set { _lowKickPlayer = value; }
    }
    //PATADA MEDIA
    private bool _middleKickPlayer = false;
    public bool MiddleKickPlayer
    {
        get { return _middleKickPlayer; }
        set { _middleKickPlayer = value; }
    }
    //PATADA ALTA
    private bool _highKickPlayer = false;
    public bool HighKickPlayer
    {
        get { return _highKickPlayer; }
        set { _highKickPlayer= value; }
    }

    //COLLISION 
    private bool _collisionPlayer = false; 
    public bool CollisionPlayer
    {
        get { return _collisionPlayer; }
        set { _collisionPlayer = value; }
    }



    void Update()
    {
        //Animación de bloqueo 

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Block", true);
            move.VelocidadHorizontal = 0;
            _blocking = true;
        }
        else
        {
            anim.SetBool("Block", false);
            move.VelocidadHorizontal = 12;
            _blocking = false;
        }


        //Animación de highkick

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("HighKick", true);
            _highKickPlayer = true;

        }
        else
        {
            anim.SetBool("HighKick", false);
            _highKickPlayer = false;
        }

        //Animación de middleKick

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("MiddleKick", true);
            move.VelocidadHorizontal = 0;
            _middleKickPlayer = true;

        }
        else if(!Input.GetKey(KeyCode.A))
        {
            anim.SetBool("MiddleKick", false);
            move.VelocidadHorizontal = 12;
            MiddleKickPlayer = false;

        }


        //Animacion de LowKick 


        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("LowKick", true);
            _lowKickPlayer = true;


        }
        else
        {
            anim.SetBool("LowKick", false);
            _lowKickPlayer = false;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            _collisionPlayer = true;
       

        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            _collisionPlayer= false;
        }
    }
}
