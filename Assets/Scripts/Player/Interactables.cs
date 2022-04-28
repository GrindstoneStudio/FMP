using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
        #region Variable
        //Variables (public can be changed in unity / private can ONLY be changed in script)
    public GameObject medkit; //Healthboost object (green ball)
    public float healthBoost = 50f; //Amount of Health gained when used
        #endregion

        #region Methods
    public void Heal() //This can be ran from other scipts
    {
        GameObject theplayer = GameObject.Find("Player"); //Finds the player object within unity
        Player Health = theplayer.GetComponent<Player>(); //Makes this script be able to access the script on the player
        Health.playerHealth += healthBoost; //Adds the health to the script which is on the player
        Debug.Log("MEDKIT USED"); //Tells the system to display the text in "..."
        Destroy(medkit); //Removes the healthboost from the level
    }
        #endregion
}
