using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public static bool checkCollision;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain")) checkCollision = true;
        Debug.Log("Estoy en el suelo");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain")) checkCollision = false;
        Debug.Log("Estoy en el aire");
    }
}
