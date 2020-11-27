using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScryingScript : MonoBehaviour
{
    [SerializeField] private GameObject[] scryableObjects;

    [SerializeField] private float timer = 500f;
    
    private bool isScrying = false;

    private void Awake()
    {
        scryableObjects = GameObject.FindGameObjectsWithTag("Scryable");

        foreach (GameObject scryable in scryableObjects)
        {
            scryable.SetActive(false);
        }
    }

    private void Update()
    {
        if (isScrying)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                foreach (GameObject scryable in scryableObjects)
                {
                    scryable.SetActive(false);
                }
                gameObject.GetComponent<SpellController>().usingScrying = false;
                isScrying = false;
                timer = 500f;
            }
        }
    }

    public void scry()
    {
        foreach (GameObject scryable in scryableObjects)
        {
            scryable.SetActive(true);
        }
        isScrying = true;
    }
}
