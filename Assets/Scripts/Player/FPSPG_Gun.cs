using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* For those of you who are struggling with programming
* Replace the comments on this script with what the line does
* You might need to use Google to find out
* TIP: Don't overthink it
*/ 

public class FPSPG_Gun : MonoBehaviour
{
    public float gunDamage; //What's this do?
    public float gunRange; //What's this do?
    public float fireRate; //What's this do?
    public float reloadTime; //What's this do?
    public int magSize; //What's this do?
    public int currentAmmo; //What's this do?
    public int reserveAmmo; //What's this do?
    public GameObject firePoint; //What's this do?
    
    //For muzzle flash you'll need a particle system variable

    float nextFire; //Should this be public? Why not?

    void Start()
    {
        currentAmmo = magSize; //Why do this at the start?  
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(firePoint.transform.position, firePoint.transform.forward, Color.green); //What's this for?
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire && currentAmmo > 0) //What are the conditions here?
        {
            GunShoot();
            currentAmmo--; //Why do this?
        }
        if(currentAmmo <= 0 && reserveAmmo > 0) //What is the condition here?
        {
            GunReload();
        }
        if(Input.GetKeyDown(KeyCode.R)) //What is the condition here?
        {
            reserveAmmo = reserveAmmo + currentAmmo;
            currentAmmo = 0;
        }
    }

    void GunShoot()
    {
        //Add a muzzle flash here

        RaycastHit hit; //What is this variable?
        nextFire = Time.time + fireRate; //Why do this?
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange)) //Sum up a Raycast here
        {
            Debug.Log(hit.transform.name); //What does this do?
            FPSPG_Target target = hit.transform.GetComponent<FPSPG_Target>(); //What are we doing here?
            if(target != null) //What does this mean?
            {
                target.TakeDamage(gunDamage);
            }
        }
    }

    void GunReload()
    {
        nextFire = Time.time + reloadTime;
        if(reserveAmmo > magSize) //What is the condition here?
        {
            reserveAmmo = reserveAmmo - magSize; //What does this do?
            currentAmmo = magSize; //Why do this?
        }
        else //What is an else statement?
        {
            currentAmmo = reserveAmmo;
            reserveAmmo = 0;
        }
    }
}
