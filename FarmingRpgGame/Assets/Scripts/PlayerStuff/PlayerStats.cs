using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //The health value of the player
    public static int playerHealth;
    //The Maximum health value a player can have
    public static int playerMaxHealth = 100;
    public static Slider playerHealthSlider;
    public GameObject healthBar;
    public GameObject playerObject;

    private void Start()
    {
        /*Tempory -- Will set to saved value once
        saving is implemented*/
        playerHealth = playerMaxHealth;

        /*Get the slider component for the health bar
          which makes the health bar work*/
        playerHealthSlider = healthBar.GetComponent<Slider>();

        //Set Default health values
        playerHealthSlider.maxValue = playerMaxHealth;
        playerHealthSlider.value = playerMaxHealth;

        //get the player object
        playerObject = gameObject;
    }

    private void Update()
    {
        if (playerHealth == 0)
        {
            Die();
        }
    }

    public static void decrementHealth(int amount)
    {
        //Decrement Health by passed in amount
        playerHealth -= amount;

        //Set health bar to reflect change in health
        playerHealthSlider.value = playerHealth;
    }

    public static void incrementHealth(int amount)
    {
        int playerTempHealth = playerHealth + amount;

        /*If Health + Passed in amount is less than
         or equal to MaxHealth*/
        if (playerHealth < playerMaxHealth && playerTempHealth <= playerMaxHealth)
        {
            //Increment Health by passed in amount
            playerHealth = playerTempHealth;

            //Set health bar to reflect change in health
            playerHealthSlider.value = playerHealth;
        }
    }

    public void Die()
    {
        //set the player object to not active
        playerObject.SetActive(false);
        //load the death scene
        SceneManager.LoadScene("scnDead", LoadSceneMode.Single);
    }
}
