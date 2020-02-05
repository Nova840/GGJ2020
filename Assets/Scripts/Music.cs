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
    private AudioSource winMusic = null;

    [SerializeField, Range(0, 1)]
    private float masterMusicVolume = 1;

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
        bool isOnGame = SceneManager.GetActiveScene().name == "Game";
        if (!isOnGame)
            GameMusicStage = 0;
        GameMusicStage = Mathf.Clamp(GameMusicStage, 0, gameMusic.Length - 1);
        menuMusic.volume = Mathf.MoveTowards(menuMusic.volume, !isOnGame && gameMusic[0].volume == 0 ? masterMusicVolume : 0, fadeSpeed * Time.deltaTime);

        for (int i = 0; i < gameMusic.Length; i++) {
            gameMusic[i].volume = Mathf.MoveTowards(gameMusic[i].volume, isOnGame && i <= GameMusicStage && menuMusic.volume == 0 && !CompleteGame.AlreadyCompleted ? masterMusicVolume : 0, fadeSpeed * Time.deltaTime);
        }
        winMusic.volume = Mathf.MoveTowards(winMusic.volume, isOnGame && menuMusic.volume == 0 && CompleteGame.AlreadyCompleted ? masterMusicVolume : 0, fadeSpeed * Time.deltaTime);

        if (menuMusic.volume == 0)
            menuMusic.time = 0;
        if (gameMusic[0].volume == 0)
            foreach (AudioSource source in gameMusic)
                source.time = 0;
        if (winMusic.volume == 0) {
            winMusic.time = 0;
            winMusic.Play();
        }
    }

}
