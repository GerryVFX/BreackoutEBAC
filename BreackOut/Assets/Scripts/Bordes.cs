using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordes : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().bola_Speed * direction;
        
    }
}
