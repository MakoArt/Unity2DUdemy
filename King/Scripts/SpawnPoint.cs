using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{


    private float positionX;
    private float positionY;

    void Start()
    {
        if(PlayerPrefs.GetFloat("positionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY")));
        }
    } 
    public void Respawn(float X , float Y)
    {
        PlayerPrefs.SetFloat("positionX", X);
        PlayerPrefs.SetFloat("positionY", Y);
    }

  
}
