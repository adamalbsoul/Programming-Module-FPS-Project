using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BGM"); // creates an array of objects with the bgm (background music) tag
        if (objs.Length > 1) // if there are more than 1 objects with the bgm tag, ie. if more than 1 instances of music are playing
            Destroy(this.gameObject); // then the object gets destroyed to insure that only 1 instance of music is playing
        DontDestroyOnLoad(this.gameObject); // the music is played seamlessly throughout scenes, because the object with the audio source doesn't get destroyed
    }
}
