using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystems : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public GameObject Enemy; //The enemy
        #endregion

        #region Methods
    void Start()
    {
        Enemy_FPS enemy_FPS = Enemy.GetComponent<Enemy_FPS>(); //Finds the enemy's attacking script
        enemy_FPS.enabled = false; //Disables the attacking script
    }
        void OnTriggerEnter(Collider other) //This runs when the Hazard has been collided with another object
    {
        if(other.gameObject.CompareTag("Player")) //This makes sure that it was the player tha collided with the hazard and if it is then the script will run
        {
            Debug.Log("Player Detected"); //Tells the system to display the text in "..."
            Enemy_FPS enemy_FPS = Enemy.GetComponent<Enemy_FPS>(); //Finds the enemy's attacking script
            enemy_FPS.enabled = true; //engages the attacking script
        }
    }
        #endregion
}