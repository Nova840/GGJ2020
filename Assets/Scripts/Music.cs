using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

    [SerializeField]
    private AudioSource menuMusic = null;

    [SerializeField]
    private AudioSource[] gameMusic = null;

    [SerializeField]
    private float fadeSpeed = 1;

    private static Music instance;

    public static int GameMusicStage { get; set; } = 0;

    private void Awake() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            GameMusicStage++;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            GameMusicStage--;
        GameMusicStage = Mathf.Clamp(GameMusicStage, 0, gameMusic.Length - 1);
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != "Game")
            GameMusicStage = 0;
        menuMusic.volume = Mathf.MoveTowards(menuMusic.volume, sceneName == "Start" ? 1 : 0, fadeSpeed * Time.deltaTime);
        for (int i = 0; i < gameMusic.Length; i++) {
            gameMusic[i].volume = Mathf.MoveTowards(gameMusic[i].volume, sceneName == "Game" && i <= GameMusicStage ? 1 : 0, fadeSpeed * Time.deltaTime);
        }
    }

}
