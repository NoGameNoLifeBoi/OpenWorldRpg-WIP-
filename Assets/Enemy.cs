using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //There are a bunch of unused variables that I have plans for in the future

    public bool onFire = false;

    private float ORIGINALMOVESPEED;

    private float speedDif;

    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private GameObject fireParticle;

    [SerializeField] private float health;

    public bool snowStormSpeedReduced = false;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float fireTimer = 5f;

    private bool fireParticleMade = false;

    private GameObject instantiatedFireParticle;

    [SerializeField] private string race;

    private bool regainSpeed = false;

    [SerializeField] private float maxWanderDistance;

    private bool isWandering = false; //Checks if they are in the middle of a wander movement

    private bool isAggro = false; //Checks if they are aggro to something

    private bool stopWandering = false; //Checks if something happened to stop them from wandering

    private Vector3 newDirection;

    private Vector3 positionToMoveTo;

    private void Awake()
    {
        enemySpawner = GameObject.Find("MainGameController").GetComponent<EnemySpawner>();

        ORIGINALMOVESPEED = moveSpeed;

        maxWanderDistance = moveSpeed * 3;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (snowStormSpeedReduced)
        {
            moveSpeed = ORIGINALMOVESPEED / 2;
            speedDif = ORIGINALMOVESPEED / 2;
            regainSpeed = false;
        }
        else if (moveSpeed != ORIGINALMOVESPEED)
        {
            regainSpeed = true;
        }

        if (regainSpeed)
        {
            moveSpeed += (speedDif / (3.0f / Time.deltaTime));

            if (moveSpeed >= ORIGINALMOVESPEED)
            {
                moveSpeed = ORIGINALMOVESPEED;
                regainSpeed = false;
            }
        }


        if (Input.GetKeyDown("i"))
        {
            Wander();
        }

        if(isWandering)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, positionToMoveTo, step);
            if (Vector3.Distance(positionToMoveTo, transform.position) <= 1)
            {
                isWandering = false;
                Wander();
            }
        }
    }
        

        public void TookDamage(int damageTakenI, float damageTakenF)
        {
            health -= damageTakenI;
            health -= damageTakenF;
        }

        
        private void Wander()
        {
            float direction = Random.Range(1, 180);

            Vector3 lookDirect = new Vector3(transform.rotation.x, direction, transform.rotation.z);

            transform.Rotate(lookDirect);

            float placeHolderDistance = Random.Range(1, Mathf.Ceil(maxWanderDistance));

            positionToMoveTo = transform.position + (transform.forward * placeHolderDistance);

            Debug.Log(positionToMoveTo);

            isWandering = true;
        }
        

        void Die()
        {
            int index = enemySpawner.forestEnemies.IndexOf(gameObject);
            enemySpawner.forestEnemies.RemoveAt(index);
            enemySpawner.forestEnemyRarities.RemoveAt(index);
            enemySpawner.ListUpdate();

            Destroy(gameObject);
        }
}