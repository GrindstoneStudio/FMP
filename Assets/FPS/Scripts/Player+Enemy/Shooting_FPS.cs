using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_FPS : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public int gunDamage; //How much damage the bullet will do
    public int gunRange; //How far the bullet can travel
    public float fireRate; //How fast the gun shoots the bullets
    public float nextFire; //How long it take for the next bullet to fire
    public float reloadTime; //How long it takes to reload the gun
    public int magSize; //How many bullets does the magasize store
    public int currentAmmo; //How many bullets are currently left in the magasive
    public int reserveAmmo; //How many bullets are in the player's inventory
    private bool isReloading = false; //true or false statment the script checks
    public GameObject firePoint; //The point where the gun will fire from
    public GameObject impactEffect; //The effect played when hitting an object
    public ParticleSystem muzzleFlash; //the flash when shoots
    public Animator animator; //the reloading animation
        #endregion

        #region Methods
    void Start()
    {
        currentAmmo = magSize; //makes the current ammo that is in the gun max out
    }
    void OnEnable()
    {
        isReloading = false; //the player is not reloading
        animator.SetBool("Reloading", false); //turns off the reloading animation
    }
    void Update()
    {
        if(isReloading) //checks if the player is reloading
        return; //returns the values back to the state
        if(Input.GetButton("Fire1") && Time.time >= nextFire) //Checks if the player shoots and if so then runs this part
        {
            nextFire = Time.time + 1f/fireRate; //sets the weapon a fire rate cuasing their to be a delay once the player has shot
            Shoot(); //This runs the shooting task
        }
        if(currentAmmo <= 0) //checks if the current ammo equals to 0 if so this runs...
        {
            StartCoroutine(Reload()); //starts the reloading process
            return; //returns the values back to the state
        }
    }

        IEnumerator Reload () //the reloading process
        {            
            isReloading = true; //reloading is in progress
            Debug.Log("Reloading"); //Tells the system to display the text in "..."
            animator.SetBool("Reloading", true); //turns on the reloadng animation
            yield return new WaitForSeconds(reloadTime); //waits for the weapons reload time
            animator.SetBool("Reloading", false); //turns off the reloadng animation
            currentAmmo = magSize; //this sets the new mag to its max value 
            reserveAmmo = reserveAmmo - magSize; //this removes the ammo from the reserve stock which is now in the new mag
            isReloading = false;
        }

    void Shoot() //This is the shooting taks
    {
        muzzleFlash.Play(); //this plays the firing effect
        currentAmmo--; //this takes away 1 bullet from the players current mag
        RaycastHit hit; //this creates a stock of what the raycast has hit when it is used
        nextFire = Time.time + fireRate; //
        Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange); 
        //this creates a ray by using the position of the end of the barrel as the start of the ray, the direction which the barrel is pionting towards and the guns range as the rays range
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange)) //hecks if the ray has hit any object if so...
        {
            Debug.Log(hit.transform.name); //Tells the system to display the name of the object
        }
        Death_FPS target = hit.transform.GetComponent<Death_FPS>(); //creates a local value from the objects scripts
        if(target != null) //checks if the object has the destruction system on it if so...
        {
            target.TakeDamage(gunDamage); //takes the weapons damage off of the object
        }
        if(hit.rigidbody != null) //checks if the object has a rigidbody if so...
        {
            hit.rigidbody.AddForce(-hit.normal * 300); //this adds a force to the rigidbody so that the object flings backwards
        }
        GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); //this takes the postion the raycast hit and displays the impact effect towards the player
        Destroy(impactObj, 2f); //this deletes that effect after 2 seconds
    }
        #endregion
}