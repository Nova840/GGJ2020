using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    private static GameObject soundPrefab = null;

    public static void PlaySound(AudioClip clip, float volume) {
        if (!soundPrefab)
            soundPrefab = Resources.Load("Sound") as GameObject;
        AudioSource source = Instantiate(soundPrefab).GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }

}