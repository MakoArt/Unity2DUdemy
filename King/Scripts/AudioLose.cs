using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioLose : MonoBehaviour
{
  [SerializeField] AudioSource loseMusic; 

    void Start()
    {
        loseMusic.Play();
    }

}
