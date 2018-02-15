using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public InputField nameField;
    public static string charName;
    public static Text displayName;
    public static Text endScore;

    public void OnSubmit()
    {
        charName = nameField.text; // when the player types in their name, it saves the value to the nameField var
        Debug.Log("name: " + charName);
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameData gD = player.GetComponent<GameData>();
        endScore.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
