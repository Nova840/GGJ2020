using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    [SerializeField]
    private AudioSource menuMusic = null;

    [SerializeField]
    private AudioSource gameMusic = null;

    [SerializeField]
    private float fadeSpeed = 1;

    private static Music instance;

    private void Awake() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        string sceneName = SceneManager.GetActiveScene().name;
        menuMusic.volume = Mathf.MoveTowards(menuMusic.volume, sceneName == "Start" ? 1 : 0, fadeSpeed * Time.deltaTime);
        gameMusic.volume = Mathf.MoveTowards(gameMusic.volume, sceneName == "Game" ? 1 : 0, fadeSpeed * Time.deltaTime);
    }

}
