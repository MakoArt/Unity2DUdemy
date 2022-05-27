using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
    [SerializeField] AudioSource musicWin; 

    void Start()
    {
        musicWin.Play();
    }

}
