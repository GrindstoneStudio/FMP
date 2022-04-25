using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
* TASK: Fix the errors in this code
    * Use the Unity Console and Google
* TASK: Comment on each line explaining what it does
*/

public class FPSPG_PlayerHealth : MonoBehaviour
{
    public int maxplayerHealth = 100; //This states the players health.
    public int playerHealth;
    public HealthBar healthBar;
    public GameObject bloodonhud;

    void Start()
    {
    playerHealth = maxplayerHealth;
    healthBar.SetMaxHealth(maxplayerHealth);
    }
    void Update()
    {
        healthBar.SetHealth(playerHealth);
        if (playerHealth < 0) //The condition here is the < this states that the player dies after a 0 health
        {
          GameOver();
        }

        if(playerHealth <=20)
        {
           bloodonhud.SetActive(true); //Damage Effect
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //What does this do?
    }
}