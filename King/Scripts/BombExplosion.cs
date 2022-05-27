using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BombExplosion: MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textBombs;
    [SerializeField] GameObject numberBombs;
    private bool explosionCheck = false;
    private bool cambioScena = false;


    private void Update()
    {
        BombsNumber();
        RenderBombs();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            explosionCheck = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("Deactivate", 3);
        }
    }

    private void Deactivate()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
      
    }

    private void BombsNumber()
    {
        if (cambioScena)
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    private void RenderBombs()
    { 

        if(numberBombs.transform.childCount <= 1 && explosionCheck)
        {
            textBombs.text = "BOMBS : 0";
            cambioScena = true;
        }
        else
        {
            textBombs.text = $"BOMBS :{numberBombs.transform.childCount}";
        }
      

    }




}


