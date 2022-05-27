using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Koi : MonoBehaviour
{
    [SerializeField] float velocidadHorizontal;
    [SerializeField] Animator anim;
    [SerializeField] Animator animPlayer;
    [SerializeField] GameManager gameManager;
    [SerializeField] Animations animations;
    private bool isCollision;
    private int aleatorio;
    private bool _block;
    [SerializeField]AudioSource musicGame;
    [SerializeField] AudioSource punch;
    [SerializeField] ParticleSystem bloodPlayer;
    [SerializeField] ParticleSystem bloodEnemy;
  






    void Start()
    {
        velocidadHorizontal = 2.0f;
        isCollision = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _block = false;
        musicGame.Play();

        InvokeRepeating("KoiIA",0,0.5f);
    }

   
    void Update()
    {
        Movement();
        DeadAndWin();
 
        

    }

    private void Movement()
    {
        transform.position += new Vector3(-velocidadHorizontal * Time.deltaTime,0,0);

        if (transform.position.x > 5f)
        {
            velocidadHorizontal *= -1;
        }

    }


    private void KoiIA()
    {
        aleatorio = Random.Range(0, 5);


        if (isCollision)
        {
            if(aleatorio == 0)
            {
                anim.SetBool("LowKickKoi", true);
            }
            else
            {
                anim.SetBool("LowKickKoi", false);
            }

            if (aleatorio == 1)
            {
                anim.SetBool("MiddleKickKoi", true);
            }
            else
            {
                anim.SetBool("MiddleKickKoi", false);
            }

            if (aleatorio == 2)
            {
                anim.SetBool("HighKickKoi", true);
            }
            else
            {
                anim.SetBool("HighKickKoi", false);
            }

            if (aleatorio == 3)
            {
                anim.SetBool("BlockKoi", true);
                _block = true;
         
            }
            else if(aleatorio !=3)
            {
                anim.SetBool("BlockKoi", false);
                _block = false;
            }

            if (aleatorio == 4 || aleatorio == 5)
            {
                velocidadHorizontal *= -1;
                anim.SetBool("BlockKoi", false);
                anim.SetBool("MiddleKickKoi", false);
                anim.SetBool("LowKickKoi", false);
                anim.SetBool("HighKickKoi", false);

            }
            



        }
       

        else
        {
            anim.SetBool("BlockKoi", false);
            anim.SetBool("MiddleKickKoi", false);
            anim.SetBool("LowKickKoi", false);
            anim.SetBool("HighKickKoi", false);

            velocidadHorizontal *= 1;
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Protagonista"))
        {
            isCollision = true;
            CheckAttack();
       
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Protagonista"))
        {
            isCollision = false;
        }
    }
    //logica del ataque del enemigo al jugador
    private void CheckAttack()
    {  

        if (isCollision && animations.Blocking==false)
        {
            if(aleatorio==0 || aleatorio==1 || aleatorio == 2)
            {
                gameManager.NumeroVidasHero-=0.2f;
                gameManager.IsDeadHero = true;
                bloodPlayer.Play();
                animPlayer.SetBool("Hit", true);
                Invoke("Quit", 1);
                punch.Play();
        
   
                
             }
           
        }
     
     
        Debug.Log(gameManager.NumeroVidasHero);
        Debug.Log(gameManager.IsDeadHero);


        //logica del ataque de el jugador al enemigo 

        if (isCollision)
        {
            if(animations.LowKickPlayer==true || animations.MiddleKickPlayer==true || animations.HighKickPlayer == true)
            {
                gameManager.NumeroVidasEnemy-=0.4f;
                gameManager.IsDeadEnemy = true;
                bloodEnemy.Play();
                anim.SetBool("HitKoi", true);
                Invoke("HitKoiFunction", 2);
                punch.Play();
               
            }
        }
  
        Debug.Log("Al enemigo le quedan " + gameManager.NumeroVidasEnemy);
        Debug.Log("¿Esta muerto el enemigo?" + gameManager.IsDeadEnemy);

    }
    //Funciones para eliminar animacion de golpeo

    private void Quit()
    {
        animPlayer.SetBool("Hit", false);
    }
    private void HitKoiFunction()
    {
        anim.SetBool("HitKoi", false);
    }
    //funciones que disparan la victoria o derrota
    private void DeadAndWin()
    {
        if (gameManager.NumeroVidasEnemy < 1)
        {
            anim.SetBool("LoseKoi", true);
            animPlayer.SetBool("Win", true);
            Invoke("WinScreen", 5);
          
          
        }

        if (gameManager.NumeroVidasHero < 1)
        {
            anim.SetBool("WinKoi", true);
            animPlayer.SetBool("Lose", true);
            Invoke("LoseScreen", 5);
           
       
        }
    }



    private void WinScreen()
    {
        SceneManager.LoadScene("Win");
  
    }
    private void LoseScreen()
    {
        SceneManager.LoadScene("Lose");
    }


}
