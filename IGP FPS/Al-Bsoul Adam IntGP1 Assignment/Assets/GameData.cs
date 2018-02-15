using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public Text playerName;
    public int score;
    public Text scoreText;

    private void Start()
    {
        // the score at the start is 0
        playerName.text = PlayerName.charName;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("Score", score);
        DontDestroyOnLoad(this);
    }
}

