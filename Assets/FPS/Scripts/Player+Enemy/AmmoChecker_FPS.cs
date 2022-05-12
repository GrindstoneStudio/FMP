using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoChecker_FPS : MonoBehaviour
{
        #region Variable
        //Variables (public can be changed in unity / private can ONLY be changed in script)
    public int additionalAmmo; //the ammo boost
    public Shooting_FPS shooting_FPS; //the shooting script
    public GameObject pistol; //the weapon
        #endregion

        #region Methods
    void Update()
    {
        if(shooting_FPS.reserveAmmo <= 0) //if the reserveammo of the weapon in less than 0 then...
        {
            if(shooting_FPS.currentAmmo > 0) //if the current magazine of the weapon in greater than 0 then...
            {
                pistol.SetActive(true); //the pistol stays on the player
            }
            if(shooting_FPS.currentAmmo <= 0) //if the current magazine of the weapon in less than 0 then...
            {
                pistol.SetActive(false); //Removes the pistol from the player
            }
        }
        if(additionalAmmo > 0) //checks if the addtional is greater the 0 if so...
        {
            pistol.SetActive(true); //the pistol returns to the player
            shooting_FPS.reserveAmmo += additionalAmmo; //adds the ammoboost to the reservedammo 
            additionalAmmo = 0; //resets the ammoboost
        }
    }
        #endregion
}