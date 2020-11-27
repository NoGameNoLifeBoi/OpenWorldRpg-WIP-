using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneEyeTimer : MonoBehaviour
{
    public bool arcaneEyeInUse = false;

    [SerializeField] float arcaneEyeTimer = 20f;

    private void Update()
    {
        if(arcaneEyeInUse)
        {
            arcaneEyeTimer -= Time.deltaTime;

            if (arcaneEyeTimer <= 0)
            {
                gameObject.SetActive(false);
                arcaneEyeInUse = false;
            }
        }
    }
}
