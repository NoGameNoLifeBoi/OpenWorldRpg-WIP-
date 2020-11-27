using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Common Enemy Chance = 55%;
    //Uncommon Enemy Chance = 33%;
    //Rare Enemy Chance = 11%;
    //Legendary Enemy Chance = 1%;

    /* 
      When Legendary spawns are full, rare becomes 12%.
      When rare spawns are full, legendary becomes 2%, uncommon becomes 38% and common becomes 60%. 
      When both rare and legendary spawns are full, uncommon becomes 45% and common gets 55%.
    */ 


    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private GameObject fairyPrefab;
    [SerializeField] private GameObject treantPrefab;
    [SerializeField] private GameObject treleperPrefab;
    [SerializeField] private GameObject corruptedTreleperPrefab;
    [SerializeField] private GameObject giantBeePrefab;
    [SerializeField] private GameObject nymphPrefab;
    [SerializeField] private GameObject woodGuardianPrefab;
    [SerializeField] private GameObject minotaurPrefab;
    [SerializeField] private GameObject unicornPrefab;

    //References To Each Of The Spawned Enemies And They're Variables
    public List<char> forestEnemyRarities = new List<char>();
    public List<GameObject> forestEnemies = new List<GameObject>();

    //Keeping Track Of The Amount Of Forest Enemies
    [SerializeField] private int amountForestEnemies = 0;
    [SerializeField] private int commonForestEnemies = 0; //No Max
    [SerializeField] private int uncommonForestEnemies = 0; //No Max
    [SerializeField] private int rareForestEnemies = 0; //Max of 5 per area
    [SerializeField] private int legendaryForestEnemies = 0; //Max of 1 per area

    //Forest Spawn Location References
    [SerializeField] private GameObject forestSpawnLoc;
    private BoxCollider forestSpawnLocCollider;
    private Vector3 spawningLoc;

    //Manticore LEGENDARY
    //Dragons LEGENDARY 
    //Unicorn LEGENDARY
    //Phoenix LEGENDARY
    //Hydra LEGENDARY

    //Treants COMMON
    //Fairies COMMON
    //Goblins COMMON
    //Skeletons COMMON
    //Treleper COMMON IN FOREST. THEY DON'T SPAWN ANYWHERE ELSE

    //Corrupted Treleper RARE IN FOREST. UNCOMMON EVERYWHERE ELSE.

    //Ogres UNCOMMON
    //Elves UNCOMMON
    //Imps UNCOMMON
    //Harpy UNCOMMON
    //Wizard UNCOMMON

    //Shadow RARE
    //Giants RARE
    //Nagas RARE
    //Minotaur RARE


    private void Awake()
    {
        forestSpawnLocCollider = forestSpawnLoc.GetComponent<BoxCollider>(); //This Finds The Forest Spawn And Makes A Reference To It
    }

    private void Update()
    { 
        if(Input.GetButtonDown("Cancel"))    //Just For Testing (Resets Spawning If The Escape Key Is Clicked)
        {
            ResetSpawning(); //Resets Spawning
        }

        if(amountForestEnemies < 20) //Checks If The Amount Of Enemies In The Forest Are Less Then What The Max Is
        {
            ForestSpawn(); //If it is less then it spawns more enemies
        }
    }

    void ForestSpawn() //Method that decides which rarity is going to be spawned in the forest
    {
        float randomNumber = Random.value; //Holds the random number that decides rarity

        if (legendaryForestEnemies == 1 && rareForestEnemies == 5) //Checks if the max amount of legendary and rare enemies are in the area, if so it changes the percentages the other rarities to fit 100%
        {
            if (randomNumber <= 0.45) 
            {
                Spawning("Forest", "Uncommon"); //Spawns an uncommon enemy in the forest
            }
            else
            {
                Spawning("Forest", "Common"); //Spawns a common enemy in the forest
            }
        }
        else if (legendaryForestEnemies == 1) //Checks if the max amount of legendary are in the area, if so it changes the percentages the other rarities to fit 100%
        {
            if (randomNumber <= 0.12)
            {
                Spawning("Forest", "Rare"); //Spawns a rare enemy in the forest
            }
            else if (randomNumber <= 0.45)
            {
                Spawning("Forest", "Uncommon"); //Spawns an uncommon enemy in the forest
            }
            else
            {
                Spawning("Forest", "Common"); //Spawns a common enemy in the forest
            }
        }
        else if (rareForestEnemies == 5) //Checks if the max amount of rare enemies are in the area, if so it changes the percentages the other rarities to fit 100%
        {
            if (randomNumber <= 0.02)
            {
                Spawning("Forest", "Legendary"); //Spawns a legendary enemy in the forest
            }
            else if (randomNumber <= 0.4)
            {
                Spawning("Forest", "Uncommon"); //Spawns an uncommon enemy in the forest
            }
            else
            {
                Spawning("Forest", "Common"); //Spawns a common enemy in the forest
            }
        }
        else //If the max amount of rare and legendary enemies has not been hit, just do the normal percentages
        {
            if (randomNumber <= 0.01)
            {
                Spawning("Forest", "Legendary"); //Spawns a legendary enemy in the forest
            }
            else if (randomNumber <= 0.12)
            {
                Spawning("Forest", "Rare"); //Spawns a rare enemy in the forest
            }
            else if (randomNumber <= 0.45)
            {
                Spawning("Forest", "Uncommon"); //Spawns an uncommon enemy in the forest
            }
            else
            {
                Spawning("Forest", "Common"); //Spawns a common enemy in the forest
            }
        }
    }

    void Spawning(string location, string rarity) //Method that actually spawns in the enemies
    {
        if(location == "Forest") //Checks if they're spawning in forest
        {

            spawningLoc = forestSpawnLocCollider.center + new Vector3(Random.Range(-forestSpawnLocCollider.size.x / 2, forestSpawnLocCollider.size.x / 2), forestSpawnLocCollider.transform.position.y, Random.Range(-forestSpawnLocCollider.size.z / 2, forestSpawnLocCollider.size.z / 2));
            //That gets the trigger that the enemies should spawn in and gets a random location in it for the enemies to spawn

            if (rarity == "Common") //Checks if its a common enemy spawning
            {
                int commonRandomNumber = Random.Range(1, 4); //Gets a random number and puts it into a variable

                switch (commonRandomNumber) //Decides which common enemy should spawn based on the random number
                {
                    case 1:
                        forestEnemies.Add(Instantiate(fairyPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a fairy in a random location in the forest
                        break;
                    case 2:
                        forestEnemies.Add(Instantiate(treantPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a treant in a random location in the forest
                        break;
                    case 3:
                        forestEnemies.Add(Instantiate(treleperPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a treleper in a random location in the forest
                        break;
                }

                forestEnemyRarities.Add('C');
                commonForestEnemies += 1;
            }
            else if(rarity == "Uncommon") //Checks if its an uncommon enemy spawning
            {
                int uncommonRandomNumber = Random.Range(1, 5); //Gets a random number and puts it into a variable

                switch (uncommonRandomNumber) //Decides which uncommon enemy should spawn based on the random number
                {
                    case 1:
                        forestEnemies.Add(Instantiate(giantBeePrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a giant bee in a random location in the forest
                        break;
                    case 2:
                        forestEnemies.Add(Instantiate(goblinPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a goblin in a random location in the forest
                        break;
                    case 3:
                        forestEnemies.Add(Instantiate(nymphPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a nymph in a random location in the forest
                        break;
                    case 4:
                        forestEnemies.Add(Instantiate(woodGuardianPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a wood guardian in a random location in the forest
                        break;
                }

                forestEnemyRarities.Add('U');
                uncommonForestEnemies += 1;
            }
            else if(rarity == "Rare") //Checks if its a rare enemy spawning
            {
                int rareRandomNumber = Random.Range(1, 3); //Gets a random number and puts it into a variable

                switch (rareRandomNumber) //Decides which rare enemy should spawn based on the random number
                {
                    case 1:
                        forestEnemies.Add(Instantiate(minotaurPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a minotaur in a random location in the forest
                        break;
                    case 2:
                        forestEnemies.Add(Instantiate(corruptedTreleperPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a corrupted treleper in a random location in the forest
                        break;
                }

                forestEnemyRarities.Add('R');
                rareForestEnemies += 1;
            }
            else //If its none of those, it spawns a legendary
            {
                int legendaryRandomNumber = Random.Range(1, 1); //Gets a random number and puts it into a variable

                switch (legendaryRandomNumber) //Decides which legendary enemy should spawn based on the random number
                {
                    case 1:
                        forestEnemies.Add(Instantiate(unicornPrefab, spawningLoc, new Quaternion(0f, 0f, 0f, 0f))); //Spawns a unicorn in a random location in the forest
                        break;
                }

                forestEnemyRarities.Add('L');
                legendaryForestEnemies += 1;
            }
            amountForestEnemies += 1;
        }
    }

    public void ListUpdate() //This method is called whenever an enemy dies so that the lists in this script can be updated
    {
        commonForestEnemies = 0; //Sets the number of common enemies it believes to be in the forest to 0
        uncommonForestEnemies = 0; //Sets the number of uncommon enemies it believes to be in the forest to 0
        rareForestEnemies = 0; //Sets the number of rare enemies it believes to be in the forest to 0
        legendaryForestEnemies = 0; //Sets the number of legendary enemies it believes to be in the forest to 0

        foreach (char rarity in forestEnemyRarities) //Goes through the entire list of forest enemy rarities adding back the amount of enemies in the forest
        {
            switch (rarity)
            {
                case 'C':
                    commonForestEnemies += 1;
                    break;
                case 'U':
                    uncommonForestEnemies += 1;
                    break;
                case 'R':
                    rareForestEnemies += 1;
                    break;
                case 'L':
                    legendaryForestEnemies += 1;
                    break;

            }
        }

        amountForestEnemies = commonForestEnemies + uncommonForestEnemies + rareForestEnemies + legendaryForestEnemies; //Updates the total amount of forest enemies there are in the forest

    }

    //This just kills off the enemies so they can be respawned easily for the purposes of testing
    private void ResetSpawning()
    {
        foreach (GameObject enemy in forestEnemies)
        {
            enemy.GetComponent<Enemy>().TookDamage(1000, 0); 
        }
    }
}