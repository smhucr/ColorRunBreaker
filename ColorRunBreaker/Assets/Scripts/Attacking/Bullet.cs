using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   //BulletSpeed
    public float speed;

    private void OnCollisionEnter(Collision collision)
    {
        //Carptiginde carpan nesne ve carpilan nesne yok olsun.
        // Destroy(collision.gameObject);
        // Destroy(gameObject);
    }
    private void Update()
    {
        //BulletAcceleration  
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
