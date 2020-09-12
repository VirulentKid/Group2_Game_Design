using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLauncher : MonoBehaviour
{
    bool facingR = true;
    public Rigidbody2D player;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        follow();
    }

    //let arm follow the mouse and flip
    void follow()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, z);
        if(z < -90 || z > 90)
        {
            if(myPlayer.transform.eulerAngles.y == 0 || myPlayer.transform.eulerAngles.y == 180)
                transform.localRotation = Quaternion.Euler(180, 0, -z);
        }
    }

    //let the arm and gun follow the player
    void followPlayer()
    {
        transform.position = player.position + new Vector2(-0.069f, 0.221f); //minus arm's coordinate by player's position
    }
}
