using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching_FPS : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public int selectedWeapon = 0; //this is the weapon select value
        #endregion

        #region Methods
    void Start()
    {
        SelectWeapon(); //the selection task
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f) //checks if the scroll wheel has gone up if so...
        {
            if(selectedWeapon >= transform.childCount - 1) //checks if the selected weapon is greater or equal to all the other children within the weapon holder if so...
            selectedWeapon = 0; //this sets the weapon select value to 0
            else //if not...
            selectedWeapon++; //this goes to the next weapon within the holder by increasing the value of the weapon select
        }
            if(Input.GetAxis("Mouse ScrollWheel") < 0f) //checks if the scroll wheel has gone down if so...
        {
            if(selectedWeapon <= 0) //checks if the weapon select if less or equal to 0 if so...
            selectedWeapon = transform.childCount - 1; //sets the weapon select to the value of the pervious weapon
            else //if not...
            selectedWeapon--; //this goes to the previous weapon within the holder by decreasing the value of the weapon select
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)) //checks if the 1 button has been pressed if so...
        {
            selectedWeapon = 0; //this sets the value of the selected weapon to 0 meaning it changes to the first weapon
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2 ) //checks if the 2 button has been pressed if so...
        {
            selectedWeapon = 1; //this sets the value of the selected weapon to 1 meaning it changes to the second weapon
        }        
        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon(); //the selection task
        }
    }

    void SelectWeapon() //the selection task
    {
        int i = 0; //the first weapon
        foreach (Transform weapon in transform) //this sets the weapon list up from all the childern of the weaponholder from the hiaraky from unity
        {
            if(i == selectedWeapon) //checks if the value of i is the same as the value of which weapon is selected if so...
            weapon.gameObject.SetActive(true); //toggels the weapon on
            else //if they are not the same value...
            weapon.gameObject.SetActive(false); //toggles the weapon off
            i++; //this adds 1 to the value of i meaning the weapon is switched to the next
        }
    }        
        #endregion
}