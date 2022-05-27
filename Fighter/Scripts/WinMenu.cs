using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{
     public void EscenaJuegoWin()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Cambiando");
    }
    
}
