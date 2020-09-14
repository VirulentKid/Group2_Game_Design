using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject myPlayer;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;
    public float bulletDestroyTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer(gameObject);
        followMouse(gameObject);
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    //let arm follow the mouse and flip
    void followMouse(GameObject input)
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        input.transform.rotation = Quaternion.Euler(0f, 0f, z);
        if(z < -90 || z > 90)
        {
            if(myPlayer.transform.eulerAngles.y == 0 || myPlayer.transform.eulerAngles.y == 180)
                input.transform.localRotation = Quaternion.Euler(180, 0, -z);
        }
    }

    //let the arm and gun follow the player
    void followPlayer(GameObject input)
    {
        input.transform.position = myPlayer.transform.position + new Vector3(-0.069f, 0.221f, 0f); //minus arm's coordinate by player's position
    }

    //fire the bullets
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        followPlayer(bullet);
        followMouse(bullet);

        Vector3 difference = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z)) - transform.position;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        Destroy(bullet, bulletDestroyTime);
    }
}
