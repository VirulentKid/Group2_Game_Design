using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //bool facingR = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //faceMouse();
    }

    

    /*void faceMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mouse.x > transform.position.x && !facingR)
        {
            transform.Rotate(0f, 180f, 0f);
            facingR = true;
        }
        else if(mouse.x < transform.position.x && facingR)
        {
            transform.Rotate(0f, 180f, 0f);
            facingR = false;
        }
    }*/
}
