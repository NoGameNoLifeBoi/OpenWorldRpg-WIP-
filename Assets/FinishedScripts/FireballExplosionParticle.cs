using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosionParticle : MonoBehaviour
{
    float timer = 0.1f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
