using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text endScore;

    private void Start()
    {
        GameObject Player = GameObject.Find("Player");
        GameData gameData = Player.GetComponent<GameData>();
        endScore = gameData.scoreText;
    }

    void Update()
    {
        Cursor.visible = true; // displays the cursor
        Cursor.lockState = CursorLockMode.None; // unlocks the cursor
    }

    // coroutines that play the click sound and then load the scenes
    IEnumerator DelayPlay()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(
       GetComponent<AudioSource>().clip.length);
        Application.LoadLevel("Main");
    }

    IEnumerator DelayMainMenuBtn()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(
       GetComponent<AudioSource>().clip.length);
        Application.LoadLevel("MainMenu");
    }

    IEnumerator DelayOptions()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(
       GetComponent<AudioSource>().clip.length);
        Application.LoadLevel("Options");
    }
    // sets the coroutines to methods
    public void DelayPlay(string Main)
    {
        StartCoroutine(DelayPlay());
    }

    public void DelayMainMenu(string MainMenu)
    {
        StartCoroutine(DelayMainMenuBtn());
    }

    public void DelayOptions(string Options)
    {
        StartCoroutine(DelayOptions());
    }

    public void QuitGame() // when the player chooses to quit the game, the game exits instantly, without a delay for sound
    {
        Application.Quit();
    }

}
