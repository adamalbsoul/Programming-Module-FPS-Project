using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public GameObject explosionPrefab;
    public AudioSource boomSound;

    private void Start()
    {
        GameObject Player = GameObject.Find("Player");
        GameData gameData = Player.GetComponent<GameData>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount; //subtracts the amount value from health
        if (health <= 0f) // if the value of health is less than or equal to 0
        {
            StartCoroutine(Die()); // Die() coroutine starts
        }
    }

    private void Update()
    {
        GameObject Player = GameObject.Find("Player");
        GameData gameData = Player.GetComponent<GameData>();
        gameData.scoreText.text = "Score: " + gameData.score; // displays the score
        DontDestroyOnLoad(this);
    }

    public IEnumerator Die()
    {

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // explosion effect spawns in the position of the barrel
            yield return new WaitForSeconds(1f); // waits for the explosion effect to finish
        }
        Destroy(gameObject); // deletes the object
        {
            GameObject Player = GameObject.Find("Player");
            GameData gameData = Player.GetComponent<GameData>();
            gameData.score++; // increments score
        }
    }
}