using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_FPS : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public float health = 100f; //The amount of health the object has
    public GameObject Ammo; //the ammo the object will drop when they die
    public Transform location; //the location of the object
        #endregion

        #region Methods
    public void TakeDamage(float amount) //Sees how much health it just lost by gettting attacked
    {
        health-= amount; //Takes the lost health away from the current health of this object
        if(health <= 0f) //Checks if the objects health is 0 or below and if so runs this part
        {
            Destroyed(); //Runs the destroy task
            Debug.Log("ObjectDestroyed"); //Tells the system to display the text in "..."
            AmmoDrop(); //runs the drop ammo task
            Debug.Log("AmmoDropped"); //Tells the system to display the text in "..."
        }
    }
    void Destroyed() //The destroy task
    {
        Destroy(gameObject); //destroys the object, removing it from the level
    }

    void AmmoDrop() //the drop ammo taks
    {
        Vector3 position = location.position; //location of object
        GameObject ammo = Instantiate(Ammo, position,Quaternion.identity); //creates an ammo drop and puts it to the location of the object
    }
        #endregion
}