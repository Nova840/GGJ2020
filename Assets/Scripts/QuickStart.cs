using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickStart : MonoBehaviour {

    private static bool usedQuickStart = false;

    private void Awake() {
        if (StartSceneLoaded.HasLoaded || usedQuickStart) {
            Destroy(gameObject);
        } else {
            usedQuickStart = true;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            SceneManager.LoadScene(currentSceneName, LoadSceneMode.Additive);
        }
    }

}