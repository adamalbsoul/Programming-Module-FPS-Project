using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{
    public Slider slider; // var for volume slider
    public AudioSource volumeAudio; // var for audioSource

    private void Awake()
    {
        if (slider)
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("CurVol"); // gets the value from PlayerPrefs
            slider.value = GetComponent<AudioSource>().volume; // equates the value of the slider to the volume value of the audio
        }
    }

    public void VolumeControl(float volumeControl)
    {
        GetComponent<AudioSource>().volume = volumeControl; // sets the volume of AudioSource to var volumeControl
        PlayerPrefs.SetFloat("CurVol", GetComponent<AudioSource>().volume); // equates the value of the slider to the volume value of the audio
        PlayerPrefs.Save(); // saves the value to PlayerPrefs
    }

    private void Update()
    {
        VolumeControl(slider.value); // updates the value of the slider every frame
    }
}