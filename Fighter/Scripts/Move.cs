using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float VelocidadHorizontal; 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(VelocidadHorizontal * Time.deltaTime,0,0);
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > -7.0f)
        {
            transform.position += new Vector3(-VelocidadHorizontal * Time.deltaTime, 0, 0);
        }


    }
}
