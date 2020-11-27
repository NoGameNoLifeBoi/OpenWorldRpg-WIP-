using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int mana = 100;

    [SerializeField] float timer = 0.5f;

    private void Update()
    {
        if(mana != 100)
        {
            ManaGainTimer();
        }

        if(health > 100)
        {
            health = 100;
        }
    }

    void ManaGainTimer()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            mana += 1;
            timer = 1f;
        }
    }

}
