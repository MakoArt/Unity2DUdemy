using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigEnemy : MonoBehaviour
{

    private bool collisionWidthPig = false;
    [SerializeField] UIManagers uiManager;
    [SerializeField] PlayerMove playerMove;
  

  
    void Update()
    {
        if (playerMove.attack && collisionWidthPig) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            uiManager.vidaActualPlayer -= 1.5f;
            collisionWidthPig = true;
        }
        else
        {
            uiManager.vidaActualPlayer -= 0f;
            collisionWidthPig = false;
        }
    }
}
