using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public AudioMixer am;
    public bool offon;

    public void AudioVolume()
    {
        if (offon == true)
        {
            am.SetFloat("masterVolume", -80f);
            offon = false;
        }
        else if (offon == false)
        {
            am.SetFloat("masterVolume", 0f);
            offon = true;
        }
    }
}
