using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{


    [SerializeField] AudioSource musicLose;
    void Start()
    {
        musicLose.Play();
    }

 
}
