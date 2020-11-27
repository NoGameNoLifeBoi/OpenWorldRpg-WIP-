using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    //Reference To Player
    [SerializeField] private GameObject player;

    //Reference To PlayerStats Script
    [SerializeField] private PlayerStats playerStats;

    //Prefabs Needed For Spells
    [SerializeField] private GameObject fireBall;
 
    //Intermidate Spells Unlocked
    [SerializeField] private bool healUnlocked = false;
    [SerializeField] private bool fireBallUnlocked = false;
    [SerializeField] private bool snowStormUnlocked = false;

    //Advanced Spells Unlocked
    [SerializeField] private bool scryingUnlocked = false;
    [SerializeField] private bool timeSlowUnlocked = false;
    [SerializeField] private bool arcaneEyeUnlocked = false;

    //Scrying Variables
    public bool usingScrying = false;

    //Time Slow Variables
    private bool usingTimeSlow = false;

    //Snow Storm Variables
    [SerializeField] private GameObject snowStormObject;
    private bool usingSnowStorm = false;

    //Arcane Eye Variables
    public float arcaneEyeTimer = 20f;
    [SerializeField] private GameObject arcaneEyeCamera;

    private void Awake()
    {
        playerStats = player.GetComponent<PlayerStats>();
        player = GameObject.FindGameObjectWithTag("Player");
    }



    void Blink()
    {
        // Add Teleport Code Here
    }

    void Fireball() //FINISHED 
    {
        if (fireBallUnlocked && playerStats.mana >= 10)
        {
            playerStats.mana -= 10;

            Vector3 spawnPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1.5f);

            Instantiate(fireBall, spawnPos, player.transform.rotation);
        }
    }


    void Heal() //FINISHED
    {
        if(healUnlocked && playerStats.mana >= 10)
        {
            playerStats.mana -= 10;

            playerStats.health += 20;
        }
    }


    void SnowStorm() //FINISHED
    {
        if (snowStormUnlocked && playerStats.mana >= 20 && !usingSnowStorm)
        {
            playerStats.mana -= 20;

            snowStormObject.SetActive(true);

            usingSnowStorm = true;
        }
    }

    void Scrying() //FINISHED but nothing has been added that your able to scry yet
    {
        if(scryingUnlocked && playerStats.mana >= 50 && !usingScrying)
        {
            playerStats.mana -= 50;

            gameObject.GetComponent<ScryingScript>().scry();

            usingScrying = true;
        }
    }

    // ----------------------------------------------------------------------------------------------------------------
    //                  REMEMBER WHEN MAKING THE DRAWING SYMBOLS CODE TO USE TIME.UNSCALEDTIME
    // ----------------------------------------------------------------------------------------------------------------

    void TimeSlow() //Unfinished
    {
        if (timeSlowUnlocked && playerStats.mana >= 30 || usingTimeSlow)
        {
            
            if(usingTimeSlow)
            {
                usingTimeSlow = false;
                Time.timeScale = 1f;
            }
            else
            {
                playerStats.mana -= 30;

                Time.timeScale = 0.1f;

                usingTimeSlow = true;

                float slowTimeTimer = 10f;

                while(slowTimeTimer > 0)
                {
                    slowTimeTimer -= Time.unscaledDeltaTime;
                    if(slowTimeTimer <= 0)
                    {
                        TimeSlow();
                    }
                }
            }
        }
    }

    void ArcaneEye() //FINISHED
    {
        if(arcaneEyeUnlocked && playerStats.mana >= 20)
        {
            playerStats.mana -= 20;

            arcaneEyeCamera.SetActive(true);

            arcaneEyeCamera.GetComponent<ArcaneEyeTimer>().arcaneEyeInUse = true;  
        }
    }



    private void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Fireball();
        }
        else if(Input.GetKeyDown("2"))
        {
            Heal();
        }
        else if(Input.GetKeyDown("3"))
        {
            SnowStorm();
        }
        else if(Input.GetKeyDown("4"))
        {
            Scrying();
        }
        else if(Input.GetKeyDown("5"))
        {
            ArcaneEye();
        }

        if (usingSnowStorm)
        {
            float snowStormTimer = 10f;

            snowStormTimer -= Time.deltaTime;

            if(snowStormTimer <= 0)
            {
                snowStormObject.SetActive(false);
                usingSnowStorm = false;
            }
        }
    
    }
}
