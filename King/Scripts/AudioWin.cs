using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWin : MonoBehaviour
{
    [SerializeField]AudioSource winMusic;


    private void Start()
    {
        winMusic.Play();
    }
}
