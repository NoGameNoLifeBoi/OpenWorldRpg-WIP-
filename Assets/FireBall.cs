using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject fireballExplosionParticle;
    private void Start()
    {
        rb.AddForce(transform.forward * 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TookDamage(15, 0);
        }
        GameObject temp = Instantiate<GameObject>(fireballExplosionParticle);
        temp.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
