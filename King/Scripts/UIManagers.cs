using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManagers : MonoBehaviour
{

    public Image vidaPlayerImage;
 
   
    public float vidaActualPlayer = 10f;

    [SerializeField] Animator anim;


    void Update()
    {
        vidaPlayerImage.fillAmount = Mathf.Lerp(vidaPlayerImage.fillAmount,vidaActualPlayer/10,1 * Time.deltaTime);
        YouLose();
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AnimatedBomb"))
        {
            vidaActualPlayer -= 0.5f;
            Debug.Log(vidaActualPlayer);
            anim.SetBool("Hit", true);
          
        }
        else
        {
            anim.SetBool("Hit", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Box"))
        {
            vidaActualPlayer -= 2.0f;
        }
    }

    private void YouLose()
    {
        if (vidaActualPlayer <= 0)
        {
            Invoke("LoseMenu", 4);
            anim.SetBool("Dead",true);
        }
    }

    private void LoseMenu()
    {
        SceneManager.LoadScene("Lose");
    }


}
