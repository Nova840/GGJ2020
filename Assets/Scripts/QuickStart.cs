using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickStart : MonoBehaviour {

    [SerializeField]
    private string defaultLevelName = "";

    private static bool usedQuickStart = false;

    private void Awake() {
        if (!StartSceneLoaded.HasLoaded && !usedQuickStart) {
            usedQuickStart = true;
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName != "Game") {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
                SceneManager.LoadScene(currentSceneName, LoadSceneMode.Additive);
            } else {
                SceneManager.LoadScene(defaultLevelName, LoadSceneMode.Additive);
            }
        }
        Destroy(gameObject);
    }

}