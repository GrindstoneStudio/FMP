using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_FPS : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)    
    public Transform playerObject; //This allows the script to access the players object
    public float damageAmount = 35f; //This is the amount of health the enemie take away from thew player
    public float attackDelay; //This is the wait between the enemies attacks
    public float attackRate; //This is how fast the enemies attacks are
    public float attackDistance; //This is the enemies attacks range
    private NavMeshAgent nav; //This is the floor's navmesh so that the enemy knows where they can walk
        #endregion

        #region Methods
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player").transform; //This finds the player object within unity
        nav = GetComponent<NavMeshAgent>(); //This gets the navmesh from the floor
    }
    void Update()
    {
        if(Time.time > attackDelay) //This makes the enemy wait after they attack the player
        {
            nav.destination = playerObject.position; //This makes the enemy's nav system link to the players movement
            if(Vector3.Distance(playerObject.position, transform.position) <= attackDistance) //This is making sure that if the attack distance of the enemy is greater than the  
            {
                playerObject.GetComponent<Player>().playerHealth -= damageAmount; //This is getting the players health from the other script and taking away the damage
                attackDelay = Time.time + attackRate; //This creates a time delay for the enemy to launch their next attack
            }
        }
        else //if not
        {
            nav.destination = transform.position; //This makes the enemy follow the players movement
        }
    }
        #endregion
}